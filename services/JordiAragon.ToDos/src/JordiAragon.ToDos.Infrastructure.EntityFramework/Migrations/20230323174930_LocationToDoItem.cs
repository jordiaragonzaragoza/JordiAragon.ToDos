using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JordiAragon.ToDos.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class LocationToDoItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location_Address",
                table: "ToDoItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Location_Coordinates_Latitude_Value",
                table: "ToDoItems",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Location_Coordinates_Longitude_Value",
                table: "ToDoItems",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location_Name",
                table: "ToDoItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location_Address",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "Location_Coordinates_Latitude_Value",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "Location_Coordinates_Longitude_Value",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "Location_Name",
                table: "ToDoItems");
        }
    }
}
