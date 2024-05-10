using UnityEngine;

namespace Avramov.Production
{
    public class RecyclingBuildingPresenter : BasePresenter
    {
        private RecyclingBuildingModel _model;
        private SelectionModel _selection;
        private Assets _assets;

        private BuildingView _view;

        public RecyclingBuildingPresenter(RecyclingBuildingModel model, SelectionModel selection, Assets assets)
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
            _model.ModelChangedEvent += UpdateView;

            UpdateView();
        }

        public override void Deactivate()
        {
            _view.ClickEvent -= OnClick;
            _model.ModelChangedEvent -= UpdateView;
        }

        private void InitView()
        {
            BuildingView prefab = _assets.GetBuilding(_model.BuildType);
            _view = GameObject.Instantiate(prefab, _model.Position, prefab.transform.rotation);
        }

        private void OnClick() => _selection.Select(_model);

        private void UpdateView()
        {
            _view.ProductionIndicator.gameObject.SetActive(_model.IsProducting);
            _view.ProgressImage.fillAmount = _model.ProductingProgress;
            _view.ItemImage.sprite = _assets.GetItemSprite(_model.ProductingItem);
        }
    }
}
