namespace testbiedro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dupa65 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Products");
            DropColumn("dbo.Products", "Id");
            AddColumn("dbo.Products", "Product_Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Products", "Product_Id");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Products");
            DropColumn("dbo.Products", "Product_Id");
            AddPrimaryKey("dbo.Products", "Id");
        }
    }
}
