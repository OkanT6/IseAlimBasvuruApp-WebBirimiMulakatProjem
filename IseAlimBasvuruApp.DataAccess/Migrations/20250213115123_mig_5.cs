using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IseAlimBasvuruApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IlanIsTanimiUzun",
                table: "Ilanlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IsYeriLokasyonId",
                table: "Ilanlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "IsYeriLokasyonlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfisAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ulke = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sehir = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsYeriLokasyonlari", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ilanlar_IsYeriLokasyonId",
                table: "Ilanlar",
                column: "IsYeriLokasyonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ilanlar_IsYeriLokasyonlari_IsYeriLokasyonId",
                table: "Ilanlar",
                column: "IsYeriLokasyonId",
                principalTable: "IsYeriLokasyonlari",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ilanlar_IsYeriLokasyonlari_IsYeriLokasyonId",
                table: "Ilanlar");

            migrationBuilder.DropTable(
                name: "IsYeriLokasyonlari");

            migrationBuilder.DropIndex(
                name: "IX_Ilanlar_IsYeriLokasyonId",
                table: "Ilanlar");

            migrationBuilder.DropColumn(
                name: "IlanIsTanimiUzun",
                table: "Ilanlar");

            migrationBuilder.DropColumn(
                name: "IsYeriLokasyonId",
                table: "Ilanlar");
        }
    }
}
