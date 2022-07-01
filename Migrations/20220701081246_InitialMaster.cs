using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PptkNew.Migrations
{
    public partial class InitialMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JenisPengadaan",
                columns: table => new
                {
                    JenisPengadaanId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaJenis = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisPengadaan", x => x.JenisPengadaanId);
                });

            migrationBuilder.CreateTable(
                name: "Kegiatan",
                columns: table => new
                {
                    KegiatanId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KodeKegiatan = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    NamaKegiatan = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kegiatan", x => x.KegiatanId);
                });

            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    ProgramId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KodeProgram = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    NamaProgram = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.ProgramId);
                });

            migrationBuilder.CreateTable(
                name: "Rekening",
                columns: table => new
                {
                    RekeningId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KodeRekening = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NamaRekening = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rekening", x => x.RekeningId);
                });

            migrationBuilder.CreateTable(
                name: "Skpd",
                columns: table => new
                {
                    SkpdId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SkpdCode = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    SkpdName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    NamaPimpinan = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skpd", x => x.SkpdId);
                });

            migrationBuilder.CreateTable(
                name: "SubKegiatan",
                columns: table => new
                {
                    SubKegiatanId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KodeSubKegiatan = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    NamaSubKegiatan = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubKegiatan", x => x.SubKegiatanId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kegiatan_KodeKegiatan",
                table: "Kegiatan",
                column: "KodeKegiatan",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Program_KodeProgram",
                table: "Program",
                column: "KodeProgram",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rekening_KodeRekening",
                table: "Rekening",
                column: "KodeRekening",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skpd_SkpdCode",
                table: "Skpd",
                column: "SkpdCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubKegiatan_KodeSubKegiatan",
                table: "SubKegiatan",
                column: "KodeSubKegiatan",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JenisPengadaan");

            migrationBuilder.DropTable(
                name: "Kegiatan");

            migrationBuilder.DropTable(
                name: "Program");

            migrationBuilder.DropTable(
                name: "Rekening");

            migrationBuilder.DropTable(
                name: "Skpd");

            migrationBuilder.DropTable(
                name: "SubKegiatan");
        }
    }
}
