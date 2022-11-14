using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace spinningwheel.Migrations
{
    /// <inheritdoc />
    public partial class segmentimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "wheelSegments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "wheelSegments");
        }
    }
}
