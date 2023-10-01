using System.Text;

namespace GildedRose;

public class Inn
{
    public List<Item> Items { get; }

    public Inn(List<Item> items)
    {
        Items = items;
    }

    public void RunEndOfDayActions()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            if (Items[i].Name != "Aged Brie" && Items[i].Name != "Concert Tickets")
            {
                if (Items[i].Quality > 0)
                {
                    if (Items[i].Name != "Ming Vase")
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

                    if (Items[i].Name == "Concert Tickets")
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

            if (Items[i].Name != "Ming Vase")
            {
                Items[i].SellIn = Items[i].SellIn - 1;
            }

            if (Items[i].SellIn < 0)
            {
                if (Items[i].Name != "Aged Brie")
                {
                    if (Items[i].Name != "Concert Tickets")
                    {
                        if (Items[i].Quality > 0)
                        {
                            if (Items[i].Name != "Ming Vase")
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

    public override string ToString()
    {
        var stringBuilder = new StringBuilder("Items:\n");
        foreach (var item in Items)
        {
            stringBuilder.Append(item.ToString() + '\n');
        }
        return stringBuilder.ToString();
    }
}
