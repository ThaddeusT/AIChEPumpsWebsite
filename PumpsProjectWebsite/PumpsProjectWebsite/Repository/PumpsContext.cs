using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PumpsProjectWebsite.Models;

namespace PumpsProjectWebsite.Repository
{
    public class PumpsContext : DbContext
    {

        public PumpsContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<TimeLog> TimeLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
