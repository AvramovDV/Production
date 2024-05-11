using System.Collections.Generic;
using UnityEngine;

namespace Avramov.Production
{
    public class MainScreenPresenter
    {
        private ScreensManager _screensManager;
        private InventoryModel _inventoryModel;
        private MapSettings _mapSettings;
        private Assets _assets;

        private List<ItemsCountPresenter> _countPresenters = new List<ItemsCountPresenter>();

        private MainScreen _mainScreen;

        public MainScreenPresenter(ScreensManager screensManager, InventoryModel playerModel, Assets assets, MapSettings mapSettings)
        {
            _screensManager = screensManager;
            _inventoryModel = playerModel;
            _assets = assets;

            _mainScreen = _screensManager.GetScreen<MainScreen>();
            _mapSettings = mapSettings;
        }

        public void Activate()
        {
            InitPresenters();

            foreach (var item in _countPresenters)
            {
                item.Activate();
            }

            _inventoryModel.CoinsChangedEvent += ShowCoins;
            ShowCoins();
            _mainScreen.SetActive(true);
        }

        public void Deactivate()
        {
            foreach (var item in _countPresenters)
            {
                item.Deactivate();
            }

            _inventoryModel.CoinsChangedEvent -= ShowCoins;
            _mainScreen.SetActive(false);
        }

        private void InitPresenters()
        {
            if (_countPresenters.Count > 0)
                return;

            foreach (var item in _inventoryModel.Items)
            {
                ItemView view = GameObject.Instantiate(_mainScreen.ItemPrefab, _mainScreen.ItemsPanelTransform);
                view.Image.sprite = _assets.GetItemSprite(item.Type);
                ItemsCountPresenter presenter = new ItemsCountPresenter(item, view);
                _countPresenters.Add(presenter);
            }
        }

        private void ShowCoins() => _mainScreen.CoinsText.text = $"{_inventoryModel.Coins} / {_mapSettings.TargetCoinsCount}";
    }
}
