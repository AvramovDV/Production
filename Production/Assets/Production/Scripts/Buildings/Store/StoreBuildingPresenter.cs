using UnityEngine;

namespace Avramov.Production
{
    public class StoreBuildingPresenter : BasePresenter
    {
        private StoreBuildingModel _model;
        private SelectionModel _selection;
        private Assets _assets;

        private BuildingView _view;

        public StoreBuildingPresenter(StoreBuildingModel model, SelectionModel selection, Assets assets)
        {
            _model = model;
            _selection = selection;
            _assets = assets;
        }

        public override void Activate()
        {
            if (_view == null)
                InitView();

            _view.ClickEvent += OnClick;
        }

        public override void Deactivate()
        {
            _view.ClickEvent -= OnClick;
        }

        private void InitView()
        {
            BuildingView prefab = _assets.GetBuilding(_model.BuildType);
            _view = GameObject.Instantiate(prefab, _model.Position, prefab.transform.rotation);
            _view.ProductionIndicator.gameObject.SetActive(false);
        }

        private void OnClick() => _selection.Select(_model);
    }
}
