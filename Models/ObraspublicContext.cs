using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AIFA_Pre.Models;

public partial class ObraspublicContext : DbContext
{
    public ObraspublicContext()
    {
    }

    public ObraspublicContext(DbContextOptions<ObraspublicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Constructora> Constructoras { get; set; }

    public virtual DbSet<FrenteObra> FrenteObras { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<Proyectofrente> Proyectofrentes { get; set; }

    public virtual DbSet<Reporte> Reportes { get; set; }

    public virtual DbSet<RolUsuario> RolUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
  //      => optionsBuilder.UseSqlServer("Server=(local); DataBase=obraspublic; Trusted_Connection=True; TrustServerCertificate=True;");
  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Constructora>(entity =>
        {
            entity.HasKey(e => e.Idconst).HasName("PK__Construc__3E1EE4EA2A767699");

            entity.ToTable("Constructora");

            entity.Property(e => e.Idconst).HasColumnName("idconst");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Numerocon).HasColumnName("numerocon");
        });

        modelBuilder.Entity<FrenteObra>(entity =>
        {
            entity.HasKey(e => e.IdFrenteObra).HasName("PK__FrenteOb__43A7FB9323B5287D");

            entity.ToTable("FrenteObra");

            entity.Property(e => e.IdFrenteObra).HasColumnName("idFrenteObra");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.FechaEstimadaTermino).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");
            entity.Property(e => e.IdProyectofrent).HasColumnName("idProyectofrent");
            entity.Property(e => e.Idconst).HasColumnName("idconst");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProyectofrentNavigation).WithMany(p => p.FrenteObras)
                .HasForeignKey(d => d.IdProyectofrent)
                .HasConstraintName("FK_idProyectofrent");

            entity.HasOne(d => d.IdconstNavigation).WithMany(p => p.FrenteObras)
                .HasForeignKey(d => d.Idconst)
                .HasConstraintName("FK_idconst");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.IdProyecto).HasName("PK__Proyecto__D0AF4CB40B53A014");

            entity.ToTable("Proyecto");

            entity.Property(e => e.IdProyecto).HasColumnName("idProyecto");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.FechaEstimadaTermino).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(400)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Proyectofrente>(entity =>
        {
            entity.HasKey(e => e.IdProyectofrent).HasName("PK__Proyecto__C4BAD768A7726E79");

            entity.ToTable("Proyectofrente");

            entity.Property(e => e.IdProyectofrent).HasColumnName("idProyectofrent");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.FechaEstimadaTermino).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");
            entity.Property(e => e.Idproyecto).HasColumnName("IDProyecto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(400)
                .IsUnicode(false);

            entity.HasOne(d => d.IdproyectoNavigation).WithMany(p => p.Proyectofrentes)
                .HasForeignKey(d => d.Idproyecto)
                .HasConstraintName("FK_IDProyecto");
        });

        modelBuilder.Entity<Reporte>(entity =>
        {
            entity.HasKey(e => e.IdReporte).HasName("PK__Reportes__40D65D3C78519479");

            entity.Property(e => e.IdReporte).HasColumnName("idReporte");
            entity.Property(e => e.Archivopdf).HasColumnName("archivopdf");
            entity.Property(e => e.FechaRealizado).HasColumnType("date");
            entity.Property(e => e.IdFrenteObra).HasColumnName("idFrenteObra");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(400)
                .IsUnicode(false);

            entity.HasOne(d => d.IdFrenteObraNavigation).WithMany(p => p.Reportes)
                .HasForeignKey(d => d.IdFrenteObra)
                .HasConstraintName("FK_idFrenteObra");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reportes)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_idUsuario");
        });

        modelBuilder.Entity<RolUsuario>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__RolUsuar__3C872F767249DF85");

            entity.ToTable("RolUsuario");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Nombredelrol)
                .HasMaxLength(400)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A67837711C");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdFrenteObra).HasColumnName("idFrenteObra");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Pass)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("pass");

            entity.HasOne(d => d.IdFrenteObraNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdFrenteObra)
                .HasConstraintName("FK_FrenteObra");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_idRol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
