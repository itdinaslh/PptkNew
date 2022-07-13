using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PptkNew.Migrations
{
    public partial class CreateUserSkpd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubKegiatan_Kegiatan_KegiatanId",
                table: "SubKegiatan");

            migrationBuilder.AlterColumn<int>(
                name: "KegiatanId",
                table: "SubKegiatan",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "UserSkpd",
                columns: table => new
                {
                    UserSkpdId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkpdId = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkpd", x => x.UserSkpdId);
                    table.ForeignKey(
                        name: "FK_UserSkpd_Skpd_SkpdId",
                        column: x => x.SkpdId,
                        principalTable: "Skpd",
                        principalColumn: "SkpdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSkpd_SkpdId",
                table: "UserSkpd",
                column: "SkpdId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubKegiatan_Kegiatan_KegiatanId",
                table: "SubKegiatan",
                column: "KegiatanId",
                principalTable: "Kegiatan",
                principalColumn: "KegiatanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubKegiatan_Kegiatan_KegiatanId",
                table: "SubKegiatan");

            migrationBuilder.DropTable(
                name: "UserSkpd");

            migrationBuilder.AlterColumn<int>(
                name: "KegiatanId",
                table: "SubKegiatan",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubKegiatan_Kegiatan_KegiatanId",
                table: "SubKegiatan",
                column: "KegiatanId",
                principalTable: "Kegiatan",
                principalColumn: "KegiatanId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
