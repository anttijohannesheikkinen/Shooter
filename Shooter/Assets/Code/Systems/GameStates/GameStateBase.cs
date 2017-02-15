using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SM=UnityEngine.SceneManagement;

namespace Shooter.Systems.States
{
    public abstract class GameStateBase
    {
        public abstract string SceneName { get; }
        public GameStateType State { get; protected set; }
        protected Dictionary<GameStateTransitionType, GameStateType> Transitions { get; set; }


        protected GameStateBase ()
        {
            Transitions = new Dictionary<GameStateTransitionType, GameStateType>();
        }

        
        protected abstract void ChangeState (GameStateTransitionType transition, GameStateType targetState);

        public bool AddTransition (GameStateTransitionType transition, GameStateType targetState)
        {
            throw new NotImplementedException();
        }

        public bool RemoveTransition (GameStateTransitionType transition)
        {
            return Transitions.Remove(transition);
        }

        public GameStateType GetTargetStateType (GameStateTransitionType transition)
        {
            if (Transitions.ContainsKey(transition))
            {
                return Transitions[transition];
            }

            return GameStateType.Error;
        }


    }
}