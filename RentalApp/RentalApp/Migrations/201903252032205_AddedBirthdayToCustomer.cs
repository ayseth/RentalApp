namespace RentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBirthdayToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthday", c => c.DateTime());
            DropColumn("dbo.Customers", "MembershipTypeIdBirthday");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MembershipTypeIdBirthday", c => c.DateTime());
            DropColumn("dbo.Customers", "Birthday");
        }
    }
}
