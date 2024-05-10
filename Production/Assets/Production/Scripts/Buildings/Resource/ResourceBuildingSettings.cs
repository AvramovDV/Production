using System.Collections.Generic;
using UnityEngine;

namespace Avramov.Production
{
    [CreateAssetMenu(fileName = "ResourceBuildingSettings", menuName = "Production/ResourceBuildingSettings")]
    public class ResourceBuildingSettings : BaseBuildingSettings
    {
        [field: SerializeField] public float ProductionTime { get; private set; }

        [SerializeField] private List<ItemTypes> _items;

        public IReadOnlyList<ItemTypes> Items => _items;

        public override BaseBuildingModel GetModel(InventoryModel inventory)
        {
            return new ResourceBuildingModel(this, inventory);
        }

    }
}
