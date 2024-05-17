using StrategyPOC.Entities;

namespace StrategyPOC.Strategy
{
    public interface IPaymentStrategy
    {
        T Mapper<T>(BasePayment basePayment);


    }
}