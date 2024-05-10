using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Avramov.Production
{
    [CreateAssetMenu(fileName = "MapSettings", menuName = "Production/MapSettings")]
    public class MapSettings : ScriptableObject
    {
        [field: SerializeField] public int TargetCoinsCount { get; private set; }
        [SerializeField] private List<BaseBuildingSettings> _buildingSettings;


        public List<BaseBuildingModel> GetBuildingsModels(int resourceBuildingsCount, InventoryModel inventory)
        {
            List<BaseBuildingSettings> targetBuildings = new List<BaseBuildingSettings>();

            List<BaseBuildingSettings> resourceBuildings = _buildingSettings.Where(x => x.BuildType == BuildType.Resource).Take(resourceBuildingsCount).ToList();
            List<BaseBuildingSettings> notResourceBuildings = _buildingSettings.Where(x => x.BuildType != BuildType.Resource).ToList();

            targetBuildings.AddRange(resourceBuildings);
            targetBuildings.AddRange (notResourceBuildings);

            List<BaseBuildingModel> result = targetBuildings.Select(x => x.GetModel(inventory)).ToList();

            return result;
        }
    }
}
