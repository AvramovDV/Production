namespace Avramov.Production
{
    public class ResourceBuildingScreenPresenter
    {
        private SelectionModel _selectionModel;
        private ScreensManager _screensManager;
        private Assets _assets;

        private ResourceBuildingModel _target;
        private int _index;
        private ResourceBuildingScreen _screen;

        private ItemTypes _currentType;

        public ResourceBuildingScreenPresenter(SelectionModel selectionModel, ScreensManager screensManager, Assets assets)
        {
            _selectionModel = selectionModel;
            _screensManager = screensManager;
            _assets = assets;

            _screen = _screensManager.GetScreen<ResourceBuildingScreen>();
        }

        public void Activate()
        {
            _selectionModel.SelectionChangedEvent += OnSelect;
            _screen.ItemButton.onClick.AddListener(OnItemClick);
            _screen.StartButton.onClick.AddListener(OnStartClick);
            _screen.StopButton.onClick.AddListener(OnStopClick);
            _screen.CloseButton.onClick.AddListener(OnCloseClick);
        }

        public void Deactivate()
        {
            _selectionModel.SelectionChangedEvent -= OnSelect;
            _screen.ItemButton.onClick.RemoveListener(OnItemClick);
            _screen.StartButton.onClick.RemoveListener(OnStartClick);
            _screen.StopButton.onClick.RemoveListener(OnStopClick);
            _screen.CloseButton.onClick.RemoveListener(OnCloseClick);

            _screen.SetActive(false);
        }

        private void OnSelect()
        {
            if (_selectionModel.Selectable is ResourceBuildingModel model)
            {
                _target = model;
                _index = 0;
                _currentType = _target.ProductingItem;
                SetupChoosenItem();
                SetupStartStopButtons();
                _screen.SetActive(true);
            }
            else
            {
                _screen.SetActive(false);
            }
        }

        private void OnItemClick()
        {
            ChangeChoosenItem();
            SetupChoosenItem();
        }

        private void OnStartClick()
        {
            if (_currentType == ItemTypes.None)
                return;

            _target.StartProducting(_currentType);
            SetupStartStopButtons();
        }

        private void OnStopClick()
        {
            _target.StopProducting();
            SetupStartStopButtons();
        }

        private void OnCloseClick()
        {
            _screen?.SetActive(false);
        }

        private void SetupStartStopButtons()
        {
            _screen.StartButton.SetActive(!_target.IsProducting);
            _screen.StopButton.SetActive(_target.IsProducting);
        }

        private void ChangeChoosenItem()
        {
            _index = _index >= _target.Items.Count ? 0 : _index;
            _currentType = _target.Items[_index];
            _index++;
        }

        private void SetupChoosenItem() => _screen.ItemImage.sprite = _assets.GetItemSprite(_currentType);
    }
}
