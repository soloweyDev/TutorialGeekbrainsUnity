using System;

namespace ConsoleApp
{
    class Program
    {
        private static void Main(string[] args)
        {
            Int32 prog = 0;
            Boolean exit = true;

            while (exit)
            {
                Console.WriteLine("Выберите программу");
                Console.WriteLine(" 0 - Выход");
                Console.WriteLine(" 1 - Сумматор");
                Console.WriteLine(" 2 - Анкета");
                Console.WriteLine(" 3 - Зарплата");
                Console.WriteLine(" 4 - Калькулятор");

                prog = Int32.Parse(Console.ReadLine());

                switch (prog)
                {
                    case 0:
                        exit = false;
                        break;
                    case 1:
                        Summ();
                        break;
                    case 2:
                        Questionnaire();
                        break;
                    case 3:
                        Wage();
                        break;
                    case 4:
                        Calculater();
                        break;
                    default:
                        Console.WriteLine("Введено не корректное число. Выходим!");
                        break;
                }
                Console.WriteLine("");
            }
        }

        private static void Calculater()
        {
            String operat = String.Empty;
            Int32 operand1 = 0, operand2 = 0;
            Double result = 0;

            Console.WriteLine("Введите знак операции (+ - * /)");
            operat = Console.ReadLine();

            Console.WriteLine("Введите первое число");
            if (!Int32.TryParse(Console.ReadLine(), out operand1))
            {
                Console.WriteLine("Ошибка ввода числа");
                return;
            }

            Console.WriteLine("Введите второе число");
            if (!Int32.TryParse(Console.ReadLine(), out operand2))
            {
                Console.WriteLine("Ошибка ввода числа");
                return;
            }

            switch (operat)
            {
                case "+":
                    result = operand1 + operand2;
                    break;
                case "-":
                    result = operand1 - operand2;
                    break;
                case "*":
                    result = operand1 * operand2;
                    break;
                case "/":
                    result = operand1 / operand2;
                    break;
                default:
                    Console.WriteLine("Введен некорректный знак операции");
                    break;
            }

            Console.WriteLine("Результат операции {0}", result);
        }

        private static void Wage()
        {
            const int year = 12;
            const int week = 5;
            const int day = 22;
            const int hour = 8;

            int rate = 0;
            Console.WriteLine("Сколько заработ в месяц?");
            rate = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Заработ в год: {0}; в неделю: {1}; в день: {2}; в час {3}.", rate * year, (float)rate / day * week, (float)rate / day, (float)rate / day / hour);
        }

        private static void Summ()
        {
            int a = 0, b = 0;
            Console.WriteLine("Введите первое число");
            a = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число");
            b = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Сумма чисел равна {0}", a + b);
        }

        private static void Questionnaire()
        {
            string name, lastname, age, date, h, w;
            Console.WriteLine("Ваше имя");
            name = Console.ReadLine();
            Console.WriteLine("Ваша фамилия");
            lastname = Console.ReadLine();
            Console.WriteLine("Ваш возраст");
            age = Console.ReadLine();
            Console.WriteLine("Ваш город рождения");
            date = Console.ReadLine();
            Console.WriteLine("Ваш рост");
            h = Console.ReadLine();
            Console.WriteLine("Ваш вес");
            w = Console.ReadLine();

            string result = name + " " + lastname + " " + age + " " + date + " " + h + " " + w;
            Console.WriteLine(result);
        }
    }
}
