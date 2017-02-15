using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Systems
{
    public class MenuManager : SceneManager
    {
        public override GameStateType StateType
        {
            get
            {
                return GameStateType.MenuState;
            }
        }

        public void StartGame()
        {
            Global.Instance.GameManager.PerformTransition(GameStateTransitionType.MenuToInGame);
            Debug.Log("Start game");
        }


        public void LoadGame()
        {
            Debug.Log("Load game");
        }

        public void QuitGame()
        {
            Debug.Log("Quit game");
            Application.Quit();
        }
    }
}