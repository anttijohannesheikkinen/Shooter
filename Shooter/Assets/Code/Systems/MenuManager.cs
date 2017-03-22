using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shooter.Data;
using Shooter.GUI;

namespace Shooter.Systems
{
    public class MenuManager : SceneManager
    {
        private LoadWindow _loadWindow;
        private PlayerSettings _playerSettingsWindow;

        public override GameStateType StateType
        {
            get
            {
                return GameStateType.MenuState;
            }
        }

        private void Awake ()
        {
            _loadWindow = GetComponentInChildren<LoadWindow>(true);
            _loadWindow.Init(this);
            _loadWindow.Close();

            _playerSettingsWindow = GetComponentInChildren<PlayerSettings>(true);
            _playerSettingsWindow.Init(this);
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


        public void OpenLoadWindow ()
        {
            _loadWindow.Open();
        }

        public void LoadGame(string loadFileName)
        {
            _loadWindow.Close();

            GameData loadData = Global.Instance.SaveManager.Load(loadFileName);
            Global.Instance.CurrentGameData = loadData;
            Global.Instance.GameManager.PerformTransition(GameStateTransitionType.MenuToInGame);
        }

        public void QuitGame()
        {
            Debug.Log("Quit game");
            Application.Quit();
        }
    }
}