using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SGPI.Models
{
    public partial class SGPDBContext : DbContext
    {
        public SGPDBContext()
        {
        }

        public SGPDBContext(DbContextOptions<SGPDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Documento> Documentos { get; set; }
        public virtual DbSet<Entrevistum> Entrevista { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Homologacion> Homologacions { get; set; }
        public virtual DbSet<Modulo> Modulos { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<Programa> Programas { get; set; }
        public virtual DbSet<ProgramaUsuario> ProgramaUsuarios { get; set; }
        public virtual DbSet<Programacion> Programacions { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HT65BFS\\SQLEXPRESS;Database=SGPDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.HasKey(e => e.IdTipoDoc)
                    .HasName("PK__Document__08119E68702A400B");

                entity.ToTable("Documento");

                entity.Property(e => e.ValTipoDoc)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Entrevistum>(entity =>
            {
                entity.HasKey(e => e.IdEntrevista)
                    .HasName("PK__Entrevis__EE6CE9C78AA9EF03");

                entity.Property(e => e.Estado)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEntrevista).HasColumnType("date");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Entrevista)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Entrevista_ToUsuario");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PK__Genero__0F834988592B9074");

                entity.ToTable("Genero");

                entity.Property(e => e.ValGenero)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Homologacion>(entity =>
            {
                entity.HasKey(e => e.IdHomologacion)
                    .HasName("PK__Homologa__C7746319624B4A04");

                entity.ToTable("Homologacion");

                entity.Property(e => e.FechaHomologacion).HasColumnType("date");

                entity.Property(e => e.Universidad)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.Homologacions)
                    .HasForeignKey(d => d.IdModulo)
                    .HasConstraintName("FK_Homologacion_ToModulo");

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.Homologacions)
                    .HasForeignKey(d => d.IdPrograma)
                    .HasConstraintName("FK_Homologacion_ToPrograma");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Homologacions)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Homologacion_ToUsuario");
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.HasKey(e => e.IdModulo)
                    .HasName("PK__Modulo__D9F1531502DDC0CB");

                entity.ToTable("Modulo");

                entity.Property(e => e.ValModulo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.Modulos)
                    .HasForeignKey(d => d.IdPrograma)
                    .HasConstraintName("FK_Modulo_ToPrograma");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago)
                    .HasName("PK__Pagos__FC851A3A44672423");

                entity.Property(e => e.ComprovantePago)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Pagos_ToUsuario");
            });

            modelBuilder.Entity<Programa>(entity =>
            {
                entity.HasKey(e => e.IdPrograma)
                    .HasName("PK__Programa__AF94ECA5A21C46B2");

                entity.ToTable("Programa");

                entity.Property(e => e.Pensum)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ValPrograma).HasMaxLength(500);
            });

            modelBuilder.Entity<ProgramaUsuario>(entity =>
            {
                entity.HasKey(e => e.IdProgramaUsuario)
                    .HasName("PK__Programa__A45CB108052189D5");

                entity.ToTable("ProgramaUsuario");

                entity.Property(e => e.ValPrograma)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.ProgramaUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_ProgramaUsuario_ToUsuario");
            });

            modelBuilder.Entity<Programacion>(entity =>
            {
                entity.HasKey(e => e.IdProgramacion)
                    .HasName("PK__Programa__74E652C0EC9D1F5F");

                entity.ToTable("Programacion");

                entity.Property(e => e.IdProgramacion).ValueGeneratedNever();

                entity.Property(e => e.FechaFin).HasColumnType("date");

                entity.Property(e => e.FechaIncio).HasColumnType("date");

                entity.Property(e => e.Salon)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Semestre)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.Programacions)
                    .HasForeignKey(d => d.IdModulo)
                    .HasConstraintName("FK_Programacion_ToModulo");

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.Programacions)
                    .HasForeignKey(d => d.IdPrograma)
                    .HasConstraintName("FK_Programacion_ToPrograma");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol__2A49584CAD5A659F");

                entity.ToTable("Rol");

                entity.Property(e => e.ValRol)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF9717C108C6");

                entity.ToTable("Usuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdGenero)
                    .HasConstraintName("FK_Usuario_ToGenero");

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPrograma)
                    .HasConstraintName("FK_Usuario_ToPrograma");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_Usuario_ToRol");

                entity.HasOne(d => d.IdTipoDocNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoDoc)
                    .HasConstraintName("FK_Usuario_ToDocumento");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
