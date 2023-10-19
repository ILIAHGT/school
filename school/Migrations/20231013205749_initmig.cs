using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace school.Migrations
{
    /// <inheritdoc />
    public partial class initmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "classrooms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    classname = table.Column<string>(type: "TEXT", nullable: false),
                    teachername = table.Column<string>(type: "TEXT", nullable: false),
                    numberofstudents = table.Column<int>(type: "INTEGER", nullable: false),
                    durationofcoursebyhour = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classrooms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    fname = table.Column<string>(type: "TEXT", nullable: false),
                    lname = table.Column<string>(type: "TEXT", nullable: false),
                    age = table.Column<int>(type: "INTEGER", nullable: false),
                    nationalcode = table.Column<int>(type: "INTEGER", maxLength: 10, nullable: false),
                    fathername = table.Column<string>(type: "TEXT", nullable: false),
                    grade = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "classroomstudent",
                columns: table => new
                {
                    classroomsid = table.Column<Guid>(type: "TEXT", nullable: false),
                    studentsid = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classroomstudent", x => new { x.classroomsid, x.studentsid });
                    table.ForeignKey(
                        name: "FK_classroomstudent_classrooms_classroomsid",
                        column: x => x.classroomsid,
                        principalTable: "classrooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classroomstudent_students_studentsid",
                        column: x => x.studentsid,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reportcards",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Studentid = table.Column<Guid>(type: "TEXT", nullable: false),
                    classroomid = table.Column<Guid>(type: "TEXT", nullable: false),
                    score = table.Column<double>(type: "REAL", nullable: false),
                    issuedate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reportcards", x => x.id);
                    table.ForeignKey(
                        name: "FK_reportcards_classrooms_classroomid",
                        column: x => x.classroomid,
                        principalTable: "classrooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reportcards_students_Studentid",
                        column: x => x.Studentid,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_classroomstudent_studentsid",
                table: "classroomstudent",
                column: "studentsid");

            migrationBuilder.CreateIndex(
                name: "IX_reportcards_classroomid",
                table: "reportcards",
                column: "classroomid");

            migrationBuilder.CreateIndex(
                name: "IX_reportcards_Studentid",
                table: "reportcards",
                column: "Studentid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "classroomstudent");

            migrationBuilder.DropTable(
                name: "reportcards");

            migrationBuilder.DropTable(
                name: "classrooms");

            migrationBuilder.DropTable(
                name: "students");
        }
    }
}
