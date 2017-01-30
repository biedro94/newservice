namespace testbiedro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dupa655 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Product_Name", c => c.String());
            DropColumn("dbo.Products", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Name", c => c.String());
            DropColumn("dbo.Products", "Product_Name");
        }
    }
}
