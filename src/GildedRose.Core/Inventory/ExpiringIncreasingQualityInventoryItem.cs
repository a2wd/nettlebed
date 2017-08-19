namespace GildedRose.Core.Inventory
{
    public class ExpiringIncreasingQualityInventoryItem : InventoryItem
    {
        private const int BackstagePassInitialQualityRate = 2;
        private const int BackstagePassSecondaryQualityRate = 3;

        private const int BackstagePassInitialSellInPeriod = 10;
        private const int BackstagePassSecondarySellInPeriod = 5;
        private const int BackstagePassExpiredSellInPeriod = 0;

        public ExpiringIncreasingQualityInventoryItem(Item item) : base(item)
        {
        }

        protected override void UpdateQuality()
        {
            if (_item.SellIn <= BackstagePassExpiredSellInPeriod)
            {
                _item.Quality = 0;
            }
            else if(_item.SellIn <= BackstagePassSecondarySellInPeriod)
            {
                _item.Quality = _item.Quality + BackstagePassSecondaryQualityRate;
            }
            else if(_item.SellIn <= BackstagePassInitialSellInPeriod)
            {
                _item.Quality = _item.Quality + BackstagePassInitialQualityRate;
            }
            else
            {
                _item.Quality = _item.Quality + Constants.Rates.Quality;
            }

            AdjustItemQualityIfBelow0();
        }
    }
}
