namespace myPosTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAmountToTransaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Amount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Amount");
        }
    }
}
