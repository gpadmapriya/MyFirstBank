namespace MyFirstBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "TypeOfAccount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "TypeOfAccount");
        }
    }
}
