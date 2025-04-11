using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpeechToTextProject.DataAccessLayer.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AudioId",
                table: "Transcriptions",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transcriptions_AudioId",
                table: "Transcriptions",
                column: "AudioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transcriptions_Audios_AudioId",
                table: "Transcriptions",
                column: "AudioId",
                principalTable: "Audios",
                principalColumn: "AudioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transcriptions_Audios_AudioId",
                table: "Transcriptions");

            migrationBuilder.DropIndex(
                name: "IX_Transcriptions_AudioId",
                table: "Transcriptions");

            migrationBuilder.DropColumn(
                name: "AudioId",
                table: "Transcriptions");
        }
    }
}
