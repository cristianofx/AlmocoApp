namespace AlmocoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriaIDRestaurante : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Restaurantes", "RestauranteCategoria_CategoriaID", "dbo.Categorias");
            DropIndex("dbo.Restaurantes", new[] { "RestauranteCategoria_CategoriaID" });
            RenameColumn(table: "dbo.Restaurantes", name: "RestauranteCategoria_CategoriaID", newName: "CategoriaID");
            AlterColumn("dbo.Restaurantes", "CategoriaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Restaurantes", "CategoriaID");
            AddForeignKey("dbo.Restaurantes", "CategoriaID", "dbo.Categorias", "CategoriaID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurantes", "CategoriaID", "dbo.Categorias");
            DropIndex("dbo.Restaurantes", new[] { "CategoriaID" });
            AlterColumn("dbo.Restaurantes", "CategoriaID", c => c.Int());
            RenameColumn(table: "dbo.Restaurantes", name: "CategoriaID", newName: "RestauranteCategoria_CategoriaID");
            CreateIndex("dbo.Restaurantes", "RestauranteCategoria_CategoriaID");
            AddForeignKey("dbo.Restaurantes", "RestauranteCategoria_CategoriaID", "dbo.Categorias", "CategoriaID");
        }
    }
}
