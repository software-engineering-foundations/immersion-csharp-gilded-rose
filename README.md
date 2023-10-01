# Gilded Rose

We're going to complete a short refactoring exercise. It is a modification of a reasonably well-known "kata" that is available on [GitHub](https://github.com/emilybache/GildedRose-Refactoring-Kata).

## Specification

You have received the following specification in an email:

> Hi and welcome to team Gilded Rose.
>
> As you know, we are a small friendly family-run inn. We also buy and sell an assortment of goods. Unfortunately, our goods are constantly degrading in quality as they approach their sell-by date. We have a system in place that updates our inventory for us. Your task is to add new features to our system so that we can begin selling new categories of items.
>
> First, an introduction to our system:
> - All items have a `SellIn` value which denotes the number of days we have to sell the item
> - All items have a `Quality` value which denotes how valuable the item is
> - At the end of each day our system decrements both values for each item
>
> Pretty simple, right? Well, this is where it gets interesting:
> - Once the sell-by date has passed, `Quality` degrades twice as fast
> - The `Quality` of an item is never negative
> - "Aged Brie" actually increases in `Quality` the older it gets (at the same rate as regular items degrade)
> - The `Quality` of an item is never more than 50
> - "Ming Vase", being an antique item, never has to be sold and does not decrease in `Quality`
> - "Concert tickets", like "Aged Brie", increase in `Quality` as their `SellIn` value approaches; `Quality` increases by 2 when there are 10 days or less before the concert and by 3 when there are 5 days or less, but drops to 0 after the concert
>
> We have recently signed suppliers of fresh and pickled fruit and vegetables. This will require two updates to our system:
> - Items that start with the word "Fresh" degrade in `Quality` twice as fast as regular items
> - Items that start with the word "Pickled" degrade in `Quality` half as fast as regular items (in practice, this means that before the sell-by date, the `Quality` value will only decrement when the updated `SellIn` value is even)
>
> Also, we've noticed recently that for some reason, green items don't seem to be as long-lived as other items. We'll require another update to our system in order to reflect this:
> - Items that contain the word "Green" degrade in quality twice as fast as equivalent items that don't contain the word "Green" (in practice, this means that before the sell-by date, pickled green items will have their `Quality` value decrement every day)
>
> Feel free to make any changes to the `RunEndOfDayActions` method and add any new code as long as everything still works correctly. However, do not alter the `Item` class or `Items` property as those are managed by another team.
> 
> Just for clarification, an item can never have its `Quality` increase above 50, with the exception of "Ming Vase", which is an antique, and as such its `Quality` is 80 and it never alters.
>
> Best Regards,
>
> Bob

## Main goals

The existing code is not very well-organised or readable. You should first take some time to understand the code, then refactor it to improve its structure and extensibility, without breaking any existing functionality.

Once you are satisfied with your refactoring, you should develop the requested features.

## Stretch goals

Another feature has been requested:

- Items that contain the word "Fancy" behave as they would otherwise except that they have an upper `Quality` limit of 60 rather than 50

Before implementing this feature, you should write some exhaustive tests to ensure that you will achieve the intended result. You can take inspiration from the existing tests. Be sure to cover all edge cases.

Once your tests are written, try implementing the feature. Perform any further refactorings you deem necessary.
