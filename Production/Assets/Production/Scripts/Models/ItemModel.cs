using System;
using System.Collections.Generic;

namespace Avramov.Production
{
    public class ItemModel
    {
        private ItemData _itemData;
        private ItemsSettings.ItemConfig _itemConfig;

        public int Count => _itemData.Count;
        public ItemTypes Type => _itemData.Type;
        public ItemData ItemData => _itemData;
        public int Price => _itemConfig.Price;
        public IReadOnlyList<ItemTypes> SubItems => _itemConfig.SubItems;

        public event Action ItemChangedEvent;

        public ItemModel(ItemData itemData, ItemsSettings.ItemConfig itemConfig)
        {
            _itemData = itemData;
            _itemConfig = itemConfig;
        }

        public void AddItems(int count)
        {
            _itemData.Count += count;
            ItemChangedEvent?.Invoke();
        }
    }
}
