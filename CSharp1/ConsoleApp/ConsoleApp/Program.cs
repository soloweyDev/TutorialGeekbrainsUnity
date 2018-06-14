using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        private static void Main()
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
            Boolean exit = true;

            while (exit)
            {
                Console.WriteLine("Выберите программу");

                Console.WriteLine(" 1 - Employer");
                Console.WriteLine(" 2 - Средняя зарплата");
                Console.WriteLine(" 3 - ");

                if (!Int32.TryParse(Console.ReadLine(), out var prog))
                {
                    Console.WriteLine("Ошибка ввода номера программы");
                    continue;
                }

                switch (prog)
                {
                    case 1:
                        WorkEmployer();
                        exit = false;
                        break;
                    case 2:
                        AverageWage();
                        exit = false;
                        break;
                    case 3:
                        
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Введено не корректное число.");
                        break;
                }
            }
        }

        private static void AverageWage()
        {
            const Int32 numMan = 7;

            List<Int32> list = new List<Int32>();
            Random random = new Random();
            Int32 sum = 0;

            for (int i = 0; i < numMan; i++)
            {
                Int32 value = random.Next(1, 4) * 10000;
                list.Add(value);
                Console.WriteLine("{0} - {1}", i + 1, value);
                sum += value;
            }

            Console.WriteLine("Средня зарплата - {0}", sum / numMan);
        }

        private static void WorkEmployer()
        {
            Employer employer = new Employer("Иван", "Раб", 3200);
            Console.WriteLine(employer.Text());
            employer.ChangePosition("Начальника");
            Console.WriteLine(employer.Text());
            employer.ChangeWage(5100);
            Console.WriteLine(employer.Text());
        }

        private static void Urok3()
        {
            Boolean exit = true;

            while (exit)
            {
                Console.WriteLine("Выберите программу");

                Console.WriteLine(" 1 - Complex");
                Console.WriteLine(" 2 - Подсчет суммы введеных чисел");
                Console.WriteLine(" 3 - Работа с дробями (сложение и вычетание)");

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
                    case 3:
                        WorkFraction();
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Введено не корректное число.");
                        break;
                }
            }
        }

        private static void WorkFraction()
        {
            Fraction fraction1 = new Fraction(1, 2);
            Fraction fraction2 = new Fraction(1, 3);

            Fraction fraction3 = fraction1 + fraction2;
            Console.WriteLine("Сумма {0}", fraction3);
            Fraction fraction4 = fraction1 - fraction2;
            Console.WriteLine("Разность {0}", fraction4);
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
            Int32 summ = 0;

            while (true)
            {
                Console.WriteLine("Введите число, для выхода введите 0.");

                if (!Int32.TryParse(Console.ReadLine(), out var temp))
                {
                    Console.WriteLine("Ошибка ввода числа");
                    continue;
                }

                list.Add(temp);

                if (temp == 0)
                {
                    break;
                }

                if (temp < 0)
                {
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
            Console.WriteLine("Введите число для перевода в двоичную систему исчисления");
            if (!Int32.TryParse(Console.ReadLine(), out var operand))
            {
                Console.WriteLine("Ошибка ввода числа");
                return;
            }

            Console.WriteLine("Число {0} переведено в двоичную систему: {1}", operand, Recursion10To2(operand));
        }

        private static String Recursion10To2(Int32 operand)
        {
            if (operand < 2)
            {
                return operand.ToString();
            }

            var str = (operand % 2).ToString();
            operand /= 2;

            return Recursion10To2(operand) + str;
        }

        private static void Authorization()
        {
            Console.WriteLine("Введите логин");
            var login = Console.ReadLine();

            Console.WriteLine("Введите пароль");
            var password = Console.ReadLine();

            Console.WriteLine(Validation(login, password) ? "Вы авторизовались" : "Вы не авторизовались");
        }

        private static Boolean Validation(String login, String password)
        {
            String[] loginPassword;
            using(StreamReader sr = new StreamReader("test.txt"))
            {
                loginPassword = sr.ReadLine()?.Split('\t');
            }
            
            return loginPassword != null && (login == loginPassword[0] && password == loginPassword[1]);
        }

        private static void Calculater()
        {
            Double result = 0;

            Console.WriteLine("Введите знак операции (+ - * /)");
            var operat = Console.ReadLine();

            Console.WriteLine("Введите первое число");
            if (!Int32.TryParse(Console.ReadLine(), out var operand1))
            {
                Console.WriteLine("Ошибка ввода числа");
                return;
            }

            Console.WriteLine("Введите второе число");
            if (!Int32.TryParse(Console.ReadLine(), out var operand2))
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

            Console.WriteLine("Сколько заработ в месяц?");
            var rate = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Заработ в год: {0}; в неделю: {1}; в день: {2}; в час {3}.", rate * year, (float)rate / day * week, (float)rate / day, (float)rate / day / hour);
        }

        private static void Summ()
        {
            Console.WriteLine("Введите первое число");
            var a = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число");
            var b = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Сумма чисел равна {0}", a + b);
        }

        private static void Questionnaire()
        {
            Console.WriteLine("Ваше имя");
            var name = Console.ReadLine();
            Console.WriteLine("Ваша фамилия");
            var lastname = Console.ReadLine();
            Console.WriteLine("Ваш возраст");
            var age = Console.ReadLine();
            Console.WriteLine("Ваш город рождения");
            var date = Console.ReadLine();
            Console.WriteLine("Ваш рост");
            var h = Console.ReadLine();
            Console.WriteLine("Ваш вес");
            var w = Console.ReadLine();

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

    public class Fraction
    {
        private readonly Int32 _numerator;
        private readonly Int32 _denominator;

        public Fraction(Int32 numerator, Int32 denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
        }

        public static Fraction operator +(Fraction left, Fraction rigth)
        {
            if (left._denominator == rigth._denominator)
                return new Fraction(left._numerator + rigth._numerator, left._denominator);

            return new Fraction(left._numerator * rigth._denominator + rigth._numerator * left._denominator, left._denominator * rigth._denominator);
        }

        public static Fraction operator -(Fraction left, Fraction rigth)
        {
            if (left._denominator == rigth._denominator)
                return new Fraction(left._numerator - rigth._numerator, left._denominator);

            return new Fraction(left._numerator * rigth._denominator - rigth._numerator * left._denominator, left._denominator * rigth._denominator);
        }
    }

    public class Employer
    {
        private readonly string _name;
        private string _position;
        private Int32 _wage;

        public Employer(string name, string position, Int32 wage)
        {
            _name = name;
            _position = position;
            _wage = wage;
        }

        public void ChangePosition(string position)
        {
            _position = position;
        }

        public void ChangeWage(Int32 wage)
        {
            _wage = wage;
        }

        public string Text()
        {
            return String.Format("Имя: {0}, должность: {1}, зарплата: {2}", _name, _position, _wage);
        }
    }
}
