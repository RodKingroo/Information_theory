/* Copyright (c) 2022 RodKingroo */

namespace AAC
{
    public class AACHost{

        /// <summary> 
        /// Входные данные, прописанные в задании
        /// </summary>
        private const double input = 0.5790710929829856;

        /// <summary> 
        /// Список всех символов
        /// </summary>
        private List<string> letters = new()
        {
            "О", "Е", "А", "И", "Н", "Т", "С", "Р", "В", "Л", "К", 
            "М", "Д", "П", "У", "Я", "З", "Ы", "Б", "Г", "Ч", "Й", 
            "Х", "Ж", "Ъ", "Ь", "Ш", "Ю", "Ц", "Щ", "Э", "Ф", " "
        };

        /// <summary> 
        /// Список веса всех символов
        /// </summary>
        private List<double> size = new()
        {
            90, 72, 62, 62, 53, 53, 45, 40, 38, 35, 28, 
            26, 25, 23, 21, 18, 16, 16, 14, 13, 12, 10, 
            9,  7,  7,  7,  6,  6,  4,  3,  3,  1,  1
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

        private List<double> _dictinarySizeA = new(){0};
        private List<double> _dictinarySizeB = new(){1};
        private List<string> _word = new();

        protected void findfirstletter(List<double> a, List<double> b, 
                                       List<double> size, double asz)
        {
            Console.WriteLine(asz);
            for(int i = 0; i < size.Count; i++)
            {
                double btoa = a[0] + size[size.Count - i - 1] * (b[i] - a[0]) / asz;
                b.Insert(0, btoa);
                a.Insert(0, b[0]);
                Console.WriteLine($"{a[1]} - {b[0]}");
            }

            for(int j = 0; j<size.Count; j++) 
            {
                if(a[j+1] < input && b[j] > input) { 
                    _word.Add(letters[j]);
                    newValue(a, j, size, b, asz);
                    break;
                }
            }



            Console.WriteLine(string.Join("", _word));
            
        }

        protected void newValue(List<double> a, int j, List<double> size, List<double> b, double asize)
        {
            a.RemoveAll(item => item != a[j+1]);
            b.RemoveAll(item => item != b[j]);
            size.RemoveAt(j);
            size.Insert(j, size[j] + 1);
            asize = asize + 1;
            findfirstletter(a, b, size, asize);
            //Console.WriteLine(size[j]);
            
        }

        public void Run()
        {
            /*Console.WriteLine($"Входное значение: {input}");
            for(int i = 0; i < size.Count; i++) Console.WriteLine($"[ {letters[i]} ] - [ {size[i]} ]");
            Console.WriteLine($"Общий вес: {sizeletters(_asize)}");*/
            double asize = sizeletters(_asize);
            findfirstletter(_dictinarySizeA, _dictinarySizeB, size, asize);
        }

    }
}