using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalApbd3.Server.Migrations.MyLocal
{
    public partial class MyLocalInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dailyOCDTOs",
                columns: table => new
                {
                    symbol = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    from = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    open = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    high = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    low = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    close = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    volume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    afterHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    preMarket = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dailyOCDTOs", x => x.symbol);
                });

            migrationBuilder.CreateTable(
                name: "dataByTickerDtos",
                columns: table => new
                {
                    ticker = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    market = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    locale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    primary_exchange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currency_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    composite_figi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    share_class_figi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    market_cap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sic_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sic_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ticker_root = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    homepage_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_employees = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    list_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    share_class_shares_outstanding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    weighted_shares_outstanding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    logo_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dataByTickerDtos", x => x.ticker);
                });

            migrationBuilder.CreateTable(
                name: "dataDTOs",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    c = table.Column<float>(type: "real", nullable: false),
                    h = table.Column<float>(type: "real", nullable: false),
                    l = table.Column<float>(type: "real", nullable: false),
                    n = table.Column<float>(type: "real", nullable: false),
                    o = table.Column<float>(type: "real", nullable: false),
                    t = table.Column<long>(type: "bigint", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    v = table.Column<long>(type: "bigint", nullable: false),
                    vw = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dataDTOs", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "newsDTOs",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    published_utc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newsDTOs", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dailyOCDTOs");

            migrationBuilder.DropTable(
                name: "dataByTickerDtos");

            migrationBuilder.DropTable(
                name: "dataDTOs");

            migrationBuilder.DropTable(
                name: "newsDTOs");
        }
    }
}
