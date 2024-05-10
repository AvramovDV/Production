using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Avramov.Production
{
    public class RecyclingBuildingModel : BaseBuildingModel, IUpdatable
    {
        private RecyclingBuildingSettings _settings;
        private InventoryModel _inventory;

        private float _producting;

        public bool IsProducting { get; private set; }
        public ItemTypes ProductingItem { get; private set; }
        public float ProductingProgress => _producting / _settings.ProductionTime;
        public IReadOnlyList<ItemTypes> Items => _settings.Items;

        public event Action ModelChangedEvent;

        public RecyclingBuildingModel(RecyclingBuildingSettings settings, InventoryModel inventory) : base(settings)
        {
            _settings = settings;
            _inventory = inventory;
        }

        public override BasePresenter GetPresenter(SelectionModel selectionModel, Assets assets)
        {
            return new RecyclingBuildingPresenter(this, selectionModel, assets);
        }

        public void StartProducting(ItemTypes item)
        {
            ProductingItem = item;
            IsProducting = true;
            _producting = 0f;

            ModelChangedEvent?.Invoke();
        }

        public void StopProducting()
        {
            IsProducting = false;
            ProductingItem = ItemTypes.None;

            ModelChangedEvent?.Invoke();
        }

        public void Update()
        {
            if (!IsProducting)
                return;

            _producting += Time.deltaTime;

            if (_producting >= _settings.ProductionTime)
                OnProductionCompleted();

            ModelChangedEvent?.Invoke();
        }

        private void OnProductionCompleted()
        {
            _inventory.AddItem(ProductingItem);
            _inventory.PayForProduction(ProductingItem);
            _producting = 0f;
            if (!_inventory.CanProductItem(ProductingItem))
                StopProducting();
        }
    }
}
