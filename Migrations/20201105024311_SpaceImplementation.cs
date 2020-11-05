using Microsoft.EntityFrameworkCore.Migrations;

namespace OrganizationDashboardAPI.Migrations
{
    public partial class SpaceImplementation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpaceId",
                table: "Commitments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Environments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Icon = table.Column<string>(maxLength: 20, nullable: true),
                    Color = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Environments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commitments_SpaceId",
                table: "Commitments",
                column: "SpaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commitments_Environments_SpaceId",
                table: "Commitments",
                column: "SpaceId",
                principalTable: "Environments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commitments_Environments_SpaceId",
                table: "Commitments");

            migrationBuilder.DropTable(
                name: "Environments");

            migrationBuilder.DropIndex(
                name: "IX_Commitments_SpaceId",
                table: "Commitments");

            migrationBuilder.DropColumn(
                name: "SpaceId",
                table: "Commitments");
        }
    }
}
