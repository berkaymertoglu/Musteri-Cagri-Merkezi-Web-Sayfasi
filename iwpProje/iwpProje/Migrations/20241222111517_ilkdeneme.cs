using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace iwpProje.Migrations
{
    /// <inheritdoc />
    public partial class ilkdeneme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "itirazkayitlari",
                columns: table => new
                {
                    itirazid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    asistanid = table.Column<string>(type: "text", nullable: false),
                    asistaninaciklamasi = table.Column<string>(type: "text", nullable: false),
                    takimliderinincevabi = table.Column<string>(type: "text", nullable: false),
                    durumid = table.Column<int>(type: "integer", nullable: false),
                    itirazakonuay = table.Column<string>(type: "text", nullable: false),
                    ilgilitakimlideri = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itirazkayitlari", x => x.itirazid);
                });

            migrationBuilder.CreateTable(
                name: "mustericagrikayitlari",
                columns: table => new
                {
                    cagriid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    asistansicil = table.Column<string>(type: "text", nullable: false),
                    gorusmekonusuid = table.Column<int>(type: "integer", nullable: false),
                    gorusmetarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    gorusmedurumid = table.Column<int>(type: "integer", nullable: false),
                    musteriid = table.Column<string>(type: "text", nullable: false),
                    baslamasaati = table.Column<TimeSpan>(type: "interval", nullable: false),
                    bitissaati = table.Column<TimeSpan>(type: "interval", nullable: false),
                    cagrisuresi = table.Column<int>(type: "integer", nullable: false),
                    ogunkucagrisayisi = table.Column<int>(type: "integer", nullable: false),
                    urettigiprim = table.Column<double>(type: "double precision", nullable: false),
                    musteriadi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mustericagrikayitlari", x => x.cagriid);
                });

            migrationBuilder.CreateTable(
                name: "musteriler",
                columns: table => new
                {
                    musteriid = table.Column<string>(type: "text", nullable: false),
                    musteriadi = table.Column<string>(type: "text", nullable: false),
                    musteritel = table.Column<string>(type: "text", nullable: false),
                    musteriadres = table.Column<string>(type: "text", nullable: false),
                    musteriemail = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musteriler", x => x.musteriid);
                });

            migrationBuilder.CreateTable(
                name: "oturumacmiskullanicilar",
                columns: table => new
                {
                    oturumid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    personelid = table.Column<string>(type: "text", nullable: false),
                    oturumbaslangiczamani = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oturumacmiskullanicilar", x => x.oturumid);
                });

            migrationBuilder.CreateTable(
                name: "sistemkullanicilari",
                columns: table => new
                {
                    eposta = table.Column<string>(type: "text", nullable: false),
                    sifre = table.Column<string>(type: "text", nullable: false),
                    personelid = table.Column<string>(type: "text", nullable: true),
                    personeladi = table.Column<string>(type: "text", nullable: true),
                    personelsoyadi = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itirazkayitlari");

            migrationBuilder.DropTable(
                name: "mustericagrikayitlari");

            migrationBuilder.DropTable(
                name: "musteriler");

            migrationBuilder.DropTable(
                name: "oturumacmiskullanicilar");

            migrationBuilder.DropTable(
                name: "sistemkullanicilari");
        }
    }
}
