using FluentAssertions;

namespace GildedRose.Test;

public class TestInn
{
    [Theory]
    [InlineData("Regular Brie", 0, 3, 1)]
    [InlineData("Mature Cheddar", 1, 3, 2)]
    [InlineData("Bowler Hat", 2, 50, 49)]
    [InlineData("Digestive Biscuits", -2, 50, 48)]
    [InlineData("Woolly Socks", 3, 5, 4)]
    [InlineData("Pencil Sharpener", -3, 5, 3)]
    [InlineData("Shiny Shoes", -5, 1, 0)]
    [InlineData("Apple Crumble", 6, 0, 0)]
    [InlineData("Olive Oil", -6, 0, 0)]
    public void RunEndOfDayActions_CalledOnRegularItem_CausesExpectedUpdates(
        string name,
        int sellInBefore,
        int qualityBefore,
        int qualityAfter
    )
    {
        // Arrange
        var item = new Item(name, sellInBefore, qualityBefore);
        var inn = new Inn(new List<Item> { item });

        // Act
        inn.RunEndOfDayActions();

        // Assert
        item.SellIn.Should().Be(sellInBefore - 1);
        item.Quality.Should().Be(qualityAfter);
    }

    [Theory]
    [InlineData(0, 3, 5)]
    [InlineData(1, 3, 4)]
    [InlineData(2, 0, 1)]
    [InlineData(-2, 0, 2)]
    [InlineData(3, 5, 6)]
    [InlineData(-3, 5, 7)]
    [InlineData(-5, 49, 50)]
    [InlineData(6, 50, 50)]
    [InlineData(-6, 50, 50)]
    public void RunEndOfDayActions_CalledOnAgedBrie_CausesExpectedUpdates(
        int sellInBefore,
        int qualityBefore,
        int qualityAfter
    )
    {
        // Arrange
        var agedBrie = new Item("Aged Brie", sellInBefore, qualityBefore);
        var inn = new Inn(new List<Item> { agedBrie });

        // Act
        inn.RunEndOfDayActions();

        // Assert
        agedBrie.SellIn.Should().Be(sellInBefore - 1);
        agedBrie.Quality.Should().Be(qualityAfter);
    }

    [Theory]
    [InlineData(-1, 0, 0)]
    [InlineData(0, 10, 0)]
    [InlineData(1, 3, 6)]
    [InlineData(2, 9, 12)]
    [InlineData(4, 8, 11)]
    [InlineData(5, 5, 8)]
    [InlineData(6, 31, 33)]
    [InlineData(7, 35, 37)]
    [InlineData(9, 40, 42)]
    [InlineData(10, 33, 35)]
    [InlineData(11, 21, 22)]
    [InlineData(5, 48, 50)]
    [InlineData(5, 49, 50)]
    [InlineData(10, 49, 50)]
    [InlineData(5, 50, 50)]
    [InlineData(10, 50, 50)]
    [InlineData(15, 50, 50)]
    public void RunEndOfDayActions_CalledOnConcertTickets_CausesExpectedUpdates(
        int sellInBefore,
        int qualityBefore,
        int qualityAfter
    )
    {
        // Arrange
        var concertTickets = new Item("Concert Tickets", sellInBefore, qualityBefore);
        var inn = new Inn(new List<Item> { concertTickets });

        // Act
        inn.RunEndOfDayActions();

        // Assert
        concertTickets.SellIn.Should().Be(sellInBefore - 1);
        concertTickets.Quality.Should().Be(qualityAfter);
    }

    [Theory]
    [InlineData(-3)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(int.MaxValue)]
    public void RunEndOfDayActions_CalledOnMingVase_CausesExpectedUpdates(int sellIn)
    {
        // Arrange
        var concertTickets = new Item("Ming Vase", sellIn, quality: 80);
        var inn = new Inn(new List<Item> { concertTickets });

        // Act
        inn.RunEndOfDayActions();

        // Assert
        concertTickets.SellIn.Should().Be(sellIn);
        concertTickets.Quality.Should().Be(80);
    }

    [Theory]
    [InlineData("Fresh Cucumber", 0, 5, 1)]
    [InlineData("Fresh Red Pepper", 1, 3, 1)]
    [InlineData("Fresh Golden Apple", 2, 50, 48)]
    [InlineData("Fresh Strawberries", -2, 50, 46)]
    [InlineData("Fresh Peach", 3, 5, 3)]
    [InlineData("Fresh Onion", -3, 5, 1)]
    [InlineData("Fresh Watermelon", -5, 3, 0)]
    [InlineData("Fresh Carrot", -6, 2, 0)]
    [InlineData("Fresh Mango", 7, 1, 0)]
    [InlineData("Fresh Tomato", -7, 1, 0)]
    [InlineData("Fresh Lime", 8, 0, 0)]
    [InlineData("Fresh Beans", -8, 0, 0)]
    public void RunEndOfDayActions_CalledOnFreshItem_CausesExpectedUpdates(
        string name,
        int sellInBefore,
        int qualityBefore,
        int qualityAfter
    )
    {
        // Arrange
        var freshItem = new Item(name, sellInBefore, qualityBefore);
        var inn = new Inn(new List<Item> { freshItem });

        // Act
        inn.RunEndOfDayActions();

        // Assert
        freshItem.SellIn.Should().Be(sellInBefore - 1);
        freshItem.Quality.Should().Be(qualityAfter);
    }

