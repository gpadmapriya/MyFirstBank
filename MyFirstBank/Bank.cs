using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstBank
{
    public static class Bank
    {
        //private static List<Account> accounts = new List<Account>();
        public static string Name { get; set; }

        public static Account CreateAccount(string emailAddress, decimal amount)
        {
            var db = new BankDB();
            var account = new Account(emailAddress, amount);
            //accounts.Add(account);
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }
        public static void Deposit(int accountNumber, decimal amount)
        {
            var db = new BankDB();
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account != null)
            {
                account.Deposit(amount);
                db.Entry(account).State = System.Data.Entity.EntityState.Modified;
                var transaction = new Transaction();
                transaction.TransactionDate = DateTime.Now;
                transaction.Amount = amount;
                transaction.TransactionType = TransactionType.Credit;
                transaction.Description = "Deposit to account";
                transaction.AccountNumber = accountNumber;

                db.Transactions.Add(transaction);
                db.SaveChanges();
            }
            try { }
            catch { }
        }
        public static void PrintAllAccounts(string emailAddress)
        {
            //foreach (Account a in accounts)
            //foreach (var a in accounts.Where(x => x.EmailAddress == emailAddress))
            //  {
            //    Console.WriteLine($"Account Number: {a.AccountNumber}, Balance: {a.Balance}");
            //   }
            var db = new BankDB();
            foreach (var a in db.Accounts.Where(x => x.EmailAddress == emailAddress))
            {
                Console.WriteLine($"Account Number: {a.AccountNumber}, Balance: {a.Balance}");
            }
        }
    }
}
