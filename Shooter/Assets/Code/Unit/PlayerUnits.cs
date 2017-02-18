using System.Collections.Generic;
using UnityEngine;
using Shooter.Data;
using Shooter.Systems;

namespace Shooter
{
    public class PlayerUnits : MonoBehaviour
    {
        public Dictionary<PlayerData.PlayerId, PlayerUnit> Players { get; private set; }

        public void Init(params PlayerData[] players)
        {

            Players = new Dictionary<PlayerData.PlayerId, PlayerUnit>();

            //We don't want to spawn all the players in the same position.
            //TODO: Proper spawning positions.
            float startPositionX = -7.5f;

            foreach (PlayerData playerData in players)
            {
                PlayerUnit unitPrefab = Global.Instance.Prefabs.GetPlayerUnitByType(playerData.UnitType);

                if (unitPrefab != null)
                {   
                    // Initialize unit
                    PlayerUnit unit = Instantiate(unitPrefab, transform);
                    unit.transform.position = new Vector3 (startPositionX, 0, -3.0f);
                    unit.transform.rotation = Quaternion.identity;
                    unit.Init(playerData);

                    Debug.Log(unit.transform.position);

                    Players.Add(playerData.Id, unit);

                    startPositionX += 5.0f;
                }

                else
                {
                    Debug.Log("Unit prefab of the type" + playerData.UnitType + "could not be found.");
                }
            }
        }
    }
}
