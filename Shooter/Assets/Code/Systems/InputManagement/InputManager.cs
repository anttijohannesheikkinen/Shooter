using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shooter.Systems;
using Shooter.Data;

namespace Shooter.InputManager {
    public class InputManager : MonoBehaviour
    {

        private Dictionary<PlayerData.PlayerId, PlayerUnit> _players;

        public void Init (PlayerUnits playerUnits)
        {
            _players = playerUnits.Players;

            if (_players == null)
            {
                Debug.Log("InputManager could not find a reference to PlayerUnits in the game.");
            }
        }

        private void Update()
        {
            foreach (var player in _players)
            {
                Vector3 input = new Vector3(Input.GetAxis(Configs.Config.ControllerAxisNames[player.Value.Data.HorizontalAxis]),
                                            0,
                                            Input.GetAxis(Configs.Config.ControllerAxisNames[player.Value.Data.VerticalAxis]));

                player.Value.Mover.MoveToDirection(input);

                if (Input.GetButton(Configs.Config.ShootButtonNames[player.Value.Data.ShootBtn]))
                {
                    player.Value.Weapons.Shoot(player.Value.ProjectileLayer);
                }
            }
        }
    }
}