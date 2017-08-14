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
        public void BeAbleToAddASimpleItem()
        {
			IList<Item> Items = new List<Item> { new Item{Name = "foo", SellIn = 0, Quality = 0} };
			GildedRose app = new GildedRose(Items);
			app.UpdateQuality();
			Assert.AreEqual("foo", Items[0].Name);
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
