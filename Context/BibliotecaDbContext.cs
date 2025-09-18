using Bibliote.Models;
using Microsoft.EntityFrameworkCore;

namespace Bibliote.Context
{
    public class BibliotecaDbContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

         public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options)
            {

            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Persona>()
                .Property(p => p.Nombre)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Persona>()
                .HasIndex(p => p.DNI)
                .IsUnique();
        }
            
    }
}