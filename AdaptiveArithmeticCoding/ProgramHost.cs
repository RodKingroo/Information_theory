namespace AAC
{
    public class ProgramHost 
    {
        private double edgeLower = 0;
        private double edgeUpper = 1;
        private const double input = 0.5790710929829856; 
        private List<string> letters = new()
        {
            "О", "Е", "А", "И", "Н", "Т", "С", "Р", "В", "Л", "К", 
            "М", "Д", "П", "У", "Я", "З", "Ы", "Б", "Г", "Ч", "Й", 
            "Х", "Ж", "Ъ", "Ь", "Ш", "Ю", "Ц", "Щ", "Э", "Ф", " "
        };

        private List<double> size = new()
        {
            90, 72, 62, 62, 53, 53, 45, 40, 38, 35, 28, 
            26, 25, 23, 21, 18, 16, 16, 14, 13, 12, 10, 
            9,  7,  7,  7,  6,  6,  4,  3,  3,  1,  1
        };

        private double aSize = 0;
        protected double sizeletters(double asize)
        {
            asize = size.Sum();
            return asize;
        }

        private List<double> dictinarySizeRight = new (){};
        private List<string> word = new();

        protected void findLetter(List<double> right, List<double> size, 
                                  double asz, double edgeLower, double edgeUpper)
        {
            int countSize = size.Count - 1;
            right.Add(edgeLower);
            for(int i = 0; i < size.Count; i++)
            {
                var btoa = right[i] + size[countSize - i] * (edgeUpper - edgeLower) / asz;
                right.Add(btoa);
            }

            int countRight = right.Count-1;            

            for(int j = 0; j < countRight; j++)
            {
                if(right[countRight-(j+1)] < input && right[countRight-j] > input)
                {
                    word.Add(letters[j]);
                    if(word[word.Count-1] == " ") break;
                    newValue(right, right[countRight-(j+1)], right[countRight-j], j, size, asz);
                    break;
                }
            }

            
            
        }

        protected void newValue(List<double> Right,
                                double left, double right,  int i, 
                                List<double> size, double asize)
        {
            Right.Clear();
            size[i] += 1;
            asize += 1;
            findLetter(Right, size, asize, left, right);
        }

        public void Run()
        {
            Console.WriteLine($"Входное значение: {input}");
            double asize = sizeletters(aSize);
            findLetter(dictinarySizeRight, size, asize, edgeLower, edgeUpper);
            Console.WriteLine(string.Join("", word));
        }
        
    }

}