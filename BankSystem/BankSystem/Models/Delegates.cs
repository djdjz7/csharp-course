using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    internal static class Delegates
    {
        public delegate void TransactionEventHandler(Transaction transaction);
        public delegate void InterWorldTransactionEventHandler(decimal amount);
        public delegate void RiskyTransactionEventHandler(Transaction transaction, decimal toAccountDailyIntake);
        public delegate void AccountEventHandler(Account account);
    }
}
