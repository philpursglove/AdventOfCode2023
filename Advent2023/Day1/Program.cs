List<string> calibrations = File.ReadAllLines("input.txt").ToList();

int sum = 0;

foreach (string calibration in calibrations)
{
    char firstDigit = calibration.First(char.IsNumber);
    char lastDigit = calibration.Last(char.IsNumber);

    sum += int.Parse($"{firstDigit}{lastDigit}");
}

Console.WriteLine(sum);

sum = 0;

foreach (string calibration in calibrations)
{
    char firstDigit = new char();
    char lastDigit = new char();
    int firstDigitPosition;
    int lastDigitPosition;
    if (calibration.Any(char.IsNumber))
    {
        firstDigit = calibration.First(char.IsNumber);
        lastDigit = calibration.Last(char.IsNumber);
        firstDigitPosition = calibration.IndexOf(firstDigit);
        lastDigitPosition = calibration.LastIndexOf(lastDigit);

    }
    else
    {
        firstDigitPosition = calibration.Length;
        lastDigitPosition = 0;
    }

    Dictionary<char, string> numberDictionary = new Dictionary<char, string>
    {
        { '1', "one" },
        { '2', "two" },
        { '3', "three" },
        { '4', "four" },
        { '5', "five" },
        { '6', "six" },
        { '7', "seven" },
        { '8', "eight" },
        { '9', "nine" }
    };

    if (firstDigitPosition != 0)
    {
        foreach (var number in numberDictionary)
        {
            if (calibration.Contains(number.Value) && calibration.IndexOf(number.Value) < firstDigitPosition)
            {
                firstDigit = number.Key;
                firstDigitPosition = calibration.IndexOf(number.Value);
            }
        }
    }

    if (lastDigitPosition < calibration.Length)
    {
        foreach (var number in numberDictionary)
        {
            if (calibration.Contains(number.Value) && calibration.LastIndexOf(number.Value) > lastDigitPosition)
            {
                lastDigit = number.Key;
                lastDigitPosition = calibration.LastIndexOf(number.Value);
            }
        }
    }


    string value = $"{firstDigit}{lastDigit}";
    sum += int.Parse(value);
}

Console.WriteLine(sum);


