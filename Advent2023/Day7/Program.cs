List<string> input = File.ReadAllLines("input.txt").ToList();
//List<string> input = new List<string>
//{
//    "32T3K 765",
//    "T55J5 684",
//    "KK677 28",
//    "KTJJT 220",
//    "QQQJA 483",
//};

List<Hand> hands = new List<Hand>();

foreach (string s in input)
{
    Hand hand = new Hand
    {
        Cards = s.Split(" ").First(),
        Bid = int.Parse(s.Split(" ").Last())
    };
    hands.Add(hand);
}

List<Hand> results = hands.OrderByDescending(h => h).ToList();

int rank = 1;
int winnings = 0;
foreach (Hand hand in results)
{
    winnings += rank * hand.Bid;
    rank++;
}

Console.WriteLine(winnings);
Console.ReadLine();