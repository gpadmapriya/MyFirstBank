using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstBank
{
    public static class Bank
    {
        private static List<Account> accounts = new List<Account>();
        public static string Name { get; set; }

        public static Account CreateAccount(string emailAddress, decimal amount)
        {
            var account = new Account(emailAddress, amount);
            accounts.Add(account);
            return account;
        }
        public static void PrintAllAccounts(string emailAddress)
        {
            //foreach (Account a in accounts)
            foreach (var a in accounts.Where(x => x.EmailAddress == emailAddress))
               {
                Console.WriteLine($"Account Number: {a.AccountNumber}, Balance: {a.Balance}");
               }
        }
    }
}
