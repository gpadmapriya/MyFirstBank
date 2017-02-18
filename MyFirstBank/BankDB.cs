namespace MyFirstBank
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BankDB : DbContext
    {
        // Your context has been configured to use a 'BankDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MyFirstBank.BankDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BankDB' 
        // connection string in the application configuration file.
        public BankDB()
            : base("name=BankDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}