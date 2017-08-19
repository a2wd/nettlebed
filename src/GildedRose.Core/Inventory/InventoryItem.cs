namespace GildedRose.Core.Inventory
{
    public abstract class InventoryItem
    {
        protected Item _item;
        
        public InventoryItem(Item item)
        {
            _item = item;
        }

        public Item GetItem()
        {
            return _item;
        }

        public void UpdateSellInAndQuality()
        {
            UpdateQuality();
            UpdateSellIn();
        }

        protected virtual void UpdateQuality()
        {
            if(ItemIsPastSellIn())
            {
                _item.Quality = _item.Quality - Constants.Rates.ExpiredQuality;
            }
            else
            {
                _item.Quality = _item.Quality - Constants.Rates.Quality;
            }

            AdjustItemQualityIfBelow0();
        }

        protected void AdjustItemQualityIfBelow0()
        {
            if(_item.Quality < 0)
            {
                _item.Quality = 0;
            }
        }

        protected bool ItemIsPastSellIn()
        {
            return _item.SellIn <= 0;
        }

        protected virtual void UpdateSellIn()
        {
            _item.SellIn--;
        }
    }
}