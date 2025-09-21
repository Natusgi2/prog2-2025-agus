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

            modelBuilder.Entity<Persona>()
                .Property(p => p.Email)
                .IsRequired(); // Configura la propiedad Email como obligatoria.

            modelBuilder.Entity<Persona>()
                .HasIndex(p => p.Email)
                .IsUnique(); // Configura un índice único en la propiedad Email.

            // Configuraciones para Autor
            //Establecemos la clave primaria
            modelBuilder.Entity<Autor>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Autor>()
                .Property(a => a.Nombre)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Autor>()
                .Property(a => a.Apellido)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Autor>()
                .HasMany(a => a.Libros)
                .WithOne(l => l.Autor)
                .HasForeignKey(l => l.IdAutor)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuraciones para Libro
            modelBuilder.Entity<Libro>()
                .HasKey(l => l.Id);
                
        }
            
    }
}