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
    
    public class DomainDbContext : ApplicationDbContext
    {
        public readonly string SchemaName;
        private readonly IConfiguration _configuration;
        public DbSet<IEntity> Foos { get; set; }

        public DomainDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration iconfiguration, string mySchema = "blazormovies")
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
            //modelBuilder.MapCategoria(SchemaName);
            base.OnModelCreating(modelBuilder);
        }
    }

    public static class ProductMap
    {
        public static ModelBuilder MapCategoria(this ModelBuilder modelBuilder, String schema)
        {
            var entity = modelBuilder.Entity<Categoria>();

            entity.ToTable("Categoria", schema);

            entity.HasKey(p => new { p.Id });

            entity.Property(p => p.Id).UseMySqlIdentityColumn();

            return modelBuilder;
        }
    }

}