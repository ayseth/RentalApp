namespace RentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedBirthdayDatatoCustomers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Birthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Birthday", c => c.String());
        }
    }
}
