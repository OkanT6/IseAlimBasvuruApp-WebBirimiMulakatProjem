using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IseAlimBasvuruApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArananCinsiyet",
                table: "Ilanlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArananCinsiyet",
                table: "Ilanlar");

            
        }
    }
}
