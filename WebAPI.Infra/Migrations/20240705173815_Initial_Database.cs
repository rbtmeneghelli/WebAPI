using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArchiveType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_Time = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 7, 5, 14, 38, 15, 158, DateTimeKind.Unspecified).AddTicks(9262)),
                    Update_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchiveType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Audit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_Time = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 7, 5, 14, 38, 15, 158, DateTimeKind.Unspecified).AddTicks(261)),
                    Update_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Table_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Action_Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Key_Values = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    Old_Values = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    New_Values = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_Time = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 7, 5, 14, 38, 15, 158, DateTimeKind.Unspecified).AddTicks(4134)),
                    Update_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_Time = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 7, 5, 14, 38, 15, 159, DateTimeKind.Unspecified).AddTicks(1203)),
                    Update_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_Time = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 7, 5, 14, 38, 15, 159, DateTimeKind.Unspecified).AddTicks(5615)),
                    Update_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SmtpConfig = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Method = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Message_Error = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    Update_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Object = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_Time = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 7, 5, 14, 38, 15, 158, DateTimeKind.Unspecified).AddTicks(6247)),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_Time = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 7, 5, 14, 38, 15, 158, DateTimeKind.Unspecified).AddTicks(2725)),
                    Update_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_Time = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 7, 5, 14, 38, 15, 156, DateTimeKind.Unspecified).AddTicks(8662)),
                    Update_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProfileTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_Time = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 7, 5, 14, 38, 15, 157, DateTimeKind.Unspecified).AddTicks(8831)),
                    Update_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Initials = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientAddress",
                columns: table => new
                {
                    ClientId = table.Column<long>(type: "bigint", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAddress", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_ClientAddress_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClientDocument",
                columns: table => new
                {
                    ClientId = table.Column<long>(type: "bigint", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDocument", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_ClientDocument_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmailDisplay",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_Time = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 7, 5, 14, 38, 15, 159, DateTimeKind.Unspecified).AddTicks(3231)),
                    Update_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    HasAttachment = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    EmailTemplateId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailDisplay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailDisplay_EmailTemplate_EmailTemplateId",
                        column: x => x.EmailTemplateId,
                        principalTable: "EmailTemplate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_Time = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 7, 5, 14, 38, 15, 157, DateTimeKind.Unspecified).AddTicks(47)),
                    Update_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Action = table.Column<byte>(type: "tinyint", nullable: false),
                    IdOperation = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "IdOperation",
                        column: x => x.IdOperation,
                        principalTable: "Operation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProfileOperations",
                columns: table => new
                {
                    Id_Profile = table.Column<long>(type: "bigint", nullable: false),
                    Id_Operation = table.Column<long>(type: "bigint", nullable: false),
                    CanCreate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CanResearch = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CanUpdate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CanDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CanExport = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CanImport = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileOperations", x => new { x.Id_Profile, x.Id_Operation });
                    table.ForeignKey(
                        name: "FK_ProfileOperations_Operation_Id_Operation",
                        column: x => x.Id_Operation,
                        principalTable: "Operation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProfileOperations_Profiles_Id_Profile",
                        column: x => x.Id_Profile,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    Created_Time = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 7, 5, 14, 38, 15, 156, DateTimeKind.Unspecified).AddTicks(6245))
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    Update_Time = table.Column<DateTime>(type: "datetime2", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    Login = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    Last_Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    Is_Authenticated = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    IdProfile = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    HasTwoFactoryValidation = table.Column<bool>(type: "bit", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    InicioValidade = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade"),
                    TerminoValidade = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Profiles_IdProfile",
                        column: x => x.IdProfile,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade");

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_Time = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 7, 5, 14, 38, 15, 157, DateTimeKind.Unspecified).AddTicks(4264)),
                    Update_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Initials = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ceps",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_Time = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 7, 5, 14, 38, 15, 157, DateTimeKind.Unspecified).AddTicks(6314)),
                    Update_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
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
                    table.PrimaryKey("PK_Ceps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ceps_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_Time = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 7, 5, 14, 38, 15, 158, DateTimeKind.Unspecified).AddTicks(7193)),
                    Update_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ibge = table.Column<long>(type: "bigint", maxLength: 255, nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ArchiveType",
                columns: new[] { "Id", "Created_Time", "Description", "Is_Active", "Update_Time" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 7, 5, 14, 38, 15, 167, DateTimeKind.Unspecified).AddTicks(6475), "Word", true, null },
                    { 2L, new DateTime(2024, 7, 5, 14, 38, 15, 167, DateTimeKind.Unspecified).AddTicks(6506), "Excel", true, null },
                    { 3L, new DateTime(2024, 7, 5, 14, 38, 15, 167, DateTimeKind.Unspecified).AddTicks(6510), "Pdf", true, null },
                    { 4L, new DateTime(2024, 7, 5, 14, 38, 15, 167, DateTimeKind.Unspecified).AddTicks(6513), "Txt", true, null },
                    { 5L, new DateTime(2024, 7, 5, 14, 38, 15, 167, DateTimeKind.Unspecified).AddTicks(6520), "Jpg", true, null },
                    { 6L, new DateTime(2024, 7, 5, 14, 38, 15, 167, DateTimeKind.Unspecified).AddTicks(6523), "Word", true, null },
                    { 7L, new DateTime(2024, 7, 5, 14, 38, 15, 167, DateTimeKind.Unspecified).AddTicks(6526), "Png", true, null }
                });

            migrationBuilder.InsertData(
                table: "EmailTemplate",
                columns: new[] { "Id", "Created_Time", "Description", "Is_Active", "Update_Time" },
                values: new object[] { 1L, new DateTime(2024, 7, 5, 14, 38, 15, 167, DateTimeKind.Unspecified).AddTicks(6587), "WebAPI", true, null });

            migrationBuilder.InsertData(
                table: "EmailType",
                columns: new[] { "Id", "Created_Time", "Description", "Is_Active", "SmtpConfig", "Update_Time" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 7, 5, 14, 38, 15, 167, DateTimeKind.Unspecified).AddTicks(6754), "Gmail", true, "smtp.gmail.com", null },
                    { 2L, new DateTime(2024, 7, 5, 14, 38, 15, 167, DateTimeKind.Unspecified).AddTicks(6759), "Outlook", true, "smtp.office365.com", null },
                    { 3L, new DateTime(2024, 7, 5, 14, 38, 15, 167, DateTimeKind.Unspecified).AddTicks(6762), "Hotmail", true, "smtp.live.com", null }
                });

            migrationBuilder.InsertData(
                table: "Operation",
                columns: new[] { "Id", "Created_Time", "Description", "Is_Active", "Update_Time" },
                values: new object[] { 1L, new DateTime(2024, 7, 5, 14, 38, 15, 159, DateTimeKind.Unspecified).AddTicks(7412), "Auditoria", true, null });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Created_Time", "Description", "Is_Active", "ProfileTypeId", "Update_Time" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 7, 5, 14, 38, 15, 159, DateTimeKind.Unspecified).AddTicks(7230), "Perfil Usuário", true, 0, null },
                    { 2L, new DateTime(2024, 7, 5, 14, 38, 15, 159, DateTimeKind.Unspecified).AddTicks(7242), "Perfil Administrador", true, 0, null },
                    { 3L, new DateTime(2024, 7, 5, 14, 38, 15, 159, DateTimeKind.Unspecified).AddTicks(7246), "Perfil Manager", true, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Action", "Created_Time", "Description", "IdOperation", "Role", "Update_Time" },
                values: new object[] { 1L, (byte)0, new DateTime(2024, 7, 5, 14, 38, 15, 159, DateTimeKind.Unspecified).AddTicks(7443), "Regra de acesso a tela de Auditoria", null, "ROLE_AUDIT", null });

            migrationBuilder.InsertData(
                table: "EmailDisplay",
                columns: new[] { "Id", "Body", "Created_Time", "EmailTemplateId", "Is_Active", "Priority", "Subject", "Title", "Update_Time" },
                values: new object[,]
                {
                    { 1L, "Olá, {0}<br>Seja bem vindo ao <b>{1}</b><br> Utilize a senha <b>1234</b> para acessar o sistema e usufrua de todas as ferramentas disponíveis.<br>", new DateTime(2024, 7, 5, 14, 38, 15, 167, DateTimeKind.Unspecified).AddTicks(6799), 1L, true, 1, "Bem vindo ao sistema {0}", "Boas vindas", null },
                    { 2L, "<center>Olá, {0}</center><center>Conforme sua solicitação enviamos este email para que você possa concluir sua solicitação de esqueci a senha. Clique no botão abaixo.</center><br> ", new DateTime(2024, 7, 5, 14, 38, 15, 167, DateTimeKind.Unspecified).AddTicks(6805), 1L, true, 1, "{0} - Esqueci a senha", "Esqueci a senha", null },
                    { 3L, "<center>Olá, {0}</center><center>Conforme sua solicitação enviamos este email para que você possa concluir sua solicitação de troca de senha. Clique no botão abaixo.</center><br> ", new DateTime(2024, 7, 5, 14, 38, 15, 167, DateTimeKind.Unspecified).AddTicks(6809), 1L, true, 1, "{0} - Solicitação de troca de senha", "Troca de senha", null },
                    { 4L, "<center>Olá, {0}</center><center>Quero reporta-lo que a sua confirmação de senha foi realizada com sucesso no periodo das 05/07/2024 - 14:38</center><br> ", new DateTime(2024, 7, 5, 14, 38, 15, 167, DateTimeKind.Unspecified).AddTicks(7178), 1L, true, 1, "{0} - Confirmação de senha", "Confirmação de senha", null }
                });

            migrationBuilder.InsertData(
                table: "EmailDisplay",
                columns: new[] { "Id", "Body", "Created_Time", "EmailTemplateId", "HasAttachment", "Is_Active", "Priority", "Subject", "Title", "Update_Time" },
                values: new object[] { 5L, "", new DateTime(2024, 7, 5, 14, 38, 15, 167, DateTimeKind.Unspecified).AddTicks(7185), 1L, true, true, 1, "{0} - Relatório", "Relatório", null });

            migrationBuilder.InsertData(
                table: "ProfileOperations",
                columns: new[] { "Id_Operation", "Id_Profile" },
                values: new object[] { 1L, 1L });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created_Time", "HasTwoFactoryValidation", "IdProfile", "Is_Active", "Is_Authenticated", "Last_Password", "Login", "Password", "Update_Time" },
                values: new object[] { 1L, new DateTime(2024, 7, 5, 14, 38, 15, 159, DateTimeKind.Unspecified).AddTicks(7500), false, 1L, true, true, "", "admin@DefaultAPI.com.br", "AQAQJwAAjxT8iTYusLQKRJlPLuTjvmY7FdABjNtppC74m7Ushfo=", null });

            migrationBuilder.CreateIndex(
                name: "IX_Ceps_StateId",
                table: "Ceps",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailDisplay_EmailTemplateId",
                table: "EmailDisplay",
                column: "EmailTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileOperations_Id_Operation",
                table: "ProfileOperations",
                column: "Id_Operation");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileOperations_Id_Profile_Id_Operation",
                table: "ProfileOperations",
                columns: new[] { "Id_Profile", "Id_Operation" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_IdOperation",
                table: "Roles",
                column: "IdOperation");

            migrationBuilder.CreateIndex(
                name: "IX_States_RegionId",
                table: "States",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdProfile",
                table: "Users",
                column: "IdProfile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchiveType");

            migrationBuilder.DropTable(
                name: "Audit");

            migrationBuilder.DropTable(
                name: "Ceps");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "ClientAddress");

            migrationBuilder.DropTable(
                name: "ClientDocument");

            migrationBuilder.DropTable(
                name: "EmailDisplay");

            migrationBuilder.DropTable(
                name: "EmailType");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "ProfileOperations");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "EmailTemplate");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
