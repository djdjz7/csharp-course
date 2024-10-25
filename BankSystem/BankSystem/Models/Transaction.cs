using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    public class Transaction
    {
        public string TransactionId { get; set; }
        required public Account? FromAccount { get; set; }
        required public Account? ToAccount { get; set; }
        public DateTime TransactionTime { get; set; }
        required public decimal Amount { get; set; }
        public Transaction()
        {
            TransactionTime = DateTime.Now;
            TransactionId = Guid.NewGuid().ToString();
        }
    }
}
