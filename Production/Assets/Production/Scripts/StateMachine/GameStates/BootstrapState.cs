using UnityEngine;

namespace Avramov.Production
{
    public class BootstrapState : BaseState
    {
        private InventoryModel _playerModel;
        private ItemsSettings _itemSettings;

        public BootstrapState(InventoryModel playerModel, ItemsSettings itemSettings)
        {
            _playerModel = playerModel;
            _itemSettings = itemSettings;
        }

        public override void Start()
        {
            SetupPlayerData();
            SwitchState<StartMenuState>();
        }

        public override void Update() { }

        public override void End() { }

        private void SetupPlayerData()
        {
            string json = PlayerPrefs.GetString(PrefsKeys.PlayerDataPrefsKey, "");
            InventoryData playerData = string.IsNullOrEmpty(json) ? _itemSettings.GetDefaultPlayerData() : json.FromJson<InventoryData>();
            _playerModel.Setup(playerData);
        }
    }
}
