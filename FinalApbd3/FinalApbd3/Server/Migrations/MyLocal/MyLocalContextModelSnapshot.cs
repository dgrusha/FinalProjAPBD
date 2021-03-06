// <auto-generated />
using System;
using FinalApbd3.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinalApbd3.Server.Migrations.MyLocal
{
    [DbContext(typeof(MyLocalContext))]
    partial class MyLocalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FinalApbd3.Server.DTO.DailyOCDTO", b =>
                {
                    b.Property<string>("symbol")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("afterHours")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("close")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("from")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("high")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("low")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("open")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("preMarket")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("volume")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("symbol");

                    b.ToTable("dailyOCDTOs");
                });

            modelBuilder.Entity("FinalApbd3.Server.DTO.DataByTickerDto", b =>
                {
                    b.Property<string>("ticker")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("active")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("composite_figi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("currency_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("homepage_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("list_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("locale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("logo_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("market")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("market_cap")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone_number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("primary_exchange")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("share_class_figi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("share_class_shares_outstanding")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sic_code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sic_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ticker_root")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("total_employees")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("weighted_shares_outstanding")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ticker");

                    b.ToTable("dataByTickerDtos");
                });

            modelBuilder.Entity("FinalApbd3.Server.DTO.DataDTO", b =>
                {
                    b.Property<float>("h")
                        .HasColumnType("real");

                    b.Property<float>("c")
                        .HasColumnType("real");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<float>("l")
                        .HasColumnType("real");

                    b.Property<float>("n")
                        .HasColumnType("real");

                    b.Property<float>("o")
                        .HasColumnType("real");

                    b.Property<long>("t")
                        .HasColumnType("bigint");

                    b.Property<long>("v")
                        .HasColumnType("bigint");

                    b.Property<float>("vw")
                        .HasColumnType("real");

                    b.HasKey("h");

                    b.ToTable("dataDTOs");
                });

            modelBuilder.Entity("FinalApbd3.Server.DTO.NewsDTO", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("published_utc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("newsDTOs");
                });
#pragma warning restore 612, 618
        }
    }
}
