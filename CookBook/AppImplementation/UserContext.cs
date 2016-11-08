using AppInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppInterface;
using System.Data.Entity;
using AppModel;

namespace AppImplementation
{
    public class UserContext : DbContext
    {
        public UserContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<UserContext>(null);
        }

        public DbSet<Users> User { get; set; }
    }
}
