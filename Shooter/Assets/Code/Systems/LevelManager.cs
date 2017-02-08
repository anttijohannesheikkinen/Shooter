using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Shooter.Systems
{
    public class LevelManager : Shooter.Systems.SceneManager
    {
        [SerializeField]
        private PlayerUnits _playerUnits;

        public PlayerUnits PlayerUnits { get { return _playerUnits; } }

        protected void Awake ()
        {
            Initialize();
        }

        private void Initialize()
        {

        }
    }
}