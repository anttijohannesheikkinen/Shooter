using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shooter.Data;

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
            Global.Instance.CurrentGameData = new GameData()
            {
                Level = 1,
                PlayerDatas = new List<PlayerData>()
                { new PlayerData()
                    { Id = PlayerData.PlayerId.Player1, UnitType = PlayerUnit.UnitType.Heavy, Lives = 3, ControlType = PlayerData.ControllerType.KeyArrows},
                    new PlayerData(){ Id = PlayerData.PlayerId.Player2, UnitType = PlayerUnit.UnitType.Balanced, Lives = 3, ControlType = PlayerData.ControllerType.KeyWASD}
                }

            };


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