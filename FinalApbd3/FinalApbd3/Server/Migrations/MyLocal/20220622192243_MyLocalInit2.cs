using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalApbd3.Server.Migrations.MyLocal
{
    public partial class MyLocalInit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_dataDTOs",
                table: "dataDTOs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "dataDTOs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dataDTOs",
                table: "dataDTOs",
                column: "h");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_dataDTOs",
                table: "dataDTOs");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "dataDTOs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dataDTOs",
                table: "dataDTOs",
                column: "Name");
        }
    }
}
