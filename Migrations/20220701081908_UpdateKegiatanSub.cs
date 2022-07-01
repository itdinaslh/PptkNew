using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PptkNew.Migrations
{
    public partial class UpdateKegiatanSub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KegiatanId",
                table: "SubKegiatan",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SubKegiatan_KegiatanId",
                table: "SubKegiatan",
                column: "KegiatanId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubKegiatan_Kegiatan_KegiatanId",
                table: "SubKegiatan",
                column: "KegiatanId",
                principalTable: "Kegiatan",
                principalColumn: "KegiatanId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubKegiatan_Kegiatan_KegiatanId",
                table: "SubKegiatan");

            migrationBuilder.DropIndex(
                name: "IX_SubKegiatan_KegiatanId",
                table: "SubKegiatan");

            migrationBuilder.DropColumn(
                name: "KegiatanId",
                table: "SubKegiatan");
        }
    }
}
