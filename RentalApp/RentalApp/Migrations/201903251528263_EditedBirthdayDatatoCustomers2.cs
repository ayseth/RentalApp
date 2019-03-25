namespace RentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedBirthdayDatatoCustomers2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
