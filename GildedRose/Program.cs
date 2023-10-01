using GildedRose;

var inn = new Inn(
    new List<Item>
    {
        new("Aged Brie", sellIn: 10, quality: 25),
        new("Concert Tickets", sellIn: 12, quality: 8),
        new("Ming Vase", sellIn: int.MaxValue, quality: 80),
        new("Pickled Cucumber", sellIn: 4, quality: 15),
        new("Fresh Cucumber", sellIn: 10, quality: 16),
    }
);
inn.RunEndOfDayActions();
Console.Write(inn);
