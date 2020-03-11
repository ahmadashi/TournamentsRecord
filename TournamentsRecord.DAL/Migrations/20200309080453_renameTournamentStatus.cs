using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentsRecord.DAL.Migrations
{
    public partial class renameTournamentStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_TournamentStatus_StatusTournamentStatusId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_StatusTournamentStatusId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "StatusTournamentStatusId",
                table: "Tournaments");

            migrationBuilder.AddColumn<int>(
                name: "TournamentStatusId",
                table: "Tournaments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_TournamentStatusId",
                table: "Tournaments",
                column: "TournamentStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_TournamentStatus_TournamentStatusId",
                table: "Tournaments",
                column: "TournamentStatusId",
                principalTable: "TournamentStatus",
                principalColumn: "TournamentStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_TournamentStatus_TournamentStatusId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_TournamentStatusId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "TournamentStatusId",
                table: "Tournaments");

            migrationBuilder.AddColumn<int>(
                name: "StatusTournamentStatusId",
                table: "Tournaments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_StatusTournamentStatusId",
                table: "Tournaments",
                column: "StatusTournamentStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_TournamentStatus_StatusTournamentStatusId",
                table: "Tournaments",
                column: "StatusTournamentStatusId",
                principalTable: "TournamentStatus",
                principalColumn: "TournamentStatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
