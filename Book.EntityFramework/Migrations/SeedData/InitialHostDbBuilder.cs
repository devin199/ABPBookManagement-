using Book.EntityFramework;
using EntityFramework.DynamicFilters;

namespace Book.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly BookDbContext _context;

        public InitialHostDbBuilder(BookDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
