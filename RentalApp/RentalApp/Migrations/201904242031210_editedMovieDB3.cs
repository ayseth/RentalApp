namespace RentalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedMovieDB3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
            AddColumn("dbo.Rentals", "Customer_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "Customer_Id");
            AddForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
            DropColumn("dbo.Rentals", "DateReturned");

            Sql("UPDATE Movies SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "DateReturned", c => c.DateTime());
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            DropColumn("dbo.Rentals", "Customer_Id");
            DropColumn("dbo.Movies", "NumberAvailable");
        }
    }
}
