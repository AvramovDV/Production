using UnityEngine;

namespace Avramov.Production
{
    public class BootstrapMainScene : MonoBehaviour
    {
        [SerializeField] private ScreensManager _screensManager;


        private SelectionModel _selectionModel = new SelectionModel();
        private StateMachine _gameStateMachine = new StateMachine();

        private ItemsSettings _itemsSettings => ProjectContext.Instance.Get<ItemsSettings>();
        private Assets _assets => ProjectContext.Instance.Get<Assets>();
        private MapSettings _mapSettings => ProjectContext.Instance.Get<MapSettings>();
        private InventoryModel _inventoryModel => ProjectContext.Instance.Get<InventoryModel>();
        private MatchModel _matchModel => ProjectContext.Instance.Get<MatchModel>();


        private void Start()
        {
            SetupGameStateMachine();
        }

        private void Update()
        {
            _gameStateMachine.Update();
        }

        private void OnDestroy()
        {
            
        }

        private void SetupGameStateMachine()
        {
            _gameStateMachine.AddState(new BootstrapState(_inventoryModel, _itemsSettings));
            _gameStateMachine.AddState(new StartMenuState(_screensManager, _gameStateMachine, _matchModel));
            _gameStateMachine.AddState(new GameLoopState(
                _matchModel,
                _inventoryModel,
                _mapSettings,
                _screensManager,
                _assets,
                _selectionModel,
                _itemsSettings));
            _gameStateMachine.AddState(new GameEndState(_screensManager, _gameStateMachine, _inventoryModel));

            _gameStateMachine.SwitchState<BootstrapState>();
        }
    }
}
