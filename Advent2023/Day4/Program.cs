List<string> input = File.ReadAllLines("input.txt").ToList();
//List<string> input = new List<string>
//{
//    "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
//    "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
//    "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
//    "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
//    "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
//    "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
//};

List<Card> cards = new List<Card>();

foreach (string cardLine in input)
{
    Card card = new Card();
    string[] cardSegments = cardLine.Split(' ');
    cardSegments = cardSegments.Where(s => s != string.Empty).ToArray();
    card.Id = int.Parse(cardSegments[1].Replace(":", string.Empty));
    foreach (string winningNumber in cardSegments.Skip(2).Take(10))
    {
        if (winningNumber != string.Empty)
        {
            card.WinningNumbers.Add(int.Parse(winningNumber));
        }
    }

    foreach (string gameNumber in cardSegments.Skip(13))
    {
        if (gameNumber != string.Empty)
        {
            card.GameNumbers.Add(int.Parse(gameNumber));

        }
    }
    cards.Add(card);
}

Console.WriteLine(cards.Sum(c => c.Value()));
//Console.ReadLine();

input = File.ReadAllLines("input.txt").ToList();
//input = new List<string>
//{
//    "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
//    "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
//    "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
//    "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
//    "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
//    "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
//};

cards = new List<Card>();

foreach (string cardLine in input)
{
    Card card = new Card();
    string[] cardSegments = cardLine.Split(' ');
    cardSegments = cardSegments.Where(s => s != string.Empty).ToArray();
    card.Id = int.Parse(cardSegments[1].Replace(":", string.Empty));
    foreach (string winningNumber in cardSegments.Skip(2).Take(10))
    {
        if (winningNumber != string.Empty)
        {
            card.WinningNumbers.Add(int.Parse(winningNumber));
        }
    }

    foreach (string gameNumber in cardSegments.Skip(13))
    {
        if (gameNumber != string.Empty)
        {
            card.GameNumbers.Add(int.Parse(gameNumber));

        }
    }
    cards.Add(card);
}

for (int i = 1; i < 193; i++)
{
    List<Card> currentCards = cards.Where(c => c.Id == i).ToList();

    int matches = currentCards.FirstOrDefault().MatchingNumbers();

    if (matches > 0)
    {
        foreach (Card currentCard in currentCards)
        {
            cards.AddRange(cards.Skip(i).Take(matches));
        }
    }
}

Console.WriteLine(cards.Count);
Console.ReadLine();

public class Card
{
    public int Id { get; set; }
    public List<int> WinningNumbers { get; set; } = new();
    public List<int> GameNumbers { get; set; } = new();

    public int Value()
    {
        int winners = GameNumbers.Count(n => WinningNumbers.Contains(n));

        switch (winners)
        {
            case 1:
                return 1;
            case 2:
                return 2;
            case 3:
                return 4;
            case 4:
                return 8;
            case 5:
                return 16;
            case 6:
                return 32;
            case 7:
                return 64;
            case 8:
                return 128;
            case 9:
                return 256;
            case 10:
                return 512;
            default:
                return 0;
        }
    }

    public int MatchingNumbers()
    {
        return GameNumbers.Count(n => WinningNumbers.Contains(n));
    }
}