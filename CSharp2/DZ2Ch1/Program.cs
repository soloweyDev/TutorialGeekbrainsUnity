using System;
using System.Collections;

namespace DZ2Ch1
{
    class Program
    {
        static void Main(string[] args)
        {

            Worker[] workers = { new WorkerFixedSalary("WorkerFixedSalary", "Frst", 1000.0), new WorkerFixedSalary("WorkerFixedSalary", "Second", 1100.0),
                new WorkerHourlyWage("WorkerHourlyWage", "Frst", 10.0), new WorkerHourlyWage("WorkerHourlyWage", "Second", 20.0), new WorkerHourlyWage("WorkerHourlyWage", "Third", 15.0) };

            Console.WriteLine("Array not sorted");
            foreach (Worker worker in workers)
            {
                Console.Write("{0}, ", worker.WageRate);
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Array sorted");
            Worker.Sort(workers);
            Worker.PrintWokers(workers);

            if (workers.Length == 5)
                throw new MyOwnException("Просто тест Exception");
        }

        public abstract class Worker
        {
            protected string Name { get; set; }
            protected string LastName { get; set; }
            public double WageRate { get; set; }

            public int CompareTo(object obj)
            {
                if (obj == null) return 1;

                Worker otherWorker = obj as Worker;
                if (otherWorker != null)
                    return WageRate.CompareTo(otherWorker.WageRate);
                else
                    throw new ArgumentException("Object is not a Worker");
            }

            public abstract double Salary();

            public static void Sort(Worker[] workers)
            {
                Array.Sort(workers, new ComparerWoker());
            }

            public static void PrintWokers(Worker[] workers)
            {
                foreach (Worker worker in workers)
                {
                    Console.WriteLine("Name: {0} {1} WageRate: {2}", worker.Name, worker.LastName, worker.WageRate);
                }
            }
        }

        public class WorkerFixedSalary : Worker
        {
            public WorkerFixedSalary(string name, string lastName, double wagerate) 
            {
                Name = name;
                LastName = lastName;
                WageRate = wagerate;
            }

            public override double Salary()
            {
                // среднемесячная заработная плата = фиксированной месячной оплате
                return WageRate;
            }
        }

        public class WorkerHourlyWage : Worker
        {
            public WorkerHourlyWage(string name, string lastName, double wagerate)
            {
                Name = name;
                LastName = lastName;
                WageRate = wagerate;
            }

            public override double Salary()
            {
                // среднемесячная заработная плата = 20.8 * 8 * почасовую ставку
                return WageRate * 20.8 * 8;
            }
        }

        public interface IArraySort<in T> : IComparable<T>
        {
            void Sort(T[] workers);
        }

        public class ComparerWoker : IComparer
        {
            public int Compare(object x, object y)
            {
                Worker worker1 = x as Worker;
                Worker worker2 = y as Worker;

                if (worker1.WageRate < worker2.WageRate)
                    return -1;
                else if (worker1.WageRate > worker2.WageRate)
                    return 1;

                return 0;
            }
        }

        public class MyOwnException : Exception
        {
            public MyOwnException(string massage) : base(massage) { }
        }
    }
}
