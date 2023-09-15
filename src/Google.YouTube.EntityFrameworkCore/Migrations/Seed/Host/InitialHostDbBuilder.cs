using Google.YouTube.EntityFrameworkCore;

namespace Google.YouTube.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly YouTubeDbContext _context;

        public InitialHostDbBuilder(YouTubeDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
