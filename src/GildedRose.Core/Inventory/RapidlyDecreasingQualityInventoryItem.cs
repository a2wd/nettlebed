namespace GildedRose.Core.Inventory
{
    public class RapidlyDecreasingQualityInventoryItem : InventoryItem
    {
        private const int ExpiredQualityRate = Constants.Rates.ExpiredQuality * 2;
        private const int QualityRate = Constants.Rates.Quality * 2;

        public RapidlyDecreasingQualityInventoryItem(Item item) : base(item)
        {
        }

        protected override void UpdateQuality()
        {
            if(ItemIsPastSellIn())
            {
                _item.Quality = _item.Quality - ExpiredQualityRate;
            }
            else
            {
                _item.Quality = _item.Quality - QualityRate;
            }

            AdjustItemQualityIfBelow0();
        }
    }
}
