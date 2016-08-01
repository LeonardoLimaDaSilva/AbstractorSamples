using System.Data.Entity.Migrations;

namespace AbstractorSamples.Persistence.EntityFramework.Contexts
{
    public sealed class ApplicationMigrationContextConfiguration : DbMigrationsConfiguration<ApplicationMigrationContext>
    {
        public ApplicationMigrationContextConfiguration()
        {
            // This configuration enables the automatic migration. 
            // It's a best practice use it only in development environment, or with extreme caution.
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}
