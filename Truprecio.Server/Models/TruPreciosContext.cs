using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Truprecio.Server.Models;

public partial class TruPreciosContext : DbContext
{
    public TruPreciosContext()
    {
    }

    public TruPreciosContext(DbContextOptions<TruPreciosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<UsuariosPro> UsuariosPros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.Clave, "IX_Productos_Clave");

            entity.HasIndex(e => e.CodBarras, "IX_Productos_CodBarras");

            entity.HasIndex(e => e.Codigo, "IX_Productos_Codigo");

            entity.Property(e => e.Clave)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.CodBarras)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Codigo)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.Imagen).IsUnicode(false);
            entity.Property(e => e.MedidaId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MedidaID");
            entity.Property(e => e.ProdServisId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ProdServisID");
            entity.Property(e => e.Unidad)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UsuariosPro>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UsuariosPro");

            entity.Property(e => e.Correo)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.CorreoRecuperacion)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioId)
                .ValueGeneratedOnAdd()
                .HasColumnName("UsuarioID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
