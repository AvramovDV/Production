using UnityEngine;

namespace Avramov.Production
{
    public class BootstrapMainScene : MonoBehaviour
    {
        [SerializeField] private ScreensManager _screensManager;
        [SerializeField] private ItemsSettings _itemsSettings;
        [SerializeField] private Assets _assets;
        [SerializeField] private MapSettings _mapSettings;

        private InventoryModel _inventoryModel;
        private MatchModel _matchModel;
        private SelectionModel _selectionModel;

        private StateMachine _gameStateMachine = new StateMachine();

        private StartScreenPresenter _startScreenPresenter;
        private MainScreenPresenter _mainScreenPresenter;
        private BuildingsPresenter _buildingsPresenter;
        private ResourceBuildingScreenPresenter _resourceBuildingScreenPresenter;
        private RecyclingBuildingScreenPresenter _recyclingbuildingScreenPresenter;
        private StoreBuildingScreenPresenter _storeBuildingScreenPresenter;
        private VictoryScreenPresenter _victoryScreenPresenter;

        private void Start()
        {
            SetupModels();
            SetupPresenters();
            SetupGameStateMachine();
        }

        private void Update()
        {
            _gameStateMachine.Update();
        }

        private void OnDestroy()
        {
            
        }

        private void SetupModels()
        {
            _inventoryModel = new InventoryModel(_itemsSettings);
            _matchModel = new MatchModel(_mapSettings, _inventoryModel);
            _selectionModel = new SelectionModel();
        }

        private void SetupPresenters()
        {
            _startScreenPresenter = new StartScreenPresenter(_screensManager, _gameStateMachine, _matchModel);
            _mainScreenPresenter = new MainScreenPresenter(_screensManager, _inventoryModel, _assets);
            _buildingsPresenter = new BuildingsPresenter(_matchModel, _assets, _selectionModel);
            _resourceBuildingScreenPresenter = new ResourceBuildingScreenPresenter(_selectionModel, _screensManager, _assets);
            _recyclingbuildingScreenPresenter = new RecyclingBuildingScreenPresenter(_selectionModel, _screensManager, _itemsSettings, _assets);
            _storeBuildingScreenPresenter = new StoreBuildingScreenPresenter(_inventoryModel, _selectionModel, _screensManager, _assets);
            _victoryScreenPresenter = new VictoryScreenPresenter(_screensManager, _gameStateMachine);
        }

        private void SetupGameStateMachine()
        {
            _gameStateMachine.AddState(new BootstrapState(_inventoryModel, _itemsSettings));
            _gameStateMachine.AddState(new StartMenuState(_startScreenPresenter));
            _gameStateMachine.AddState(new GameLoopState(
                _matchModel,
                _inventoryModel,
                _mapSettings,
                _mainScreenPresenter,
                _buildingsPresenter,
                _resourceBuildingScreenPresenter,
                _recyclingbuildingScreenPresenter,
                _storeBuildingScreenPresenter));
            _gameStateMachine.AddState(new GameEndState(_victoryScreenPresenter));

            _gameStateMachine.SwitchState<BootstrapState>();
        }
    }
}
