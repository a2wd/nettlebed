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

        public void NeverLowerSellInBelow0()
        {
            var sellIn = 1;
            var quality = 1;
            var item = GetSampleItemAsList(sellIn, quality);

            var gildedRose = new GildedRose(item);
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();

            Assert.AreEqual(0, item[0].SellIn);
        }

        [Test]
        public void LowerQualityInMultiplesOfTwoWhenPastSellIn()
        {
            var sellIn = 0;
            var quality = 2;
            var item = GetSampleItemAsList(sellIn, quality);

            var gildedRose = new GildedRose(item);
            gildedRose.UpdateQuality();

            Assert.AreEqual(0, item[0].Quality);
        }

        [Test]
        public void IncreaseTheQualityOfBrieWithAge()
        {
            var sellIn = 1;
            var quality = 1;
            var name = "Aged Brie";
            var item = GetNamedSampleItemAsList(sellIn, quality, name);

            var gildedRose = new GildedRose(item);
            gildedRose.UpdateQuality();

            Assert.AreEqual(quality + 1, item[0].Quality);
        }

        [Test]
        public void NeverIncreaseQualityAbove50()
        {
            var sellIn = 1;
            var quality = 50;
            var name = "Aged Brie";
            var item = GetNamedSampleItemAsList(sellIn, quality, name);

            var gildedRose = new GildedRose(item);
            gildedRose.UpdateQuality();

            Assert.AreEqual(quality, item[0].Quality);
        }

        [Test]
        public void NeverChangeThePropertiesOfSulfuras()
        {
            var sellIn = 10;
            var quality = 80;
            var name = "Sulfuras, Hand of Ragnaros";
            var item = GetNamedSampleItemAsList(sellIn, quality, name);

            var gildedRose = new GildedRose(item);
            gildedRose.UpdateQuality();

            Assert.AreEqual(quality, item[0].Quality);
            Assert.AreEqual(sellIn, item[0].SellIn);
        }

        [Test]
        public void IncreaseBackstagePassQualityWhileSellInIsAbove10()
        {

            var sellIn = 20;
            var quality = 10;
            var name = "Backstage passes to a TAFKAL80ETC concert";
            var item = GetNamedSampleItemAsList(sellIn, quality, name);

            var gildedRose = new GildedRose(item);
            gildedRose.UpdateQuality();

            Assert.AreEqual(quality + 1, item[0].Quality);
            Assert.AreEqual(sellIn - 1, item[0].SellIn);
        }

        [Test]
        public void IncreaseBackstagePassQualityBy2WhileSellInIsBetween5And10()
        {

            var sellIn = 10;
            var quality = 10;
            var name = "Backstage passes to a TAFKAL80ETC concert";
            var item = GetNamedSampleItemAsList(sellIn, quality, name);

            var gildedRose = new GildedRose(item);
            gildedRose.UpdateQuality();

            Assert.AreEqual(quality + 2, item[0].Quality);
            Assert.AreEqual(sellIn - 1, item[0].SellIn);
        }

        [Test]
        public void IncreaseBackstagePassQualityBy3WhileSellInIsBetween0And5()
        {

            var sellIn = 5;
            var quality = 10;
            var name = "Backstage passes to a TAFKAL80ETC concert";
            var item = GetNamedSampleItemAsList(sellIn, quality, name);

            var gildedRose = new GildedRose(item);
            gildedRose.UpdateQuality();

            Assert.AreEqual(quality + 3, item[0].Quality);
            Assert.AreEqual(sellIn - 1, item[0].SellIn);
        }

        [Test]
        public void DecreaseBackstagePassQualityTo0WhenSellInIsBelow1()
        {
            var sellIn = 0;
            var quality = 10;
            var name = "Backstage passes to a TAFKAL80ETC concert";
            var item = GetNamedSampleItemAsList(sellIn, quality, name);

            var gildedRose = new GildedRose(item);
            gildedRose.UpdateQuality();

            Assert.AreEqual(0, item[0].Quality);
            Assert.AreEqual(sellIn - 1, item[0].SellIn);
        }

        #region Helpers
        private IList<Item> GetSampleItemAsList(int sellIn, int quality)
        {
            var emptyName = string.Empty;

            return GetNamedSampleItemAsList(sellIn, quality, emptyName);
        }

        private IList<Item> GetNamedSampleItemAsList(int sellIn, int quality, string name)
        {
            return new List<Item>
            {
                new Item
                {
                    Name = name,
                    SellIn = sellIn,
                    Quality = quality
                }
            };
        }
        #endregion
    }
}
