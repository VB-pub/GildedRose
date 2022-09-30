using GildedRose.Models;
using GildedRoseKata.Extensions;
using System.Collections.Generic;
using System.ComponentModel;

namespace GildedRoseKata
{
    public partial class GildedRose
    {
        public IList<Item> Items;
        public GildedRose(IList<Item> Items) =>
            this.Items = Items;

        public void UpdateQuality()
        {
            foreach (var item in Items)
                UpdateQuality(item);
        }

        public static void UpdateQuality(Item item)
        { 
            switch (item.Name)
            {
                case string a when a.Contains(CONJURED):
                    item.ConjuredItemUpdateQuality();
                    break;
                case AGED_BRIE:
                    item.AgedBrieUpdateQuality();
                    break;
                case PASSES_TO_CONCERT:
                    item.PassesToConcertUpdateQuality();
                    break;
                case HAND_OF_RAGNAROS:
                    break;
                default:
                    item.DefaultItemUpdateQuality();
                    break;
            }
        }
    }
}
