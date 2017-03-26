using System.Collections.Generic;
using UnityEngine;
using Shooter.Data;
using Shooter.Systems;
using System.Collections;

namespace Shooter
{
    public class PlayerUnits : MonoBehaviour
    {
        public Dictionary<PlayerData.PlayerId, PlayerUnit> Players { get; private set; }
        public Dictionary<PlayerData.PlayerId, Transform> PlayerSpawnPoints { get; private set; }

        [SerializeField] private LevelManager _levelManager;

        public void Init(params PlayerData[] players)
        {
            Players = new Dictionary<PlayerData.PlayerId, PlayerUnit>();
            PlayerSpawnPoints = new Dictionary<PlayerData.PlayerId, Transform>();
            InitPlayers(players);
            AssignSpawnPoints();

            foreach (var player in Players)
            {
                StartCoroutine(SetPlayerActiveAfterDelay(player.Key, 0, false));
            }
        }

        private void InitPlayers(PlayerData[] players)
        {
            foreach (PlayerData playerData in players)
            {
                PlayerUnit unitPrefab = Global.Instance.Prefabs.GetPlayerUnitByType(playerData.UnitType);

                if (unitPrefab != null && playerData.Lives > 0)
                {
                    // Initialize unit
                    PlayerUnit unit = Instantiate(unitPrefab, transform);
                    unit.Init(playerData, this);
                    Players.Add(playerData.Id, unit);
                }
            }
        }

        private void AssignSpawnPoints ()
        {

            int count = 0;

            foreach (var playerData in Players)
            {
                if (_levelManager.PlayerSpawnPoints[count] != null)
                {
                    PlayerSpawnPoints.Add(playerData.Key, _levelManager.PlayerSpawnPoints[count]);
                }

                else
                {
                    Debug.LogError("PlayerUnits encountered a non-existent spawnpoint! Set spawnpoints for the players in the editor and make sure there's enough for the amount of players!");
                }

                count++;
            }


            Vector3 player1XOffsetFromVector3Zero = new Vector3 (Vector3.zero.x - _levelManager.PlayerSpawnPoints[0].transform.position.x, 0, 0);

            // Centers spawnpoints if there's 1 or 3 players.
            if (count == 1 || count == 3)
            {
                foreach (var spawnpoint in PlayerSpawnPoints)
                {
                    spawnpoint.Value.transform.position += player1XOffsetFromVector3Zero;
                }
            }
        }

        public void HandlePlayerDeath (PlayerData playerData)
        {
            // Play effect & hide
            // Blink
            // Wait
            // Invulnerability
            // Spawn again
            // Coroutine: blink and release invulnerability

            playerData.Lives--;

            if (playerData.Lives > 0)
            { 
                // Let's allow some time, before player is spawned again. If we want to play an effect or something, before placing the player back in scene.
                StartCoroutine(SetPlayerActiveAfterDelay(playerData.Id, 0.5f, true));
            }
        }

        private IEnumerator SetPlayerActiveAfterDelay (PlayerData.PlayerId playerId, float time, bool respawn)
        {
            yield return new WaitForSeconds(time);
            Players[playerId].transform.position = PlayerSpawnPoints[playerId].transform.position;
            Players[playerId].transform.rotation = Quaternion.identity;
            Players[playerId].SpawnPlayer(respawn);
        }
    }
}
