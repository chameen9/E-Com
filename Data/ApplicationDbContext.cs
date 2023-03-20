using E_Com.Models.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Com.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<UserTypes> UserTypes { get; set; }

        public DbSet<MemoryDevices> MemoryDevices { get; set; }
        public DbSet<OperatingSytems> OperatingSytems { get; set; }
        public DbSet<StorageDevices> StorageDevices { get; set; }
        public DbSet<Processors> Processors { get; set; }
        public DbSet<VGADevices> VGADevices { get; set; }

        public DbSet<Products> Products { get; set; }
    }
}