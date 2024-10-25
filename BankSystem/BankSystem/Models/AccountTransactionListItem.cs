using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    internal class AccountTransactionListItem
    {
        required public decimal Amount { get; set; }
        required public DateTime Time { get; set; }
        required public string? FromAccountName { get; set; }
        required public string? ToAccountName { get; set; }
        required public string? FromAccountLoginName { get; set; }
        required public string? ToAccountLoginName { get; set; }
        required public string TransactionId { get; set; }
    }
}
