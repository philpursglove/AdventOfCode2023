class Hand : IComparable<Hand>
{
    public string Cards { get; set; }

    public int Bid { get; set; }

    public HandType Type()
    {
        var groups = Cards.GroupBy(c => c, c => c, (card, count) => new {card, count = count.Count()});

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

    public string TypeString
    {
        get
        {
            return Type().ToString();
        }
        private set
        {

        }
    }

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