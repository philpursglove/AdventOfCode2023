class Hand : IComparable<Hand>
{
    public string Cards { get; set; }

    public int Bid { get; set; }

    public HandType Type()
    {
        var groups = Cards.GroupBy(c => c, c => c, (card, count) => new { card, count = count.Count() });

        switch (groups.Count())
        {
            case 1:
                return HandType.FiveOfAKind;
            case 2:
                if (groups.OrderByDescending(g => g.count).First().count == 4)
                {
                    return HandType.FourOfAKind;
                }
                else
                {
                    return HandType.FullHouse;
                }
            case 3:
                if (groups.OrderByDescending(g => g.count).First().count == 3)
                {
                    return HandType.ThreeOfAKind;
                }
                else
                {
                    return HandType.TwoPair;
                }
            case 4:
                return HandType.OnePair;
            default:
                return HandType.HighCard;
        }
    }

    public string TypeString => Type().ToString();

    public int CompareTo(Hand? other)
    {
        int result = 0;

        Dictionary<char, int> cardValues = new Dictionary<char, int>
        {
            { 'A', 14 },
            { 'K', 13 },
            { 'Q', 12 },
            { 'J', 11 },
            { 'T', 10 },
            { '9', 9 },
            { '8', 8 },
            { '7', 7 },
            { '6', 6 },
            { '5', 5 },
            { '4', 4 },
            { '3', 3 },
            { '2', 2 }
        };

        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        if (Type() == other.Type())
        {
            for (int i = 0; i < 5; i++)
            {
                if (Cards[i] != other.Cards[i])
                {
                    if (cardValues[Cards[i]] > cardValues[other.Cards[i]])
                    {
                        result = -1;
                        break;
                    }

                    result = 1;
                    break;
                }
            }
        }
        else
        {
            if (Type() > other.Type())
            {
                result = -1;
            }
            else
            {
                result = 1;
            }
        }

        return result;
    }
}

class MutatingHand : Hand, IComparable<MutatingHand>
{
    public HandType Type()
    {
        var groups = Cards.GroupBy(c => c, c => c, (Card, Count) => new { Card, Count = Count.Count() })
            .OrderByDescending(g => g.Count).ToList();

        switch (groups.Count())
        {
            case 1:
                return HandType.FiveOfAKind;
            case 2:
                if (groups.Any(g => g.Card == 'J'))
                {
                    return HandType.FiveOfAKind;
                }

                if (groups.First().Count == 4)
                {
                    return HandType.FourOfAKind;
                }

                return HandType.FullHouse;
            case 3:
                if (groups.First().Count == 3)
                {
                    if (groups.Any(g => g.Card == 'J' & g.Count == 1))
                    {
                        return HandType.FourOfAKind;
                    }
                    return HandType.ThreeOfAKind;
                }

                if (groups.Any(g => g.Card == 'J'))
                {

                    switch (groups.First(g => g.Card == 'J').Count)
                    {
                        case 2:
                            return HandType.FourOfAKind;
                        case 1:
                            return HandType.ThreeOfAKind;
                    }
                }
                return HandType.TwoPair;
            case 4:
                if (groups.Any(g => g.Card == 'J' && g.Count == 1))
                {
                    return HandType.ThreeOfAKind;
                }
                return HandType.OnePair;
            default:
                if (groups.Any(g => g.Card == 'J'))
                {
                    return HandType.OnePair;
                }
                return HandType.HighCard;
        }
    }

    public int CompareTo(MutatingHand? other)
    {
        int result = 0;

        Dictionary<char, int> cardValues = new Dictionary<char, int>
        {
            { 'A', 13 },
            { 'K', 12 },
            { 'Q', 11 },
            { 'T', 10 },
            { '9', 9 },
            { '8', 8 },
            { '7', 7 },
            { '6', 6 },
            { '5', 5 },
            { '4', 4 },
            { '3', 3 },
            { '2', 2 },
            { 'J', 1 },
        };

        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        if (Type() == other.Type())
        {
            for (int i = 0; i < 5; i++)
            {
                if (Cards[i] != other.Cards[i])
                {
                    if (cardValues[Cards[i]] > cardValues[other.Cards[i]])
                    {
                        result = -1;
                        break;
                    }

                    result = 1;
                    break;
                }
            }
        }
        else
        {
            if (Type() > other.Type())
            {
                result = -1;
            }
            else
            {
                result = 1;
            }
        }

        return result;
    }
}