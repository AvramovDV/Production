using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Avramov.Production
{
    public class VictoryScreenPresenter
    {
        private ScreensManager _screensManager;
        private VictoryScreen _screen;
        private StateMachine _gameStateMachine;

        public VictoryScreenPresenter(ScreensManager screensManager, StateMachine gameStateMachine)
        {
            _screensManager = screensManager;
            _gameStateMachine = gameStateMachine;
            _screen = _screensManager.GetScreen<VictoryScreen>();
        }

        public void Activate()
        {
            _screen.OkButton.onClick.AddListener(OnClick);
            _screen.SetActive(true);
            _screen.StartCoroutine(ShowScreen());
        }

        public void Deactivate()
        {
            _screen.OkButton.onClick.RemoveAllListeners();
            _screen.SetActive(false);
        }

        private IEnumerator ShowScreen()
        {
            float t = 0f;

            while (t < 1f)
            {
                _screen.PanelTransform.position = Vector3.Lerp(_screen.StartPoint.position, _screen.EndPoint.position, t);
                t += _screen.Speed * Time.deltaTime;
                yield return null;
            }
        }

        private void OnClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
