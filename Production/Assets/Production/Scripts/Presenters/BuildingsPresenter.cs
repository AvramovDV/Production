using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Avramov.Production
{
    public class BuildingsPresenter
    {
        private MatchModel _matchModel;
        private Assets _assets;
        private SelectionModel _selectionModel;

        //private List<BuildingStatusPresenter> _buildingPresenters = new List<BuildingStatusPresenter>();
        private List<BasePresenter> _buildingPresenters = new List<BasePresenter>();

        public BuildingsPresenter(MatchModel matchModel, Assets assets, SelectionModel selectionModel)
        {
            _matchModel = matchModel;
            _assets = assets;
            _selectionModel = selectionModel;
        }

        public void Activate()
        {
            InitBuildingPresenters();

            foreach (var item in _buildingPresenters)
            {
                item.Activate();
            }
        }

        public void Deactivate()
        {
            foreach (var item in _buildingPresenters)
            {
                item.Deactivate();
            }
        }

        private void InitBuildingPresenters()
        {
            if (_buildingPresenters.Count > 0)
                return;

            foreach (var item in _matchModel.Buildings)
            {
                //BuildingView prefab = _assets.GetBuilding(item.BuildType);
                //BuildingView view = GameObject.Instantiate(prefab, item.Position, prefab.transform.rotation);
                //BuildingStatusPresenter presenter = new BuildingStatusPresenter(view, item, _assets, _selectionModel);
                BasePresenter presenter = item.GetPresenter(_selectionModel, _assets);
                _buildingPresenters.Add(presenter);
            }
        }
    }
}
