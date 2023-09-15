using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Google.YouTube.EntityFrameworkCore
{
    public static class YouTubeDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<YouTubeDbContext> builder, string connectionString)
        {
            //builder.UseSqlServer(connectionString);
            builder.UseSqlite(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<YouTubeDbContext> builder, DbConnection connection)
        {
            //builder.UseSqlServer(connection);
            builder.UseSqlite(connection);
        }
    }
}