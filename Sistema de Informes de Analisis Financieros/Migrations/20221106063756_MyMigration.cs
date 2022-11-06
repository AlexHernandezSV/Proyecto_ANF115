using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_de_Informes_de_Analisis_Financieros.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NomCuentaE",
                columns: table => new
                {
                    nomCuentaEID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomCuentaE = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomCuentaE", x => x.nomCuentaEID);
                });

            migrationBuilder.CreateTable(
                name: "RATIO",
                columns: table => new
                {
                    IDRATIO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRERATIOB = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RATIO", x => x.IDRATIO)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Razon",
                columns: table => new
                {
                    idRazon = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreRazon = table.Column<string>(nullable: false),
                    numerador = table.Column<string>(nullable: false),
                    denominador = table.Column<string>(nullable: false),
                    tipo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Razon", x => x.idRazon);
                });

            migrationBuilder.CreateTable(
                name: "SECTOR",
                columns: table => new
                {
                    IDSECTOR = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMSECTOR = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SECTOR", x => x.IDSECTOR)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "TIPOCUENTA",
                columns: table => new
                {
                    IDTIPOCUENTA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMTIPOCUENTA = table.Column<string>(unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPOCUENTA", x => x.IDTIPOCUENTA)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MensajesAnalisis",
                columns: table => new
                {
                    idMensaje = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mensajeMayorBase = table.Column<string>(nullable: true),
                    mensajeMenorBase = table.Column<string>(nullable: true),
                    mensajeMayorEmp = table.Column<string>(nullable: true),
                    mensajeMenorEmp = table.Column<string>(nullable: true),
                    mensajeIgualBase = table.Column<string>(nullable: true),
                    mensajeIgualEmp = table.Column<string>(nullable: true),
                    idRatio = table.Column<int>(nullable: false),
                    RatioIdratio = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensajesAnalisis", x => x.idMensaje);
                    table.ForeignKey(
                        name: "FK_MensajesAnalisis_RATIO_RatioIdratio",
                        column: x => x.RatioIdratio,
                        principalTable: "RATIO",
                        principalColumn: "IDRATIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMPRESA",
                columns: table => new
                {
                    IDEMPRESA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSECTOR = table.Column<int>(nullable: false),
                    NOMEMPRESA = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    DESCEMPRESA = table.Column<string>(unicode: false, maxLength: 350, nullable: true),
                    RAZONSOCIAL = table.Column<string>(unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPRESA", x => x.IDEMPRESA)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_EMPRESA_RELATIONS_SECTOR",
                        column: x => x.IDSECTOR,
                        principalTable: "SECTOR",
                        principalColumn: "IDSECTOR",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RATIOBASESECTOR",
                columns: table => new
                {
                    IDRATIO = table.Column<int>(nullable: false),
                    IDSECTOR = table.Column<int>(nullable: false),
                    VALORRATIOB = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RATIOBASESECTOR", x => new { x.IDRATIO, x.IDSECTOR })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_RATIOBAS_RELATIONS_RATIO",
                        column: x => x.IDRATIO,
                        principalTable: "RATIO",
                        principalColumn: "IDRATIO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RATIOBAS_RELATIONS_SECTOR",
                        column: x => x.IDSECTOR,
                        principalTable: "SECTOR",
                        principalColumn: "IDSECTOR",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CUENTA",
                columns: table => new
                {
                    IDCUENTA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDTIPOCUENTA = table.Column<int>(nullable: false),
                    NOMCUENTA = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUENTA", x => x.IDCUENTA)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_CUENTA_RELATIONS_TIPOCUEN",
                        column: x => x.IDTIPOCUENTA,
                        principalTable: "TIPOCUENTA",
                        principalColumn: "IDTIPOCUENTA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Idempresa1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_EMPRESA_Idempresa1",
                        column: x => x.Idempresa1,
                        principalTable: "EMPRESA",
                        principalColumn: "IDEMPRESA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RATIOEMPRESA",
                columns: table => new
                {
                    IDRATIOEMPRESA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDRATIO = table.Column<int>(nullable: false),
                    IDEMPRESA = table.Column<int>(nullable: false),
                    VALORRATIOEMPRESA = table.Column<double>(nullable: false),
                    anio = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RATIOEMPRESA", x => x.IDRATIOEMPRESA)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_RATIOEMP_RELATIONS_EMPRESA",
                        column: x => x.IDEMPRESA,
                        principalTable: "EMPRESA",
                        principalColumn: "IDEMPRESA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RATIOEMP_RELATIONS_RATIO",
                        column: x => x.IDRATIO,
                        principalTable: "RATIO",
                        principalColumn: "IDRATIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CATALOGODECUENTA",
                columns: table => new
                {
                    IDEMPRESA = table.Column<int>(nullable: false),
                    IDCUENTA = table.Column<int>(nullable: false),
                    CODCUENTACATALOGO = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    nomCuentaEID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATALOGODECUENTA", x => new { x.IDEMPRESA, x.IDCUENTA })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_CATALOGO_RELATIONS_CUENTA",
                        column: x => x.IDCUENTA,
                        principalTable: "CUENTA",
                        principalColumn: "IDCUENTA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CATALOGO_RELATIONS_EMPRESA",
                        column: x => x.IDEMPRESA,
                        principalTable: "EMPRESA",
                        principalColumn: "IDEMPRESA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CATALOGODECUENTA_NomCuentaE_nomCuentaEID",
                        column: x => x.nomCuentaEID,
                        principalTable: "NomCuentaE",
                        principalColumn: "nomCuentaEID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VALORESDEBALANCE",
                columns: table => new
                {
                    IDBALANCE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDEMPRESA = table.Column<int>(nullable: false),
                    IDCUENTA = table.Column<int>(nullable: false),
                    VALORCUENTA = table.Column<double>(nullable: false),
                    ANIO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VALORESDEBALANCE", x => x.IDBALANCE)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_VALORESD_RELATIONS_CATALOGO",
                        columns: x => new { x.IDEMPRESA, x.IDCUENTA },
                        principalTable: "CATALOGODECUENTA",
                        principalColumns: new[] { "IDEMPRESA", "IDCUENTA" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VALORESESTADO",
                columns: table => new
                {
                    IDVALORE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDEMPRESA = table.Column<int>(nullable: false),
                    IDCUENTA = table.Column<int>(nullable: false),
                    NOMBREVALORE = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    VALORESTADO = table.Column<double>(nullable: false),
                    ANIO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VALORESESTADO", x => x.IDVALORE)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_VALORESE_RELATIONS_CATALOGO",
                        columns: x => new { x.IDEMPRESA, x.IDCUENTA },
                        principalTable: "CATALOGODECUENTA",
                        principalColumns: new[] { "IDEMPRESA", "IDCUENTA" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Idempresa1",
                table: "AspNetUsers",
                column: "Idempresa1");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RELATIONSHIP_4_FK",
                table: "CATALOGODECUENTA",
                column: "IDCUENTA");

            migrationBuilder.CreateIndex(
                name: "RELATIONSHIP_5_FK",
                table: "CATALOGODECUENTA",
                column: "IDEMPRESA");

            migrationBuilder.CreateIndex(
                name: "IX_CATALOGODECUENTA_nomCuentaEID",
                table: "CATALOGODECUENTA",
                column: "nomCuentaEID");

            migrationBuilder.CreateIndex(
                name: "RELATIONSHIP_2_FK",
                table: "CUENTA",
                column: "IDTIPOCUENTA");

            migrationBuilder.CreateIndex(
                name: "RELATIONSHIP_1_FK",
                table: "EMPRESA",
                column: "IDSECTOR");

            migrationBuilder.CreateIndex(
                name: "IX_MensajesAnalisis_RatioIdratio",
                table: "MensajesAnalisis",
                column: "RatioIdratio");

            migrationBuilder.CreateIndex(
                name: "RELATIONSHIP_8_FK",
                table: "RATIOBASESECTOR",
                column: "IDRATIO");

            migrationBuilder.CreateIndex(
                name: "RELATIONSHIP_7_FK",
                table: "RATIOBASESECTOR",
                column: "IDSECTOR");

            migrationBuilder.CreateIndex(
                name: "RELATIONSHIP_10_FK",
                table: "RATIOEMPRESA",
                column: "IDEMPRESA");

            migrationBuilder.CreateIndex(
                name: "RELATIONSHIP_11_FK",
                table: "RATIOEMPRESA",
                column: "IDRATIO");

            migrationBuilder.CreateIndex(
                name: "RELATIONSHIP_9_FK",
                table: "VALORESDEBALANCE",
                columns: new[] { "IDEMPRESA", "IDCUENTA" });

            migrationBuilder.CreateIndex(
                name: "RELATIONSHIP_13_FK",
                table: "VALORESESTADO",
                columns: new[] { "IDEMPRESA", "IDCUENTA" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "MensajesAnalisis");

            migrationBuilder.DropTable(
                name: "RATIOBASESECTOR");

            migrationBuilder.DropTable(
                name: "RATIOEMPRESA");

            migrationBuilder.DropTable(
                name: "Razon");

            migrationBuilder.DropTable(
                name: "VALORESDEBALANCE");

            migrationBuilder.DropTable(
                name: "VALORESESTADO");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "RATIO");

            migrationBuilder.DropTable(
                name: "CATALOGODECUENTA");

            migrationBuilder.DropTable(
                name: "CUENTA");

            migrationBuilder.DropTable(
                name: "EMPRESA");

            migrationBuilder.DropTable(
                name: "NomCuentaE");

            migrationBuilder.DropTable(
                name: "TIPOCUENTA");

            migrationBuilder.DropTable(
                name: "SECTOR");
        }
    }
}
