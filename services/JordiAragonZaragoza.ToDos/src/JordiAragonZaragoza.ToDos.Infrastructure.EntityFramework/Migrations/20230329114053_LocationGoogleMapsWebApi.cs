using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JordiAragonZaragoza.ToDos.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class LocationGoogleMapsWebApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location_Name",
                table: "ToDoItems",
                newName: "Location_RegionCode");

            migrationBuilder.AddColumn<string>(
                name: "Location_CountryCode",
                table: "ToDoItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location_Locality",
                table: "ToDoItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location_PostalCode",
                table: "ToDoItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location_CountryCode",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "Location_Locality",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "Location_PostalCode",
                table: "ToDoItems");

            migrationBuilder.RenameColumn(
                name: "Location_RegionCode",
                table: "ToDoItems",
                newName: "Location_Name");
        }
    }
}
