namespace RentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8c57072a-c1e0-4436-8cb1-5a7854c1f4c7', N'admin@rental.com', 0, N'AOSq2KGupZnoM/qBhB3d5LxoqVmdCpfaSmHNt9wmRka4rn0VVI1a6IFZgDJbGMEmaw==', N'978f9855-aa1b-4b29-b820-8f7dd182f91a', NULL, 0, 0, NULL, 1, 0, N'admin@rental.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b58321dc-0c1f-4b3f-a08a-9c3f00a73115', N'guest@rental.com', 0, N'AEV8jh1Ccq0yZaPKGkM8nLoAa7uxPVM/zsc4Xz8z9kXLAbN+UdImwjO75726KzEPaw==', N'dd9a2000-7ed1-4c1e-8bfe-e519a12a6695', NULL, 0, 0, NULL, 1, 0, N'guest@rental.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2000e760-1090-453b-bee7-4c0a99de9a0a', N'CanManageMovie')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8c57072a-c1e0-4436-8cb1-5a7854c1f4c7', N'2000e760-1090-453b-bee7-4c0a99de9a0a')


");
        }
        
        public override void Down()
        {
        }
    }
}
