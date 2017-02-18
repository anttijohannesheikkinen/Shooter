using System;
using System.Collections.Generic;
using UnityEngine;
using Shooter.Systems.States;
using Shooter.Data;

namespace Shooter.Systems
{
    public enum GameStateType
    {
        Error = -1,
        MenuState = 0,
        InGameState = 1,
        GameOverState = 2

        //Jos haluut tallentaaa jotain. kantsii enumien numerot määritellä eksplisiittisesti, kun numerot vaihtuvat jos väliin lisäillee jotain ja hommat menee paskaksi.
    }

    public enum GameStateTransitionType
    {
        Error = -1,
        MenuToInGame,
        InGameToMenu,
        InGameToGameOver,
        GameOverToMenu

            //Ei kyllä tässä tapauksessa tarvii määritelläkään eksplisiittisesti, kun ei näitä tallenneta.
    }

    public class GameManager : MonoBehaviour
    {
        #region Fields
        private readonly List<GameStateBase> _states = new List<GameStateBase>();

        #endregion

        #region Events and delegates

        public event Action<GameStateType> GameStateChanging;
        public event Action<GameStateType> GameStateChanged;

        #endregion

        #region Properties

        public SceneManager CurrentSceneManager { get; private set; }
        public GameStateBase CurrentState { get; private set; }
        public GameStateType CurrentGameStateType { get { return CurrentState.State; } }

        #endregion

        #region Public methods

        public void Init()
        {
            MenuState startingState = new MenuState();
            AddState(startingState);
            AddState(new InGameState());
            CurrentState = startingState;
        }
        public bool AddState(GameStateBase state)
        {
            bool exists = false;

            foreach (var s in _states)
            {
                if (s.State == state.State)
                {
                    exists = true;
                }
            }

            if (!exists)
            {
                _states.Add(state);
            }

            return !exists;
        }

        public bool RemoveState (GameStateType stateType)
        {
            GameStateBase state = null;

            foreach (var s in _states)
            {
                if (s.State == stateType)
                {
                    state = s;
                }
            }

            return state != null && _states.Remove(state);
        }

        public bool PerformTransition (GameStateTransitionType transition)
        {
            GameStateType targetStateType = CurrentState.GetTargetStateType(transition);

            if (targetStateType == GameStateType.Error)
            {
                return false;
            }

            foreach (var state in _states)
            {
                if (state.State == targetStateType)
                {
                    CurrentState.StateDeactivating();
                    CurrentState = state;
                    CurrentState.StateActivated();

                    return true;
                }
            }

            return false;
        }

        public void RaiseGameStateChangingEvent (GameStateType gameStateType)
        {
            if (GameStateChanging != null)
            {
                GameStateChanging(gameStateType);
            }
        }

        public void RaiseGameStateChangedEvent (GameStateType gameStateType)
        {
            if (GameStateChanged != null)
            {
                GameStateChanged(gameStateType);
            }
        }

        public GameStateBase GetStateByStateType (GameStateType gameStateType)
        {
            GameStateBase state = null;

            foreach (var s in _states)
            {
                if (s.State == gameStateType)
                {
                    state = s;
                    break; // Pitkät listat voi hyvin breikata, ettei turhaan luuppaile.
                }
            }

            return state;
        }

        #endregion

        #region PlayerData Retrieval and Creation

        public PlayerData[] GetPlayers ()
        {
            return CreatePlayers();
        }

        private PlayerData[] CreatePlayers()
        {
            PlayerData[] players = new PlayerData[4];

            players[0] = new PlayerData()
            {
                Id = PlayerData.PlayerId.Player1,
                UnitType = PlayerUnit.UnitType.Balanced,
                Lives = 3,
                ControlType = PlayerData.ControllerType.KeyArrows
            };

            players[1] = new PlayerData()
            {
                Id = PlayerData.PlayerId.Player2,
                UnitType = PlayerUnit.UnitType.Heavy,
                Lives = 3,
                ControlType = PlayerData.ControllerType.KeyWASD
            };

            players[2] = new PlayerData()
            {
                Id = PlayerData.PlayerId.Player3,
                UnitType = PlayerUnit.UnitType.Fast,
                Lives = 3,
                ControlType = PlayerData.ControllerType.Pad
            };

            players[3] = new PlayerData()
            {
                Id = PlayerData.PlayerId.Player4,
                UnitType = PlayerUnit.UnitType.Balanced,
                Lives = 3,
                ControlType = PlayerData.ControllerType.Pad
            };

            return players;
        }

        #endregion
    }
}