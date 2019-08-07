using System;

namespace DZ2Ch1
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker[] workers = { new WorkerFixedSalary(1000.0), new WorkerFixedSalary(1100.0), new WorkerHourlyWage(10.0), new WorkerHourlyWage(20.0), new WorkerHourlyWage(15.0), };
            Console.WriteLine("Array not sorted");
            foreach (Worker worker in workers)
            {
                Console.Write("{0}, ", worker.WageRate);
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Array sorted");
            workers[0].Sort(workers);
            foreach (Worker worker in workers)
            {
                Console.Write("{0}, ", worker.WageRate);
            }
        }

        public abstract class Worker : IArraySort
        {
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

            public void Sort(object[] workers)
            {
                Array.Sort(workers);
            }
        }

        public class WorkerFixedSalary : Worker
        {
            public WorkerFixedSalary(double wagerate)
            {
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
            public WorkerHourlyWage(double wagerate)
            {
                WageRate = wagerate;
            }

            public override double Salary()
            {
                // среднемесячная заработная плата = 20.8 * 8 * почасовую ставку
                return WageRate * 20.8 * 8;
            }
        }

        public interface IArraySort : IComparable
        {
            void Sort(object[] workers);
        }
    }
}
