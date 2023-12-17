using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp3.Models.Entitys;

public partial class OvaEstructuraContext : DbContext
{
    public OvaEstructuraContext()
    {
    }

    public OvaEstructuraContext(DbContextOptions<OvaEstructuraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; }

    public virtual DbSet<Modulo> Modulos { get; set; }

    public virtual DbSet<ModuloDet> ModuloDets { get; set; }

    public virtual DbSet<OpcionesPregunta> OpcionesPreguntas { get; set; }

    public virtual DbSet<Pregunta> Preguntas { get; set; }

    public virtual DbSet<Respuesta> Respuestas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=217.113.49.50;port=3306;database=OvaEstructura;username=root;password=Admin123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.LockoutEnd).HasMaxLength(6);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PRIMARY");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey }).HasName("PRIMARY");

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name }).HasName("PRIMARY");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<EfmigrationsHistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__EFMigrationsHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.HasKey(e => e.Moduloid).HasName("PRIMARY");

            entity.ToTable("MODULOS");

            entity.Property(e => e.Moduloid).HasColumnName("moduloid");
            entity.Property(e => e.Codigo)
                .HasMaxLength(255)
                .HasColumnName("codigo");
            entity.Property(e => e.Enlace)
                .HasMaxLength(255)
                .HasColumnName("enlace");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Tienecuestionario)
                .HasDefaultValueSql("'0'")
                .HasColumnName("tienecuestionario");
        });

        modelBuilder.Entity<ModuloDet>(entity =>
        {
            entity.HasKey(e => e.Modulodet1).HasName("PRIMARY");

            entity.ToTable("MODULO_DET");

            entity.HasIndex(e => e.Moduloid, "FK_MODULO_DET_moduloid");

            entity.HasIndex(e => e.Userid, "FK_MODULO_DET_userid");

            entity.Property(e => e.Modulodet1).HasColumnName("modulodet");
            entity.Property(e => e.Moduloid).HasColumnName("moduloid");
            entity.Property(e => e.Porcentaje)
                .HasPrecision(10)
                .HasColumnName("porcentaje");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Modulo).WithMany(p => p.ModuloDets)
                .HasForeignKey(d => d.Moduloid)
                .HasConstraintName("FK_MODULO_DET_moduloid");

            entity.HasOne(d => d.User).WithMany(p => p.ModuloDets)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("FK_MODULO_DET_userid");
        });

        modelBuilder.Entity<OpcionesPregunta>(entity =>
        {
            entity.HasKey(e => e.Opcionid).HasName("PRIMARY");

            entity.ToTable("OPCIONES_PREGUNTAS");

            entity.HasIndex(e => e.Preguntaid, "FK_OPCIONES_PREGUNTA_preguntaid");

            entity.Property(e => e.Opcionid).HasColumnName("opcionid");
            entity.Property(e => e.ContenidoOpcion)
                .HasMaxLength(500)
                .HasColumnName("contenido_opcion");
            entity.Property(e => e.LetraOpcion)
                .HasMaxLength(1)
                .HasColumnName("letra_opcion");
            entity.Property(e => e.Preguntaid).HasColumnName("preguntaid");

            entity.HasOne(d => d.Pregunta).WithMany(p => p.OpcionesPregunta)
                .HasForeignKey(d => d.Preguntaid)
                .HasConstraintName("FK_OPCIONES_PREGUNTA_preguntaid");
        });

        modelBuilder.Entity<Pregunta>(entity =>
        {
            entity.HasKey(e => e.Preguntaid).HasName("PRIMARY");

            entity.ToTable("PREGUNTAS");

            entity.HasIndex(e => e.Moduloid, "FK_PREGUNTAS_moduloid");

            entity.Property(e => e.Preguntaid).HasColumnName("preguntaid");
            entity.Property(e => e.Correcta)
                .HasMaxLength(1)
                .HasColumnName("correcta");
            entity.Property(e => e.Moduloid).HasColumnName("moduloid");
            entity.Property(e => e.Numero).HasColumnName("numero");
            entity.Property(e => e.Pregunta1)
                .HasMaxLength(1500)
                .HasColumnName("pregunta");

            entity.HasOne(d => d.Modulo).WithMany(p => p.Pregunta)
                .HasForeignKey(d => d.Moduloid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PREGUNTAS_moduloid");
        });

        modelBuilder.Entity<Respuesta>(entity =>
        {
            entity.HasKey(e => e.Respuestaid).HasName("PRIMARY");

            entity.ToTable("RESPUESTAS");

            entity.HasIndex(e => e.Moduloid, "FK_RESPUESTAS_moduloid");

            entity.HasIndex(e => e.Opcionid, "FK_RESPUESTAS_opcionid");

            entity.HasIndex(e => e.Preguntaid, "FK_RESPUESTAS_preguntaid");

            entity.HasIndex(e => e.Userid, "FK_RESPUESTAS_userid");

            entity.Property(e => e.Respuestaid).HasColumnName("respuestaid");
            entity.Property(e => e.Correcta).HasColumnName("correcta");
            entity.Property(e => e.Moduloid).HasColumnName("moduloid");
            entity.Property(e => e.Opcionid).HasColumnName("opcionid");
            entity.Property(e => e.Preguntaid).HasColumnName("preguntaid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Modulo).WithMany(p => p.Respuesta)
                .HasForeignKey(d => d.Moduloid)
                .HasConstraintName("FK_RESPUESTAS_moduloid");

            entity.HasOne(d => d.Opcion).WithMany(p => p.Respuesta)
                .HasForeignKey(d => d.Opcionid)
                .HasConstraintName("FK_RESPUESTAS_opcionid");

            entity.HasOne(d => d.Pregunta).WithMany(p => p.Respuesta)
                .HasForeignKey(d => d.Preguntaid)
                .HasConstraintName("FK_RESPUESTAS_preguntaid");

            entity.HasOne(d => d.User).WithMany(p => p.Respuesta)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("FK_RESPUESTAS_userid");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PRIMARY");

            entity.ToTable("USUARIOS");

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(255)
                .HasColumnName("contrasenia");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
            entity.Property(e => e.Verificado)
                .HasDefaultValueSql("'0'")
                .HasColumnName("verificado");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
