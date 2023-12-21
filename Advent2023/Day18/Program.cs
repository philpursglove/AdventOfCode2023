List<string> input = File.ReadAllLines("input.txt").ToList();
//List<string> input = new List<string>
//{
//    "R 6 (#70c710)",
//    "D 5 (#0dc571)",
//    "L 2 (#5713f0)",
//    "D 2 (#d2c081)",
//    "R 2 (#59c680)",
//    "D 2 (#411b91)",
//    "L 5 (#8ceee2)",
//    "U 2 (#caa173)",
//    "L 1 (#1b58a2)",
//    "U 2 (#caa171)",
//    "R 2 (#7807d2)",
//    "U 3 (#a77fa3)",
//    "L 2 (#015232)",
//    "U 2 (#7a21e3)",
//};

List<Instruction> instructions = new List<Instruction>();

foreach (string s in input)
{
    string[] inputSegments = s.Split(" ");
    instructions.Add(new Instruction
    {
        Direction = inputSegments[0] switch
        {
            "U" => Direction.Up,
            "D" => Direction.Down,
            "L" => Direction.Left,
            "R" => Direction.Right,
            _ => throw new Exception("Invalid direction")
        },
        Distance = int.Parse(inputSegments[1]),
        Colour = inputSegments[2].Replace("(", String.Empty).Replace(")", String.Empty)
    });
}

int x = 0;
int y = 0;
int maxX = 0;
int maxY = 0;

foreach (Instruction instruction in instructions)
{
    for (int i = 0; i < instruction.Distance; i++)
    {
        switch (instruction.Direction)
        {
            case Direction.Up:
                y -= 1;
                break;
            case Direction.Down:
                y += 1;
                break;
            case Direction.Left:
                x -= 1;
                break;
            case Direction.Right:
                x += 1;
                break;
        }
    }

    if (x > maxX)
    {
        maxX = x;
    }

    if (y > maxY)
    {
        maxY = y;
    }
}

maxX++;
maxY++;
Hole[,] grid = new Hole[maxX, maxY];

x = 0;
y = 0;
foreach (Instruction instruction in instructions)
{
    for (int i = 0; i < instruction.Distance; i++)
    {
        if (grid[x, y] == null)
        {
            grid[x, y] = new Hole();
        }
        grid[x, y].Dug = true;
        grid[x, y].Colour = instruction.Colour;
        switch (instruction.Direction)
        {
            case Direction.Up:
                y -= 1;
                break;
            case Direction.Down:
                y += 1;
                break;
            case Direction.Left:
                x -= 1;
                break;
            case Direction.Right:
                x += 1;
                break;
        }
    }
}

int digCount = 0;
for (int i = 0; i < maxY; i++)
{
    bool inTrench = false;
    for (int j = 0; j < maxX; j++)
    {
        if (grid[j, i] == null)
        {
            grid[j, i] = new Hole();
            if (inTrench)
            {
                grid[j, i].Dug = true;
            }
        }
        else
        {
            inTrench = grid[j, i].Dug;
        }

        if (inTrench)
        {
            digCount++;
        }

    }
}

Console.WriteLine(digCount - 2);

class Hole
{
    public bool Dug { get; set; }
    public string Colour { get; set; }
}


class Instruction
{
    public Direction Direction { get; set; }
    public int Distance { get; set; }
    public string Colour { get; set; }
}

enum Direction
{
    Up,
    Down,
    Left,
    Right
}