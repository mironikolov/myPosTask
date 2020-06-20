namespace myPosTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transactions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(maxLength: 200),
                        Receiver_Id = c.String(nullable: false, maxLength: 128),
                        Sender_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Receiver_Id, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.Sender_Id, cascadeDelete: false)
                .Index(t => t.Receiver_Id)
                .Index(t => t.Sender_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Sender_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transactions", "Receiver_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Transactions", new[] { "Sender_Id" });
            DropIndex("dbo.Transactions", new[] { "Receiver_Id" });
            DropTable("dbo.Transactions");
        }
    }
}
