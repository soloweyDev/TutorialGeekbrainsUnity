using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace DZ2Ch8_Host
{
    [ServiceContract]
    public interface ISockService
    {
        [OperationContract]
        double GetPrice(string tiker);
    }

    public class StoclService : ISockService
    {
        public double GetPrice(string tiker)
        {
            return 94.85;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(StoclService), new Uri("http://localhost:8080/EssentialWCF"));
            serviceHost.AddServiceEndpoint(typeof(ISockService), new BasicHttpBinding(), "");

            ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
            behavior.HttpGetEnabled = true;
            serviceHost.Description.Behaviors.Add(behavior);
            serviceHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            serviceHost.Open();
            Console.WriteLine("Для завершения нажмите <ENTER>.\n\n");
            Console.ReadLine();
            serviceHost.Close();
        }
    }
}
