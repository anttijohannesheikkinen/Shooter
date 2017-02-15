using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}