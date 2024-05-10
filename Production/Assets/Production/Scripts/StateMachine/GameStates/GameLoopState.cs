using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Avramov.Production
{
    public class GameLoopState : BaseState
    {
        private MatchModel _matchModel;
        private InventoryModel _inventoryModel;
        private MapSettings _mapSettings;

        private MainScreenPresenter _mainScreenPresenter;
        private BuildingsPresenter _buildingsPresenter;
        private ResourceBuildingScreenPresenter _resourceBuildingScreenPresenter;
        private RecyclingBuildingScreenPresenter _recyclingBuildingScreenPresenter;
        private StoreBuildingScreenPresenter _storeBuildingScreenPresenter;

        public GameLoopState(
            MatchModel matchModel,
            InventoryModel inventoryModel,
            MapSettings mapSettings,
            MainScreenPresenter mainScreenPresenter,
            BuildingsPresenter buildingsPresenter,
            ResourceBuildingScreenPresenter resourceBuildingScreenPresenter,
            RecyclingBuildingScreenPresenter recyclingBuildingScreenPresenter,
            StoreBuildingScreenPresenter storeBuildingScreenPresenter)
        {
            _matchModel = matchModel;
            _inventoryModel = inventoryModel;
            _mapSettings = mapSettings;
            _mainScreenPresenter = mainScreenPresenter;
            _buildingsPresenter = buildingsPresenter;
            _resourceBuildingScreenPresenter = resourceBuildingScreenPresenter;
            _recyclingBuildingScreenPresenter = recyclingBuildingScreenPresenter;
            _storeBuildingScreenPresenter = storeBuildingScreenPresenter;
        }

        public override void Start()
        {
            _mainScreenPresenter.Activate();
            _buildingsPresenter.Activate();
            _resourceBuildingScreenPresenter.Activate();
            _recyclingBuildingScreenPresenter.Activate();
            _storeBuildingScreenPresenter.Activate();

            _inventoryModel.CoinsChangedEvent += CheckVictory;
        }

        public override void Update()
        {
            _matchModel.Update();
        }

        public override void End()
        {
            _mainScreenPresenter.Deactivate();
            _buildingsPresenter.Deactivate();
            _resourceBuildingScreenPresenter.Deactivate();
            _recyclingBuildingScreenPresenter.Deactivate();
            _storeBuildingScreenPresenter.Deactivate();

            _inventoryModel.CoinsChangedEvent -= CheckVictory;
        }

        private void CheckVictory()
        {
            if (_inventoryModel.Coins >= _mapSettings.TargetCoinsCount)
                SwitchState<GameEndState>();
        }
    }
}
