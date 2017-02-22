using UnityEngine;

namespace Shooter.GUI
{
    public class GlobalGUI : MonoBehaviour
    {

        protected void Awake ()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}