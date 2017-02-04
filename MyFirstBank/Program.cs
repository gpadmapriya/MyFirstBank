using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstBank
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("*****Welcome to my bank!****");
            Console.WriteLine("Please provide your email address: ");
            var email = Console.ReadLine();
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Create an account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Print All accounts");
            while (true)
            {
                Console.WriteLine("Please select one of the options from above");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        return;

                    case "1":
                        
                        //var newAccount = new Account(email);
                        var newAccount = Bank.CreateAccount(email, 0.0M);
                        Console.WriteLine($"The balance in my account {newAccount.AccountNumber} is {newAccount.Balance:C}");
                        Console.ReadLine();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        Bank.PrintAllAccounts(email);
                        break;
                    default:
                        Console.WriteLine("Sorry, option not available");
                        break;

                }
            }

            //account is created in the stack. Account() is in the heap(reference type)
            /*var account = new Account();
            //account.AccountNumber = 123;
            account.EmailAddress = "test@test.com";
            decimal bal = account.Balance;
            //M - 3 different kinds of floating point variable-double, float, decimal.
            //decimal is used for money M.
            var newBalance = account.Deposit(3560.45M);
            //$-telling c# that you are putting placeholders within the string
            //C- balance is written in currency format
            Console.WriteLine($"The balance in my account {account.AccountNumber} is {account.Balance:C}");

            var account2 = new Account();
            account2.EmailAddress = "test2@test.com";
            newBalance = account2.Deposit(200.5M);
            Console.WriteLine($"The balance in my account {account2.AccountNumber} is {account2.Balance:C}");

            var account3 = new Account("test3@test.com");
            newBalance = account3.Deposit(200.5M);
            Console.WriteLine($"The balance in my account {account3.AccountNumber} is {account3.Balance:C}");

            Console.ReadLine();
            */
        }
    }
}
