using UnityEngine;

namespace Avramov.Production
{
    public class ResourceBuildingPresenter : BasePresenter
    {
        private ResourceBuildingModel _model;
        private SelectionModel _seletion;
        private Assets _assets;

        private ResourceBuildingView _view;

        public ResourceBuildingPresenter(ResourceBuildingModel model, SelectionModel selectionModel, Assets assets)
        {
            _model = model;
            _seletion = selectionModel;
            _assets = assets;
        }

        public override void Activate()
        {
            if (_view == null)
                InitBuilding();

            _model.ModelChangedEvent += UpdateView;
            _view.ClickEvent += OnClick;

            UpdateView();
        }

        public override void Deactivate()
        {
            _model.ModelChangedEvent -= UpdateView;
            _view.ClickEvent -= OnClick;
        }

        private void InitBuilding()
        {
            ResourceBuildingView prefab = _assets.GetBuilding<ResourceBuildingView>();
            _view = GameObject.Instantiate(prefab, _model.Position, prefab.transform.rotation);
        }

        private void UpdateView()
        {
            _view.ProductionIndicator.gameObject.SetActive(_model.IsProducting);
            _view.ProgressImage.fillAmount = _model.ProductingProgress;
            _view.ItemImage.sprite = _assets.GetItemSprite(_model.ProductingItem);
        }

        private void OnClick()
        {
            _seletion.Select(_model);
        }
    }
}
