namespace testbiedro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lolo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Order_Id = c.Int(nullable: false, identity: true),
                        Client_Name = c.String(),
                        Table_Number = c.Int(nullable: false),
                        Order_Date = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Order_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
