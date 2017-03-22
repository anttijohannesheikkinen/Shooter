using UnityEngine;

namespace Shooter.GUI
{
    public class GlobalGUI : MonoBehaviour
    {
        private LoadingIndicator _loader;

        protected void Awake ()
        {
            DontDestroyOnLoad(gameObject);
            _loader = GetComponentInChildren<LoadingIndicator>(true);
            _loader.Init();
        }
    }
}