using StrategyPOC.Enums;

namespace StrategyPOC.Entities
{
    public class Paypal : BasePayment
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
