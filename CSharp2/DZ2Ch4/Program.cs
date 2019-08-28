using System;
using System.Collections.Generic;
using System.Linq;

namespace DZ2Ch4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 1");
            Task1();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Задача 2");
            Task2();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Задача 3");
            Task3();
        }

        // С клавиатуры вводится скобочное выражение. Требуется проверить правильность расстановки скобок.(Использовать обобщенную коллекцию Stack<char>)
        static void Task1()
        {
            Console.WriteLine("Введите скобочное выражение");
            string input = Console.ReadLine();
            Stack<char> parentheses = new Stack<char>();
            bool result = true;

            foreach (char ch in input)
            {
                if (ch == '(')
                {
                    parentheses.Push(ch);
                }
                else if (ch == ')')
                {
                    if (parentheses.Count == 0)
                    {
                        result = false;
                        break;
                    }
                    parentheses.Pop();
                }
            }

            if (!result || parentheses.Count != 0) Console.WriteLine("Число скобок не совпадает");
            else Console.WriteLine("Число скобок совпадает");
        }

        /* Дана коллекция List<T> требуется подсчитать сколько раз каждый элемент встречается в данной коллекции. 
         * а) для целых чисел; 
         * б) для обобщенной коллекции; 
         * в) используя Linq.
         */
        static void Task2()
        {
            List<int> list = new List<int>() { 1, 2, 3, 2, 1, 2 };
            foreach (var value in list)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();

            Dictionary<int, int> dic = new Dictionary<int, int>();

            Console.WriteLine("для целых чисел");
            dic = F(list);
            PrintDictionary(dic);

            Console.WriteLine("для обобщенной коллекции");
            dic = F(list);
            PrintDictionary(dic);

            Console.WriteLine("используя Linq");
            dic = list.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            PrintDictionary(dic);
        }

        static Dictionary<int, int> F(List<int> list)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();

            foreach (var key in list)
            {
                int value;
                if (dic.TryGetValue(key, out value))
                {
                    //dic.Remove(key);
                    //dic.Add(key, ++value);
                    dic[key]++;
                }
                else
                {
                    dic.Add(key, 1);
                }
            }

            return dic;
        }

        static Dictionary<object, int> F(List<object> list)
        {
            Dictionary<object, int> dic = new Dictionary<object, int>();

            foreach (var key in list)
            {
                int value;
                if (dic.TryGetValue(key, out value))
                {
                    dic.Remove(key);
                    dic.Add(key, ++value);
                }
                else
                {
                    dic.Add(key, 1);
                }
            }

            return dic;
        }

        static void PrintDictionary(Dictionary<int, int> dic)
        {
            foreach (var pair in dic)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }

        /* Дан фрагмент программы:
         * Dictionary<string, int> dict = new Dictionary<string, int>()
         * {
         * {"four",4 },
         * {"two",2 },
         * { "one",1 },
         * {"three",3 },
         * };
         * var d = dict.OrderBy(delegate(KeyValuePair<string,int> pair) { return pair.Value; });
         * foreach (var pair in d)
         * {
         * Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
         * }
         * а) Сверните обращение к OrderBy с использованием лямбда выражения 
         * б) Разверните обращение к OrderBy с использованием делегата Predicate<T>
         */
        static void Task3()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                { "four",4 },
                { "two",2 },
                { "one",1 },
                { "three",3 },
            };
            Console.WriteLine("Исходный OrderBy");
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

            Console.WriteLine("Лямбда выражение");
            var a = dict.OrderBy(x => x.Value);
            foreach (var pair in a)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

            Console.WriteLine("С Predicate<T>");
            //var b = dict.OrderBy();
        }
    }
}
