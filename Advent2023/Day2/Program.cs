List<string> games = File.ReadAllLines("input.txt").ToList();
//List<string> games = new List<string>
//{
//    "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
//    "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
//    "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
//    "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
//    "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
//};

List<Game> GamesList = new List<Game>(100);

foreach (string game in games)
{
    string gameCopy = game;
    gameCopy = gameCopy.Replace("Game ", String.Empty);

    int id = int.Parse(gameCopy.Substring(0, gameCopy.IndexOf(":")));

    gameCopy = gameCopy.Substring(gameCopy.IndexOf(":") + 2);
    string[] subsetStrings = gameCopy.Split(";");

    Game gameObject = new Game() { Id = id };

    foreach (string subsetString in subsetStrings)
    {
        string[] subsetSegment = subsetString.Trim().Split(",");
        Subset subset = new Subset();
        for (int i = 0; i < subsetSegment.Length; i++)
        {
            switch (subsetSegment[i].Trim().Split(" ").Last())
            {
                case "blue":
                    subset.Blue += int.Parse(subsetSegment[i].Trim().Split(" ").First());
                    break;
                case "red":
                    subset.Red += int.Parse(subsetSegment[i].Trim().Split(" ").First());
                    break;
                case "green":
                    subset.Green += int.Parse(subsetSegment[i].Trim().Split(" ").First());
                    break;
                default:
                    throw new Exception("Unknown colour");
            }
        }
        gameObject.Subsets.Add(subset);
    }
    GamesList.Add(gameObject);
}

Subset pool = new Subset() { Blue = 14, Green = 13, Red = 12 };

Console.WriteLine(GamesList.Count(g => g.Possible(pool)));
Console.WriteLine(GamesList.Where(g => g.Possible(pool)).Sum(g => g.Id));
Console.WriteLine(GamesList.Sum(g => g.Power()));
Console.ReadLine();

class Game
{
    public int Id { get; set; }
    public List<Subset> Subsets { get; set; } = new();

    public bool Possible(Subset pool)
    {

        if (Subsets.Select(s => s.Blue).Any(b => b > pool.Blue) |
            Subsets.Select(s => s.Green).Any(g => g > pool.Green) | Subsets.Select(s => s.Red).Any(r => r > pool.Red))
        {
            return false;
        }

        return true;
    }

    public int Power()
    {
        return Subsets.Max(s => s.Blue) * Subsets.Max(s => s.Green) * Subsets.Max(s => s.Red);
    }

}

class Subset
{
    public int Blue { get; set; }
    public int Red { get; set; }
    public int Green { get; set; }
}