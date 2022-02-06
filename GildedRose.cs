﻿using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private const string CONCERT = "Backstage passes to a TAFKAL80ETC concert";
        private const string BRIE = "Aged Brie";
        private const string SULFURAS = "Sulfuras, Hand of Ragnaros";

        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }

        public void new_updateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {

                // Update according the item
                
                // If the item is an "Aged Brie"
                if (Items[i].Name == BRIE)
                {
                    Brie brie = new Brie {Name = Items[i].Name, SellIn = Items[i].SellIn, Quality = Items[i].Quality};
                    brie.updateBrie();
                    Items[i].Quality = brie.Quality;
                    Items[i].SellIn = brie.SellIn;

                }
                // If the item is an "Backstage passes to a TAFKAL80ETC concert"
                if (Items[i].Name == CONCERT)
                {
                    Concert concert = new Concert {Name = Items[i].Name, SellIn = Items[i].SellIn, Quality = Items[i].Quality};
                    concert.updateConcert();
                    Items[i].Quality = concert.Quality;
                    Items[i].SellIn = concert.SellIn;
                }
                
                // if the item is considered an normal item, decreased by 1 or by 2
                if (Items[i].Name != BRIE && Items[i].Name != CONCERT && Items[i].Name != SULFURAS)
                {
                    Normal normal = new Normal {Name = Items[i].Name, SellIn = Items[i].SellIn, Quality = Items[i].Quality};
                    normal.updateNormal();
                    Items[i].Quality = normal.Quality;
                    Items[i].SellIn = normal.SellIn;
                }
                
                // if the item is a "sulfuras", we do nothing, the SellIn and the quality stay the same over time
            }
        }
    }


    public class Brie : Item
    {
        public void updateBrie()
        {
            if (Quality < 50)
            {
                Quality++;
            }

            SellIn--;

            if (SellIn < 0)
            {
                if (Quality < 50)
                {
                    Quality++;
                }
            }
        }
    }

    public class Concert : Item
    {
        public void updateConcert()
        {
            if (Quality < 50)
            {
                Quality++;

                if (Quality < 50)
                {
                    if (SellIn < 11)
                    {
                        Quality++;
                    }

                    if (SellIn < 6)
                    {
                        Quality++;
                    }
                }
            }

            SellIn--;

            if (SellIn < 0)
            {
                Quality = Quality - Quality;
            }
        }
    }

    public class Normal : Item
    {
        public void updateNormal()
        {
            if (Quality > 0)
            {
                Quality = Quality - 1;
            }
            SellIn--;
            if (SellIn < 0)
            {
                if (Quality > 0)
                {
                    Quality = Quality - 1;
                }
            }
        }
    }
}
