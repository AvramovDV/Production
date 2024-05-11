using UnityEngine;

namespace Avramov.Production
{
    public class StoreBuildingPresenter : BasePresenter
    {
        private StoreBuildingModel _model;
        private SelectionModel _selection;
        private Assets _assets;

        private StoreBuildingView _view;

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
            StoreBuildingView prefab = _assets.GetBuilding<StoreBuildingView>();
            _view = GameObject.Instantiate(prefab, _model.Position, prefab.transform.rotation);
        }

        private void OnClick() => _selection.Select(_model);
    }
}
