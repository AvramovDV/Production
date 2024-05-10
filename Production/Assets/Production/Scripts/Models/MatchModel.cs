using System.Collections.Generic;

namespace Avramov.Production
{
    public class MatchModel
    {
        private MapSettings _mapSettings;
        private InventoryModel _inventory;
        private List<BaseBuildingModel> _buildings;

        public IReadOnlyList<BaseBuildingModel> Buildings => _buildings;

        public MatchModel(MapSettings mapSettings, InventoryModel inventory)
        {
            _mapSettings = mapSettings;
            _inventory = inventory;
        }

        public void Setup(int resourceBuildingsCount)
        {
            _buildings = _mapSettings.GetBuildingsModels(resourceBuildingsCount, _inventory);
        }

        public void Update()
        {
            foreach (var build in _buildings)
            {
                if(build is IUpdatable updatable)
                    updatable.Update();
            }
        }
    }
}
