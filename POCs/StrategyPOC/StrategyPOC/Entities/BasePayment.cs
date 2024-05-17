using StrategyPOC.Enums;

namespace StrategyPOC.Entities
{
    public class BasePayment
    {
        public decimal Value { get; set; }

        public TransactionType Type { get; set; }
    }
}
