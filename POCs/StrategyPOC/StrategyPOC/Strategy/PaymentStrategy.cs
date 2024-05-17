using StrategyPOC.Entities;
using StrategyPOC.Enums;
using StrategyPOC.Strategy.NewFolder;

namespace StrategyPOC.Strategy
{
    public class PaymentStrategy : IPaymentStrategy
    {
        private readonly IPaymentStrategy _payment;

        public PaymentStrategy(TransactionType transactionType)
        {
            switch (transactionType)
            {
                case TransactionType.Boleto:
                    _payment = new BoletoPayment();
                    break;
                case TransactionType.Cartao:
                    _payment = new CartaoPayment();
                    break;
                case TransactionType.Paypal:
                    _payment = new PaypalPayment();
                    break;
                default:
                    throw new Exception("Tipo inválido"); //Criar mensagem
            }
        }

        public T Mapper<T>(BasePayment basePayment)
        {
            try
            {
                return _payment.Mapper<T>(basePayment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}