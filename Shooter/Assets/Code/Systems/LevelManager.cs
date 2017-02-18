using UnityEngine;
using Shooter.Data;
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
            InputManager = GameObject.FindObjectOfType<InputManager.InputManager>();

            CheckForNulls();
            EnemyUnits.Init();

            //Initialize InputManager with proper info of current player data.
            //Tyhmä kierto tätä kautta IMO. Kai. Voisi tehdä järkevämminkin ehkä.
            PlayerData[] players = Global.Instance.GameManager.GetPlayers();
            PlayerUnits.Init(players);
            InputManager.Init(PlayerUnits);
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