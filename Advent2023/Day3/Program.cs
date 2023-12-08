List<string> input = File.ReadAllLines("input.txt").ToList();
//List<string> input = new List<string>
//{
//    "467..114..",
//    "...*......",
//    "..35..633.",
//    "......#...",
//    "617*......",
//    ".....+.58.",
//    "..592.....",
//    "......755.",
//    "...$.*....",
//    ".664.598.."
//};

List<Char> symbols = new List<char>();

foreach (string line in input)
{
    foreach (char c in line)
    {
        if (Char.IsDigit(c) | c == '.')
        {
        }
        else
        {
            if (!symbols.Contains(c))
            {
                symbols.Add(c);
            }
        }
    }
}

List<List<(int start, int end)>> numbersBoundsLists = new List<List<(int start, int end)>>();

foreach (string line in input)
{
    List<(int start, int end)> numberBounds = new List<(int start, int end)>();
    bool inANumber = false;

    int start = 0;
    int end;
    for (int i = 0; i < line.Length; i++)
    {
        if (char.IsDigit(line[i]))
        {
            if (!inANumber)
            {
                inANumber = true;
                start = i;
            }
        }
        else
        {
            if (inANumber)
            {
                end = i - 1;
                numberBounds.Add(new(start, end));
                inANumber = false;
            }
        }
    }

    if (inANumber)
    {
        numberBounds.Add(new (start, line.Length - 1));
    }
    numbersBoundsLists.Add(numberBounds);
}



List<int> partNumbers = new List<int>();

for (int i = 0; i < numbersBoundsLists.Count; i++)
{
    List<(int start, int end)> bounds = numbersBoundsLists[i];

    foreach (var bound in bounds)
    {
        int lineAboveStart = 0;
        int lineAboveEnd = input[i].Length;
        if (bound.start > 0)
        {
            lineAboveStart = bound.start - 1;
        }
        else
        {
            lineAboveStart = 0;
        }

        if (bound.end + 1 < input[i].Length)
        {
            lineAboveEnd = bound.end + 1;
        }
        else
        {
            lineAboveEnd = input[i].Length;
        }

        int lineBelowStart = 0;
        int lineBelowEnd = input[i].Length;
        if (bound.start > 0)
        {
            lineBelowStart = bound.start - 1;
        }
        else
        {
            lineBelowStart = 0;
        }

        if (bound.end + 1 < input[i].Length)
        {
            lineBelowEnd = bound.end + 1;
        }
        else
        {
            lineBelowEnd = input[i].Length;
        }

        int leftSide;
        int rightSide;
        if (bound.start > 0)
        {
            leftSide = bound.start - 1;
        }
        else
        {
            leftSide = 0;
        }

        if (bound.end < input[i].Length)
        {
            rightSide = bound.end + 1;
        }
        else
        {
            rightSide = input[i].Length;
        }

        List<char> boundaryChars = new List<char>();
        if (i > 0)
        {
            for (int j = lineAboveStart; j <= lineAboveEnd; j++)
            {
                if (j < input[i - 1].Length)
                {
                    boundaryChars.AddRange(input[i - 1].Substring(j, 1));
                }
            }
        }

        if (i < (input.Count - 1))
        {
            for (int j = lineBelowStart; j <= lineBelowEnd; j++)
            {
                if (j < input[i + 1].Length)
                {
                    boundaryChars.AddRange(input[i + 1].Substring(j, 1));
                }
            }

        }
        boundaryChars.AddRange(input[i].Substring(leftSide, 1));
        if (rightSide < input[i].Length)
        {
            boundaryChars.AddRange(input[i].Substring(rightSide, 1));
        }
        boundaryChars.RemoveAll(c => c == '.');

        if (boundaryChars.Any(c => symbols.Contains(c)))
        {
            partNumbers.Add(int.Parse(input[i].Substring(bound.start, (bound.end - bound.start) + 1)));

        }

    }
}
Console.WriteLine(partNumbers.Sum());
Console.ReadLine();