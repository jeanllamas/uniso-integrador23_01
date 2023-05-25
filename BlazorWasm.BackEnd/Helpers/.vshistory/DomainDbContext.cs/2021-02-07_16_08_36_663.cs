using System;
using System.Configuration;
using System.Data.Common;
using BlazorMovies.Base.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;

namespace BlazorMovies.Server.Helpers
{
    // public class DomainDbContext : IdentityDbContext<IdentityUser>

    public class DomainDbContext : Microsoft.EntityFrameworkCore.DbContext    {
        public readonly string SchemaName;
        private readonly IConfiguration _configuration;
        public DbSet<IEntity> Foos { get; set; }

        public DomainDbContext(string mySchema, DbContextOptions<DomainDbContext> options, IConfiguration iconfiguration)
            : base(options)
        {
            SchemaName = mySchema;
            _configuration = iconfiguration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


             optionsBuilder.UseMySql(_configuration.GetConnectionString("DefaultConnection"),
                 ServerVersion.AutoDetect(_configuration.GetConnectionString("DefaultConnection")));
            

            // this block forces map method invoke for each instance
            var builder = new ModelBuilder(new ConventionSet());
          

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