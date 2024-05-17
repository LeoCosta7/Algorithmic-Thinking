using StrategyPOC.Entities;
using StrategyPOC.Factory;
using StrategyPOC.Strategy;
using System.Configuration;

namespace StrategyPOC
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = ConfigurationManager.AppSettings["Path"];

            try
            {
                string[] files = Directory.GetFiles(path);

                foreach (string file in files)
                {

                    BasePayment basePayment = FactoryInstance.Create(file);

                    IPaymentStrategy payment = new PaymentStrategy(basePayment.Type);

                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex);  
            }
        }        
    }
}
