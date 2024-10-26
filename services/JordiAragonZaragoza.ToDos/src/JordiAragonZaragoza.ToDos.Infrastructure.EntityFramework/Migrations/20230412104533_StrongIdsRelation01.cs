using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JordiAragonZaragoza.ToDos.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class StrongIdsRelation01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_Projects_ProjectId1",
                table: "ToDoItems");

            migrationBuilder.DropIndex(
                name: "IX_ToDoItems_ProjectId1",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "ToDoItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId1",
                table: "ToDoItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_ProjectId1",
                table: "ToDoItems",
                column: "ProjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_Projects_ProjectId1",
                table: "ToDoItems",
                column: "ProjectId1",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
