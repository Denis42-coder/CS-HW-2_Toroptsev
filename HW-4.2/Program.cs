using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_3
{
    /*

Дан фрагмент программы:
Dictionary<string, int> dict = new Dictionary<string, int>()
  {
    {"four",4 },
    {"two",2 },
    { "one",1 },
    {"three",3 },
  };
     var d = dict.OrderBy(delegate(KeyValuePair<string,int> pair) { return pair.Value; });
     foreach (var pair in d)
    {
      Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
    }
        а) Свернуть обращение к OrderBy с использованием лямбда-выражения $.
        б) *Развернуть обращение к OrderBy с использованием делегата Predicate<T>.
    */
    class Task4
    {
        static Dictionary<string, int> dict = new Dictionary<string, int>() { { "four", 4 }, { "two", 2 }, { "one", 1 }, { "three", 3 } };

        class MyComparer : IComparer<int>//для того, чтобы можно было отсортировать словарь (для OrderBy)
        {            
            public int Compare(int s1, int s2)
            {
                if (s1 < s2)
                    return (-1);
                else if (s1 > s2)
                    return (1);
                else
                    return (0);
            }
        }

        public static void DoIt()  //используем метод расширения OrderBy, сообщая, что мы из пары ключ-значение для сортировки используем значение
        {
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair)
                {
                    return pair.Value;
                }
            );
            
            foreach (var pair in d) Console.WriteLine("{0} {1}", pair.Key, pair.Value);//выводим результат сортировки

            //а)Сверните обращение к OrderBy с использованием лямбда выражения
            Console.WriteLine("лямбда-выражение:");
            
            var dd = dict.OrderBy(pair => pair.Value); //используем метод расширения OrderBy, сообщая, что мы из пары ключ-значение для сортировки используем значение

            foreach (var pair in dd) Console.WriteLine("{0} {1}", pair.Key, pair.Value);

            //б)*Разверните обращение к OrderBy с использованием делегата Func<KeyValuePair<T1,T2>,T3>
            Console.WriteLine("Предикат:");

            //используем системный делегат Func<T,R>, чтобы создать свой делегат
            //где T - это обобщенная структура ключ-значение, а R - это число (сколько раз встречается ValueGetter
            //Func<KeyValuePair<string, int>, int> mypredicate = new Func<KeyValuePair<string, int>, int>(ValueGetter);
            Func<KeyValuePair<string, int>, int> mypredicate = ValueGetter;

            var ddd = dict.OrderBy(mypredicate);
            foreach (var pair in ddd) Console.WriteLine("{0} {1}", pair.Key, pair.Value);
        }
        
        static int ValueGetter(KeyValuePair<string, int> kvp) //Просто метод, который из пары ключ-значение получает значение (может получать и что-то другое)
        {
            return (kvp.Value);
        }

        static void Main()
        {
            DoIt();
            Console.ReadKey();
        }

    }
}
