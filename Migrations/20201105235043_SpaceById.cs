using Microsoft.EntityFrameworkCore.Migrations;

namespace OrganizationDashboardAPI.Migrations
{
    public partial class SpaceById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commitments_Spaces_SpaceId",
                table: "Commitments");

            migrationBuilder.AlterColumn<int>(
                name: "SpaceId",
                table: "Commitments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Commitments_Spaces_SpaceId",
                table: "Commitments",
                column: "SpaceId",
                principalTable: "Spaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commitments_Spaces_SpaceId",
                table: "Commitments");

            migrationBuilder.AlterColumn<int>(
                name: "SpaceId",
                table: "Commitments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Commitments_Spaces_SpaceId",
                table: "Commitments",
                column: "SpaceId",
                principalTable: "Spaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
