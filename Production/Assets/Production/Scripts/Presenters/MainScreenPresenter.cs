using System.Collections.Generic;
using UnityEngine;

namespace Avramov.Production
{
    public class MainScreenPresenter
    {
        private ScreensManager _screensManager;
        private InventoryModel _playerModel;
        private Assets _assets;

        private List<ItemsCountPresenter> _countPresenters = new List<ItemsCountPresenter>();

        private MainScreen _mainScreen;

        public MainScreenPresenter(ScreensManager screensManager, InventoryModel playerModel, Assets assets)
        {
            _screensManager = screensManager;
            _playerModel = playerModel;
            _assets = assets;

            _mainScreen = _screensManager.GetScreen<MainScreen>();
        }

        public void Activate()
        {
            InitPresenters();

            foreach (var item in _countPresenters)
            {
                item.Activate();
            }

            _playerModel.CoinsChangedEvent += ShowCoins;
            ShowCoins();
            _mainScreen.SetActive(true);
        }

        public void Deactivate()
        {
            foreach (var item in _countPresenters)
            {
                item.Deactivate();
            }

            _playerModel.CoinsChangedEvent -= ShowCoins;
            _mainScreen.SetActive(false);
        }

        private void InitPresenters()
        {
            if (_countPresenters.Count > 0)
                return;

            foreach (var item in _playerModel.Items)
            {
                ItemView view = GameObject.Instantiate(_mainScreen.ItemPrefab, _mainScreen.ItemsPanelTransform);
                view.Image.sprite = _assets.GetItemSprite(item.Type);
                ItemsCountPresenter presenter = new ItemsCountPresenter(item, view);
                _countPresenters.Add(presenter);
            }
        }

        private void ShowCoins() => _mainScreen.CoinsText.text = _playerModel.Coins.ToString();
    }
}
