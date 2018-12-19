namespace MeuEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizandoOBancoComNovosCampos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Compras_Item", "Produto_Id", "dbo.Produtoes");
            DropIndex("dbo.Compras_Item", new[] { "Produto_Id" });
            RenameColumn(table: "dbo.Compras_Item", name: "Produto_Id", newName: "ProdutoId");
            AlterColumn("dbo.Compras_Item", "ProdutoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Compras_Item", "ProdutoId");
            AddForeignKey("dbo.Compras_Item", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Compras_Item", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.Compras_Item", new[] { "ProdutoId" });
            AlterColumn("dbo.Compras_Item", "ProdutoId", c => c.Int());
            RenameColumn(table: "dbo.Compras_Item", name: "ProdutoId", newName: "Produto_Id");
            CreateIndex("dbo.Compras_Item", "Produto_Id");
            AddForeignKey("dbo.Compras_Item", "Produto_Id", "dbo.Produtoes", "Id");
        }
    }
}
