using Microsoft.EntityFrameworkCore.Migrations;

namespace OrganizationDashboardAPI.Migrations
{
    public partial class SpaceImplementationCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commitments_Environments_SpaceId",
                table: "Commitments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Environments",
                table: "Environments");

            migrationBuilder.RenameTable(
                name: "Environments",
                newName: "Spaces");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Spaces",
                table: "Spaces",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commitments_Spaces_SpaceId",
                table: "Commitments",
                column: "SpaceId",
                principalTable: "Spaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commitments_Spaces_SpaceId",
                table: "Commitments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Spaces",
                table: "Spaces");

            migrationBuilder.RenameTable(
                name: "Spaces",
                newName: "Environments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Environments",
                table: "Environments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commitments_Environments_SpaceId",
                table: "Commitments",
                column: "SpaceId",
                principalTable: "Environments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
