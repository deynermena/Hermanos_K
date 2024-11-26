using Microsoft.EntityFrameworkCore;
using HermanosK.Models;
using BCrypt.Net;

namespace HermanosK.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraciones de las entidades
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.PasswordHash).IsRequired();
            });

            // Datos iniciales para roles
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, Name = "Cliente" },
                new Role { RoleId = 2, Name = "Administrador" },
                new Role { RoleId = 3, Name = "Empleado" }
            );

            // Datos iniciales para usuarios
            var passwordHash = BCrypt.Net.BCrypt.HashPassword("123456");
            
            modelBuilder.Entity<User>().HasData(
                new User 
                { 
                    UserId = 1,
                    Email = "cliente@hermanosk.com",
                    PasswordHash = passwordHash,
                    FirstName = "Usuario",
                    LastName = "Cliente",
                    PhoneNumber = "123456789",
                    RoleId = 1,
                    CreatedAt = DateTime.Now,
                    IsActive = true
                },
                new User 
                { 
                    UserId = 2,
                    Email = "admin@hermanosk.com",
                    PasswordHash = passwordHash,
                    FirstName = "Usuario",
                    LastName = "Administrador",
                    PhoneNumber = "123456789",
                    RoleId = 2,
                    CreatedAt = DateTime.Now,
                    IsActive = true
                },
                new User 
                { 
                    UserId = 3,
                    Email = "empleado@hermanosk.com",
                    PasswordHash = passwordHash,
                    FirstName = "Usuario",
                    LastName = "Empleado",
                    PhoneNumber = "123456789",
                    RoleId = 3,
                    CreatedAt = DateTime.Now,
                    IsActive = true
                }
            );
        }
    }
}
