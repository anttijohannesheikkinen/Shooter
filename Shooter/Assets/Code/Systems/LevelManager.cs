using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shooter.Data;
using Shooter.InputManager;
using Shooter.Configs;

namespace Shooter.Systems
{
    public class LevelManager : Shooter.Systems.SceneManager
    {
        // TODO: Add reference to InputManager here.
        public PlayerUnits PlayerUnits { get; private set; }
        public EnemyUnits EnemyUnits { get; private set; }

        public InputManager.InputManager InputManager;

        public override GameStateType StateType
        {
            get
            {
                return GameStateType.InGameState;
            }
        }

        protected void Awake ()
        {
            Initialize();
        }

        private void Initialize()
        {
            PlayerUnits = GetComponentInChildren<PlayerUnits>();
            EnemyUnits = GetComponentInChildren<EnemyUnits>();
            InputManager = GetComponentInChildren<InputManager.InputManager>();

            CheckForNulls();

            EnemyUnits.Init();

            // TODO : get Player data from GameManager (new data or saved data).
            PlayerData[] players = CreatePlayers();

            PlayerUnits.Init(players);
            InputManager.Init(PlayerUnits);
        }

        private static PlayerData[] CreatePlayers()
        {
            PlayerData[] players = new PlayerData[4];

            players[0] = new PlayerData()
            {
                Id = PlayerData.PlayerId.Player1,
                UnitType = PlayerUnit.UnitType.Balanced,
                Lives = 3,
                HorizontalAxis = ControllerAxis.HorizontalKey1,
                VerticalAxis = ControllerAxis.VerticalKey1,
                ShootBtn = ShootButton.ShootKey1
            };

            players[1] = new PlayerData()
            {
                Id = PlayerData.PlayerId.Player2,
                UnitType = PlayerUnit.UnitType.Heavy,
                Lives = 3,
                HorizontalAxis = ControllerAxis.HorizontalKey2,
                VerticalAxis = ControllerAxis.VerticalKey2,
                ShootBtn = ShootButton.ShootKey2
            };

            players[2] = new PlayerData()
            {
                Id = PlayerData.PlayerId.Player3,
                UnitType = PlayerUnit.UnitType.Fast,
                Lives = 3,
                HorizontalAxis = ControllerAxis.HorizontalJoy1,
                VerticalAxis = ControllerAxis.VerticalJoy1,
                ShootBtn = ShootButton.ShootJoy1
            };

            players[3] = new PlayerData()
            {
                Id = PlayerData.PlayerId.Player4,
                UnitType = PlayerUnit.UnitType.Balanced,
                Lives = 3,
                HorizontalAxis = ControllerAxis.HorizontalJoy2,
                VerticalAxis = ControllerAxis.VerticalJoy2,
                ShootBtn = ShootButton.ShootJoy2
            };
            return players;
        }

        private void CheckForNulls()
        {
            if (PlayerUnits == null)
            {
                Debug.Log("Couldn't find PlayerUnits" + gameObject);
            }

            if (EnemyUnits == null)
            {
                Debug.Log("Couldn't find EnemyUnits" + gameObject);
            }

            if (InputManager == null)
            {
                Debug.Log("Couldn't find InputManager" + gameObject);
            }
        }
    }
}