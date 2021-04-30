using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTracker.Migrations
{
    public partial class AddTaskTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "TaskTags",
               columns: table => new
               {
                   StudentTaskId = table.Column<int>(type: "int", nullable: false),
                   StudentTagId = table.Column<int>(type: "int", nullable: false),
                   Name = table.Column<string>(nullable: true),
                   Description = table.Column<string>(nullable: true),
                   DueDate = table.Column<DateTime>(nullable: false),
                   SubmitDate = table.Column<DateTime>(nullable: false),
                   ApproveDate = table.Column<DateTime>(nullable: false),
                   Approved = table.Column<bool>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_TaskTags", x => new { x.StudentTaskId, x.StudentTagId });
                   table.ForeignKey(
                       name: "FK_TaskTags_StudentTasks_StudentTaskId",
                       column: x => x.StudentTaskId,
                       principalTable: "StudentTasks",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                       name: "FK_TaskTags_StudentTags_StudentTagId",
                       column: x => x.StudentTagId,
                       principalTable: "StudentTags",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "TaskTags");
        }
    }
}
