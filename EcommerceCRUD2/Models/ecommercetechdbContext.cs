using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EcommerceCRUD2.Models
{
    public partial class ecommercetechdbContext : DbContext
    {
       

        public ecommercetechdbContext(DbContextOptions<ecommercetechdbContext> options)
       : base(options)
        {
        }

       

        public virtual DbSet<Ciudad> Ciudads { get; set; } = null!;
        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<RolUsuario> RolUsuarios { get; set; } = null!;
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.ToTable("ciudad");

                entity.HasComment("Identifica la ciudad donde se encuentra el cliente");

                entity.HasIndex(e => e.Departamentoid, "FKCiudad399883");

                entity.Property(e => e.Id)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("id")
                    .HasComment("Identificador unico para las ciudades");

                entity.Property(e => e.Departamentoid)
                    .HasColumnType("tinyint(3)")
                    .HasColumnName("departamentoid")
                    .HasComment("Llave foranea de la tabla de departamento");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .HasColumnName("nom")
                    .HasComment("Nombre de la ciudad");

                entity.HasOne(d => d.Departamento)
                    .WithMany(p => p.Ciudads)
                    .HasForeignKey(d => d.Departamentoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCiudad399883");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.ToTable("departamento");

                entity.HasComment("Identifica el departamento donde se encuentra el cliente a partir de la ciudad");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(3)")
                    .HasColumnName("id")
                    .HasComment("Identificador unico para los departamentos");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .HasColumnName("nom")
                    .HasComment("Nombre del departamento");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("rol");

                entity.HasComment("Espacio destinado para la gestion de roles");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(3)")
                    .HasColumnName("id")
                    .HasComment("Identificador unico del rol");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .HasColumnName("descripcion")
                    .HasComment("Espacio destinado para indicar los permisos y descripcion general de cada rol");

                entity.Property(e => e.Nom)
                    .HasMaxLength(25)
                    .HasColumnName("nom")
                    .HasComment("Identifica el rol del usuario");
            });

            modelBuilder.Entity<RolUsuario>(entity =>
            {
                entity.HasKey(e => new { e.RolIdRol, e.UsuarioIdUsuario })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("rol_usuario");

                entity.HasComment("Tabla para la asignacion de roles de usuarios");

                entity.HasIndex(e => e.UsuarioIdUsuario, "FKRol_Usuari104401");

                entity.Property(e => e.RolIdRol)
                    .HasColumnType("tinyint(3)")
                    .HasColumnName("RolId_Rol")
                    .HasComment("Llave foranea de la tabla rol");

                entity.Property(e => e.UsuarioIdUsuario)
                    .HasColumnType("int(10)")
                    .HasColumnName("UsuarioId_usuario")
                    .HasComment("Llave foranea de la tabla usuario");

                entity.Property(e => e.Estado)
                    .HasColumnType("bit(1)")
                    .HasColumnName("estado")
                    .HasComment("Campo destinado para la activacion o desactivacion del rol de un usuario");

                entity.HasOne(d => d.RolIdRolNavigation)
                    .WithMany(p => p.RolUsuarios)
                    .HasForeignKey(d => d.RolIdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRol_Usuari631635");

                entity.HasOne(d => d.UsuarioIdUsuarioNavigation)
                    .WithMany(p => p.RolUsuarios)
                    .HasForeignKey(d => d.UsuarioIdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRol_Usuari104401");
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.ToTable("tipo_documento");

                entity.HasComment("Tabla para la gestion del tipo de documento");

                entity.Property(e => e.Id)
                    .HasColumnType("tinyint(3)")
                    .HasColumnName("id")
                    .HasComment("Identificador unico del tipo de documento");

                entity.Property(e => e.Nom)
                    .HasMaxLength(25)
                    .HasColumnName("nom")
                    .HasComment("Nombre del tipo de documento");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.HasComment("En esta tabla se gestionara la informacion de los usuarios");

                entity.HasIndex(e => e.Correo, "Correo")
                    .IsUnique();

                entity.HasIndex(e => e.CiudadId, "FKUsuario642574");

                entity.HasIndex(e => e.TipoDocId, "FKUsuario878723");

                entity.HasIndex(e => e.Usuario1, "usuario")
                    .IsUnique();

                entity.Property(e => e.IdUsuario)
                    .HasColumnType("int(10)")
                    .HasColumnName("Id_usuario")
                    .HasComment("Llave primaria que identifica de forma única al usuario");

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(50)
                    .HasColumnName("apellido_1")
                    .HasComment("Primer apellido del usuario");

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(50)
                    .HasColumnName("apellido_2")
                    .HasComment("segundo apellido del usuario");

                entity.Property(e => e.CiudadId)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("ciudadId")
                    .HasComment("Llave foranea de la tabla ciudad");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .HasComment("Correo electronico del usuario");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(25)
                    .HasComment("Direcion donde se encuentra el usuario");

                entity.Property(e => e.Doc)
                    .HasColumnType("bigint(11)")
                    .HasColumnName("doc")
                    .HasComment("Numero de documento del usuario.");

                entity.Property(e => e.Nom1)
                    .HasMaxLength(50)
                    .HasColumnName("nom_1")
                    .HasComment("primer nombre del usuario");

                entity.Property(e => e.Nom2)
                    .HasMaxLength(50)
                    .HasColumnName("nom_2")
                    .HasComment("Segundo nombre del usuario");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password")
                    .HasComment("Palabra secreta que permite el acceso a la plataforma");

                entity.Property(e => e.Tel1)
                    .HasColumnType("bigint(10)")
                    .HasComment("Numero telefonico del usuario");

                entity.Property(e => e.Tel2)
                    .HasColumnType("bigint(10)")
                    .HasComment("Segundo numero de telefono del usuario");

                entity.Property(e => e.TipoDocId)
                    .HasColumnType("tinyint(3)")
                    .HasColumnName("tipo_DocId")
                    .HasComment("Llave foranea de la tabla tipo de documento");

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(70)
                    .HasColumnName("usuario")
                    .HasComment("Nombre unico para ingresar al sistema ");

                entity.HasOne(d => d.Ciudad)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.CiudadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUsuario642574");

                entity.HasOne(d => d.TipoDoc)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUsuario878723");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
