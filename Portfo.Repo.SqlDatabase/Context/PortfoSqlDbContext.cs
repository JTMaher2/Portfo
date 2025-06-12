using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Portfo.Repo.SqlDatabase.DTO;

namespace Portfo.Repo.SqlDatabase.Context
{
    public partial class PortfoSqlDbContext : DbContext
    {
        public PortfoSqlDbContext()
        {
        }

        public PortfoSqlDbContext(DbContextOptions<PortfoSqlDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User>? Users { get; set; }
        public virtual DbSet<Post>? Posts {get;set;}
        public virtual DbSet<Like>? Likes {get;set;}
        public virtual DbSet<Address>? Addresses {get;set;}
        public virtual DbSet<Activity>? Activities {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Data Source=JAMES-PC\\SQLEXPRESS;User ID=DNN;Password=##DNNUser2019;Initial Catalog=RelationalDatabase;app=LINQPad;Encrypt=true;TrustServerCertificate=true");

            // Enable sensitive data logging
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
