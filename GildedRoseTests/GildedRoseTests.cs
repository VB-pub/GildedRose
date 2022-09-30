using GildedRoseKata.Extensions;
using ApprovalTests;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
using GildedRose.Models;

namespace GildedRoseTests
{
    [TestClass]
    public partial class GildedRoseTests
    {
        [UseReporter(typeof(DiffReporter))]
        [TestMethod]
        public void UpdateQualityTest()
        {
            CombinationApprovals.VerifyAllCombinations(StartUpdateQuality,
                _names, _sellIns, _qualities);
        }

        [UseReporter(typeof(DiffReporter))]
        [TestMethod]
        public void UpdateConjuredQualityTest()
        {
            CombinationApprovals.VerifyAllCombinations(StartUpdateQuality,
                _namesConjured, _sellIns, _qualities);
        }

        private string StartUpdateQuality(string name, int sellIn, int quality)
        {
            Item[] items = new Item[] {
                
                new Item
                {
                    Name = name,
                    SellIn = sellIn,
                    Quality = quality
                }
            };

            GildedRoseKata.GildedRose app = new(items);
            app.UpdateQuality();
            return app.Items[0].ConvertToString(delimiter);
        }
    }
}