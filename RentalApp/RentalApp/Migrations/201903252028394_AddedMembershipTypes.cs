namespace RentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMembershipTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MembershipTypeIdBirthday", c => c.DateTime());
            DropColumn("dbo.Customers", "Birthday");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Birthday", c => c.DateTime());
            DropColumn("dbo.Customers", "MembershipTypeIdBirthday");
        }
    }
}
