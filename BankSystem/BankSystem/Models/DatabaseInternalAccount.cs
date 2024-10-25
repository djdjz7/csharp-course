using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    internal class DatabaseInternalAccount
    {
        required public Account Account { get; set; }
        required public decimal Balance { get; set; }
        required public string Password { get; set; }
    }
}
