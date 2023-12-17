//List<Race> races = new List<Race>
//{
//    new Race {Duration = 7, Record = 9},
//    new Race {Duration = 15, Record = 40},
//    new Race {Duration = 30, Record = 200}
//};



List<Race> races = new List<Race>()
{
    new Race {Duration = 40, Record = 233},
    new Race {Duration = 82, Record = 1011},
    new Race {Duration = 84, Record = 1110},
    new Race {Duration = 92, Record = 1487}

};


foreach (Race race in races)
{
    race.FindWinningStrategies();
}

var strategies = races.Select(r => r.WinningStrategies).ToList();
var total = strategies.First();
for (int i = 1; i < strategies.Count(); i++)
{
    total *= strategies[i];
}



Console.WriteLine(total);
Console.ReadLine();


Race singleRace = new Race {Duration = 40828492, Record = 233101111101487};
singleRace.FindWinningStrategies();

Console.WriteLine(singleRace.WinningStrategies);
Console.ReadLine();

class Race
{
    public int Duration { get; set; }
    public long Record { get; set; }
    public int WinningStrategies { get; set; }

    public void FindWinningStrategies()
    {
        for (int i = 1; i < Duration - 1; i++)
        {
            var speed = i;
            var remainingDuration = Duration - i;
            long distance = speed * remainingDuration;

            if (distance > Record)
            {
                WinningStrategies++;
            }
        }
    }
}