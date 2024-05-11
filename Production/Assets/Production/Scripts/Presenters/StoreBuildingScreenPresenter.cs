namespace Avramov.Production
{
    public class StoreBuildingScreenPresenter
    {
        private InventoryModel _inventoryModel;
        private SelectionModel _selectionModel;
        private ScreensManager _screensManager;
        private Assets _assets;

        private ItemTypes _currentItem;
        private int _index = 0;
        private StoreBuildingModel _target;

        private StoreBuildingScreen _screen;

        public StoreBuildingScreenPresenter(InventoryModel inventoryModel, SelectionModel selectionModel, ScreensManager screensManager, Assets assets)
        {
            _inventoryModel = inventoryModel;
            _selectionModel = selectionModel;
            _screensManager = screensManager;
            _assets = assets;

            _screen = _screensManager.GetScreen<StoreBuildingScreen>();
        }

        public void Activate()
        {
            _selectionModel.SelectionChangedEvent += OnSelect;
            _screen.ItemButton.onClick.AddListener(OnItemClick);
            _screen.SellButton.onClick.AddListener(OnSellClick);
            _screen.CloseButton.onClick.AddListener(OnCloseClick);
        }

        public void Deactivate()
        {
            _selectionModel.SelectionChangedEvent -= OnSelect;
            _screen.ItemButton.onClick.RemoveListener(OnItemClick);
            _screen.SellButton.onClick.RemoveListener(OnSellClick);
            _screen.CloseButton.onClick.RemoveListener(OnCloseClick);

            _screen.SetActive(false);
        }

        private void OnSelect()
        {
            if(_selectionModel.Selectable is StoreBuildingModel model)
            {
                _target = model;
                _index = 0;
                _currentItem = ItemTypes.None;
                _screen.ItemImage.sprite = _assets.GetItemSprite(_currentItem);
                _screen.PriceText.text = "0";
                SetupEnableStatus();
                _screen.SetActive(true);
            }
            else
            {
                _screen.SetActive(false);
            }
        }

        private void OnItemClick()
        {
            ChangeCurrentItem();
            _screen.ItemImage.sprite = _assets.GetItemSprite(_currentItem);
            _screen.PriceText.text = _inventoryModel.GetItem(_currentItem).Price.ToString();
            SetupEnableStatus();
        }

        private void OnSellClick()
        {
            if (_currentItem == ItemTypes.None)
                return;

            if (!_inventoryModel.CanSellItem(_currentItem))
                return;

            _inventoryModel.SellItem(_currentItem);
            SetupEnableStatus();
        }

        private void OnCloseClick() => _screen.SetActive(false);

        private void ChangeCurrentItem()
        {
            _index = _index >= _target.Items.Count ? 0 : _index;
            _currentItem = _target.Items[_index];
            _index++;
        }

        private void SetupEnableStatus()
        {
            _screen.EnableSellImage.enabled = _inventoryModel.CanSellItem(_currentItem);
            _screen.DisableSellImage.enabled = !_inventoryModel.CanSellItem(_currentItem);
        }
    }
}
