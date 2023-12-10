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
        var hand = new Hand() {Cards = cards};

        Assert.That(hand.Type(), Is.EqualTo(expected));
    }
}