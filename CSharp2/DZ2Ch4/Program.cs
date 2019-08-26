using System;
using System.Collections.Generic;

namespace DZ2Ch4
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
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
    }
}
