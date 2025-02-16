using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IseAlimBasvuruApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilFoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.KullaniciId);
                });

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RolTanimi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Ilanlar",
                columns: table => new
                {
                    IlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlanBaslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IlanYayinlanmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IlanAktif = table.Column<bool>(type: "bit", nullable: false),
                    IlanIsTanimi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YoneticiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilanlar", x => x.IlanId);
                    table.ForeignKey(
                        name: "FK_Ilanlar_Kullanicilar_YoneticiId",
                        column: x => x.YoneticiId,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciBecerileri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    BeceriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciBecerileri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KullaniciBecerileri_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciDeneyimleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    IsPozisyonu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalismaTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsYeriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaslamaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AyrilmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Konum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KonumTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsTanimi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciDeneyimleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KullaniciDeneyimleri_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciEgitimBilgileri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    OkulAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiplomaTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotOrtalamasiTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotOrtalamasi = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciEgitimBilgileri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KullaniciEgitimBilgileri_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciIletisimBilgileri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciIletisimBilgileri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KullaniciIletisimBilgileri_Kullanicilar_Id",
                        column: x => x.Id,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciRolleri",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciRolleri", x => new { x.KullaniciId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_KullaniciRolleri_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullaniciRolleri_Roller_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roller",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Basvurular",
                columns: table => new
                {
                    IlanId = table.Column<int>(type: "int", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    BasvuruId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basvurular", x => new { x.IlanId, x.KullaniciId });
                    table.UniqueConstraint("AK_Basvurular_BasvuruId", x => x.BasvuruId);
                    table.ForeignKey(
                        name: "FK_Basvurular_Ilanlar_IlanId",
                        column: x => x.IlanId,
                        principalTable: "Ilanlar",
                        principalColumn: "IlanId");
                    table.ForeignKey(
                        name: "FK_Basvurular_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciId");
                });

            migrationBuilder.CreateTable(
                name: "Degerlendirmeler",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    BasvuruId = table.Column<int>(type: "int", nullable: false),
                    Puan = table.Column<int>(type: "int", nullable: false),
                    Rapor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasvuruIlanId = table.Column<int>(type: "int", nullable: true),
                    BasvuruKullaniciId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degerlendirmeler", x => new { x.BasvuruId, x.KullaniciId });
                    table.ForeignKey(
                        name: "FK_Degerlendirmeler_Basvurular_BasvuruId",
                        column: x => x.BasvuruId,
                        principalTable: "Basvurular",
                        principalColumn: "BasvuruId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Degerlendirmeler_Basvurular_BasvuruIlanId_BasvuruKullaniciId",
                        columns: x => new { x.BasvuruIlanId, x.BasvuruKullaniciId },
                        principalTable: "Basvurular",
                        principalColumns: new[] { "IlanId", "KullaniciId" });
                    table.ForeignKey(
                        name: "FK_Degerlendirmeler_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dosyalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasvuruId = table.Column<int>(type: "int", nullable: false),
                    DosyaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosyalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dosyalar_Basvurular_BasvuruId",
                        column: x => x.BasvuruId,
                        principalTable: "Basvurular",
                        principalColumn: "BasvuruId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Referanslar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasvuruId = table.Column<int>(type: "int", nullable: false),
                    ReferansTanimi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referanslar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referanslar_Basvurular_BasvuruId",
                        column: x => x.BasvuruId,
                        principalTable: "Basvurular",
                        principalColumn: "BasvuruId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sertifikalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasvuruId = table.Column<int>(type: "int", nullable: false),
                    DosyaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sertifikalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sertifikalar_Basvurular_BasvuruId",
                        column: x => x.BasvuruId,
                        principalTable: "Basvurular",
                        principalColumn: "BasvuruId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Basvurular_KullaniciId",
                table: "Basvurular",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Degerlendirmeler_BasvuruIlanId_BasvuruKullaniciId",
                table: "Degerlendirmeler",
                columns: new[] { "BasvuruIlanId", "BasvuruKullaniciId" });

            migrationBuilder.CreateIndex(
                name: "IX_Degerlendirmeler_KullaniciId",
                table: "Degerlendirmeler",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Dosyalar_BasvuruId",
                table: "Dosyalar",
                column: "BasvuruId");

            migrationBuilder.CreateIndex(
                name: "IX_Ilanlar_YoneticiId",
                table: "Ilanlar",
                column: "YoneticiId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciBecerileri_KullaniciId",
                table: "KullaniciBecerileri",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciDeneyimleri_KullaniciId",
                table: "KullaniciDeneyimleri",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciEgitimBilgileri_KullaniciId",
                table: "KullaniciEgitimBilgileri",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciRolleri_RoleId",
                table: "KullaniciRolleri",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Referanslar_BasvuruId",
                table: "Referanslar",
                column: "BasvuruId");

            migrationBuilder.CreateIndex(
                name: "IX_Sertifikalar_BasvuruId",
                table: "Sertifikalar",
                column: "BasvuruId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Degerlendirmeler");

            migrationBuilder.DropTable(
                name: "Dosyalar");

            migrationBuilder.DropTable(
                name: "KullaniciBecerileri");

            migrationBuilder.DropTable(
                name: "KullaniciDeneyimleri");

            migrationBuilder.DropTable(
                name: "KullaniciEgitimBilgileri");

            migrationBuilder.DropTable(
                name: "KullaniciIletisimBilgileri");

            migrationBuilder.DropTable(
                name: "KullaniciRolleri");

            migrationBuilder.DropTable(
                name: "Referanslar");

            migrationBuilder.DropTable(
                name: "Sertifikalar");

            migrationBuilder.DropTable(
                name: "Roller");

            migrationBuilder.DropTable(
                name: "Basvurular");

            migrationBuilder.DropTable(
                name: "Ilanlar");

            migrationBuilder.DropTable(
                name: "Kullanicilar");
        }
    }
}
