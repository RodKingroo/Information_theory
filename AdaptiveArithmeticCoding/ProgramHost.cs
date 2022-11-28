namespace AAC
{
    public class ProgramHost 
    {
        private double _edgeA = 0, _edgeB = 1;

        /// <summary> 
        /// Входные данные, прописанные в задании
        /// </summary>
        private const double input = 759021.0/4194304.0;//0.5790710929829856;

        /// <summary> 
        /// Список всех символов
        /// </summary>
        private List<string> letters = new()
        {
           "A", "B", "C", " " 
        // "О", "Е", "А", "И", "Н", "Т", "С", "Р", "В", "Л", "К", 
        // "М", "Д", "П", "У", "Я", "З", "Ы", "Б", "Г", "Ч", "Й", 
        // "Х", "Ж", "Ъ", "Ь", "Ш", "Ю", "Ц", "Щ", "Э", "Ф", " "
        };

        /// <summary> 
        /// Список веса всех символов
        /// </summary>
        private List<double> size = new()
        {
            1, 1, 1, 1 
            //90, 72, 62, 62, 53, 53, 45, 40, 38, 35, 28, 
            //26, 25, 23, 21, 18, 16, 16, 14, 13, 12, 10, 
            //9,  7,  7,  7,  6,  6,  4,  3,  3,  1,  1
        };

        /// <summary> 
        /// Количество всех символов в "библиотеке"
        /// </summary>
        private double _asize = 0;
        internal double sizeletters(double asize)
        {
            for(int i = 0; i<size.Count; i++) asize += size[i];
            return asize;
        }

        private List<double> _dictinarySizeA = new(){};
        private List<double> _dictinarySizeB = new(){};
        private List<string> _word = new();

        protected void findLetter(List<double> a, List<double> b, 
                                  List<double> size, double asz, 
                                  double _edgeA, double _edgeB)
        {
            a.Add(_edgeA);
            for(int i = 0; i < size.Count; i++)
            {
                double btoa = a[i]+ size[i] * (_edgeB - _edgeA) / asz;
                b.Add(btoa);
                a.Add(b[i]);
                //Console.WriteLine($"{a[i]} - {b[i]}");
            }

            for(int j = 0; j<size.Count; j++)
            {
                //Console.WriteLine($"{a[j]} - {b[j]}");
                if(a[j] < input && b[j] > input)
                {
                    _word.Add(letters[j]);
                    newValue(a, b, a[j], b[j], j, size, asz);
                    break;
                }
            }

            Console.WriteLine(string.Join("", _word));
            
        }

        protected void newValue(List<double> a, List<double> b,
                                double _a, double _b,  int i, 
                                List<double> size, double asize)
        {
            a.Clear();
            b.Clear();
            size[i] += 1;
            asize += 1;
            findLetter(a, b, size, asize, _a, _b);
        }

        public void Run()
        {
            Console.WriteLine($"Входное значение: {input}");
            double asize = sizeletters(_asize);
            Console.WriteLine($"Общий вес: {asize}");
            findLetter(_dictinarySizeA, _dictinarySizeB, size, asize, _edgeA, _edgeB);
        }
        
    }

}