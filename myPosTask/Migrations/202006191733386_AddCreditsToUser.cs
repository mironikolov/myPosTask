namespace myPosTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreditsToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Credits", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Credits");
        }
    }
}
