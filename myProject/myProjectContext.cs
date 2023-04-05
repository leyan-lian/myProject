using myProject.Models;
using myProject.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace myProject
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class myProjectContext: DbContext
    {
        static myProjectContext()
        {
            Database.SetInitializer<myProjectContext>(null);
        }
        public myProjectContext()
            : base("Name=myProjectContext")
        {
            Database.SetInitializer<myProjectContext>(null);
        }
        public DbSet<hradmin> hradmin { get; set; }
        public DbSet<hremp> hremp { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new hradminMap());
            modelBuilder.Configurations.Add(new hrempMap());
        }
    }
}