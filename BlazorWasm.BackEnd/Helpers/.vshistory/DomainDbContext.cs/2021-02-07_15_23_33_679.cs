using System;
using System.Configuration;
using System.Data.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Microsoft.Extensions.Options;

namespace AdventureWorksAPI.Models
{
    public class DomainDbContext : IdentityDbContext<ApplicationUser>
    {
        public readonly string SchemaName;
        public DbSet<Foo> Foos { get; set; }

        public DomainDbContext(ICompanyProvider companyProvider, DbContextOptions<DomainDbContext> options)
            : base(options)
        {
            SchemaName = companyProvider.GetSchemaName();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SchemaName);
            base.OnModelCreating(modelBuilder);
        }
    }
}