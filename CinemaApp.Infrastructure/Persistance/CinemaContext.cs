using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CinemaApp.Domain.Entities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CinemaApp.Infrastructure.Persistance
{
    public partial class CinemaContext : DbContext
    {
        public CinemaContext()
        {
        }

        public CinemaContext(DbContextOptions<CinemaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<DetalleFactura> DetalleFactura { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Funcion> Funcion { get; set; }
        public virtual DbSet<Pelicula> Pelicula { get; set; }
        public virtual DbSet<Sala> Sala { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=COL-LT-210601I;Database=Cinema;User Id=cesde;Password=abc123..");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.Property(e => e.IdCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasKey(e => e.IdDetalleFactura);

                entity.Property(e => e.IdDetalleFactura).ValueGeneratedNever();

                entity.Property(e => e.FechaUso).HasColumnType("datetime");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.DetalleFactura)
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleFactura_Factura");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura);

                entity.Property(e => e.IdFactura).ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ValorBruto).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ValorIva).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ValorNeto).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ValorServicio).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Factura_Cliente");

                entity.HasOne(d => d.IdFuncionNavigation)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.IdFuncion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Factura_Funcion");
            });

            modelBuilder.Entity<Funcion>(entity =>
            {
                entity.HasKey(e => e.IdFuncion);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.PrecioBoleta).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdPeliculaNavigation)
                    .WithMany(p => p.Funcion)
                    .HasForeignKey(d => d.IdPelicula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcion_Pelicula");

                entity.HasOne(d => d.IdSalaNavigation)
                    .WithMany(p => p.Funcion)
                    .HasForeignKey(d => d.IdSala)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcion_Sala");
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasKey(e => e.IdPelicula);

                entity.Property(e => e.ActorPrincipal)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Director)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sinopsis)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.HasKey(e => e.IdSala);

                entity.Property(e => e.Nomenclatura)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
