namespace convol
{
    public class ProgramHost
    {
        private const string input = "100111011";

        internal List<string> CBA = new List<string>()
        {
            "000", "001", "010", "011",
            "100", "101", "110", "111"
        };

        
        internal List<string> XY = new List<string>()
        {
            "00", "11", "10", "01",
            "11", "00", "01", "10"

        };

        internal List<char> valueCBA = new List<char>() 
        {
            '0', '0', '0'
        };
     
        private List<string> finalXY = new List<string>();

        internal List<string> finalBA = new List<string>(){ "00" }; 

        protected void RealiseMethod()
        {
            string sCBA = string.Join("", valueCBA);
            for(int i = 0; i < CBA.Count; i++)
            {
                if(sCBA == CBA[i])
                {
                    finalXY.Add(XY[i]);
                    break;
                }
                
            }
        }

        protected void ConvertLine()
        {
            char[] charInput = input.ToArray();
            for(int i = 0; i < charInput.Length; i++)
            { 
                valueCBA.Insert(0, charInput[i]);
                valueCBA.RemoveAt(valueCBA.Count - 1);
                RealiseMethod();
                
            }

            for (int j = 0; j < finalXY.Count; j++)
            {
                int a, b, c = 0;
                a = Convert.ToInt32(finalBA[j], 2);
                b = Convert.ToInt32(finalXY[j], 2);
                var ac = ConvertRed(a, b, c);
                Console.WriteLine(ac);
                finalBA.Add(Convert.ToString(ac, 2));
            }

            finalBA.RemoveAt(0);

        }

        internal int ConvertRed(int a, int b, int c)
        {
            switch ((a + b))
            {
                case 0:
                    c = 0;
                    break;
                case > 0 and <= 1:
                    c = 1;
                    break;
                case > 1 and <= 2:
                    c = 2;
                    break;
                case > 2 and <= 3:
                    c = 3;
                    break;
                case > 3 and <= 4:
                    c = 4;
                    break;
            }
            return c;
        }

        public void Run()
        {
            Console.WriteLine($"Исходное значение: {input}");
            ConvertLine();

            Console.WriteLine($"XY: {string.Join(" ", finalXY)}");
            Console.WriteLine($"BA: {string.Join(" ", finalBA)}");
            
        }
    }
}