using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JordiAragon.ToDos.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class StrongIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId1",
                table: "ToDoItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Accounts",
                type: "nvarchar(320)",
                maxLength: 320,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_ContributorId",
                table: "ToDoItems",
                column: "ContributorId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_ProjectId1",
                table: "ToDoItems",
                column: "ProjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Email",
                table: "Accounts",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_Contributors_ContributorId",
                table: "ToDoItems",
                column: "ContributorId",
                principalTable: "Contributors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_Projects_ProjectId1",
                table: "ToDoItems",
                column: "ProjectId1",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_Contributors_ContributorId",
                table: "ToDoItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_Projects_ProjectId1",
                table: "ToDoItems");

            migrationBuilder.DropIndex(
                name: "IX_ToDoItems_ContributorId",
                table: "ToDoItems");

            migrationBuilder.DropIndex(
                name: "IX_ToDoItems_ProjectId1",
                table: "ToDoItems");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_Email",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "ToDoItems");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(320)",
                oldMaxLength: 320);
        }
    }
}
