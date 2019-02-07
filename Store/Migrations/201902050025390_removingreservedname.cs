namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removingreservedname : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Order", newName: "Orders");
            RenameColumn(table: "dbo.CartItem", name: "Order_Id", newName: "Orders_Id");
            RenameIndex(table: "dbo.CartItem", name: "IX_Order_Id", newName: "IX_Orders_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CartItem", name: "IX_Orders_Id", newName: "IX_Order_Id");
            RenameColumn(table: "dbo.CartItem", name: "Orders_Id", newName: "Order_Id");
            RenameTable(name: "dbo.Orders", newName: "Order");
        }
    }
}
