namespace Avramov.Production
{
    public class StartMenuState : BaseState
    {
        private StartScreenPresenter _startScreenPresenter;

        public StartMenuState(StartScreenPresenter startScreenPresenter)
        {
            _startScreenPresenter = startScreenPresenter;
        }

        public override void Start()
        {
            _startScreenPresenter.Activate();
        }

        public override void Update() { }

        public override void End()
        {
            _startScreenPresenter.Deactivate();
        }
    }
}
