namespace Avramov.Production
{
    public class GameLoopState : BaseState
    {
        private MatchModel _matchModel;
        private InventoryModel _inventoryModel;
        private MapSettings _mapSettings;
        private ScreensManager _screensManager;
        private Assets _assets;
        private SelectionModel _selectionModel;
        private ItemsSettings _itemsSettings;

        private MainScreenPresenter _mainScreenPresenter;
        private BuildingsPresenter _buildingsPresenter;
        private ResourceBuildingScreenPresenter _resourceBuildingScreenPresenter;
        private RecyclingBuildingScreenPresenter _recyclingBuildingScreenPresenter;
        private StoreBuildingScreenPresenter _storeBuildingScreenPresenter;

        public GameLoopState(
            MatchModel matchModel,
            InventoryModel inventoryModel,
            MapSettings mapSettings,
            ScreensManager screens,
            Assets assets,
            SelectionModel selectionModel,
            ItemsSettings itemsSettings)
        {
            _matchModel = matchModel;
            _inventoryModel = inventoryModel;
            _mapSettings = mapSettings;
            _screensManager = screens;
            _assets = assets;
            _selectionModel = selectionModel;
            _itemsSettings = itemsSettings;
        }

        public override void Start()
        {
            SetupPresenters();

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

        private void SetupPresenters()
        {
            _mainScreenPresenter = new MainScreenPresenter(_screensManager, _inventoryModel, _assets, _mapSettings);
            _buildingsPresenter = new BuildingsPresenter(_matchModel, _assets, _selectionModel);
            _resourceBuildingScreenPresenter = new ResourceBuildingScreenPresenter(_selectionModel, _screensManager, _assets);
            _recyclingBuildingScreenPresenter = new RecyclingBuildingScreenPresenter(_selectionModel, _screensManager, _itemsSettings, _assets);
            _storeBuildingScreenPresenter = new StoreBuildingScreenPresenter(_inventoryModel, _selectionModel, _screensManager, _assets);
        }

        private void CheckVictory()
        {
            if (_inventoryModel.Coins >= _mapSettings.TargetCoinsCount)
                SwitchState<GameEndState>();
        }
    }
}
