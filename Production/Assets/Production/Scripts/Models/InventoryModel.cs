using System;
using System.Collections.Generic;
using System.Linq;

namespace Avramov.Production
{
    public class InventoryModel
    {
        private ItemsSettings _itemsSettings;
        private List<ItemModel> _items = new List<ItemModel>();

        public IReadOnlyList<ItemModel> Items => _items;
        public int Coins { get; private set; }

        public event Action CoinsChangedEvent;

        public InventoryModel(ItemsSettings itemsSettings)
        {
            _itemsSettings = itemsSettings;
        }

        public void Setup(InventoryData playerData)
        {
            Coins = playerData.Coins;
            SetupItems(playerData.Items);
        }

        public void AddCoins(int coins)
        {
            Coins += coins;
            CoinsChangedEvent?.Invoke();
        }

        public InventoryData GetData()
        {
            InventoryData playerData = new InventoryData()
            {
                Coins = Coins,
                Items = _items.Select(x => x.ItemData).ToList()
            };

            return playerData;
        }

        public bool CanProductItem(ItemTypes itemType)
        {
            ItemModel item = _items.Find(x => x.Type == itemType);

            if (item.SubItems.Count == 0)
                return true;

            List<ItemModel> requires = _items.Where(x => item.SubItems.Contains(x.Type)).ToList();

            if (requires.Any(x => x.Count == 0))
                return false;

            return true;
        }

        public void PayForProduction(ItemTypes target)
        {
            ItemModel item = _items.Find(x => x.Type == target);
            foreach (var subitem in item.SubItems)
            {
                AddItem(subitem, -1);
            }
        }

        public void AddItem(ItemTypes itemType, int count = 1) => _items.Find(x => x.Type == itemType).AddItems(count);

        public bool CanSellItem(ItemTypes itemType, int count = 1) => (_items.Find(x => x.Type == itemType)?.Count ?? 0) >= count;

        public void SellItem(ItemTypes itemType, int count = 1)
        {
            if (!CanSellItem(itemType, count))
                return;

            var item = _items.Find(x => x.Type == itemType);
            item.AddItems(-count);
            AddCoins(item.Price);
        }

        public ItemModel GetItem(ItemTypes type) => _items.Find(x => x.Type == type);

        private void SetupItems(List<ItemData> data)
        {
            foreach (ItemData item in data)
            {
                _items.Add(_itemsSettings.GetItemModel(item));
            }
        }
    }
}
