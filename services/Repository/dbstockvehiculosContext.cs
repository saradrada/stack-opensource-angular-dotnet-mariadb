using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace services.Repository
{
    public partial class dbstockvehiculosContext : DbContext
    {
        // public dbstockvehiculosContext()
        // {
        // }

        public dbstockvehiculosContext(DbContextOptions<dbstockvehiculosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anio> Anio { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Modelo> Modelo { get; set; }
        public virtual DbSet<Vehiculosstock> Vehiculosstock { get; set; }
        public virtual DbSet<Version> Version { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anio>(entity =>
            {
                entity.ToTable("anio");

                entity.HasComment("Modelo/Año del vechículo.");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .HasComment("Identificador único del año.");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("smallint(6)")
                    .HasComment("Descriptor del año.");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.ToTable("marca");

                entity.HasComment("Marcas de los vechículos.");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .HasComment("Identificador único de la marca del vehículo.");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(100)")
                    .HasComment("Descriptor de la marca.")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.ToTable("modelo");

                entity.HasComment("Modelos de los vechículos de acuerdo a la marca y año.");

                entity.HasIndex(e => e.IdAnio)
                    .HasName("Modelo_FK_1");

                entity.HasIndex(e => e.IdMarca)
                    .HasName("Modelo_FK");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .HasComment("Identificador único del modelo.");

                entity.Property(e => e.IdAnio)
                    .HasColumnName("idAnio")
                    .HasColumnType("int(11)")
                    .HasComment("Id del año al cual pertenece el modelo.");

                entity.Property(e => e.IdMarca)
                    .HasColumnName("idMarca")
                    .HasColumnType("int(11)")
                    .HasComment("Id de la marca a la cual pertenece el modelo.");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.IdAnioNavigation)
                    .WithMany(p => p.Modelo)
                    .HasForeignKey(d => d.IdAnio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Modelo_FK_1");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Modelo)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Modelo_FK");
            });

            modelBuilder.Entity<Vehiculosstock>(entity =>
            {
                entity.ToTable("vehiculosstock");

                entity.HasComment("Contiene el inventario/stock de vechículos.");

                entity.HasIndex(e => e.IdVersion)
                    .HasName("VehiculosStock_FK");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .HasComment("Identificador único del vechículo.");

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("int(11)")
                    .HasComment("Cantidad de vechículos en existencia.");

                entity.Property(e => e.Comentarios)
                    .HasColumnName("comentarios")
                    .HasColumnType("varchar(8000)")
                    .HasComment("Comentarios adicionales del vechículo.")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.IdVersion)
                    .HasColumnName("idVersion")
                    .HasColumnType("int(11)")
                    .HasComment("Id de la versión del vehículo.");

                entity.HasOne(d => d.IdVersionNavigation)
                    .WithMany(p => p.Vehiculosstock)
                    .HasForeignKey(d => d.IdVersion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VehiculosStock_FK");
            });

            modelBuilder.Entity<Version>(entity =>
            {
                entity.ToTable("version");

                entity.HasComment("Características del vechículo de acuerdo al modelo.");

                entity.HasIndex(e => e.IdModelo)
                    .HasName("Version_FK");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .HasComment("Identificador único de la versión.");

                entity.Property(e => e.IdModelo)
                    .HasColumnName("idModelo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.Version)
                    .HasForeignKey(d => d.IdModelo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Version_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
