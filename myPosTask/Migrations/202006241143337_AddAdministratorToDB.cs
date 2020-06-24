namespace myPosTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdministratorToDB : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Credits]) VALUES (N'4f584cc1-f6b6-40c1-87cd-50daca1c1c25', N'administrator@test.com', 0, N'APBAPkSs1e+ajHX6JJ4t4tgUyu2VtSxoMYJj4Evu0YDJJhXc286hPIId9SZYGy+rHA==', N'959ef50b-f270-4cb4-a348-768a5a068eed', N'0889999999', 0, 0, NULL, 1, 0, N'administrator@test.com', 100)

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b3da24be-d687-4f99-944f-9b0ff313ba44', N'Administrator')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4f584cc1-f6b6-40c1-87cd-50daca1c1c25', N'b3da24be-d687-4f99-944f-9b0ff313ba44')
");
        }
        
        public override void Down()
        {
        }
    }
}
