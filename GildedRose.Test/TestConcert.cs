using System.Collections.Generic;
using NUnit.Framework;
using csharp;

namespace GildedRose.Test
{
    [TestFixture]
    public class TestConcert
    {
        [Test]
        public void concert_quality_with_sellIn_over_10()
        {
            /*
             * This test is made on the quality parameter for a "Backstage passes to a TAFKAL80ETC concert" with sellIn over 10
             * the quality should increase by 1
             */
            
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 10 } };
            csharp.GildedRose app = new csharp.GildedRose(Items);
            
            // Act
            app.UpdateQuality();
            
            // Assert
            // The quality should be equal to 10+1 = 11
            Assert.AreEqual(11 , Items[0].Quality);
        }
        
        [Test]
        public void concert_quality_with_sellIn_between_5_and_10()
        {
            /*
             * This test is made on the quality parameter for a "Backstage passes to a TAFKAL80ETC concert" with sellIn between 5 and 10
             * the quality should increase by 2
             */
            
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 10 } };
            csharp.GildedRose app = new csharp.GildedRose(Items);
            
            // Act
            app.UpdateQuality();
            
            // Assert
            // The quality should be equal to 10+2 = 12
            Assert.AreEqual(12 , Items[0].Quality);
        }
        
        [Test]
        public void concert_quality_with_sellIn_between_0_and_5()
        {
            /*
             * This test is made on the quality parameter for a "Backstage passes to a TAFKAL80ETC concert" with sellIn between 0 and 5
             * the quality should increase by 3
             */
            
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 10 } };
            csharp.GildedRose app = new csharp.GildedRose(Items);
            
            // Act
            app.UpdateQuality();
            
            // Assert
            // The quality should be equal to 10+3 = 13
            Assert.AreEqual(13 , Items[0].Quality);
        }
        
        [Test]
        public void concert_quality_with_sellIn_at_0()
        {
            /*
             * This test is made on the quality parameter for a "Backstage passes to a TAFKAL80ETC concert" with sellIn at 0
             * the quality should equal to 0
             */
            
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 } };
            csharp.GildedRose app = new csharp.GildedRose(Items);
            
            // Act
            app.UpdateQuality();
            
            // Assert
            // The quality should be equal to 0
            Assert.AreEqual(0 , Items[0].Quality);
        }
        
        [Test]
        public void concert_quality_with_quality_at_50()
        {
            /*
             * This test is made on the quality parameter for a "Backstage passes to a TAFKAL80ETC concert" with quality at 49 and sellIn at 3
             * the quality should increased by 3, however, the quality can't be over 50, so the quality should be equal at 50
             */
            
            // Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 49 } };
            csharp.GildedRose app = new csharp.GildedRose(Items);
            
            // Act
            app.UpdateQuality();
            
            // Assert
            // The quality should be equal to 50
            Assert.AreEqual(50 , Items[0].Quality);
        }
    }
}