using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Avramov.Production
{
    public abstract class BaseBuildingModel : ISelectable
    {
        private BaseBuildingSettings _settings;

        public BuildType BuildType => _settings.BuildType;
        public Vector3 Position => _settings.Position;

        public BaseBuildingModel(BaseBuildingSettings settings)
        {
            _settings = settings;
        }

        public abstract BasePresenter GetPresenter(SelectionModel selectionModel, Assets assets);
    }
}
