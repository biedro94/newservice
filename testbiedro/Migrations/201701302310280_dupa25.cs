namespace testbiedro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dupa25 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Category_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "Category_Id");
        }
    }
}
