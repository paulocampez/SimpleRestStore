namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Discount", "ProductId", "dbo.Product");
            DropIndex("dbo.CartItem", new[] { "ProductId" });
            DropIndex("dbo.Discount", new[] { "ProductId" });
            DropPrimaryKey("dbo.Product");
            AddColumn("dbo.CartItem", "Product_Id", c => c.Int());
            AddColumn("dbo.Product", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Discount", "Product_Id", c => c.Int());
            AlterColumn("dbo.CartItem", "ProductId", c => c.String());
            AlterColumn("dbo.Product", "ProductId", c => c.String());
            AlterColumn("dbo.Discount", "ProductId", c => c.String());
            AddPrimaryKey("dbo.Product", "Id");
            CreateIndex("dbo.CartItem", "Product_Id");
            CreateIndex("dbo.Discount", "Product_Id");
            AddForeignKey("dbo.CartItem", "Product_Id", "dbo.Product", "Id");
            AddForeignKey("dbo.Discount", "Product_Id", "dbo.Product", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Discount", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.CartItem", "Product_Id", "dbo.Product");
            DropIndex("dbo.Discount", new[] { "Product_Id" });
            DropIndex("dbo.CartItem", new[] { "Product_Id" });
            DropPrimaryKey("dbo.Product");
            AlterColumn("dbo.Discount", "ProductId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Product", "ProductId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.CartItem", "ProductId", c => c.String(maxLength: 128));
            DropColumn("dbo.Discount", "Product_Id");
            DropColumn("dbo.Product", "Id");
            DropColumn("dbo.CartItem", "Product_Id");
            AddPrimaryKey("dbo.Product", "ProductId");
            CreateIndex("dbo.Discount", "ProductId");
            CreateIndex("dbo.CartItem", "ProductId");
            AddForeignKey("dbo.Discount", "ProductId", "dbo.Product", "ProductId");
            AddForeignKey("dbo.CartItem", "ProductId", "dbo.Product", "ProductId");
        }
    }
}
