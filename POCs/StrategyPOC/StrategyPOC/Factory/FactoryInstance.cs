using StrategyPOC.Entities;
using StrategyPOC.Enums;
using StrategyPOC.Util; 


namespace StrategyPOC.Factory
{
    public class FactoryInstance
    {
        public static BasePayment Create(string file)
        {
            try
            {
                string property = Utilitario.GetParameterValue(file, "Tipo");

                Enum.TryParse(property, out TransactionType type);

                switch (type)
                {
                    case TransactionType.Boleto:
                        return new Boleto();
                    case TransactionType.Cartao:
                        return new Card();
                    case TransactionType.Paypal:
                        return new Paypal();
                    default:
                        throw new ArgumentException("Tipo de transação inválido.");
                }

            } catch
            {
                throw;
            }            
        }
    }
}
