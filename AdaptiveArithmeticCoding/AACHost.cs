/* Copyright (c) 2022 RodKingroo */

namespace AAC
{
    public class AACHost{

        /// <summary> 
        /// Входные данные, прописанные в задании
        /// </summary>
        private const double input = 759021.0/4194304.0;//0.5790710929829856;

        /// <summary> 
        /// Список всех символов
        /// </summary>
        private List<string> letters = new()
        {
           " ", "C", "B", "A" // "О", "Е", "А", "И", "Н", "Т", "С", "Р", "В", "Л", "К", 
           // "М", "Д", "П", "У", "Я", "З", "Ы", "Б", "Г", "Ч", "Й", 
           // "Х", "Ж", "Ъ", "Ь", "Ш", "Ю", "Ц", "Щ", "Э", "Ф", " "
        };

        /// <summary> 
        /// Список веса всех символов
        /// </summary>
        private List<double> size = new()
        {
            1, 1, 1, 1 //90, 72, 62, 62, 53, 53, 45, 40, 38, 35, 28, 
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

        private List<double> _dictinarySizeA = new(){0};
        private List<double> _dictinarySizeB = new(){1};
        private List<string> _word = new();

        protected void findletter(List<double> a, List<double> b, 
                                       List<double> size, double asz)
        {
            Console.WriteLine(asz);
            for(int i = 1; i < size.Count+1; i++)
            {
                double btoa = a[i-1] + size[size.Count - i] * (b[0] - a[0]) / asz;
                b.Add(btoa);
                a.Add(b[i]);
                Console.WriteLine($"{a[i-1]} - {b[i]}");
            }

            for(int j = 1; j<=size.Count; j++) 
            {
                //Console.WriteLine($"[ {a[j-1]} ]-[ {b[j]} ]");
                if(a[j-1] < input && b[j] > input) { 
                    _word.Add(letters[size.Count - j]);
                    newValue(a, j, size, b, asz);
                    break;
                }
                
            }



            Console.WriteLine(string.Join("", _word));
            
        }

        protected void newValue(List<double> a, int j, List<double> size, List<double> b, double asize)
        {
            a.RemoveAll(item => item != a[j-1]);
            b.RemoveAll(item => item != b[j]);
            //size.RemoveAt(size.Count - j);
            //size.Insert(size.Count - j, size[size.Count - j] + 1);
            size[j - 1] += 1;
            asize = asize + 1;
            findletter(a, b, size, asize);
            //Console.WriteLine(size[j]);
            //Console.WriteLine($"Новая граница А: { string.Join("", a) } Новая граница B: { string.Join("", b) } {size[size.Count - j]} {asize}");
            
        }

        public void Run()
        {
            Console.WriteLine($"Входное значение: {input}");
            /*for(int i = 0; i < size.Count; i++) Console.WriteLine($"[ {letters[i]} ] - [ {size[i]} ]");
            Console.WriteLine($"Общий вес: {sizeletters(_asize)}");*/
            double asize = sizeletters(_asize);
            findletter(_dictinarySizeA, _dictinarySizeB, size, asize);
        }

    }
}