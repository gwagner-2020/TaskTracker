using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTracker.Migrations
{
    public partial class AddTaskTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StudentName",
                table: "StudentTags",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50) CHARACTER SET utf8mb4",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "TaskTags",
                columns: table => new
                {
                    StudentTaskId = table.Column<int>(nullable: false),
                    StudentTagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTags", x => new { x.StudentTaskId, x.StudentTagId });
                    table.ForeignKey(
                        name: "FK_TaskTags_StudentTags_StudentTagId",
                        column: x => x.StudentTagId,
                        principalTable: "StudentTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskTags_StudentTasks_StudentTaskId",
                        column: x => x.StudentTaskId,
                        principalTable: "StudentTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskTags_StudentTagId",
                table: "TaskTags",
                column: "StudentTagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskTags");

            migrationBuilder.AlterColumn<string>(
                name: "StudentName",
                table: "StudentTags",
                type: "varchar(50) CHARACTER SET utf8mb4",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
