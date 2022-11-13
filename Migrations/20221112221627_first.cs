using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace spinningwheel.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "spinningWheels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spinningWheels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "wheelSegments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpinningWheelId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wheelSegments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_wheelSegments_spinningWheels_SpinningWheelId",
                        column: x => x.SpinningWheelId,
                        principalTable: "spinningWheels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_spinningWheels_Name",
                table: "spinningWheels",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_wheelSegments_SpinningWheelId",
                table: "wheelSegments",
                column: "SpinningWheelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "wheelSegments");

            migrationBuilder.DropTable(
                name: "spinningWheels");
        }
    }
}
