using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class grades_update_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentTeacher",
                columns: table => new
                {
                    studentsStudentNr = table.Column<int>(type: "INTEGER", nullable: false),
                    teachersTeacherNr = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTeacher", x => new { x.studentsStudentNr, x.teachersTeacherNr });
                    table.ForeignKey(
                        name: "FK_StudentTeacher_Studenten_studentsStudentNr",
                        column: x => x.studentsStudentNr,
                        principalTable: "Studenten",
                        principalColumn: "StudentNr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTeacher_Teacher_teachersTeacherNr",
                        column: x => x.teachersTeacherNr,
                        principalTable: "Teacher",
                        principalColumn: "TeacherNr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentTeacher_teachersTeacherNr",
                table: "StudentTeacher",
                column: "teachersTeacherNr");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentTeacher");
        }
    }
}
