using UnityEngine.UI;

namespace Avramov.Production
{
    public class RecyclingBuildingScreenPresenter
    {
        private SelectionModel _selectionModel;
        private ScreensManager _screensManager;
        private ItemsSettings _itemsSettings;
        private Assets _assets;

        private int _index1 = 0;
        private int _index2 = 0;
        private ItemTypes _currentItem1;
        private ItemTypes _currentItem2;
        private ItemTypes _currentItemResult;

        //private BuildModel _target;
        private RecyclingBuildingModel _target;

        private RecyclingBuildingScreen _screen;

        public RecyclingBuildingScreenPresenter(SelectionModel selectionModel, ScreensManager screensManager, ItemsSettings itemsSettings, Assets assets)
        {
            _selectionModel = selectionModel;
            _screensManager = screensManager;
            _itemsSettings = itemsSettings;
            _assets = assets;

            _screen = _screensManager.GetScreen<RecyclingBuildingScreen>();
        }

        public void Activate()
        {
            _selectionModel.SelectionChangedEvent += OnSelected;
            _screen.ResourceButton1.onClick.AddListener(OnItem1Click);
            _screen.ResourceButton2.onClick.AddListener(OnItem2Click);
            _screen.StartButton.onClick.AddListener(OnStartClick);
            _screen.StopButton.onClick.AddListener(OnStopClick);
            _screen.CloseButton.onClick.AddListener(OnCloseClick);
        }

        public void Deactivate()
        {
            _selectionModel.SelectionChangedEvent -= OnSelected;
            _screen.ResourceButton1.onClick.RemoveListener(OnItem1Click);
            _screen.ResourceButton2.onClick.RemoveListener(OnItem2Click);
            _screen.StartButton.onClick.RemoveListener(OnStartClick);
            _screen.StopButton.onClick.RemoveListener(OnStopClick);
            _screen.CloseButton.onClick.RemoveListener(OnCloseClick);
        }

        private void OnSelected()
        {
            if (_selectionModel.Selectable is RecyclingBuildingModel build)
            {
                _target = build;
                _index1 = 0;
                _index2 = 0;
                _currentItem1 = ItemTypes.None;
                _currentItem2 = ItemTypes.None;
                _currentItemResult = ItemTypes.None;
                _screen.ResourceImage1.sprite = _assets.GetItemSprite(_currentItem1);
                _screen.ResourceImage2.sprite = _assets.GetItemSprite(_currentItem2);
                _screen.ResultImage.sprite = _assets.GetItemSprite(_currentItemResult);
                SetupStartStopButtons();
                _screen.SetActive(true);
            }
            else
            {
                _screen.SetActive(false);
            }
        }

        private void SetupStartStopButtons()
        {
            _screen.StartButton.SetActive(!_target.IsProducting);
            _screen.StopButton.SetActive(_target.IsProducting);
        }

        private void OnItem1Click()
        {
            ChangeCurrentItem(ref _index1, ref _currentItem1, _screen.ResourceImage1);
        }

        private void OnItem2Click()
        {
            ChangeCurrentItem(ref _index2, ref _currentItem2, _screen.ResourceImage2);
        }

        private void OnStartClick()
        {
            if (_currentItemResult == ItemTypes.None)
                return;

            _target.StartProducting(_currentItemResult);
            SetupStartStopButtons();
        }

        private void OnStopClick()
        {
            _target.StopProducting();
            SetupStartStopButtons();
        }

        private void OnCloseClick()
        {
            _screen.SetActive(false);
        }

        private void ChangeCurrentItem(ref int index, ref ItemTypes item, Image resourceImage)
        {
            index = index >= _target.Items.Count ? 0 : index;
            item = _target.Items[index];
            index++;
            _currentItemResult = _itemsSettings.FindProduct(_currentItem1, _currentItem2);
            resourceImage.sprite = _assets.GetItemSprite(item);
            _screen.ResultImage.sprite = _assets.GetItemSprite(_currentItemResult);
        }
    }
}
