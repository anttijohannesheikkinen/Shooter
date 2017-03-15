﻿using System.Collections.Generic;
using UnityEngine;
using Shooter.Data;
using Shooter.Configs;
using Shooter.Systems;
using System;

namespace Shooter.InputManagement {
    public class InputManager : MonoBehaviour
    {

        #region Fields

        private Dictionary<PlayerData.PlayerId, PlayerUnit> _players;
        private int _assignedJoypads;
        private bool _isInitialized;

        #endregion

        #region Initialization
        public void Init (PlayerUnits playerUnits)
        {
            _players = playerUnits.Players;
            _assignedJoypads = 0;

            if (_players == null)
            {
                Debug.Log("InputManager could not find a reference to PlayerUnits in the game.");
            }

            AssignControllers();
            _isInitialized = true;
        }

        private void AssignControllers()
        {
            foreach (var player in _players)
            {
                if (player.Value.Data.ControlType == PlayerData.ControllerType.KeyArrows)
                {
                    player.Value.Data.HorizontalAxis = ControllerAxis.HorizontalKey1;
                    player.Value.Data.VerticalAxis = ControllerAxis.VerticalKey1;
                    player.Value.Data.ShootBtn = ShootButton.ShootKey1;

                    Debug.Log("Assigned keyboard: Arrows");
                }

                else if (player.Value.Data.ControlType == PlayerData.ControllerType.KeyWASD)
                {
                    player.Value.Data.HorizontalAxis = ControllerAxis.HorizontalKey2;
                    player.Value.Data.VerticalAxis = ControllerAxis.VerticalKey2;
                    player.Value.Data.ShootBtn = ShootButton.ShootKey2;

                    Debug.Log("Assigned keyboard: WASD");
                }

                else if (player.Value.Data.ControlType == PlayerData.ControllerType.Pad && _assignedJoypads == 0)
                {
                    player.Value.Data.HorizontalAxis = ControllerAxis.HorizontalJoy1;
                    player.Value.Data.VerticalAxis = ControllerAxis.VerticalJoy1;
                    player.Value.Data.ShootBtn = ShootButton.ShootJoy1;

                    _assignedJoypads++;

                    Debug.Log("Assigned pad 1.");
                }

                else if (player.Value.Data.ControlType == PlayerData.ControllerType.Pad && _assignedJoypads == 1)
                {
                    player.Value.Data.HorizontalAxis = ControllerAxis.HorizontalJoy2;
                    player.Value.Data.VerticalAxis = ControllerAxis.VerticalJoy2;
                    player.Value.Data.ShootBtn = ShootButton.ShootJoy2;

                    _assignedJoypads++;

                    Debug.Log("Assigned pad 2.");
                }

                else
                {
                    Debug.LogError("Found A Player without a controller! Poor fella! Error. Error. Error. I am Error.");
                }
            }
        }

        #endregion

        #region Unity
        private void Start ()
        {
            if (_players == null)
            {
                Debug.LogError("Input Manager was not properly initialized. Errors are bound to come in the Update loop and"
                                + "the game cannot be played.");

                Application.Quit();
            }
        }

        private void Update()
        {
            if (!_isInitialized)
            {
                return;
            }

            foreach (var player in _players)
            {
                Vector3 input = new Vector3(Input.GetAxis(Config.ControllerAxisNames[player.Value.Data.HorizontalAxis]),
                                            0,
                                            Input.GetAxis(Config.ControllerAxisNames[player.Value.Data.VerticalAxis]));


                if (IsDeadZone(new Vector2 (input.x, input.z)))
                {
                    input = Vector3.zero;
                }

                player.Value.Mover.MoveToDirection(input);

                if (Input.GetButton(Config.ShootButtonNames[player.Value.Data.ShootBtn]))
                {
                    player.Value.Weapons.Shoot(player.Value.ProjectileLayer);
                }
            }

            PollSave();
        }

        private void PollSave()
        {
            if (Input.GetKeyDown(KeyCode.F2))
            {
                Global.Instance.SaveManager.Save(Global.Instance.CurrentGameData, DateTime.Now.ToString("yyyy-mm-dd"));
                Debug.Log("Tried to save");
            }
        }

        #endregion

        private bool IsDeadZone (Vector2 input)
        {

            return input.magnitude < Config.DeadZone; 
        }
    }
}