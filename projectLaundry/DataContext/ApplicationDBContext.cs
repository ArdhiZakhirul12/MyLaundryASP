using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using projectLaundry.Models;

namespace projectLaundry.DataContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base(nameOrConnectionString: "MyConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<custClass> custobj {get; set;}
        public virtual DbSet<adminClass> adminobj { get; set; }
        public virtual DbSet<paketClass> paketobj { get; set; }
        public virtual DbSet<transaksiClass> transaksiobj { get; set; }

    }
}