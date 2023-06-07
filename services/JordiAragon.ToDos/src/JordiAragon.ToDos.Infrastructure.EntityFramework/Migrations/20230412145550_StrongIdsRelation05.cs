﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JordiAragon.ToDos.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class StrongIdsRelation05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_Contributors_ContributorId",
                table: "ToDoItems");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_Contributors_ContributorId",
                table: "ToDoItems",
                column: "ContributorId",
                principalTable: "Contributors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_Contributors_ContributorId",
                table: "ToDoItems");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_Contributors_ContributorId",
                table: "ToDoItems",
                column: "ContributorId",
                principalTable: "Contributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
