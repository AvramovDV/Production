namespace Avramov.Production
{
    public class StartMenuState : BaseState
    {
        private ScreensManager _screensManager;
        private StateMachine _stateMachine;
        private MatchModel _matchModel;

        private StartScreenPresenter _startScreenPresenter;

        public StartMenuState(ScreensManager screensManager, StateMachine stateMachine, MatchModel matchModel)
        {
            _screensManager = screensManager;
            _stateMachine = stateMachine;
            _matchModel = matchModel;
        }

        public override void Start()
        {
            SetupPresenters();
            _startScreenPresenter.Activate();
        }

        public override void Update() { }

        public override void End()
        {
            _startScreenPresenter.Deactivate();
        }

        private void SetupPresenters()
        {
            _startScreenPresenter = new StartScreenPresenter(_screensManager, _stateMachine, _matchModel);
        }
    }
}
