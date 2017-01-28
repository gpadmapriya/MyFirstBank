using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstBank
{
    /// <summary>
    /// This class defines an account for MyFirstBank
    /// This is a blueprint
    /// </summary>
    class Account
    {
        #region Statics
        private static int LastAccountNumber = 0;
        #endregion
        
        #region Properties
        public int AccountNumber { get; private set; }
        public string EmailAddress { get; set; }

        //if balance is public program.cs can set it which is not desirable
        //if balance is set to private program.cs cannot even read balance to display
        //so set balance to public but the set method to private
        //visual c# how to program for beginners
        public decimal Balance { get; private set; }
        #endregion

        #region Methods
        public Account():this("", 0.0M)
        {
            //this.AccountNumber = ++LastAccountNumber;
        }
        public Account(string EmailAddress):this(EmailAddress, 0.0M)
        {
            //this.AccountNumber = ++LastAccountNumber;
            //this.EmailAddress = EmailAddress;
        }
        public Account(string EmailAddress, decimal balance)
        {
            this.AccountNumber = ++LastAccountNumber;
            this.EmailAddress = EmailAddress;
            this.Balance = balance;
        }

        public decimal Deposit(decimal Amount)
        {
            Balance += Amount;
            return Balance;
        }
        public void WithDraw(decimal Amount)
        {
            Balance -= Amount;
        }
        #endregion
    }
}
