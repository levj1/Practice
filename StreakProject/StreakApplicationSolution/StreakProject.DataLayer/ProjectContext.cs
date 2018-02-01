using StreakProject.Model;
using System.Data.Entity;

namespace StreakProject.DataLayer
{
    public class ProjectContext: DbContext
    {
        public ProjectContext():base("DefaultConnection")
        {

        }

        public DbSet<Project> Project { get; set; }
    }
}
