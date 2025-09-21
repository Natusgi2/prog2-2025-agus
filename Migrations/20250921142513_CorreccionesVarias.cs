using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class CorreccionesVarias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autores_autorId",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Libros_autorId",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "autorId",
                table: "Libros");

            migrationBuilder.RenameColumn(
                name: "Edcicion",
                table: "Libros",
                newName: "Edicion");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Personas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Autores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Autores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Email",
                table: "Personas",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Libros_IdAutor",
                table: "Libros",
                column: "IdAutor");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Autores_IdAutor",
                table: "Libros",
                column: "IdAutor",
                principalTable: "Autores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Autores_IdAutor",
                table: "Libros");

            migrationBuilder.DropIndex(
                name: "IX_Personas_Email",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Libros_IdAutor",
                table: "Libros");

            migrationBuilder.RenameColumn(
                name: "Edicion",
                table: "Libros",
                newName: "Edcicion");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "autorId",
                table: "Libros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Autores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Autores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Libros_autorId",
                table: "Libros",
                column: "autorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Autores_autorId",
                table: "Libros",
                column: "autorId",
                principalTable: "Autores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
