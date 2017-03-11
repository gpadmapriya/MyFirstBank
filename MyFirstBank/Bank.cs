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

        public static Account CreateAccount(string accountName, string emailAddress, decimal amount, AccountTypes typeOfAccount)
        {
            var db = new BankDB();
            var account = new Account(emailAddress, amount);
            account.TypeOfAccount = typeOfAccount;
            account.AccountName = accountName;
            //accounts.Add(account);
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="amount"></param>
        /// <exception cref="ArgumentException">Argument exception</exception>
        public static void Deposit(int accountNumber, decimal amount)
        {
            if (accountNumber <= 0)
            {
                throw new ArgumentException("Account Number is invalid");
            }
            if (amount <= 0)
            {
                throw new ArgumentException("Amount is invalid");
            }
            var db = new BankDB();
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account == null)
            {
                throw new ArgumentOutOfRangeException("Inavlid Account Number");
            }
            
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
        public static void Withdraw(int accountNumber, decimal amount)
        {
            var db = new BankDB();
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account != null)
            {
                account.WithDraw(amount);
                db.Entry(account).State = System.Data.Entity.EntityState.Modified;
                var transaction = new Transaction();
                transaction.TransactionDate = DateTime.Now;
                transaction.Amount = amount;
                transaction.TransactionType = TransactionType.Debit;
                transaction.Description = "Withdraw from account";
                transaction.AccountNumber = accountNumber;

                db.Transactions.Add(transaction);
                db.SaveChanges();
            }
            try { }
            catch { }
        }
        public static IQueryable<Account> GetAllAccounts(string emailAddress)
        {
            //foreach (Account a in accounts)
            //foreach (var a in accounts.Where(x => x.EmailAddress == emailAddress))
            //  {
            //    Console.WriteLine($"Account Number: {a.AccountNumber}, Balance: {a.Balance}");
            //   }
            var db = new BankDB();
            return db.Accounts.Where(x => x.EmailAddress == emailAddress);
            //foreach (var a in db.Accounts.Where(x => x.EmailAddress == emailAddress))
            //{
            //    Console.WriteLine($"Account Number: {a.AccountNumber}, Balance: {a.Balance}");
            //}

        }
        //public static void PrintAllTransactions(int accountNumber)
        //{
        //    var db = new BankDB();
        //    foreach (var a in db.Accounts.Where(x => x.AccountNumber == accountNumber))
        //    {
        //        Console.WriteLine($"Account Number: {a.AccountNumber}, Balance: {a.Balance}");
        //    }
        //}
        public static IQueryable<Transaction> GetAllTransactions(int accountNumber)
        {
            var db = new BankDB();
            return db.Transactions.Where(t => t.AccountNumber == accountNumber).OrderByDescending(t => t.TransactionDate);
            
        }
    }
}
