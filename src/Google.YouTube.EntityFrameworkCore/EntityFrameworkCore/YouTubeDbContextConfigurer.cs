using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Google.YouTube.EntityFrameworkCore
{
    public static class YouTubeDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<YouTubeDbContext> builder, string connectionString)
        {
            //builder.UseSqlServer(connectionString);
            builder.UseMySql(connectionString, new MariaDbServerVersion(new Version(10, 11, 5)));
        }

        public static void Configure(DbContextOptionsBuilder<YouTubeDbContext> builder, DbConnection connection)
        {
            //builder.UseSqlServer(connection);
            builder.UseMySql(connection, new MariaDbServerVersion(new Version(10, 11, 5)));
        }
    }
}