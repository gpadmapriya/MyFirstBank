namespace MyFirstBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "AccountName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "AccountName");
        }
    }
}
