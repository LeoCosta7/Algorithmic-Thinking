using StrategyPOC.Enums;

namespace StrategyPOC.Entities
{
    public class Card : BasePayment
    {
        public string Name { get; set; }

        public DateTime DueDate { get; set; }

        public string CCV { get; set; }

        public string Number { get; set; }
    }
}
