using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shooter.Data;


namespace Shooter.Systems
{
    public class LevelManager : Shooter.Systems.SceneManager
    {
        // TODO: Add reference to InputManager here.
        public PlayerUnits PlayerUnits { get; private set; }
        public EnemyUnits EnemyUnits { get; private set; }

        protected void Awake ()
        {
            Initialize();
        }

        private void Initialize()
        {
            PlayerUnits = GetComponentInChildren<PlayerUnits>();
            EnemyUnits = GetComponentInChildren<EnemyUnits>();

            EnemyUnits.Init();

            // TODO : get Player data from GameManager (new data or saved data).
            PlayerData data = new PlayerData()
            {
                Id = PlayerData.PlayerId.Player1,
                UnitType = PlayerUnit.UnitType.Balanced,
                Lives = 3
            };

            PlayerUnits.Init(data);

            if (PlayerUnits == null)
            {
                Debug.Log("Couldn't find PlayerUnits" + gameObject);
            }

            if (EnemyUnits == null)
            {
                Debug.Log("Couldn't find EnemyUnits" + gameObject);
            }
        }
    }
}