namespace СonvolutionalСoding;

public class ProgramHost
{
    private const string input = """100111011""";

    private readonly List<string> cBA = new List<string>()
    {
        "000", "001", "010", "011",
        "100", "101", "110", "111"
    };


    private readonly List<string> XY = new List<string>()
    {
        "00", "11", "10", "01",
        "11", "00", "01", "10"

    };

    private List<char> valueCBA = new List<char>()
    {
        '0', '0', '0'
    };

    private List<string> finalXY = new List<string>();

    private List<string> finalBA = new List<string>() { "00" };

    public static string Input => input;
    internal List<char> ValueCBA { get => valueCBA; set => valueCBA = value; }
    public List<string> FinalXY { get => finalXY; set => finalXY = value; }
    internal List<string> FinalBA { get => finalBA; set => finalBA = value; }

    protected void RealiseMethod()
    {
        string sCBA = string.Join("", ValueCBA);
        for (int i = 0; i < cBA.Count; i++)
        {
            if (sCBA == cBA[i])
            {
                FinalXY.Add(XY[i]);
                break;
            }

        }
    }

    protected void ConvertLine()
    {
        for (var i = 0; i < Input.ToArray().Length; i++)
        {
            ValueCBA.Insert(index: 0, item: Input.ToArray()[i]);
            ValueCBA.RemoveAt(index: ValueCBA.Count - 1);
            RealiseMethod();

        }

        for (var j = 0; j < FinalXY.Count; j++)
        {
            int a, b, c = 0;
            a = Convert.ToInt32(value: FinalBA[j], 2);
            b = Convert.ToInt32(value: FinalXY[j], 2);
            var ac = ConvertRed(a: a, b: b, c: c);
            Console.WriteLine(value: ac);
            FinalBA.Add(item: Convert.ToString(ac, 2));
        }

        FinalBA.RemoveAt(0);

    }

    internal int ConvertRed(int a, int b, int c)
    {
        int v = (a + b) / 2;
        switch (v)
        {
            case 0:
                c = 0b00;
                break;
            case >= 1 and < 2:
                c = 0b01;
                break;
            case >= 2 and < 3:
                c = 0b10;
                break;
            case >= 3 and < 4:
                c = 0b11;
                break;
        }
        return c;
    }

    public void Run()
    {
        Console.WriteLine(value: $"Исходное значение: {Input}");
        ConvertLine();

        Console.WriteLine(value: $"XY: {string.Join(" ", FinalXY)}");
        Console.WriteLine(value: $"BA: {string.Join(" ", FinalBA)}");

    }
}