namespace Avramov.Production
{
    public class ItemsCountPresenter
    {
        private ItemModel _itemModel;
        private ItemView _itemView;

        public ItemsCountPresenter(ItemModel itemModel, ItemView itemView)
        {
            _itemModel = itemModel;
            _itemView = itemView;
        }

        public void Activate()
        {
            _itemModel.ItemChangedEvent += ShowCount;
            ShowCount();
            _itemView.SetActive(true);
        }

        public void Deactivate()
        {
            _itemModel.ItemChangedEvent -= ShowCount;
            _itemView.SetActive(false);
        }

        private void ShowCount()
        {
            _itemView.CountText.text = _itemModel.Count.ToString();
        }
    }
}
