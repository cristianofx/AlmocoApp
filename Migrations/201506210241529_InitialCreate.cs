namespace AlmocoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        CategoriaNome = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Restaurantes",
                c => new
                    {
                        RestauranteID = c.Int(nullable: false, identity: true),
                        RestauranteNome = c.String(),
                        Descricao = c.String(),
                        Endereco = c.String(),
                        FaixaPreco = c.Short(nullable: false),
                        RestauranteCategoria_CategoriaID = c.Int(),
                    })
                .PrimaryKey(t => t.RestauranteID)
                .ForeignKey("dbo.Categorias", t => t.RestauranteCategoria_CategoriaID)
                .Index(t => t.RestauranteCategoria_CategoriaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurantes", "RestauranteCategoria_CategoriaID", "dbo.Categorias");
            DropIndex("dbo.Restaurantes", new[] { "RestauranteCategoria_CategoriaID" });
            DropTable("dbo.Restaurantes");
            DropTable("dbo.Categorias");
        }
    }
}
