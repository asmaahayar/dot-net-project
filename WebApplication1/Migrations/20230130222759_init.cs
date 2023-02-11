using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cosmetics",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cosmetics", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "cosmetics",
                columns: new[] { "id", "brand", "description", "image", "name", "price" },
                values: new object[] { "17c0692d-e6d9-4874-a860-a7f8f10742e7", "GuCci", "this is Lip Gloss", "https://m.media-amazon.com/images/I/51gD8c5l6GL._SL1500_.jpg", "Lip Gloss", 99.989999999999995 });

            migrationBuilder.InsertData(
                table: "cosmetics",
                columns: new[] { "id", "brand", "description", "image", "name", "price" },
                values: new object[] { "a0405df3-5376-41e6-9e22-beee7f049ff4", "GuCci", "this is miror", "https://m.media-amazon.com/images/I/51d3KvJwdAL._SL1000_.jpg", "Miror", 99.989999999999995 });

            migrationBuilder.InsertData(
                table: "cosmetics",
                columns: new[] { "id", "brand", "description", "image", "name", "price" },
                values: new object[] { "c1fcc190-e767-4757-b87f-9c140925c089", "GuCci", "this is Maskra", "https://www.shutterstock.com/image-illustration/blank-eyeliner-mascara-tube-golden-260nw-2145996573.jpg", "Maskra", 99.989999999999995 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cosmetics");
        }
    }
}
