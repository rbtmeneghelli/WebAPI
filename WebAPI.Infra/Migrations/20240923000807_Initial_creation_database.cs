using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial_creation_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configuration_EnvironmentTypeSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 224, DateTimeKind.Unspecified).AddTicks(583)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Description = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Initials = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration_EnvironmentTypeSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ControlPanel_Area",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 220, DateTimeKind.Unspecified).AddTicks(6534)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HierarchyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlPanel_Area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ControlPanel_Audit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(1783)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    TableName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    KeyValues = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    OldValues = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlPanel_Audit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ControlPanel_Client",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 221, DateTimeKind.Unspecified).AddTicks(9209)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlPanel_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ControlPanel_Logs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Method = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Error = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Object = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlPanel_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ControlPanel_Notification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(4416)),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlPanel_Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ControlPanel_Operation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 221, DateTimeKind.Unspecified).AddTicks(1567)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlPanel_Operation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ControlPanel_Region",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(216)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Initials = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlPanel_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ControlPanel_User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ControlPanel_UserHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 221, DateTimeKind.Unspecified).AddTicks(2863))
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ControlPanel_UserHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ControlPanel_UserHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ControlPanel_UserHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    Login = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ControlPanel_UserHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ControlPanel_UserHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    LastPassword = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ControlPanel_UserHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    IsAuthenticated = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ControlPanel_UserHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    HasTwoFactoryValidation = table.Column<bool>(type: "bit", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ControlPanel_UserHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    InicioValidade = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ControlPanel_UserHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    TerminoValidade = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "ControlPanel_UserHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlPanel_User", x => x.Id);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ControlPanel_UserHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade");

            migrationBuilder.CreateTable(
                name: "Configuration_AuthenticationSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 222, DateTimeKind.Unspecified).AddTicks(8868)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    NumberOfTryToBlockUser = table.Column<int>(type: "int", nullable: false),
                    BlockUserTime = table.Column<int>(type: "int", nullable: false),
                    ApplyTwoFactoryValidation = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IdEnvironmentType = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration_AuthenticationSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configuration_AuthenticationSettings_Configuration_EnvironmentTypeSettings_IdEnvironmentType",
                        column: x => x.IdEnvironmentType,
                        principalTable: "Configuration_EnvironmentTypeSettings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Configuration_EmailSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 222, DateTimeKind.Unspecified).AddTicks(6329)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Host = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    SmtpConfig = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    PrimaryPort = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    EnableSsl = table.Column<bool>(type: "bit", maxLength: 80, nullable: false),
                    IdEnvironmentType = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration_EmailSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configuration_EmailSettings_Configuration_EnvironmentTypeSettings_IdEnvironmentType",
                        column: x => x.IdEnvironmentType,
                        principalTable: "Configuration_EnvironmentTypeSettings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Configuration_ExpirationPasswordSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 223, DateTimeKind.Unspecified).AddTicks(1163)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    QtyDaysPasswordExpire = table.Column<int>(type: "int", nullable: false),
                    NotifyExpirationDays = table.Column<int>(type: "int", nullable: false),
                    IdEnvironmentType = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration_ExpirationPasswordSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configuration_ExpirationPasswordSettings_Configuration_EnvironmentTypeSettings_IdEnvironmentType",
                        column: x => x.IdEnvironmentType,
                        principalTable: "Configuration_EnvironmentTypeSettings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Configuration_LayoutSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 223, DateTimeKind.Unspecified).AddTicks(3402))
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    LogoWeb = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    BannerWeb = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    LogoMobile = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    BannerMobile = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    ImageFileContentToUpload = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    DocumentFileContentToUpload = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    MaxImageFileSize = table.Column<int>(type: "int", nullable: false, defaultValue: 20)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    MaxDocumentFileSize = table.Column<int>(type: "int", nullable: false, defaultValue: 20)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    IdEnvironmentType = table.Column<long>(type: "bigint", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    InicioValidade = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    TerminoValidade = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration_LayoutSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configuration_LayoutSettings_Configuration_EnvironmentTypeSettings_IdEnvironmentType",
                        column: x => x.IdEnvironmentType,
                        principalTable: "Configuration_EnvironmentTypeSettings",
                        principalColumn: "Id");
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade");

            migrationBuilder.CreateTable(
                name: "Configuration_LogSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 223, DateTimeKind.Unspecified).AddTicks(6327)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    SaveLogTurnOnSystem = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SaveLogTurnOffSystem = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SaveLogCreateData = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    SaveLogResearchData = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    SaveLogUpdateData = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    SaveLogDeleteData = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IdEnvironmentType = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration_LogSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configuration_LogSettings_Configuration_EnvironmentTypeSettings_IdEnvironmentType",
                        column: x => x.IdEnvironmentType,
                        principalTable: "Configuration_EnvironmentTypeSettings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Configuration_RequiredPasswordSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 223, DateTimeKind.Unspecified).AddTicks(8841)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    MinimalOfChars = table.Column<int>(type: "int", nullable: false),
                    MustHaveUpperCaseLetter = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    MustHaveNumbers = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    MustHaveSpecialChars = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IdEnvironmentType = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration_RequiredPasswordSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configuration_RequiredPasswordSettings_Configuration_EnvironmentTypeSettings_IdEnvironmentType",
                        column: x => x.IdEnvironmentType,
                        principalTable: "Configuration_EnvironmentTypeSettings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ControlPanel_Profile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 221, DateTimeKind.Unspecified).AddTicks(5190)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdArea = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlPanel_Profile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlPanel_Profile_ControlPanel_Area_IdArea",
                        column: x => x.IdArea,
                        principalTable: "ControlPanel_Area",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ControlPanel_ClientAddress",
                columns: table => new
                {
                    ClientId = table.Column<long>(type: "bigint", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlPanel_ClientAddress", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_ControlPanel_ClientAddress_ControlPanel_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ControlPanel_Client",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ControlPanel_ClientDocument",
                columns: table => new
                {
                    ClientId = table.Column<long>(type: "bigint", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlPanel_ClientDocument", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_ControlPanel_ClientDocument_ControlPanel_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ControlPanel_Client",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ControlPanel_State",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 224, DateTimeKind.Unspecified).AddTicks(5308)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Initials = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlPanel_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlPanel_State_ControlPanel_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "ControlPanel_Region",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Configuration_EmailTemplateSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 222, DateTimeKind.Unspecified).AddTicks(1620)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EmailSettingsId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration_EmailTemplateSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configuration_EmailTemplateSettings_Configuration_EmailSettings_EmailSettingsId",
                        column: x => x.EmailSettingsId,
                        principalTable: "Configuration_EmailSettings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ControlPanel_Employee",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 220, DateTimeKind.Unspecified).AddTicks(8759)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TelPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CelPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IdProfile = table.Column<long>(type: "bigint", nullable: false),
                    IdUser = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlPanel_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlPanel_Employee_ControlPanel_Profile_IdProfile",
                        column: x => x.IdProfile,
                        principalTable: "ControlPanel_Profile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ControlPanel_Employee_ControlPanel_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "ControlPanel_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ControlPanel_ProfileOperations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProfile = table.Column<long>(type: "bigint", nullable: false),
                    IdOperation = table.Column<long>(type: "bigint", nullable: false),
                    RoleTag = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlPanel_ProfileOperations", x => new { x.Id, x.IdProfile, x.IdOperation });
                    table.ForeignKey(
                        name: "FK_ControlPanel_ProfileOperations_ControlPanel_Operation_IdOperation",
                        column: x => x.IdOperation,
                        principalTable: "ControlPanel_Operation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ControlPanel_ProfileOperations_ControlPanel_Profile_IdProfile",
                        column: x => x.IdProfile,
                        principalTable: "ControlPanel_Profile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ControlPanel_Cep",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 224, DateTimeKind.Unspecified).AddTicks(7495)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Cep = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Complement = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    District = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uf = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Ibge = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Gia = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ddd = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Siafi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StateId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlPanel_Cep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlPanel_Cep_ControlPanel_State_StateId",
                        column: x => x.StateId,
                        principalTable: "ControlPanel_State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ControlPanel_City",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(5321)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ibge = table.Column<long>(type: "bigint", maxLength: 255, nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlPanel_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlPanel_City_ControlPanel_State_StateId",
                        column: x => x.StateId,
                        principalTable: "ControlPanel_State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Configuration_EmailDisplaySettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 222, DateTimeKind.Unspecified).AddTicks(3815)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    HasAttachment = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    EmailTemplateId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration_EmailDisplaySettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configuration_EmailDisplaySettings_Configuration_EmailTemplateSettings_EmailTemplateId",
                        column: x => x.EmailTemplateId,
                        principalTable: "Configuration_EmailTemplateSettings",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Configuration_EmailTemplateSettings",
                columns: new[] { "Id", "CreateDate", "Description", "EmailSettingsId", "Status", "UpdateDate" },
                values: new object[] { 1L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), "WebAPI", null, true, null });

            migrationBuilder.InsertData(
                table: "Configuration_EnvironmentTypeSettings",
                columns: new[] { "Id", "CreateDate", "Description", "Initials", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), "Ambiente Produção", "PRD", true, null },
                    { 2L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), "Ambiente PréProdução", "PREPRD", true, null },
                    { 3L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), "Ambiente Homologação", "HML", true, null },
                    { 4L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), "Ambiente QA", "QA", true, null },
                    { 5L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), "Ambiente DEV", "DEV", true, null }
                });

            migrationBuilder.InsertData(
                table: "ControlPanel_Area",
                columns: new[] { "Id", "CreateDate", "Description", "HierarchyLevel", "Order", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416), "Administrador Dev", "Development", 0, true, null },
                    { 2L, new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416), "Administrador Sistema", "Principal", 0, true, null },
                    { 3L, new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416), "Setor Operacional", "Areas", 0, true, null },
                    { 4L, new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416), "Setor Financeiro", "Areas", 1, true, null },
                    { 5L, new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416), "Setor Marketing", "Areas", 2, true, null },
                    { 6L, new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416), "Setor Relações Humanas", "Areas", 3, true, null }
                });

            migrationBuilder.InsertData(
                table: "ControlPanel_Operation",
                columns: new[] { "Id", "CreateDate", "Description", "Order", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416), "Auditoria", 1, true, null },
                    { 2L, new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416), "Logs", 2, true, null },
                    { 3L, new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416), "Area", 3, true, null },
                    { 4L, new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416), "Operação", 4, true, null },
                    { 5L, new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416), "Perfil", 5, true, null },
                    { 6L, new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416), "Funcionario", 6, true, null },
                    { 7L, new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416), "Usuario", 7, true, null }
                });

            migrationBuilder.InsertData(
                table: "ControlPanel_User",
                columns: new[] { "Id", "CreateDate", "HasTwoFactoryValidation", "IsAuthenticated", "LastPassword", "Login", "Password", "Status", "UpdateDate" },
                values: new object[] { 1L, new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416), false, true, "", "admin@DefaultAPI.com.br", "AQAQJwAA6Qe8bt7a6+WlUjOtloEbMHYIKxQi163Q3aAyeio6v94=", true, null });

            migrationBuilder.InsertData(
                table: "Configuration_AuthenticationSettings",
                columns: new[] { "Id", "BlockUserTime", "CreateDate", "IdEnvironmentType", "NumberOfTryToBlockUser", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 1L, 60, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 1L, 3, true, null },
                    { 2L, 60, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 2L, 3, true, null },
                    { 3L, 60, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 3L, 3, true, null },
                    { 4L, 60, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 4L, 3, true, null },
                    { 5L, 60, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 5L, 3, true, null }
                });

            migrationBuilder.InsertData(
                table: "Configuration_EmailDisplaySettings",
                columns: new[] { "Id", "Body", "CreateDate", "EmailTemplateId", "Priority", "Status", "Subject", "Title", "UpdateDate" },
                values: new object[,]
                {
                    { 1L, "Olá, {0}<br>Seja bem vindo ao <b>{1}</b><br> Utilize a senha <b>1234</b> para acessar o sistema e usufrua de todas as ferramentas disponíveis.<br>", new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 1L, 1, true, "Bem vindo ao sistema {0}", "Email de boas vindas", null },
                    { 2L, "<center>Olá, {0}</center><center>Conforme sua solicitação enviamos este email para que você possa concluir sua solicitação de troca de senha. Clique no botão abaixo.</center><br> ", new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 1L, 1, true, "{0} - Solicitação de troca de senha", "Email de troca de senha", null },
                    { 3L, "<center>Olá, {0}</center><center>Conforme sua solicitação enviamos este email para que você possa concluir sua solicitação de esqueci a senha. Clique no botão abaixo.</center><br> ", new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 1L, 1, true, "{0} - Esqueci a senha", "Email de reset de senha", null },
                    { 4L, "<center>Olá, {0}</center><center>Quero reporta-lo que a sua confirmação de senha foi realizada com sucesso no periodo das 22/09/2024 - 21:08</center><br> ", new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 1L, 1, true, "{0} - Confirmação de senha", "Email de confirmação de senha", null },
                    { 5L, "", new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 1L, 1, true, "{0} - Relatório", "Email de relatório", null }
                });

            migrationBuilder.InsertData(
                table: "Configuration_EmailSettings",
                columns: new[] { "Id", "CreateDate", "Email", "EnableSsl", "Host", "IdEnvironmentType", "Password", "PrimaryPort", "SmtpConfig", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), "teste@gmail.com", true, "Gmail", 5L, "S3b7D2vFThf5+uQEQlU0Yw==", 25, "smtp.gmail.com", true, null },
                    { 2L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), "teste@gmail.com", true, "Outlook", 5L, "zdCkZ5yXfN6rVPJ8G34oRw==", 25, "smtp.office365.com", true, null },
                    { 3L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), "teste@gmail.com", true, "Hotmail", 5L, "V1p2qYzM2lX6PZbP4A6ctQ==", 25, "smtp.live.com", true, null }
                });

            migrationBuilder.InsertData(
                table: "Configuration_ExpirationPasswordSettings",
                columns: new[] { "Id", "CreateDate", "IdEnvironmentType", "NotifyExpirationDays", "QtyDaysPasswordExpire", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 1L, 5, 90, true, null },
                    { 2L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 2L, 5, 90, true, null },
                    { 3L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 3L, 5, 90, true, null },
                    { 4L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 4L, 5, 90, true, null },
                    { 5L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 5L, 5, 90, true, null }
                });

            migrationBuilder.InsertData(
                table: "Configuration_LogSettings",
                columns: new[] { "Id", "CreateDate", "IdEnvironmentType", "SaveLogCreateData", "SaveLogDeleteData", "SaveLogResearchData", "SaveLogUpdateData", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 1L, true, true, true, true, true, null },
                    { 2L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 2L, true, true, true, true, true, null },
                    { 3L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 3L, true, true, true, true, true, null },
                    { 4L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 4L, true, true, true, true, true, null },
                    { 5L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 5L, true, true, true, true, true, null }
                });

            migrationBuilder.InsertData(
                table: "Configuration_RequiredPasswordSettings",
                columns: new[] { "Id", "CreateDate", "IdEnvironmentType", "MinimalOfChars", "MustHaveNumbers", "MustHaveSpecialChars", "MustHaveUpperCaseLetter", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 1L, 10, true, true, true, true, null },
                    { 2L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 2L, 10, true, true, true, true, null },
                    { 3L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 3L, 10, true, true, true, true, null },
                    { 4L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 4L, 10, true, true, true, true, null },
                    { 5L, new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), 5L, 10, true, true, true, true, null }
                });

            migrationBuilder.InsertData(
                table: "ControlPanel_Profile",
                columns: new[] { "Id", "CreateDate", "Description", "IdArea", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416), "Perfil Desenvolvedor", 1L, true, null },
                    { 2L, new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416), "Perfil Administrador", 2L, true, null },
                    { 3L, new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416), "Perfil Manager Operacional", 3L, true, null },
                    { 4L, new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416), "Perfil Manager Financeiro", 4L, true, null }
                });

            migrationBuilder.InsertData(
                table: "ControlPanel_Employee",
                columns: new[] { "Id", "CelPhone", "CreateDate", "Email", "IdProfile", "IdUser", "Name", "Status", "TelPhone", "UpdateDate" },
                values: new object[] { 1L, "12999991234", new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416), "xpto@gmail.com", 1L, 1L, "Administrador Desenvolvedor", true, "1233336789", null });

            migrationBuilder.InsertData(
                table: "ControlPanel_ProfileOperations",
                columns: new[] { "Id", "IdOperation", "IdProfile", "IsEnable", "Order", "RoleTag" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, true, 0, "ROLE_AUDIT_NEW" },
                    { 2L, 1L, 1L, true, 1, "ROLE_AUDIT_EDIT" },
                    { 3L, 1L, 1L, true, 2, "ROLE_AUDIT_DELETE" },
                    { 4L, 1L, 1L, true, 3, "ROLE_AUDIT_VIEW" },
                    { 5L, 2L, 1L, true, 0, "ROLE_LOG_NEW" },
                    { 6L, 2L, 1L, true, 1, "ROLE_LOG_EDIT" },
                    { 7L, 2L, 1L, true, 2, "ROLE_LOG_DELETE" },
                    { 8L, 2L, 1L, true, 3, "ROLE_LOG_VIEW" },
                    { 9L, 3L, 1L, true, 0, "ROLE_AREA_NEW" },
                    { 10L, 3L, 1L, true, 1, "ROLE_AREA_EDIT" },
                    { 11L, 3L, 1L, true, 2, "ROLE_AREA_DELETE" },
                    { 12L, 3L, 1L, true, 3, "ROLE_AREA_VIEW" },
                    { 13L, 4L, 1L, true, 0, "ROLE_OPERATION_NEW" },
                    { 14L, 4L, 1L, true, 1, "ROLE_OPERATION_EDIT" },
                    { 15L, 4L, 1L, true, 2, "ROLE_OPERATION_DELETE" },
                    { 16L, 4L, 1L, true, 3, "ROLE_OPERATION_VIEW" },
                    { 17L, 5L, 1L, true, 0, "ROLE_PROFILE_NEW" },
                    { 18L, 5L, 1L, true, 1, "ROLE_PROFILE_EDIT" },
                    { 19L, 5L, 1L, true, 2, "ROLE_PROFILE_DELETE" },
                    { 20L, 5L, 1L, true, 3, "ROLE_PROFILE_VIEW" },
                    { 21L, 6L, 1L, true, 0, "ROLE_EMPLOYEE_NEW" },
                    { 22L, 6L, 1L, true, 1, "ROLE_EMPLOYEE_EDIT" },
                    { 23L, 6L, 1L, true, 2, "ROLE_EMPLOYEE_DELETE" },
                    { 24L, 6L, 1L, true, 3, "ROLE_EMPLOYEE_VIEW" },
                    { 25L, 7L, 1L, true, 0, "ROLE_USER_NEW" },
                    { 26L, 7L, 1L, true, 1, "ROLE_USER_EDIT" },
                    { 27L, 7L, 1L, true, 2, "ROLE_USER_DELETE" },
                    { 28L, 7L, 1L, true, 3, "ROLE_USER_VIEW" },
                    { 29L, 2L, 2L, true, 0, "ROLE_LOG_NEW" },
                    { 30L, 2L, 2L, true, 1, "ROLE_LOG_EDIT" },
                    { 31L, 2L, 2L, true, 2, "ROLE_LOG_DELETE" },
                    { 32L, 2L, 2L, true, 3, "ROLE_LOG_VIEW" },
                    { 33L, 3L, 2L, true, 0, "ROLE_AREA_NEW" },
                    { 34L, 3L, 2L, true, 1, "ROLE_AREA_EDIT" },
                    { 35L, 3L, 2L, true, 2, "ROLE_AREA_DELETE" },
                    { 36L, 3L, 2L, true, 3, "ROLE_AREA_VIEW" },
                    { 37L, 4L, 2L, true, 0, "ROLE_OPERATION_NEW" },
                    { 38L, 4L, 2L, true, 1, "ROLE_OPERATION_EDIT" },
                    { 39L, 4L, 2L, true, 2, "ROLE_OPERATION_DELETE" },
                    { 40L, 4L, 2L, true, 3, "ROLE_OPERATION_VIEW" },
                    { 41L, 5L, 2L, true, 0, "ROLE_PROFILE_NEW" },
                    { 42L, 5L, 2L, true, 1, "ROLE_PROFILE_EDIT" },
                    { 43L, 5L, 2L, true, 2, "ROLE_PROFILE_DELETE" },
                    { 44L, 5L, 2L, true, 3, "ROLE_PROFILE_VIEW" },
                    { 45L, 6L, 2L, true, 0, "ROLE_EMPLOYEE_NEW" },
                    { 46L, 6L, 2L, true, 1, "ROLE_EMPLOYEE_EDIT" },
                    { 47L, 6L, 2L, true, 2, "ROLE_EMPLOYEE_DELETE" },
                    { 48L, 6L, 2L, true, 3, "ROLE_EMPLOYEE_VIEW" },
                    { 49L, 7L, 2L, true, 0, "ROLE_USER_NEW" },
                    { 50L, 7L, 2L, true, 1, "ROLE_USER_EDIT" },
                    { 51L, 7L, 2L, true, 2, "ROLE_USER_DELETE" },
                    { 52L, 7L, 2L, true, 3, "ROLE_USER_VIEW" },
                    { 53L, 5L, 3L, true, 0, "ROLE_PROFILE_NEW" },
                    { 54L, 5L, 3L, true, 1, "ROLE_PROFILE_EDIT" },
                    { 55L, 5L, 3L, true, 2, "ROLE_PROFILE_DELETE" },
                    { 56L, 5L, 3L, true, 3, "ROLE_PROFILE_VIEW" },
                    { 57L, 6L, 3L, true, 0, "ROLE_EMPLOYEE_NEW" },
                    { 58L, 6L, 3L, true, 1, "ROLE_EMPLOYEE_EDIT" },
                    { 59L, 6L, 3L, true, 2, "ROLE_EMPLOYEE_DELETE" },
                    { 60L, 6L, 3L, true, 3, "ROLE_EMPLOYEE_VIEW" },
                    { 61L, 7L, 3L, true, 0, "ROLE_USER_NEW" },
                    { 62L, 7L, 3L, true, 1, "ROLE_USER_EDIT" },
                    { 63L, 7L, 3L, true, 2, "ROLE_USER_DELETE" },
                    { 64L, 7L, 3L, true, 3, "ROLE_USER_VIEW" },
                    { 65L, 5L, 4L, true, 0, "ROLE_PROFILE_NEW" },
                    { 66L, 5L, 4L, true, 1, "ROLE_PROFILE_EDIT" },
                    { 67L, 5L, 4L, true, 2, "ROLE_PROFILE_DELETE" },
                    { 68L, 5L, 4L, true, 3, "ROLE_PROFILE_VIEW" },
                    { 69L, 6L, 4L, true, 0, "ROLE_EMPLOYEE_NEW" },
                    { 70L, 6L, 4L, true, 1, "ROLE_EMPLOYEE_EDIT" },
                    { 71L, 6L, 4L, true, 2, "ROLE_EMPLOYEE_DELETE" },
                    { 72L, 6L, 4L, true, 3, "ROLE_EMPLOYEE_VIEW" },
                    { 73L, 7L, 4L, true, 0, "ROLE_USER_NEW" },
                    { 74L, 7L, 4L, true, 1, "ROLE_USER_EDIT" },
                    { 75L, 7L, 4L, true, 2, "ROLE_USER_DELETE" },
                    { 76L, 7L, 4L, true, 3, "ROLE_USER_VIEW" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_AuthenticationSettings_IdEnvironmentType",
                table: "Configuration_AuthenticationSettings",
                column: "IdEnvironmentType",
                unique: true,
                filter: "[IdEnvironmentType] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_EmailDisplaySettings_EmailTemplateId",
                table: "Configuration_EmailDisplaySettings",
                column: "EmailTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_EmailSettings_IdEnvironmentType",
                table: "Configuration_EmailSettings",
                column: "IdEnvironmentType");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_EmailTemplateSettings_EmailSettingsId",
                table: "Configuration_EmailTemplateSettings",
                column: "EmailSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_ExpirationPasswordSettings_IdEnvironmentType",
                table: "Configuration_ExpirationPasswordSettings",
                column: "IdEnvironmentType",
                unique: true,
                filter: "[IdEnvironmentType] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_LayoutSettings_IdEnvironmentType",
                table: "Configuration_LayoutSettings",
                column: "IdEnvironmentType",
                unique: true,
                filter: "[IdEnvironmentType] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_LogSettings_IdEnvironmentType",
                table: "Configuration_LogSettings",
                column: "IdEnvironmentType",
                unique: true,
                filter: "[IdEnvironmentType] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_RequiredPasswordSettings_IdEnvironmentType",
                table: "Configuration_RequiredPasswordSettings",
                column: "IdEnvironmentType",
                unique: true,
                filter: "[IdEnvironmentType] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ControlPanel_Cep_StateId",
                table: "ControlPanel_Cep",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlPanel_City_StateId",
                table: "ControlPanel_City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlPanel_Employee_IdProfile",
                table: "ControlPanel_Employee",
                column: "IdProfile");

            migrationBuilder.CreateIndex(
                name: "IX_ControlPanel_Employee_IdUser",
                table: "ControlPanel_Employee",
                column: "IdUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ControlPanel_Profile_IdArea",
                table: "ControlPanel_Profile",
                column: "IdArea");

            migrationBuilder.CreateIndex(
                name: "IX_ControlPanel_ProfileOperations_Id_IdProfile_IdOperation",
                table: "ControlPanel_ProfileOperations",
                columns: new[] { "Id", "IdProfile", "IdOperation" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ControlPanel_ProfileOperations_IdOperation",
                table: "ControlPanel_ProfileOperations",
                column: "IdOperation");

            migrationBuilder.CreateIndex(
                name: "IX_ControlPanel_ProfileOperations_IdProfile",
                table: "ControlPanel_ProfileOperations",
                column: "IdProfile");

            migrationBuilder.CreateIndex(
                name: "IX_ControlPanel_State_RegionId",
                table: "ControlPanel_State",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuration_AuthenticationSettings");

            migrationBuilder.DropTable(
                name: "Configuration_EmailDisplaySettings");

            migrationBuilder.DropTable(
                name: "Configuration_ExpirationPasswordSettings");

            migrationBuilder.DropTable(
                name: "Configuration_LayoutSettings")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade");

            migrationBuilder.DropTable(
                name: "Configuration_LogSettings");

            migrationBuilder.DropTable(
                name: "Configuration_RequiredPasswordSettings");

            migrationBuilder.DropTable(
                name: "ControlPanel_Audit");

            migrationBuilder.DropTable(
                name: "ControlPanel_Cep");

            migrationBuilder.DropTable(
                name: "ControlPanel_City");

            migrationBuilder.DropTable(
                name: "ControlPanel_ClientAddress");

            migrationBuilder.DropTable(
                name: "ControlPanel_ClientDocument");

            migrationBuilder.DropTable(
                name: "ControlPanel_Employee");

            migrationBuilder.DropTable(
                name: "ControlPanel_Logs");

            migrationBuilder.DropTable(
                name: "ControlPanel_Notification");

            migrationBuilder.DropTable(
                name: "ControlPanel_ProfileOperations");

            migrationBuilder.DropTable(
                name: "Configuration_EmailTemplateSettings");

            migrationBuilder.DropTable(
                name: "ControlPanel_State");

            migrationBuilder.DropTable(
                name: "ControlPanel_Client");

            migrationBuilder.DropTable(
                name: "ControlPanel_User")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ControlPanel_UserHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade");

            migrationBuilder.DropTable(
                name: "ControlPanel_Operation");

            migrationBuilder.DropTable(
                name: "ControlPanel_Profile");

            migrationBuilder.DropTable(
                name: "Configuration_EmailSettings");

            migrationBuilder.DropTable(
                name: "ControlPanel_Region");

            migrationBuilder.DropTable(
                name: "ControlPanel_Area");

            migrationBuilder.DropTable(
                name: "Configuration_EnvironmentTypeSettings");
        }
    }
}
