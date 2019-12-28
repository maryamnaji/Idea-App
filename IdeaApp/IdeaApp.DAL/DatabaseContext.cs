using IdeaApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaApp.DAL
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext() :base("name=connectionString")
        {
                
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
