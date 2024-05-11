using UnityEngine;

namespace Avramov.Production
{
    public class GameEndState : BaseState
    {
        private ScreensManager _screensManager;
        private StateMachine _machine;
        private InventoryModel _inventory;

        private VictoryScreenPresenter _victoryScreenPresenter;

        public GameEndState(ScreensManager screensManager, StateMachine machine, InventoryModel inventoryModel)
        {
            _screensManager = screensManager;
            _machine = machine;
            _inventory = inventoryModel;
        }

        public override void Start()
        {
            SaveData();
            SetupPresenters();
            _victoryScreenPresenter.Activate();
        }

        public override void Update()
        {

        }

        public override void End()
        {
            _victoryScreenPresenter?.Deactivate();
        }

        private void SetupPresenters()
        {
            _victoryScreenPresenter = new VictoryScreenPresenter(_screensManager, _machine);
        }

        private void SaveData()
        {
            InventoryData data = _inventory.GetData();
            string json = data.ToJson();
            PlayerPrefs.SetString(PrefsKeys.PlayerDataPrefsKey, json);
            PlayerPrefs.Save();
        }
    }
}
