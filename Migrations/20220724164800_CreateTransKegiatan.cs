using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PptkNew.Migrations
{
    public partial class CreateTransKegiatan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransKegiatan",
                columns: table => new
                {
                    TransKegiatanId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SkpdId = table.Column<int>(type: "integer", nullable: false),
                    ProgId = table.Column<int>(type: "integer", nullable: false),
                    SubKegiatanId = table.Column<int>(type: "integer", nullable: false),
                    KodePASK = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Penjabaran = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    RekeningId = table.Column<int>(type: "integer", nullable: false),
                    Anggaran = table.Column<double>(type: "double precision", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    JenisPengadaanId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransKegiatan", x => x.TransKegiatanId);
                    table.ForeignKey(
                        name: "FK_TransKegiatan_JenisPengadaan_JenisPengadaanId",
                        column: x => x.JenisPengadaanId,
                        principalTable: "JenisPengadaan",
                        principalColumn: "JenisPengadaanId");
                    table.ForeignKey(
                        name: "FK_TransKegiatan_Program_ProgId",
                        column: x => x.ProgId,
                        principalTable: "Program",
                        principalColumn: "ProgramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransKegiatan_Rekening_RekeningId",
                        column: x => x.RekeningId,
                        principalTable: "Rekening",
                        principalColumn: "RekeningId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransKegiatan_Skpd_SkpdId",
                        column: x => x.SkpdId,
                        principalTable: "Skpd",
                        principalColumn: "SkpdId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransKegiatan_SubKegiatan_SubKegiatanId",
                        column: x => x.SubKegiatanId,
                        principalTable: "SubKegiatan",
                        principalColumn: "SubKegiatanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransKegiatan_JenisPengadaanId",
                table: "TransKegiatan",
                column: "JenisPengadaanId");

            migrationBuilder.CreateIndex(
                name: "IX_TransKegiatan_ProgId",
                table: "TransKegiatan",
                column: "ProgId");

            migrationBuilder.CreateIndex(
                name: "IX_TransKegiatan_RekeningId",
                table: "TransKegiatan",
                column: "RekeningId");

            migrationBuilder.CreateIndex(
                name: "IX_TransKegiatan_SkpdId",
                table: "TransKegiatan",
                column: "SkpdId");

            migrationBuilder.CreateIndex(
                name: "IX_TransKegiatan_SubKegiatanId",
                table: "TransKegiatan",
                column: "SubKegiatanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransKegiatan");
        }
    }
}
