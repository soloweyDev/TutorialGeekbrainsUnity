using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        private static void Main(string[] args)
        {
            Uroks();
        }

        private static void Uroks()
        {
            Boolean exit = true;

            while (exit)
            {
                Console.WriteLine("Введите номер урока (1-8). 0 - выход.");

                if (!Int32.TryParse(Console.ReadLine(), out var prog))
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
                        Urok1();
                        break;
                    case 2:
                        Urok2();
                        break;
                    case 3:
                        Urok3();
                        break;
                    case 4:
                        Urok4();
                        break;
                    case 5:
                        Urok5();
                        break;
                    case 6:
                        Urok6();
                        break;
                    case 7:
                        Urok7();
                        break;
                    case 8:
                        Urok8();
                        break;
                    default:
                        Console.WriteLine("Введено не корректное число.");
                        break;
                }

                Console.WriteLine("");
            }
        }

        private static void Urok8()
        {
            throw new NotImplementedException();
        }

        private static void Urok7()
        {
            throw new NotImplementedException();
        }

        private static void Urok6()
        {
            throw new NotImplementedException();
        }

        private static void Urok5()
        {
            throw new NotImplementedException();
        }

        private static void Urok4()
        {
            throw new NotImplementedException();
        }

        private static void Urok3()
        {
            Boolean exit = true;

            while (exit)
            {
                Console.WriteLine("Выберите программу");

                Console.WriteLine(" 1 - Complex");
                Console.WriteLine(" 2 - Подсчет суммы введеных чисел");

                if (!Int32.TryParse(Console.ReadLine(), out var prog))
                {
                    Console.WriteLine("Ошибка ввода номера программы");
                    continue;
                }

                switch (prog)
                {
                    case 1:
                        WorkComplex();
                        exit = false;
                        break;
                    case 2:
                        SumOfNumber();
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Введено не корректное число.");
                        break;
                }
            }
        }

        private static void Urok2()
        {
            Boolean exit = true;

            while (exit)
            {
                Console.WriteLine("Выберите программу");

                Console.WriteLine(" 1 - Авторизация");
                Console.WriteLine(" 2 - Калькулятор");
                Console.WriteLine(" 3 - Перевод десятичного числа в двоичное");
                Console.WriteLine(" 7 - Complex");
                Console.WriteLine(" 8 - Подсчет суммы введеных чисел");

                if (!Int32.TryParse(Console.ReadLine(), out var prog))
                {
                    Console.WriteLine("Ошибка ввода номера программы");
                    continue;
                }

                switch (prog)
                {
                    case 1:
                        Authorization();
                        exit = false;
                        break;
                    case 2:
                        Calculater();
                        exit = false;
                        break;
                    case 3:
                        Translations10To2();
                        exit = false;
                        break;
                    case 7:
                        WorkComplex();
                        exit = false;
                        break;
                    case 8:
                        SumOfNumber();
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Введено не корректное число.");
                        break;
                }
            }
        }

        private static void Urok1()
        {
            Boolean exit = true;

            while (exit)
            {
                Console.WriteLine("Выберите программу");
                Console.WriteLine(" 1 - Сумматор");
                Console.WriteLine(" 2 - Анкета");
                Console.WriteLine(" 3 - Зарплата");

                if (!Int32.TryParse(Console.ReadLine(), out var prog))
                {
                    Console.WriteLine("Ошибка ввода номера программы");
                    continue;
                }

                switch (prog)
                {
                    case 1:
                        Summ();
                        exit = false;
                        break;
                    case 2:
                        Questionnaire();
                        exit = false;
                        break;
                    case 3:
                        Wage();
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Введено не корректное число.");
                        break;
                }
            }
        }

        private static void WorkComplex()
        {
            Complex complex1 = new Complex(2, 3);
            Complex complex2 = new Complex(1, 2);
            Complex complex3 = complex1 + complex2;
            Complex complex4 = complex1 - complex2;

            Console.WriteLine("complex3 ({0}, {1})", complex3.Real, complex3.Mag);
            Console.WriteLine("complex4 ({0}, {1})", complex4.Real, complex4.Mag);
        }

        private static void SumOfNumber()
        {
            List<Int32> list = new List<int>();
            Int32 summ = 0, temp = 0;

            while (true)
            {
                Console.WriteLine("Введите число, для выхода введите 0.");
                
                if (!Int32.TryParse(Console.ReadLine(), out temp))
                {
                    Console.WriteLine("Ошибка ввода числа");
                    continue;
                }

                list.Add(temp);

                if (temp == 0)
                {
                    break;
                }
                else if (temp < 0)
                {
                    continue;
                }
                else
                {
                    summ += temp;
                }
            }

            Console.Write("Были введены слудующие числа: ");
            foreach (Int32 value in list)
            {
                Console.Write("{0}, ", value);
            }
            Console.WriteLine();
            Console.WriteLine("Сумма положительных чисел равна: {0}", summ);
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

    public struct Complex
    {
        public Int32 Real { get; set; }
        public Int32 Mag { get; set; }

        public Complex(Int32 real, Int32 mag)
        {
            Real = real;
            Mag  = mag;
        }

        public static Complex operator + (Complex left, Complex rigth)
        {
            return new Complex(left.Real + rigth.Real, left.Mag + rigth.Mag);
        }

        public static Complex operator -(Complex left, Complex rigth)
        {
            return new Complex(left.Real - rigth.Real, left.Mag - rigth.Mag);
        }
    }
}
