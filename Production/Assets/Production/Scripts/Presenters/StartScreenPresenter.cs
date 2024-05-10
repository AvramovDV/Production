using System.Collections.Generic;
using System.Linq;

namespace Avramov.Production
{
    public class StartScreenPresenter
    {
        private ScreensManager _screensManager;
        private StateMachine _gameStateMachine;
        private MatchModel _matchModel;

        private StartScreen _startScreen;

        public StartScreenPresenter(ScreensManager screensManager, StateMachine gameStateMachine, MatchModel matchModel)
        {
            _screensManager = screensManager;
            _gameStateMachine = gameStateMachine;
            _matchModel = matchModel;

            _startScreen = _screensManager.GetScreen<StartScreen>();
        }

        public void Activate()
        {
            _startScreen.StartButton.onClick.AddListener(OnStartClick);
            _startScreen.SetActive(true);
        }

        public void Deactivate()
        {
            _startScreen.StartButton.onClick.RemoveListener(OnStartClick);
            _startScreen.SetActive(false);
        }

        private void OnStartClick()
        {
            _matchModel.Setup(GetResourceCount());
            _gameStateMachine.SwitchState<GameLoopState>();
        }

        private int GetResourceCount() => _startScreen.ResourceBuildingsSelectors.First(x => x.IsOn).Count;
    }
}
