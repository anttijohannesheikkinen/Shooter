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
                {

                        new PlayerData ()
                        {
                            Id = PlayerData.PlayerId.Player1,
                            Lives = 3,
                            ControlType = PlayerData.ControllerType.KeyWASD,
                            UnitType = PlayerUnit.UnitType.Fast
                        },

                        new PlayerData ()
                        {
                            Id = PlayerData.PlayerId.Player2,
                            Lives = 3,
                            ControlType = PlayerData.ControllerType.KeyArrows,
                            UnitType = PlayerUnit.UnitType.Heavy
                        },

                        new PlayerData ()
                        {
                            Id = PlayerData.PlayerId.Player3,
                            Lives = 3,
                            ControlType = PlayerData.ControllerType.Pad,
                            UnitType = PlayerUnit.UnitType.Balanced
                        },

                        new PlayerData ()
                        {
                            Id = PlayerData.PlayerId.Player4,
                            Lives = 3,
                            ControlType = PlayerData.ControllerType.Pad,
                            UnitType = PlayerUnit.UnitType.Balanced
                        }
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