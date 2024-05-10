using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Avramov.Production
{
    public class StoreBuildingModel : BaseBuildingModel
    {
        private StoreBuildingSettings _settings;
        private InventoryModel _inventory;

        public IReadOnlyList<ItemTypes> Items => _settings.Items;

        public StoreBuildingModel(StoreBuildingSettings settings, InventoryModel inventoryModel) : base(settings)
        {
            _settings = settings;
            _inventory = inventoryModel;
        }

        public override BasePresenter GetPresenter(SelectionModel selectionModel, Assets assets)
        {
            return new StoreBuildingPresenter(this, selectionModel, assets);
        }
    }
}
