using NUnit.Framework;

[TestFixture]
class HandTests
{
    [TestCase("AAAAA", HandType.FiveOfAKind)]
    [TestCase("23456", HandType.HighCard)]
    [TestCase("AAAAK", HandType.FourOfAKind)]
    [TestCase("AAAKK", HandType.FullHouse)]
    [TestCase("AAAKQ", HandType.ThreeOfAKind)]
    [TestCase("AAKKQ", HandType.TwoPair)]
    [TestCase("AAKQJ", HandType.OnePair)]
    public void TypeTest(string cards, HandType expected)
    {
        var hand = new Hand() { Cards = cards };

        Assert.That(hand.Type(), Is.EqualTo(expected));
    }
}

[TestFixture]
class MutatingHandTests
{
    [TestCase("AAAAA", HandType.FiveOfAKind)]
    [TestCase("AAAAJ", HandType.FiveOfAKind)]
    [TestCase("AAAJJ", HandType.FiveOfAKind)]
    [TestCase("AAAAK", HandType.FourOfAKind)]
    [TestCase("AAJJK", HandType.FourOfAKind)]
    [TestCase("AAAKK", HandType.FullHouse)]
    [TestCase("AAAKQ", HandType.ThreeOfAKind)]
    [TestCase("AAAJK", HandType.FourOfAKind)]
    [TestCase("AAKKQ", HandType.TwoPair)]
    [TestCase("AAKQJ", HandType.ThreeOfAKind)]
    [TestCase("AAKQ2", HandType.OnePair)]
    [TestCase("23456", HandType.HighCard)]
    [TestCase("2345J", HandType.OnePair)]
    [TestCase("AAKKJ", HandType.ThreeOfAKind)]
    public void TypeTest(string cards, HandType expected)
    {
        var hand = new MutatingHand() { Cards = cards };

        Assert.That(hand.Type(), Is.EqualTo(expected));
    }
}