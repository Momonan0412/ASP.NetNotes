using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppDev.API.Migrations
{
    /// <inheritdoc />
    public partial class fifthmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Waypoints",
                columns: table => new
                {
                    WaypointId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WaypointName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    WaypointType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PointX = table.Column<int>(type: "int", nullable: false),
                    PointY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waypoints", x => x.WaypointId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Waypoints");
        }
    }
}
