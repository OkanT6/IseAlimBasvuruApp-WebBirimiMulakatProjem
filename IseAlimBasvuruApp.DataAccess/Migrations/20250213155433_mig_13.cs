using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IseAlimBasvuruApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ilanlar_IsYeriLokasyonId",
                table: "Ilanlar");

            migrationBuilder.CreateIndex(
                name: "IX_Ilanlar_IsYeriLokasyonId",
                table: "Ilanlar",
                column: "IsYeriLokasyonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ilanlar_IsYeriLokasyonId",
                table: "Ilanlar");

            migrationBuilder.CreateIndex(
                name: "IX_Ilanlar_IsYeriLokasyonId",
                table: "Ilanlar",
                column: "IsYeriLokasyonId",
                unique: true);
        }
    }
}
