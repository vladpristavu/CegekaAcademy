using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private const string AgedBrie = "Aged Brie";
        private const string Backstage = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string Conjured = "Conjured, Hearthstone";

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            //aplicati Factory Pattern on init
            IList<Item> FactoryItems = new List<Item>();
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.ChangeDay();
                item.updateQuality();
            }
        }
    }
}
