using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PptkNew.Migrations
{
    public partial class CreateKontraks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransKegiatan_JenisPengadaan_JenisPengadaanId",
                table: "TransKegiatan");

            migrationBuilder.DropIndex(
                name: "IX_TransKegiatan_JenisPengadaanId",
                table: "TransKegiatan");

            migrationBuilder.DropColumn(
                name: "JenisPengadaanId",
                table: "TransKegiatan");

            migrationBuilder.AlterColumn<string>(
                name: "NPWP",
                table: "Penyedia",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Kontrak",
                columns: table => new
                {
                    KontrakId = table.Column<Guid>(type: "uuid", nullable: false),
                    TransKegiatanId = table.Column<long>(type: "bigint", nullable: false),
                    PenyediaId = table.Column<Guid>(type: "uuid", nullable: false),
                    NoKontrak = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    KodeRUP = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NilaiKontrak = table.Column<double>(type: "double precision", nullable: true),
                    NilaiKAK = table.Column<double>(type: "double precision", nullable: true),
                    NilaiRAB = table.Column<double>(type: "double precision", nullable: true),
                    NilaiHPS = table.Column<double>(type: "double precision", nullable: true),
                    TglMulai = table.Column<DateOnly>(type: "date", nullable: false),
                    TglBerakhir = table.Column<DateOnly>(type: "date", nullable: false),
                    JenisPengadaanId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontrak", x => x.KontrakId);
                    table.ForeignKey(
                        name: "FK_Kontrak_JenisPengadaan_JenisPengadaanId",
                        column: x => x.JenisPengadaanId,
                        principalTable: "JenisPengadaan",
                        principalColumn: "JenisPengadaanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kontrak_Penyedia_PenyediaId",
                        column: x => x.PenyediaId,
                        principalTable: "Penyedia",
                        principalColumn: "PenyediaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kontrak_TransKegiatan_TransKegiatanId",
                        column: x => x.TransKegiatanId,
                        principalTable: "TransKegiatan",
                        principalColumn: "TransKegiatanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kontrak_JenisPengadaanId",
                table: "Kontrak",
                column: "JenisPengadaanId");

            migrationBuilder.CreateIndex(
                name: "IX_Kontrak_PenyediaId",
                table: "Kontrak",
                column: "PenyediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kontrak_TransKegiatanId",
                table: "Kontrak",
                column: "TransKegiatanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kontrak");

            migrationBuilder.AddColumn<int>(
                name: "JenisPengadaanId",
                table: "TransKegiatan",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NPWP",
                table: "Penyedia",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransKegiatan_JenisPengadaanId",
                table: "TransKegiatan",
                column: "JenisPengadaanId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransKegiatan_JenisPengadaan_JenisPengadaanId",
                table: "TransKegiatan",
                column: "JenisPengadaanId",
                principalTable: "JenisPengadaan",
                principalColumn: "JenisPengadaanId");
        }
    }
}
