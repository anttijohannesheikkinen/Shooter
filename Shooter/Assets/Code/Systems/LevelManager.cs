using UnityEngine;
using Shooter.Data;
using Shooter.InputManagement;
using Shooter.Level;
using Shooter.Systems.States;
using System.Collections.Generic;

namespace Shooter.Systems
{
    public class LevelManager : SceneManager
    {
        public PlayerUnits PlayerUnits { get; private set; }
        public EnemyUnits EnemyUnits { get; private set; }

        private ConditionBase[] _conditions;
        private EnemySpawner[] _enemySpawners;
        [SerializeField] private Transform[] _playerSpawnPoints;

        public Transform[] PlayerSpawnPoints { get { return _playerSpawnPoints; } private set { _playerSpawnPoints = value; } }

        private InputManager InputManager;

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
            InputManager = FindObjectOfType<InputManager>();

            _enemySpawners = GetComponentsInChildren<EnemySpawner>();

            foreach (var spawner in _enemySpawners)
            {
                spawner.Init(EnemyUnits);

                if (EnemyUnits == null) {
                    Debug.Log("enemyunitsnull");
                }
            }

#if UNITY_EDITOR
            if (Global.Instance.CurrentGameData == null || Global.Instance.devModePlayerData)
            {
                Global.Instance.CurrentGameData = new GameData()
                {
                    Level = 1,
                    PlayerDatas = new List<PlayerData>()
                    {
                        new PlayerData ()
                        {
                            Id = PlayerData.PlayerId.Player1,
                            Lives = 3,
                            ControlType = PlayerData.ControllerType.KeyWASD,
                            UnitType = PlayerUnit.UnitType.Fast
                        },

                        new PlayerData ()
                        {
                            Id = PlayerData.PlayerId.Player2,
                            Lives = 3,
                            ControlType = PlayerData.ControllerType.KeyArrows,
                            UnitType = PlayerUnit.UnitType.Heavy
                        },

                        new PlayerData ()
                        {
                            Id = PlayerData.PlayerId.Player3,
                            Lives = 3,
                            ControlType = PlayerData.ControllerType.Pad,
                            UnitType = PlayerUnit.UnitType.Balanced
                        },

                        new PlayerData ()
                        {
                            Id = PlayerData.PlayerId.Player4,
                            Lives = 3,
                            ControlType = PlayerData.ControllerType.Pad,
                            UnitType = PlayerUnit.UnitType.Balanced
                        }
                    }
                };
            }

#endif


            CheckForNulls();

            //Instantiate and Init player units with proper data and then 
            //initialize InputManager with proper info of current player unit data.
            PlayerData[] players = Global.Instance.CurrentGameData.PlayerDatas.ToArray();
            PlayerUnits.Init(players);
            InputManager.Init(PlayerUnits);

            _conditions = GetComponentsInChildren<ConditionBase>();
            foreach (var condition in _conditions)
            {
                condition.Init(this);
            }
        }

    public void ConditionMet(ConditionBase condition)
        {
            bool areConditionsMet = true;

            foreach (ConditionBase c in _conditions)
            {
                if (!c.IsConditionMet)
                {
                    areConditionsMet = false;
                    break;
                }
            }

            if (areConditionsMet)
            {
                (AssociatedGameState as InGameState).LevelCompleted();
            }
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