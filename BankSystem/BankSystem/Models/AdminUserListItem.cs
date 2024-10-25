using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    public class AdminUserListItem
    {
        required public string Pronouns { get; set; }
        required public string Name { get; set; }
        required public string LoginName { get; set; }
        required public string AccountId { get; set; }
        required public decimal Balance { get; set; }
    }
}
