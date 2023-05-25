using System;
using System.Configuration;
using System.Data.Common;
using BlazorMovies.Base.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Microsoft.Extensions.Options;

namespace AdventureWorksAPI.Models
{
    public class DomainDbContext : IdentityDbContext<IdentityUser>
    {
        public readonly string SchemaName;
        public DbSet<IEntity> Foos { get; set; }

        public DomainDbContext(string mySchema, DbContextOptions<DomainDbContext> options)
            : base(options)
        {
            SchemaName = mySchema;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(Configuration.GetConnectionString("DefaultConnection"))

            // this block forces map method invoke for each instance
            var builder = new ModelBuilder(new ConventionSet());
            //var builder = new ModelBuilder(new CoreConventionSetBuilder().CreateConventionSet());

            OnModelCreating(builder);

            optionsBuilder.UseModel(builder.Model);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SchemaName);
            base.OnModelCreating(modelBuilder);
        }
    }
}