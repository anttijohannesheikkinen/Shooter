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

            foreach (PlayerData playerData in players)
            {
                PlayerUnit unitPrefab = Global.Instance.Prefabs.GetPlayerUnitByType(playerData.UnitType);

                if (unitPrefab != null)
                {   
                    // Initialize unit
                    PlayerUnit unit = Instantiate(unitPrefab, transform);
                    unit.transform.position = Vector3.zero;
                    unit.transform.rotation = Quaternion.identity;
                    unit.Init(playerData);

                    Debug.Log(unit.transform.position);

                    Players.Add(playerData.Id, unit);
                }

                else
                {
                    Debug.Log("Unit prefab of the type" + playerData.UnitType + "could not be found.");
                }
            }
        }
    }
}
