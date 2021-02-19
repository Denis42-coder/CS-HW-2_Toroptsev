using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_2
{
    class Program
    {              
        public static List<int> intListFromTextBoxInput(string input)// !дженерик  Конвертируем строку в набор целых чисел
        {
            return Array.ConvertAll(input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), new Converter<string, int>(Convert.ToInt32)).ToList<int>();
        }

        public static Dictionary<int, int> FreqDict(List<int> a)// !дженерик  для целых чисел
        {
            Dictionary<int, int> fd = new Dictionary<int, int>();
            a.Sort();
            foreach (int i in a)
                if (!fd.ContainsKey(i)) fd.Add(i, 1); else fd[i]++;
            return fd;
        }

        public static List<string> strListFromTextBoxInput(string input)
        {
            List<string> res = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return res;
        }

        //б. дженерик, будет работать только если T реализует IComparable(чтобы проверить ContainsKey(T i), надо уметь сравнивать экземпляры T) для обобщенных коллекций
        public static Dictionary<T, int> FreqDict<T, value>(List<T> a)
        {
            Dictionary<T, int> fd = new Dictionary<T, int>();
            //a.Sort(); //string: IComparable
            foreach (T i in a)
                if (!fd.ContainsKey(i)) fd.Add(i, 1); else fd[i]++;
            return fd;
        }

        //в. используя Linq
        public static void FreqDict2(List<int> list)
        {
            var query = from n in list
                        group n by n;
            //orderby gr.Key
            foreach (IGrouping<int, int> el in query)
                Console.WriteLine("{0} {1}", el.Key, el.Count());

            //return query.ToDictionary<int,IGrouping<int,int>>();
        }

        static public void Main()
        {
            FreqDict2(new List<int>() { 1, 2, 3, 4, 1, 2, 5, 2, 10, 15, 10, 10, 10});
            Console.ReadKey();
        }       
    }
 }

