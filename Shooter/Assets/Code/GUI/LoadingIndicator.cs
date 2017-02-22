using System.Collections;
using UnityEngine;
using Shooter.Systems;
using UnityEngine.UI;
using DG.Tweening;

namespace Shooter.GUI
{

    public class LoadingIndicator : MonoBehaviour
    {
        [SerializeField] private Image _loadIndicatorImage;
        [SerializeField] private Image _backGroundImage;

        private Coroutine _rotateCoroutine;

        protected void Awake ()
        {
            gameObject.SetActive(false);
            Global.Instance.GameManager.GameStateChanging += HandleGameStateChanging;
            Global.Instance.GameManager.GameStateChanged += HandleGameStateChanged;
        }

        protected void OnDestroy()
        {
            Global.Instance.GameManager.GameStateChanging -= HandleGameStateChanging;
            Global.Instance.GameManager.GameStateChanged -= HandleGameStateChanged;
        }

        private void HandleGameStateChanging (GameStateType obj)
        {
            gameObject.SetActive(true);
            _rotateCoroutine = StartCoroutine(Rotate());

            _backGroundImage.color = new Color(0, 0, 0, 0);
            DOTween.To(() => _backGroundImage.color, (value) => _backGroundImage.color = value, Color.black, 0.5f);
        }

        private void HandleGameStateChanged(GameStateType obj)
        {
            StopCoroutine(_rotateCoroutine);
            _rotateCoroutine = null;
            DOTween.To(() => _backGroundImage.color, 
                       (value) => _backGroundImage.color = value, 
                       new Color(0, 0, 0, 0), 0.5f).OnComplete(TweenCompleted);
        }

        private void TweenCompleted ()
        {
            gameObject.SetActive(false);
        }

        private IEnumerator Rotate ()
        {
            while (true)
            {
                _loadIndicatorImage.transform.Rotate(Vector3.forward, -180 * Time.deltaTime, Space.Self);
                yield return null;
            }
        }
    }
}