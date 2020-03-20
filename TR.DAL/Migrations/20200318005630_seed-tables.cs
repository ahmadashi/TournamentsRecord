using Microsoft.EntityFrameworkCore.Migrations;

namespace TR.DAL.Migrations
{
    public partial class seedtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "TournamentStatus",
                columns: new[] { "TournamentStatusId", "Description" },
                values: new object[,]
                {
                    { 1, "Registered" },
                    { 2, "In-progress" },
                    { 3, "Suspended" },
                    { 4, "Finished" }
                });


            migrationBuilder.InsertData(
                table: "RoleType",
                columns: new[] { "RoleTypeId", "Description" },
                values: new object[,]
                {
                    { 1, "Head Of Coaches" },
                    { 2, "Coach" },
                    { 3, "Coach Assestance" },
                    { 4, "Team Manager" },
                    { 5, "Fitness Trainer" }
                });


            migrationBuilder.InsertData(
                table: "SportType",
                columns: new[] { "SportTypeId", "Description" },
                values: new object[,]
                {
                    { 1, "Soccer" },
                    { 2, "Tennis" },
                    { 3, "TableTennis" },
                    { 4, "Basketball" },

                });

            migrationBuilder.InsertData(
                table: "TournamentType",
                columns: new[] { "TournamentTypeId", "Description" },
                values: new object[,]
                {
                    { 1, "Tournament (Playoff)" },
                    { 2, "One Leg League" },
                    { 3, "Two Legs Leage" },
                });


            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "UserTypeId", "Description" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" },                    
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
