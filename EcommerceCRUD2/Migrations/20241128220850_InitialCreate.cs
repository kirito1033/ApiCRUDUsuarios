using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceCRUD2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    id = table.Column<sbyte>(type: "tinyint(3)", nullable: false, comment: "Identificador unico para los departamentos")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Nombre del departamento", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.id);
                },
                comment: "Identifica el departamento donde se encuentra el cliente a partir de la ciudad")
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    id = table.Column<sbyte>(type: "tinyint(3)", nullable: false, comment: "Identificador unico del rol")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false, comment: "Identifica el rol del usuario", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    descripcion = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "Espacio destinado para indicar los permisos y descripcion general de cada rol", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.id);
                },
                comment: "Espacio destinado para la gestion de roles")
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "tipo_documento",
                columns: table => new
                {
                    id = table.Column<sbyte>(type: "tinyint(3)", nullable: false, comment: "Identificador unico del tipo de documento")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false, comment: "Nombre del tipo de documento", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_documento", x => x.id);
                },
                comment: "Tabla para la gestion del tipo de documento")
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "ciudad",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint(6)", nullable: false, comment: "Identificador unico para las ciudades")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Nombre de la ciudad", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    departamentoid = table.Column<sbyte>(type: "tinyint(3)", nullable: false, comment: "Llave foranea de la tabla de departamento")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ciudad", x => x.id);
                    table.ForeignKey(
                        name: "FKCiudad399883",
                        column: x => x.departamentoid,
                        principalTable: "departamento",
                        principalColumn: "id");
                },
                comment: "Identifica la ciudad donde se encuentra el cliente")
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id_usuario = table.Column<int>(type: "int(10)", nullable: false, comment: "Llave primaria que identifica de forma única al usuario")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom_1 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "primer nombre del usuario", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    nom_2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "Segundo nombre del usuario", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    apellido_1 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Primer apellido del usuario", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    apellido_2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "segundo apellido del usuario", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    doc = table.Column<long>(type: "bigint(11)", nullable: false, comment: "Numero de documento del usuario."),
                    Correo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Correo electronico del usuario", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    Tel1 = table.Column<long>(type: "bigint(10)", nullable: false, comment: "Numero telefonico del usuario"),
                    Tel2 = table.Column<long>(type: "bigint(10)", nullable: true, comment: "Segundo numero de telefono del usuario"),
                    Direccion = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false, comment: "Direcion donde se encuentra el usuario", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    usuario = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false, comment: "Nombre unico para ingresar al sistema ", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Palabra secreta que permite el acceso a la plataforma", collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    tipo_DocId = table.Column<sbyte>(type: "tinyint(3)", nullable: false, comment: "Llave foranea de la tabla tipo de documento"),
                    ciudadId = table.Column<short>(type: "smallint(6)", nullable: false, comment: "Llave foranea de la tabla ciudad")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id_usuario);
                    table.ForeignKey(
                        name: "FKUsuario642574",
                        column: x => x.ciudadId,
                        principalTable: "ciudad",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FKUsuario878723",
                        column: x => x.tipo_DocId,
                        principalTable: "tipo_documento",
                        principalColumn: "id");
                },
                comment: "En esta tabla se gestionara la informacion de los usuarios")
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "rol_usuario",
                columns: table => new
                {
                    RolId_Rol = table.Column<sbyte>(type: "tinyint(3)", nullable: false, comment: "Llave foranea de la tabla rol"),
                    UsuarioId_usuario = table.Column<int>(type: "int(10)", nullable: false, comment: "Llave foranea de la tabla usuario"),
                    estado = table.Column<ulong>(type: "bit(1)", nullable: false, comment: "Campo destinado para la activacion o desactivacion del rol de un usuario")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.RolId_Rol, x.UsuarioId_usuario })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "FKRol_Usuari104401",
                        column: x => x.UsuarioId_usuario,
                        principalTable: "usuario",
                        principalColumn: "Id_usuario");
                    table.ForeignKey(
                        name: "FKRol_Usuari631635",
                        column: x => x.RolId_Rol,
                        principalTable: "rol",
                        principalColumn: "id");
                },
                comment: "Tabla para la asignacion de roles de usuarios")
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateIndex(
                name: "FKCiudad399883",
                table: "ciudad",
                column: "departamentoid");

            migrationBuilder.CreateIndex(
                name: "FKRol_Usuari104401",
                table: "rol_usuario",
                column: "UsuarioId_usuario");

            migrationBuilder.CreateIndex(
                name: "Correo",
                table: "usuario",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FKUsuario642574",
                table: "usuario",
                column: "ciudadId");

            migrationBuilder.CreateIndex(
                name: "FKUsuario878723",
                table: "usuario",
                column: "tipo_DocId");

            migrationBuilder.CreateIndex(
                name: "usuario",
                table: "usuario",
                column: "usuario",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rol_usuario");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "ciudad");

            migrationBuilder.DropTable(
                name: "tipo_documento");

            migrationBuilder.DropTable(
                name: "departamento");
        }
    }
}
