using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TK_Project.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class removed_capabilities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapabilityRole");

            migrationBuilder.DropTable(
                name: "Capabilities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Capabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capabilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CapabilityRole",
                columns: table => new
                {
                    CapabilitiesId = table.Column<int>(type: "int", nullable: false),
                    RolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapabilityRole", x => new { x.CapabilitiesId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_CapabilityRole_Capabilities_CapabilitiesId",
                        column: x => x.CapabilitiesId,
                        principalTable: "Capabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapabilityRole_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CapabilityRole_RolesId",
                table: "CapabilityRole",
                column: "RolesId");
        }
    }
}
