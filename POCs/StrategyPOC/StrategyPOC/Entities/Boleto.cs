using StrategyPOC.Enums;

namespace StrategyPOC.Entities
{
    public class Boleto : BasePayment
    {
        public string Name { get; set; }

        public DateTime DueDate { get; set; }

    }
}
