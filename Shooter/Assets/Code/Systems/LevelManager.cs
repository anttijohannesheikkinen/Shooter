using UnityEngine;
using Shooter.Data;
using Shooter.InputManagement;
using Shooter.Level;
using Shooter.Systems.States;

namespace Shooter.Systems
{
    public class LevelManager : SceneManager
    {
        public PlayerUnits PlayerUnits { get; private set; }
        public EnemyUnits EnemyUnits { get; private set; }

        private ConditionBase[] _conditions;
        private EnemySpawner[] _enemySpawners;

        public InputManager InputManager;

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
            }

            CheckForNulls();

            //Instantiate and Init player units with proper data and then 
            //initialize InputManager with proper info of current player unit data.
            PlayerData[] players = Global.Instance.GameManager.GetPlayers();
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