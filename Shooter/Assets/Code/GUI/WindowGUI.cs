using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.GUI
{
    public class WindowGUI : MonoBehaviour
    {

        public void Open ()
        {
            gameObject.SetActive(true);
        }

        public void Close ()
        {
            gameObject.SetActive(false);
        }
    }
}