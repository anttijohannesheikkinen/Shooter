using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Shooter.Data;

namespace Shooter
{
    public class PlayerUnits : MonoBehaviour
    {
        private Dictionary<PlayerData.PlayerId, PlayerUnit> _players = new Dictionary<PlayerData.PlayerId, PlayerUnit>();

        public void Init(params PlayerData[] players)
        {
            foreach (PlayerData playerData in players)
            {
                // TOTO Get prefab by unit type
                // Initialize unit
                // Add player to dictionary
            }
        }

    }
}
