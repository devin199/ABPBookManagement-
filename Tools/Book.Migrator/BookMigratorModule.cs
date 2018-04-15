using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Book.EntityFramework;

namespace Book.Migrator
{
    [DependsOn(typeof(BookDataModule))]
    public class BookMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<BookDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}