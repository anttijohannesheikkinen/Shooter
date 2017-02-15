using UnityEngine;
using Shooter.Systems.States;

namespace Shooter.Systems
{

    public abstract class SceneManager : MonoBehaviour
    {
        private GameStateBase _associatedState;

        public abstract GameStateType StateType { get; }
        public virtual GameStateBase AssociatedGameState
        {
            get
            {
                if (_associatedState == null)
                {
                    _associatedState = Global.Instance.GameManager.GetStateByStateType(StateType);
                }

                return _associatedState;
            }
        }

    }
}