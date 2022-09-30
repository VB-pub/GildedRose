using GildedRose.Models;

namespace GildedRoseKata.Extensions
{
    public static class ItemExtensions
    {
        public static string ConvertToString(this Item item, char delimiter = '\0') =>
            $"{item.Name}{delimiter}{item.SellIn}{delimiter}{item.Quality}";

        public static void ConjuredItemUpdateQuality(this Item item)
        {
            item.DefaultItemUpdateQuality();
            item.DefaultItemUpdateQuality();

            AdjustItemSellIn(item, 1);
        }

        public static void AgedBrieUpdateQuality(this Item item)
        {
            if (item.Quality < 50)
                AdjustItemQuality(item, 1);

            AdjustItemSellIn(item, -1);

            if (item.SellIn < 0 && item.Quality < 50)
                AdjustItemQuality(item, 1);
        }

        public static void PassesToConcertUpdateQuality(this Item item)
        {
            if (item.Quality < 50)
            {
                AdjustItemQuality(item, 1);

                if (item.SellIn < 11 && item.Quality < 50)
                    AdjustItemQuality(item, 1);

                if (item.SellIn < 6 && item.Quality < 50)
                    AdjustItemQuality(item, 1);
            }

            AdjustItemSellIn(item, -1);

            if (item.SellIn < 0)
                AdjustItemQuality(item, -item.Quality);
        }

        public static void DefaultItemUpdateQuality(this Item item)
        {
            if (item.Quality > 0)
                AdjustItemQuality(item, -1);

            AdjustItemSellIn(item, -1);

            if (item.SellIn < 0 && item.Quality > 0)
                AdjustItemQuality(item, -1);
        }

        public static void AdjustItemSellIn(Item item, int by) => item.SellIn += by;

        public static void AdjustItemQuality(Item item, int by) => item.Quality += by;
    }
}
