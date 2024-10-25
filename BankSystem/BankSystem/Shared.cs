using BankSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    internal static class Shared
    {
        public static Database Database { get; set; } = new Database();
    }
}
