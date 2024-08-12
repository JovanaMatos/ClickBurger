using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClickBurger.Migrations
{
    public partial class PopularHamburgueres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Hamburgueres(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnaiUrl,ImagemUrl,IsHamburguerPreferido,Nome,Preco) VALUES(1,'Pão, hambúrguer, ovo, fiambre, queijo e batata palha','Delicioso pão de hambúrguer com ovo frito; fiambre e queijo de primeira qualidade acompanhado com batata palha',1, 'http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg','http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg', 0 ,'Cheese Salada', 12.50)");
            migrationBuilder.Sql("INSERT INTO Hamburgueres(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnaiUrl,ImagemUrl,IsHamburguerPreferido,Nome,Preco) VALUES(1,'Pão, fiambre, mussarela e tomate','Delicioso pão francês quentinho na chapa com fiambre e mussarela bem servidos com tomate preparado com carinho.',1,'http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg','http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg',0,'Misto Quente', 8.00)");
            migrationBuilder.Sql("INSERT INTO Hamburgueres(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnaiUrl,ImagemUrl,IsHamburguerPreferido,Nome,Preco) VALUES(1,'Pão, hambúrguer, fiambre, mussarela e batalha palha','Pão de hambúrguer especial com hambúrguer de nossa preparação e fiambre e mussarela; acompanha batata palha.',1,'http://www.macoratti.net/Imagens/lanches/cheeseburger1.jpg','http://www.macoratti.net/Imagens/lanches/cheeseburger1.jpg',0,'Cheese Burger', 11.00)");
            migrationBuilder.Sql("INSERT INTO Hamburgueres(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnaiUrl,ImagemUrl,IsHamburguerPreferido,Nome,Preco) VALUES(2,'Pão Integral, queijo branco, peito de peru, cenoura, alface, iogurte','Pão integral natural com queijo branco, peito de peru e cenoura ralada com alface picado e iorgurte natural.',1,'http://www.macoratti.net/Imagens/lanches/lanchenatural.jpg','http://www.macoratti.net/Imagens/lanches/lanchenatural.jpg',1,'Lanche Natural Peito Peru', 15.00)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("DELETE FROM Hamburgueres");

        }
    }
}

