using System;

namespace GildedRose.Core.Inventory
{
    public class RegularItem : IInventoryItem
    {
        private Item _item;
        
        public RegularItem(Item item)
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

        private void UpdateQuality()
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

        private void AdjustItemQualityIfBelow0()
        {
            if(_item.Quality < 0)
            {
                _item.Quality = 0;
            }
        }

        private bool ItemIsPastSellIn()
        {
            return _item.SellIn <= 0;
        }

        private void UpdateSellIn()
        {
            _item.SellIn--;
        }
    }
}
