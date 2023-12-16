using AdventUtilities;

List<string> input = File.ReadAllText("input.txt").Split(",").ToList();
//List<string> input = "rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7".Split(",").ToList();

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

List<Box> boxes = new List<Box>(256);
for (int i = 0; i < 256; i++)
{
    Box box = new Box() {Id = i};
    boxes.Add(box);
}

foreach (string s in input)
{
    string operation;
    string label;
    int focalLength = 0;
    if (s.IndexOf("=") != -1)
    {
        operation = "=";
        label = s.Substring(0, s.IndexOf("=") );
        focalLength = int.Parse(s.Substring(s.IndexOf("=") + 1));
    }
    else
    {
        operation = "-";
        label = s.Substring(0, s.IndexOf("-"));
    }

    int boxNumber = Hash(label,0);

    Box box = boxes[boxNumber];
    if (operation == "=")
    {
        if (box.Lenses.Any(l => l.Label == label))
        {
            box.Lenses.First(l => l.Label == label).FocalLength = focalLength;
        }
        else
        {
            box.Lenses.Add(new Lens(){Label = label, FocalLength = focalLength});
        }
    }
    else
    {
        Lens lens = box.Lenses.FirstOrDefault(l => l.Label == label);
        if (lens != null)
        {
            box.Lenses.Remove(lens);
        }
    }

}

int power = 0;

foreach (Box box in boxes)
{
    for (int i = 0; i < box.Lenses.Count; i++)
    {
        power += (box.Id + 1) * (i+1) * box.Lenses[i].FocalLength;
    }
}

Console.WriteLine(power);
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

class Box
{
    public int Id { get; set; }

    public List<Lens> Lenses { get; set; } = new List<Lens>();
}

class Lens
{
    public string Label { get; set; }
    public int FocalLength { get; set; }
}