    [Theory]
    [InlineData("Pickled Cucumber", 0, 5, 4)]
    [InlineData("Pickled Yellow Pepper", 1, 3, 2)]
    [InlineData("Pickled Red Apple", 2, 50, 50)]
    [InlineData("Pickled Strawberries", -2, 50, 49)]
    [InlineData("Pickled Peach", 3, 5, 4)]
    [InlineData("Pickled Onion", -3, 5, 4)]
    [InlineData("Pickled Lime", 4, 3, 3)]
    [InlineData("Pickled Mango", -4, 3, 2)]
    [InlineData("Pickled Gherkin", 5, 0, 0)]
    [InlineData("Pickled Carrot", -5, 0, 0)]
    public void RunEndOfDayActions_CalledOnPickledItem_CausesExpectedUpdates(
        string name,
        int sellInBefore,
        int qualityBefore,
        int qualityAfter
    )
    {
        // Arrange
        var pickledItem = new Item(name, sellInBefore, qualityBefore);
        var inn = new Inn(new List<Item> { pickledItem });

        // Act
        inn.RunEndOfDayActions();

        // Assert
        pickledItem.SellIn.Should().Be(sellInBefore - 1);
        pickledItem.Quality.Should().Be(qualityAfter);
    }

    [Theory]
    [InlineData("Green Shoes", 0, 5, 1)]
    [InlineData("Green Dress", 1, 3, 1)]
    [InlineData("Green Trousers", 2, 50, 48)]
    [InlineData("Large Green Handbag", -2, 50, 46)]
    [InlineData("Small Green Earrings", 3, 5, 3)]
    [InlineData("Warm Green Coat", -3, 5, 1)]
    [InlineData("Green Lampshade", -5, 3, 0)]
    [InlineData("Green Jar", -6, 2, 0)]
    [InlineData("Green Bangle", 7, 1, 0)]
    [InlineData("Green Necklace", -7, 1, 0)]
    [InlineData("Green Kettle", 8, 0, 0)]
    [InlineData("Green Pot", -8, 0, 0)]
    public void RunEndOfDayActions_CalledOnGreenItem_CausesExpectedUpdates(
        string name,
        int sellInBefore,
        int qualityBefore,
        int qualityAfter
    )
    {
        // Arrange
        var greenItem = new Item(name, sellInBefore, qualityBefore);
        var inn = new Inn(new List<Item> { greenItem });

        // Act
        inn.RunEndOfDayActions();

        // Assert
        greenItem.SellIn.Should().Be(sellInBefore - 1);
        greenItem.Quality.Should().Be(qualityAfter);
    }

    [Theory]
    [InlineData("Fresh Green Mango", 0, 9, 1)]
    [InlineData("Fresh Green Pepper", 1, 5, 1)]
    [InlineData("Fresh Green Apple", 2, 50, 46)]
    [InlineData("Fresh Green Papaya", -2, 50, 42)]
    [InlineData("Fresh Green Pear", 3, 15, 11)]
    [InlineData("Fresh Green Tomato", -3, 15, 7)]
    [InlineData("Fresh Green Plum", -5, 7, 0)]
    [InlineData("Fresh Green Beans", -6, 6, 0)]
    [InlineData("Fresh Green Olives", -7, 5, 0)]
    [InlineData("Fresh Green Banana", -8, 4, 0)]
    [InlineData("Fresh Green Cabbage", 9, 3, 0)]
    [InlineData("Fresh Green Melon", -9, 3, 0)]
    [InlineData("Fresh Green Fig", 10, 2, 0)]
    [InlineData("Fresh Green Orange", -10, 2, 0)]
    [InlineData("Fresh Green Watermelon", 11, 1, 0)]
    [InlineData("Fresh Green Gooseberry", -11, 1, 0)]
    [InlineData("Fresh Green Tamarind", 12, 0, 0)]
    [InlineData("Fresh Green Avocado", -12, 0, 0)]
    public void RunEndOfDayActions_CalledOnFreshGreenItem_CausesExpectedUpdates(
        string name,
        int sellInBefore,
        int qualityBefore,
        int qualityAfter
    )
    {
        // Arrange
        var freshGreenItem = new Item(name, sellInBefore, qualityBefore);
        var inn = new Inn(new List<Item> { freshGreenItem });

        // Act
        inn.RunEndOfDayActions();

        // Assert
        freshGreenItem.SellIn.Should().Be(sellInBefore - 1);
        freshGreenItem.Quality.Should().Be(qualityAfter);
    }

    [Theory]
    [InlineData("Pickled Green Mango", 0, 5, 3)]
    [InlineData("Pickled Green Pepper", 1, 3, 2)]
    [InlineData("Pickled Green Apple", 2, 50, 49)]
    [InlineData("Pickled Green Papaya", -2, 50, 48)]
    [InlineData("Pickled Green Pear", 3, 5, 4)]
    [InlineData("Pickled Green Tomato", -3, 5, 3)]
    [InlineData("Pickled Green Plum", -5, 1, 0)]
    [InlineData("Pickled Green Grapes", 6, 0, 0)]
    [InlineData("Pickled Green Olives", -6, 0, 0)]
    public void RunEndOfDayActions_CalledOnPickledGreenItem_CausesExpectedUpdates(
        string name,
        int sellInBefore,
        int qualityBefore,
        int qualityAfter
    )
    {
        // Arrange
        var pickledGreenItem = new Item(name, sellInBefore, qualityBefore);
        var inn = new Inn(new List<Item> { pickledGreenItem });

        // Act
        inn.RunEndOfDayActions();

        // Assert
        pickledGreenItem.SellIn.Should().Be(sellInBefore - 1);
        pickledGreenItem.Quality.Should().Be(qualityAfter);
    }
}
