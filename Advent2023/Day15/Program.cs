using AdventUtilities;

List<string> input = File.ReadAllText("input.txt").Split(",").ToList();

int value = 0;
int sum = 0;

foreach (string s in input)
{
    value = Hash(s, 0);
    Console.WriteLine($"{s}, {value}");
    sum += value;
}

Console.WriteLine(sum);
Console.ReadLine();

int Hash(string code, int currentValue)
{
    for (int i = 0; i < code.Length; i++)
    {
        currentValue += code[i].ToAscii();
        currentValue *= 17;
        currentValue %= 256;
    }

    return currentValue;
}