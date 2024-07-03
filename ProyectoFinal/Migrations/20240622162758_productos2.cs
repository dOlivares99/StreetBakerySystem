using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    /// <inheritdoc />
    public partial class productos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "imagenURL",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PadreId",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "estado",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_PadreId",
                table: "Productos",
                column: "PadreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Productos_PadreId",
                table: "Productos",
                column: "PadreId",
                principalTable: "Productos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Productos_PadreId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_PadreId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "PadreId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "Productos");

            migrationBuilder.AlterColumn<string>(
                name: "imagenURL",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
