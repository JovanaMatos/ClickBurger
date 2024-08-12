using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClickBurger.Migrations
{
    public partial class PopularCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias (CategoriaNome, Descricao)" +
                "VALUES('Normal','Hambúrguer feito com igredientes normais')");

            migrationBuilder.Sql("INSERT INTO Categorias (CategoriaNome, Descricao)" +
                "VALUES('Natural','Hambúrguer feito com igredientes integrais e naturais')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
