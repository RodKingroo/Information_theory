namespace LinearCode;

public class Host
{

    protected Dictionary<int, int> table = new Dictionary<int, int>();
    protected int[] G = {8, 4, 2, 1, 9, 12, 6, 6, 3};

    private static int w(int x)
    {
        var sum = 0;
        while(x > 0)
        {
            sum += x & 1;
            x >>= 1;
        }
        return sum;
    } 

    private static int d (int x, int y) 
        => w(x: x ^ y);

    private int xor(int x)
    {
        var sum = 0;
        while(x>0)
        {
            sum ^= x & 1;
            x >>=1;
        }
        return sum;
    }

    private int mult(int a, int[] G)
    {
        var b = 0;
        foreach(var v in G) 
            b = (b << 1) ^ xor(x: a & v);
        return b;
    }

    static int codeming(int c, Dictionary<int, int> D)
    {
        if (D.ContainsKey(key: c))
            return D[key: c];
        var keys = new List<int>(collection: D.Keys);
        int mind = 100;
        int minKey = 0;
        int t = 0;
        foreach (int v in keys)
        {
            t = d(x: c, y: v);
            if (t < mind)
            {
                mind = t;
                minKey = v;
            }
        }
        return D[key: minKey];
    }

    public void Run()
    {
        int m = 4;
        var size = Math.Pow(x: 2, y: m);
        int a; 
        int b;

        for(a = 0; a < size; a++)
        {
            b = mult(a, G);
            table[b] = a;
        }

        byte[] codes = File.ReadAllBytes("17.code");
        byte[] words = new byte[codes.Length / 2];

        var keys = new List<int>(collection: table.Keys);
        for(var i = 0; i < words.Length; i++)
        {
            int[] code =
            {
                (int)codes[2*i],
                (int)codes[2 * i + 1]
            };

            int word = 0;
            for(int j = 0; j < 2; j++)
                word = (word << 4) ^ (codeming(c: code[j], D: table) & 15);
            words[i] = (byte)word;

        }
        File.WriteAllBytes(path: "fiaso.wtf", bytes: words);
    }
}