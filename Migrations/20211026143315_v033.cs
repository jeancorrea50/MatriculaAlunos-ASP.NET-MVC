using Microsoft.EntityFrameworkCore.Migrations;

namespace MatriculaFaculdade.Migrations
{
    public partial class v033 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cursos",
                table: "Curso",
                newName: "NomeCurso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeCurso",
                table: "Curso",
                newName: "Cursos");
        }
    }
}
