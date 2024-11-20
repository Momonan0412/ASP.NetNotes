using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppDev.API.Migrations
{
    /// <inheritdoc />
    public partial class sixthmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Waypoints_WaypointName",
                table: "Waypoints",
                column: "WaypointName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Waypoints_WaypointName",
                table: "Waypoints");
        }
    }
}
