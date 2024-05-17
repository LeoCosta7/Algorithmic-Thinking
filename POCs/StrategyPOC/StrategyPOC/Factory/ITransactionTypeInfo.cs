using StrategyPOC.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPOC.Factory
{
    public interface ITransactionTypeInfo
    {
        TransactionType GetInstance(string type);
    }
}
