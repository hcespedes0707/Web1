using Microsoft.EntityFrameworkCore.Migrations;

namespace HCRWeb.Migrations
{
    public partial class PeliculaImageNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pelicula_Imagen_ImagenId",
                table: "Pelicula");

            migrationBuilder.AlterColumn<int>(
                name: "ImagenId",
                table: "Pelicula",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pelicula_Imagen_ImagenId",
                table: "Pelicula",
                column: "ImagenId",
                principalTable: "Imagen",
                principalColumn: "ImagenId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pelicula_Imagen_ImagenId",
                table: "Pelicula");

            migrationBuilder.AlterColumn<int>(
                name: "ImagenId",
                table: "Pelicula",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pelicula_Imagen_ImagenId",
                table: "Pelicula",
                column: "ImagenId",
                principalTable: "Imagen",
                principalColumn: "ImagenId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
