using System.Collections.Generic;
using Shooter.Configs;
using UnityEngine;

namespace Shooter.Systems.States
{
    class InGameState : GameStateBase
    {
        public int CurrentLevelIndex { get; private set; }

        public override string SceneName
        {
            get
            {
                try
                {
                    return Config.LevelNames[CurrentLevelIndex];
                }

                catch (KeyNotFoundException exception)
                {
                    Debug.LogException( exception);
                    return null;
                }
            }
        }

        //Kantaluokan konstruktori kutsutaan eka, nyt sitten kutsutaan tätä ingamestatekonstruktoria ja sitten vasta tota this (1) -versiota.
        public InGameState(int levelIndex) : base ()
        {
            CurrentLevelIndex = levelIndex;
            State = GameStateType.InGameState;
            AddTransition(GameStateTransitionType.InGameToGameOver, GameStateType.GameOverState);
            AddTransition(GameStateTransitionType.InGameToMenu, GameStateType.MenuState);
        }

        public InGameState() : this (1) { }
    }
}
