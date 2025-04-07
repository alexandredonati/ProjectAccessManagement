using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectAccessManagement.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AppType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessAreas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CredentialType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AllowsMultiAccess = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credentials_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Automations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    BusinessAreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Automations_BusinessAreas_BusinessAreaId",
                        column: x => x.BusinessAreaId,
                        principalTable: "BusinessAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CredentialModules",
                columns: table => new
                {
                    CredentialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CredentialModules", x => new { x.CredentialId, x.ModuleId });
                    table.ForeignKey(
                        name: "FK_CredentialModules_Credentials_CredentialId",
                        column: x => x.CredentialId,
                        principalTable: "Credentials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CredentialModules_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutomationCredentials",
                columns: table => new
                {
                    AutomationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CredentialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutomationCredentials", x => new { x.AutomationId, x.CredentialId });
                    table.ForeignKey(
                        name: "FK_AutomationCredentials_Automations_AutomationId",
                        column: x => x.AutomationId,
                        principalTable: "Automations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AutomationCredentials_Credentials_CredentialId",
                        column: x => x.CredentialId,
                        principalTable: "Credentials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutomationModules",
                columns: table => new
                {
                    AutomationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutomationModules", x => new { x.AutomationId, x.ModuleId });
                    table.ForeignKey(
                        name: "FK_AutomationModules_Automations_AutomationId",
                        column: x => x.AutomationId,
                        principalTable: "Automations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AutomationModules_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutomationCredentials_CredentialId",
                table: "AutomationCredentials",
                column: "CredentialId");

            migrationBuilder.CreateIndex(
                name: "IX_AutomationModules_ModuleId",
                table: "AutomationModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Automations_BusinessAreaId",
                table: "Automations",
                column: "BusinessAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_CredentialModules_ModuleId",
                table: "CredentialModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_ApplicationId",
                table: "Credentials",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_ApplicationId",
                table: "Modules",
                column: "ApplicationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutomationCredentials");

            migrationBuilder.DropTable(
                name: "AutomationModules");

            migrationBuilder.DropTable(
                name: "CredentialModules");

            migrationBuilder.DropTable(
                name: "Automations");

            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "BusinessAreas");

            migrationBuilder.DropTable(
                name: "Applications");
        }
    }
}
