namespace GildedRose.Tests
{
    using GildedRose.Core;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class GildedRoseShould
    {
        [Test]
        public void LowerSellInAndQualityForAnItem()
        {
            var sellIn = 1;
            var quality = 1;
            var item = GetSampleItemAsList(sellIn, quality);

            var gildedRose = new GildedRose(item);
            gildedRose.UpdateQuality();

            Assert.AreEqual(sellIn - 1, item[0].SellIn);
            Assert.AreEqual(quality - 1, item[0].Quality);
        }

        [Test]
        public void NeverLowerQualityBelow0()
        {
            var sellIn = 1;
            var quality = 1;
            var item = GetSampleItemAsList(sellIn, quality);

            var gildedRose = new GildedRose(item);
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();

            Assert.AreEqual(0, item[0].Quality);
        }

        private IList<Item> GetSampleItemAsList(int sellIn, int quality)
        {
            return new List<Item>
            {
                new Item
                {
                    Name = string.Empty,
                    SellIn = sellIn,
                    Quality = quality
                }
            };
        }
    }
}
