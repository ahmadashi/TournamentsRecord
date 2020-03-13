using Microsoft.EntityFrameworkCore.Migrations;

namespace TR.DAL.Migrations
{
    public partial class addedTournamentStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusTournamentStatusId",
                table: "Tournaments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TournamentStatus",
                columns: table => new
                {
                    TournamentStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentStatus", x => x.TournamentStatusId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_TournamentStatus_StatusTournamentStatusId",
                table: "Tournaments");

            migrationBuilder.DropTable(
                name: "TournamentStatus");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_StatusTournamentStatusId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "StatusTournamentStatusId",
                table: "Tournaments");
        }
    }
}
