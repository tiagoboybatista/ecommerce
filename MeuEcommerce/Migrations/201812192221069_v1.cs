namespace MeuEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Compras_Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qtd = c.Int(nullable: false),
                        PrecoUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Produto_Id = c.Int(),
                        Compra_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produtoes", t => t.Produto_Id)
                .ForeignKey("dbo.Compras", t => t.Compra_Id)
                .Index(t => t.Produto_Id)
                .Index(t => t.Compra_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Compras_Item", "Compra_Id", "dbo.Compras");
            DropForeignKey("dbo.Compras_Item", "Produto_Id", "dbo.Produtoes");
            DropIndex("dbo.Compras_Item", new[] { "Compra_Id" });
            DropIndex("dbo.Compras_Item", new[] { "Produto_Id" });
            DropTable("dbo.Compras_Item");
            DropTable("dbo.Compras");
        }
    }
}
