using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JordiAragon.ToDos.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contributors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreationDateOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDateOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutboxMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOccurredOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateProcessedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Error = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessages", x => x.Id);
                });

            // Value Objects modified manually due to: https://github.com/dotnet/EntityFramework.Docs/issues/3750
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ColorRValue = table.Column<int>(name: "Color_R_Value", type: "int", nullable: false),
                    ColorGValue = table.Column<int>(name: "Color_G_Value", type: "int", nullable: false),
                    ColorBValue = table.Column<int>(name: "Color_B_Value", type: "int", nullable: false),
                    CreationDateOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDateOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            // Value Objects modified manually due to: https://github.com/dotnet/EntityFramework.Docs/issues/3750
            migrationBuilder.CreateTable(
                name: "ToDoItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ExpirationDateOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContributorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDateOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDateOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoItems_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_ProjectId",
                table: "ToDoItems",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contributors");

            migrationBuilder.DropTable(
                name: "OutboxMessages");

            migrationBuilder.DropTable(
                name: "ToDoItems");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
