using Microsoft.EntityFrameworkCore.Migrations;

namespace JWS.Data.Migrations
{
    public partial class AddInvestHighestPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "HighestPrice",
                table: "FundInvestments",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighestPrice",
                table: "FundInvestments");
        }
    }
}
