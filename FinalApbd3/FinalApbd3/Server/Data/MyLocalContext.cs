using FinalApbd3.Server.DTO;
using Microsoft.EntityFrameworkCore;
using FinalApbd3.Shared.DTO;

namespace FinalApbd3.Server.Data
{
    public class MyLocalContext : DbContext
    {
        public MyLocalContext(DbContextOptions<MyLocalContext> options)
            : base(options)
        {

        }
        public DbSet<DataDTO> dataDTOs { get; set; }

        public DbSet<DailyOCDTO> dailyOCDTOs { get; set; }

        public DbSet<DataByTickerDto> dataByTickerDtos { get; set; }

        public DbSet<NewsDTO> newsDTOs { get; set; }
    }
}
