using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Infraestructure.Data
{
    public partial class BDLibreriaNexosContext : DbContext
    {
        public BDLibreriaNexosContext()
        {
        }

        public BDLibreriaNexosContext(DbContextOptions<BDLibreriaNexosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autore> Autores { get; set; }
        public virtual DbSet<Editoriale> Editoriales { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-9H09STR1\\MSSQLSERVER_HANS;Database=BDLibreriaNexos;Integrated Security= true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Autore>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                    .HasName("PK__Autores__DD33B031A23CAB26");

                entity.Property(e => e.IdAutor).ValueGeneratedNever();

                entity.Property(e => e.CiudadProced)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Editoriale>(entity =>
            {
                entity.HasKey(e => e.IdEditorial)
                    .HasName("PK__Editoria__EF8386710F35DB3A");

                entity.Property(e => e.IdEditorial).ValueGeneratedNever();

                entity.Property(e => e.Correo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.Idisbn)
                    .HasName("PK__Libros__C933397EF9AF099B");

                entity.Property(e => e.Idisbn)
                    .ValueGeneratedNever()
                    .HasColumnName("IDIsbn");

                entity.Property(e => e.Genero)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            

             
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
