using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    public class Account
    {
        required public string LoginName { get; set; }
        required public string AccountId { get; set; }
        required public string Name { get; set; }
        required public string Pronouns { get; set; }

        public static bool operator ==(Account? a, Account? b)
        {
            return a?.AccountId == b?.AccountId;
        }
        public static bool operator !=(Account? a, Account? b)
        {
            return a?.AccountId != b?.AccountId;
        }
    }
}
