using UnityEngine;
using System.Collections.Generic;
using UnitType = Shooter.PlayerUnit.UnitType;

namespace Shooter.Systems
{

    public class Prefabs : MonoBehaviour
    {

        [SerializeField]
        private PlayerUnit[] _playerPrefabs;

        public PlayerUnit GetPlayerUnitByType (UnitType playerUnitType)
        {
            PlayerUnit result = null;

            foreach (PlayerUnit playerUnit in _playerPrefabs)
            {
                if (playerUnit.Type == playerUnitType)
                {
                    result = playerUnit;
                    break;
                }
            }

            return result;
        }

    }
}
