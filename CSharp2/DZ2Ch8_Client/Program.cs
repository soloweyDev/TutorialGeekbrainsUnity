using System;

namespace DZ2Ch8_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            localhost.StoclService service = new localhost.StoclService();
            bool res;
            double price;
            service.GetPrice("100", out price, out res);

            Console.WriteLine(price);
            Console.ReadLine();
        }
    }
}
