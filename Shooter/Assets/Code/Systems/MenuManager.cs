using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Systems
{
    public class MenuManager : SceneManager
    {
        public void StartGame()
        {
            Debug.Log("Start game");
        }


        public void LoadGame()
        {
            Debug.Log("Load game");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}