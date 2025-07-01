using System;
using System.Collections.Generic;
using DoradosBlazor.Server.Models;
using DoradosBlazor.Shared;
using Microsoft.EntityFrameworkCore;

namespace DoradosBlazor.Server.Models;

public partial class DbcrudBlazorContext : DbContext
{
    public DbcrudBlazorContext()
    {
    }

    public DbcrudBlazorContext(DbContextOptions<DbcrudBlazorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<Login> Login { get; set; }
    public virtual DbSet<Correo> Correos { get; set; }
    public virtual DbSet<SiExisteMatricula> siExisteMatricula { get; set; }
    public virtual DbSet<GposEmpaquetados> gposEmpaquetados { get; set; }
    public virtual DbSet<Ciclos> ciclos { get; set; }
    public virtual DbSet<ST_S_GposEmpaquetados> sT_S_GposEmpaquetados { get; set; }
    public virtual DbSet<ST_S_GposEmpaquetadosListos> sT_S_GposEmpaquetadosListos { get; set; }
    public virtual DbSet<CalificacionesPar> calificacionesPar { get; set; }
    public virtual DbSet<CalificacionesMens> calificacionesMens { get; set; }
    public virtual DbSet<CalificacionesTrim> calificacionesTrim { get; set; }

    public virtual DbSet<AdeudosAlum> adeudosAlum { get; set; }
    public virtual DbSet<ConAdeudo> conAdeudo { get; set; }
    public virtual DbSet<TotalAdeudos> adeudosTotal { get; set; }

    public virtual DbSet<MateriasProfesores> materiasprofesores { get; set; }
    public virtual DbSet<GruposAlumApp> gruposAlumApp { get; set; }
    public virtual DbSet<CalificacionAlumApp> calificacionAlumApp { get; set; }
    public virtual DbSet<CalificacionParcAlumApp> calificacionParcAlumApp { get; set; }

    public virtual DbSet<CalificacionMateriaApp> calificacionMateriaApp { get; set; }
    public virtual DbSet<ST_S_PREINSCRIP> sT_S_PREINSCRIP { get; set; }
    public virtual DbSet<ST_S_PREINSCRIPCOUNT> sT_S_PREINSCRIPCOUNT { get; set; }
    public virtual DbSet<ST_S_CARRERAS> sT_S_CARRERAS { get; set; }
    public virtual DbSet<ST_S_PREINSC_INCOMP> sT_S_PREINSC_INCOMP { get; set; }
    public virtual DbSet<ST_S_DatosPDF> sT_S_DatosPDF { get; set; }
    public virtual DbSet<ST_S_CorreosMisCuentas> sT_S_CorreosMisCuentas { get; set; }


    public virtual DbSet<Respuesta> respuesta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__787A433DF63A679C");

            entity.ToTable("Roles");

            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioID).HasName("PK__Usuario__CE6D8B9EE00ACDF7");

            entity.ToTable("Usuario");

            entity.Property(e => e.FechaReg).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolesNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleado__IdDepa__1273C1CD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
