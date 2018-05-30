using System;
using System.IO;

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
                Console.WriteLine(" 4 - Авторизация");
                Console.WriteLine(" 5 - Калькулятор");
                Console.WriteLine(" 6 - Перевод десятичного числа в двоичное");

                if (!Int32.TryParse(Console.ReadLine(), out prog))
                {
                    Console.WriteLine("Ошибка ввода номера программы");
                    continue;
                }

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
                        Authorization();
                        break;
                    case 5:
                        Calculater();
                        break;
                    case 6:
                        Translations10To2();
                        break;
                    default:
                        Console.WriteLine("Введено не корректное число. Выходим!");
                        break;
                }
                Console.WriteLine("");
            }
        }

        private static void Translations10To2()
        {
            Int32 operand = 0;

            Console.WriteLine("Введите число для перевода в двоичную систему исчисления");
            if (!Int32.TryParse(Console.ReadLine(), out operand))
            {
                Console.WriteLine("Ошибка ввода числа");
                return;
            }

            Console.WriteLine("Число {0} переведено в двоичную систему: {1}", operand, Recursion10To2(operand));
        }

        private static String Recursion10To2(Int32 operand)
        {
            String str = String.Empty;

            if (operand < 2)
            {
                return operand.ToString();
            }

            str = (operand % 2).ToString();
            operand /= 2;

            return Recursion10To2(operand) + str;
        }

        private static void Authorization()
        {
            String password = String.Empty, login = String.Empty;

            Console.WriteLine("Введите логин");
            login = Console.ReadLine();

            Console.WriteLine("Введите пароль");
            password = Console.ReadLine();

            if (Validation(login, password))
            {
                Console.WriteLine("Вы авторизовались");
            }
            else
            {
                Console.WriteLine("Вы не авторизовались");
            }
        }

        private static Boolean Validation(String login, String password)
        {
            String[] loginPassword = new String[2];
            using(StreamReader sr = new StreamReader("test.txt"))
            {
                loginPassword = sr.ReadLine().Split(new char[] { '\t' });
            }
            
            return (login == loginPassword[0] && password == loginPassword[1]) ? true : false;
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
