using System.Collections.Generic;
using UnityEngine;

namespace Avramov.Production
{
    [CreateAssetMenu(fileName = "StoreBuildingSettings", menuName = "Production/StoreBuildingSettings")]
    public class StoreBuildingSettings : BaseBuildingSettings
    {
        [field: SerializeField] private List<ItemTypes> _items;

        public IReadOnlyList<ItemTypes> Items => _items;

        public override BaseBuildingModel GetModel(InventoryModel inventory)
        {
            return new StoreBuildingModel(this, inventory);
        }
    }
}
