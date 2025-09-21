using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class CorregirNombreColumnaDescripcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Cambiar nombre de la propiedad Descripcion a Descripción
            migrationBuilder.RenameColumn(
                name: "Descripción",
                table: "Autores",
                newName: "Descripcion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //Cambiar nombre de la propiedad Descripción a Descripcion
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Autores",
                newName: "Descripción");
        }
    }
}
