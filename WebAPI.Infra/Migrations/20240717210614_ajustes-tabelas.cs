using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ajustestabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientAddress_Client_ClientId",
                table: "ClientAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientDocument_Client_ClientId",
                table: "ClientDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Profiles_IdProfile",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdProfile",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileOperations",
                table: "ProfileOperations");

            migrationBuilder.DropIndex(
                name: "IX_ProfileOperations_Id_Profile_Id_Operation",
                table: "ProfileOperations");

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DropColumn(
                name: "IdProfile",
                table: "Users")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade");

            migrationBuilder.DropColumn(
                name: "ProfileTypeId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "CanDelete",
                table: "ProfileOperations");

            migrationBuilder.DropColumn(
                name: "CanExport",
                table: "ProfileOperations");

            migrationBuilder.DropColumn(
                name: "CanImport",
                table: "ProfileOperations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 56, DateTimeKind.Unspecified).AddTicks(381),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 203, DateTimeKind.Unspecified).AddTicks(6037))
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "States",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 56, DateTimeKind.Unspecified).AddTicks(5926),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 204, DateTimeKind.Unspecified).AddTicks(3752));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Regions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(385),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 205, DateTimeKind.Unspecified).AddTicks(1584));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Profiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 56, DateTimeKind.Unspecified).AddTicks(2392),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 203, DateTimeKind.Unspecified).AddTicks(8401));

            migrationBuilder.AddColumn<long>(
                name: "IdArea",
                table: "Profiles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "CanUpdate",
                table: "ProfileOperations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "CanCreate",
                table: "ProfileOperations",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "ProfileOperations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Operation",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(4196),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 205, DateTimeKind.Unspecified).AddTicks(6378));

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Operation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Notification",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(7469),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 206, DateTimeKind.Unspecified).AddTicks(293));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 58, DateTimeKind.Unspecified).AddTicks(9773),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 207, DateTimeKind.Unspecified).AddTicks(253));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailTemplate",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 58, DateTimeKind.Unspecified).AddTicks(2663),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 206, DateTimeKind.Unspecified).AddTicks(5482));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailDisplay",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 58, DateTimeKind.Unspecified).AddTicks(6111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 206, DateTimeKind.Unspecified).AddTicks(7981));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Client",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(5459),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 205, DateTimeKind.Unspecified).AddTicks(7846));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Cities",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(8389),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 206, DateTimeKind.Unspecified).AddTicks(1290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Ceps",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 56, DateTimeKind.Unspecified).AddTicks(7922),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 204, DateTimeKind.Unspecified).AddTicks(7129));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Audit",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(1827),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 205, DateTimeKind.Unspecified).AddTicks(3338));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "ArchiveType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 58, DateTimeKind.Unspecified).AddTicks(365),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 206, DateTimeKind.Unspecified).AddTicks(3419));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileOperations",
                table: "ProfileOperations",
                columns: new[] { "Id", "Id_Profile", "Id_Operation" });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_Time = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(1564)),
                    Update_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HierarchyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_Time = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(3695)),
                    Update_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TelPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CelPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IdProfile = table.Column<long>(type: "bigint", nullable: false),
                    IdUser = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Profiles_IdProfile",
                        column: x => x.IdProfile,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 66, DateTimeKind.Unspecified).AddTicks(8596));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 66, DateTimeKind.Unspecified).AddTicks(8596));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 66, DateTimeKind.Unspecified).AddTicks(8596));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 66, DateTimeKind.Unspecified).AddTicks(8596));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 66, DateTimeKind.Unspecified).AddTicks(8596));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 66, DateTimeKind.Unspecified).AddTicks(8596));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 66, DateTimeKind.Unspecified).AddTicks(8596));

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "Created_Time", "Description", "HierarchyLevel", "Is_Active", "Order", "Update_Time" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791), "Administrador Dev", "Development", true, 0, null },
                    { 2L, new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791), "Administrador Sistema", "Principal", true, 0, null },
                    { 3L, new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791), "Setor Operacional", "Areas", true, 0, null },
                    { 4L, new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791), "Setor Financeiro", "Areas", true, 1, null },
                    { 5L, new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791), "Setor Marketing", "Areas", true, 2, null },
                    { 6L, new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791), "Setor Relações Humanas", "Areas", true, 3, null }
                });

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 66, DateTimeKind.Unspecified).AddTicks(8596));

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 66, DateTimeKind.Unspecified).AddTicks(8596));

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 66, DateTimeKind.Unspecified).AddTicks(8596));

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Body", "Created_Time" },
                values: new object[] { "<center>Olá, {0}</center><center>Quero reporta-lo que a sua confirmação de senha foi realizada com sucesso no periodo das 17/07/2024 - 18:06</center><br> ", new DateTime(2024, 7, 17, 18, 6, 13, 66, DateTimeKind.Unspecified).AddTicks(8596) });

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Created_Time", "HasAttachment" },
                values: new object[] { new DateTime(2024, 7, 17, 18, 6, 13, 66, DateTimeKind.Unspecified).AddTicks(8596), false });

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 66, DateTimeKind.Unspecified).AddTicks(8596));

            migrationBuilder.UpdateData(
                table: "EmailType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 66, DateTimeKind.Unspecified).AddTicks(8596));

            migrationBuilder.UpdateData(
                table: "EmailType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 66, DateTimeKind.Unspecified).AddTicks(8596));

            migrationBuilder.UpdateData(
                table: "EmailType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 66, DateTimeKind.Unspecified).AddTicks(8596));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CelPhone", "Created_Time", "Email", "IdProfile", "IdUser", "Is_Active", "Name", "TelPhone", "Update_Time" },
                values: new object[] { 1L, "12999991234", new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791), "xpto@gmail.com", 1L, 1L, true, "Administrador Desenvolvedor", "1233336789", null });

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created_Time", "Order" },
                values: new object[] { new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791), 1 });

            migrationBuilder.InsertData(
                table: "Operation",
                columns: new[] { "Id", "Created_Time", "Description", "Is_Active", "Order", "Update_Time" },
                values: new object[,]
                {
                    { 2L, new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791), "Logs", true, 2, null },
                    { 3L, new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791), "Area", true, 3, null },
                    { 4L, new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791), "Operação", true, 4, null },
                    { 5L, new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791), "Perfil", true, 5, null },
                    { 6L, new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791), "Funcionario", true, 6, null },
                    { 7L, new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791), "Usuario", true, 7, null }
                });

            migrationBuilder.InsertData(
                table: "ProfileOperations",
                columns: new[] { "Id", "Id_Operation", "Id_Profile", "CanResearch", "CanCreate", "CanUpdate" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, true, 0, "ROLE_NEW" },
                    { 2L, 1L, 1L, true, 1, "ROLE_EDIT" },
                    { 3L, 1L, 1L, true, 2, "ROLE_DELETE" },
                    { 4L, 1L, 1L, true, 3, "ROLE_VIEW" }
                });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created_Time", "Description", "IdArea" },
                values: new object[] { new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791), "Perfil Desenvolvedor", 1L });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created_Time", "IdArea" },
                values: new object[] { new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791), 2L });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created_Time", "Description", "IdArea" },
                values: new object[] { new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791), "Perfil Manager Operacional", 3L });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created_Time", "Password" },
                values: new object[] { new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791), "AQAQJwAAWZP/MOTfE6cyYfLhnLYWyaXYJVZNxvah7zQCA9mJQRM=" });

            migrationBuilder.InsertData(
                table: "ProfileOperations",
                columns: new[] { "Id", "Id_Operation", "Id_Profile", "CanResearch", "CanCreate", "CanUpdate" },
                values: new object[,]
                {
                    { 2L, 5L, 1L, true, 3, "ROLE_VIEW" },
                    { 5L, 2L, 1L, true, 0, "ROLE_NEW" },
                    { 6L, 2L, 1L, true, 1, "ROLE_EDIT" },
                    { 7L, 2L, 1L, true, 2, "ROLE_DELETE" },
                    { 8L, 2L, 1L, true, 3, "ROLE_VIEW" },
                    { 9L, 3L, 1L, true, 0, "ROLE_NEW" },
                    { 10L, 3L, 1L, true, 1, "ROLE_EDIT" },
                    { 11L, 3L, 1L, true, 2, "ROLE_DELETE" },
                    { 12L, 3L, 1L, true, 3, "ROLE_VIEW" },
                    { 13L, 4L, 1L, true, 0, "ROLE_NEW" },
                    { 14L, 4L, 1L, true, 1, "ROLE_EDIT" },
                    { 15L, 4L, 1L, true, 2, "ROLE_DELETE" },
                    { 16L, 4L, 1L, true, 3, "ROLE_VIEW" },
                    { 17L, 5L, 1L, true, 0, "ROLE_NEW" },
                    { 18L, 5L, 1L, true, 1, "ROLE_EDIT" },
                    { 19L, 5L, 1L, true, 2, "ROLE_DELETE" },
                    { 21L, 6L, 1L, true, 0, "ROLE_NEW" },
                    { 22L, 6L, 1L, true, 1, "ROLE_EDIT" },
                    { 23L, 6L, 1L, true, 2, "ROLE_DELETE" },
                    { 24L, 6L, 1L, true, 3, "ROLE_VIEW" },
                    { 25L, 7L, 1L, true, 0, "ROLE_NEW" },
                    { 26L, 7L, 1L, true, 1, "ROLE_EDIT" },
                    { 27L, 7L, 1L, true, 2, "ROLE_DELETE" },
                    { 28L, 7L, 1L, true, 3, "ROLE_VIEW" },
                    { 29L, 2L, 2L, true, 0, "ROLE_NEW" },
                    { 30L, 2L, 2L, true, 1, "ROLE_EDIT" },
                    { 31L, 2L, 2L, true, 2, "ROLE_DELETE" },
                    { 32L, 2L, 2L, true, 3, "ROLE_VIEW" },
                    { 33L, 3L, 2L, true, 0, "ROLE_NEW" },
                    { 34L, 3L, 2L, true, 1, "ROLE_EDIT" },
                    { 35L, 3L, 2L, true, 2, "ROLE_DELETE" },
                    { 36L, 3L, 2L, true, 3, "ROLE_VIEW" },
                    { 37L, 4L, 2L, true, 0, "ROLE_NEW" },
                    { 38L, 4L, 2L, true, 1, "ROLE_EDIT" },
                    { 39L, 4L, 2L, true, 2, "ROLE_DELETE" },
                    { 40L, 4L, 2L, true, 3, "ROLE_VIEW" },
                    { 41L, 5L, 2L, true, 0, "ROLE_NEW" },
                    { 42L, 5L, 2L, true, 1, "ROLE_EDIT" },
                    { 43L, 5L, 2L, true, 2, "ROLE_DELETE" },
                    { 44L, 5L, 2L, true, 3, "ROLE_VIEW" },
                    { 45L, 6L, 2L, true, 0, "ROLE_NEW" },
                    { 46L, 6L, 2L, true, 1, "ROLE_EDIT" },
                    { 47L, 6L, 2L, true, 2, "ROLE_DELETE" },
                    { 48L, 6L, 2L, true, 3, "ROLE_VIEW" },
                    { 49L, 7L, 2L, true, 0, "ROLE_NEW" },
                    { 50L, 7L, 2L, true, 1, "ROLE_EDIT" },
                    { 51L, 7L, 2L, true, 2, "ROLE_DELETE" },
                    { 52L, 7L, 2L, true, 3, "ROLE_VIEW" },
                    { 53L, 5L, 3L, true, 0, "ROLE_NEW" },
                    { 54L, 5L, 3L, true, 1, "ROLE_EDIT" },
                    { 55L, 5L, 3L, true, 2, "ROLE_DELETE" },
                    { 56L, 5L, 3L, true, 3, "ROLE_VIEW" },
                    { 57L, 6L, 3L, true, 0, "ROLE_NEW" },
                    { 58L, 6L, 3L, true, 1, "ROLE_EDIT" },
                    { 59L, 6L, 3L, true, 2, "ROLE_DELETE" },
                    { 60L, 6L, 3L, true, 3, "ROLE_VIEW" },
                    { 61L, 7L, 3L, true, 0, "ROLE_NEW" },
                    { 62L, 7L, 3L, true, 1, "ROLE_EDIT" },
                    { 63L, 7L, 3L, true, 2, "ROLE_DELETE" },
                    { 64L, 7L, 3L, true, 3, "ROLE_VIEW" }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Created_Time", "Description", "IdArea", "Is_Active", "Update_Time" },
                values: new object[] { 4L, new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791), "Perfil Manager Financeiro", 4L, true, null });

            migrationBuilder.InsertData(
                table: "ProfileOperations",
                columns: new[] { "Id", "Id_Operation", "Id_Profile", "CanResearch", "CanCreate", "CanUpdate" },
                values: new object[,]
                {
                    { 65L, 5L, 4L, true, 0, "ROLE_NEW" },
                    { 66L, 5L, 4L, true, 1, "ROLE_EDIT" },
                    { 67L, 5L, 4L, true, 2, "ROLE_DELETE" },
                    { 68L, 5L, 4L, true, 3, "ROLE_VIEW" },
                    { 69L, 6L, 4L, true, 0, "ROLE_NEW" },
                    { 70L, 6L, 4L, true, 1, "ROLE_EDIT" },
                    { 71L, 6L, 4L, true, 2, "ROLE_DELETE" },
                    { 72L, 6L, 4L, true, 3, "ROLE_VIEW" },
                    { 73L, 7L, 4L, true, 0, "ROLE_NEW" },
                    { 74L, 7L, 4L, true, 1, "ROLE_EDIT" },
                    { 75L, 7L, 4L, true, 2, "ROLE_DELETE" },
                    { 76L, 7L, 4L, true, 3, "ROLE_VIEW" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_IdArea",
                table: "Profiles",
                column: "IdArea");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileOperations_Id_Id_Profile_Id_Operation",
                table: "ProfileOperations",
                columns: new[] { "Id", "Id_Profile", "Id_Operation" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileOperations_Id_Profile",
                table: "ProfileOperations",
                column: "Id_Profile");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdProfile",
                table: "Employees",
                column: "IdProfile");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdUser",
                table: "Employees",
                column: "IdUser",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAddress_Client_ClientId",
                table: "ClientAddress",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientDocument_Client_ClientId",
                table: "ClientDocument",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Areas_IdArea",
                table: "Profiles",
                column: "IdArea",
                principalTable: "Areas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientAddress_Client_ClientId",
                table: "ClientAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientDocument_Client_ClientId",
                table: "ClientDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Areas_IdArea",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_IdArea",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileOperations",
                table: "ProfileOperations");

            migrationBuilder.DropIndex(
                name: "IX_ProfileOperations_Id_Id_Profile_Id_Operation",
                table: "ProfileOperations");

            migrationBuilder.DropIndex(
                name: "IX_ProfileOperations_Id_Profile",
                table: "ProfileOperations");

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 1L, 1L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 2L, 1L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 2L, 5L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 3L, 1L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 4L, 1L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 5L, 2L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 6L, 2L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 7L, 2L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 8L, 2L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 9L, 3L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 10L, 3L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 11L, 3L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 12L, 3L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 13L, 4L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 14L, 4L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 15L, 4L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 16L, 4L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 17L, 5L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 18L, 5L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 19L, 5L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 21L, 6L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 22L, 6L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 23L, 6L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 24L, 6L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 25L, 7L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 26L, 7L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 27L, 7L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 28L, 7L, 1L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 29L, 2L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 30L, 2L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 31L, 2L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 32L, 2L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 33L, 3L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 34L, 3L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 35L, 3L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 36L, 3L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 37L, 4L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 38L, 4L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 39L, 4L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 40L, 4L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 41L, 5L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 42L, 5L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 43L, 5L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 44L, 5L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 45L, 6L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 46L, 6L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 47L, 6L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 48L, 6L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 49L, 7L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 50L, 7L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 51L, 7L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 52L, 7L, 2L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 53L, 5L, 3L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 54L, 5L, 3L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 55L, 5L, 3L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 56L, 5L, 3L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 57L, 6L, 3L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 58L, 6L, 3L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 59L, 6L, 3L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 60L, 6L, 3L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 61L, 7L, 3L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 62L, 7L, 3L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 63L, 7L, 3L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 64L, 7L, 3L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 65L, 5L, 4L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 66L, 5L, 4L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 67L, 5L, 4L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 68L, 5L, 4L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 69L, 6L, 4L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 70L, 6L, 4L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 71L, 6L, 4L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 72L, 6L, 4L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 73L, 7L, 4L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 74L, 7L, 4L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 75L, 7L, 4L });

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyColumnTypes: new[] { "bigint", "bigint", "bigint" },
                keyValues: new object[] { 76L, 7L, 4L });

            migrationBuilder.DeleteData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DropColumn(
                name: "IdArea",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProfileOperations");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Operation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 203, DateTimeKind.Unspecified).AddTicks(6037),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 56, DateTimeKind.Unspecified).AddTicks(381))
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade");

            migrationBuilder.AddColumn<long>(
                name: "IdProfile",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "UsersHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "States",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 204, DateTimeKind.Unspecified).AddTicks(3752),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 56, DateTimeKind.Unspecified).AddTicks(5926));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Regions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 205, DateTimeKind.Unspecified).AddTicks(1584),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(385));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Profiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 203, DateTimeKind.Unspecified).AddTicks(8401),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 56, DateTimeKind.Unspecified).AddTicks(2392));

            migrationBuilder.AddColumn<int>(
                name: "ProfileTypeId",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "CanUpdate",
                table: "ProfileOperations",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<bool>(
                name: "CanCreate",
                table: "ProfileOperations",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "CanDelete",
                table: "ProfileOperations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanExport",
                table: "ProfileOperations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanImport",
                table: "ProfileOperations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Operation",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 205, DateTimeKind.Unspecified).AddTicks(6378),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(4196));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Notification",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 206, DateTimeKind.Unspecified).AddTicks(293),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(7469));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 207, DateTimeKind.Unspecified).AddTicks(253),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 58, DateTimeKind.Unspecified).AddTicks(9773));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailTemplate",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 206, DateTimeKind.Unspecified).AddTicks(5482),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 58, DateTimeKind.Unspecified).AddTicks(2663));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailDisplay",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 206, DateTimeKind.Unspecified).AddTicks(7981),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 58, DateTimeKind.Unspecified).AddTicks(6111));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Client",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 205, DateTimeKind.Unspecified).AddTicks(7846),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(5459));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Cities",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 206, DateTimeKind.Unspecified).AddTicks(1290),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(8389));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Ceps",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 204, DateTimeKind.Unspecified).AddTicks(7129),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 56, DateTimeKind.Unspecified).AddTicks(7922));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Audit",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 205, DateTimeKind.Unspecified).AddTicks(3338),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(1827));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "ArchiveType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 206, DateTimeKind.Unspecified).AddTicks(3419),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 58, DateTimeKind.Unspecified).AddTicks(365));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileOperations",
                table: "ProfileOperations",
                columns: new[] { "Id_Profile", "Id_Operation" });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_Time = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 7, 5, 14, 41, 43, 203, DateTimeKind.Unspecified).AddTicks(9818)),
                    Update_Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IdOperation = table.Column<long>(type: "bigint", nullable: true),
                    Action = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
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

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 5, 14, 41, 43, 214, DateTimeKind.Unspecified).AddTicks(5201));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 5, 14, 41, 43, 214, DateTimeKind.Unspecified).AddTicks(5211));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 5, 14, 41, 43, 214, DateTimeKind.Unspecified).AddTicks(5214));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 5, 14, 41, 43, 214, DateTimeKind.Unspecified).AddTicks(5217));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 5, 14, 41, 43, 214, DateTimeKind.Unspecified).AddTicks(5383));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 5, 14, 41, 43, 214, DateTimeKind.Unspecified).AddTicks(5386));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 5, 14, 41, 43, 214, DateTimeKind.Unspecified).AddTicks(5389));

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 5, 14, 41, 43, 214, DateTimeKind.Unspecified).AddTicks(5529));

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 5, 14, 41, 43, 214, DateTimeKind.Unspecified).AddTicks(5536));

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 5, 14, 41, 43, 214, DateTimeKind.Unspecified).AddTicks(5540));

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Body", "Created_Time" },
                values: new object[] { "<center>Olá, {0}</center><center>Quero reporta-lo que a sua confirmação de senha foi realizada com sucesso no periodo das 05/07/2024 - 14:41</center><br> ", new DateTime(2024, 7, 5, 14, 41, 43, 214, DateTimeKind.Unspecified).AddTicks(5709) });

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Created_Time", "HasAttachment" },
                values: new object[] { new DateTime(2024, 7, 5, 14, 41, 43, 214, DateTimeKind.Unspecified).AddTicks(5714), true });

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 5, 14, 41, 43, 214, DateTimeKind.Unspecified).AddTicks(5459));

            migrationBuilder.UpdateData(
                table: "EmailType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 5, 14, 41, 43, 214, DateTimeKind.Unspecified).AddTicks(5489));

            migrationBuilder.UpdateData(
                table: "EmailType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 5, 14, 41, 43, 214, DateTimeKind.Unspecified).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "EmailType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 5, 14, 41, 43, 214, DateTimeKind.Unspecified).AddTicks(5497));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 5, 14, 41, 43, 207, DateTimeKind.Unspecified).AddTicks(2067));

            migrationBuilder.InsertData(
                table: "ProfileOperations",
                columns: new[] { "Id_Operation", "Id_Profile" },
                values: new object[] { 1L, 1L });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created_Time", "Description", "ProfileTypeId" },
                values: new object[] { new DateTime(2024, 7, 5, 14, 41, 43, 207, DateTimeKind.Unspecified).AddTicks(1886), "Perfil Usuário", 0 });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Created_Time", "ProfileTypeId" },
                values: new object[] { new DateTime(2024, 7, 5, 14, 41, 43, 207, DateTimeKind.Unspecified).AddTicks(1898), 0 });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Created_Time", "Description", "ProfileTypeId" },
                values: new object[] { new DateTime(2024, 7, 5, 14, 41, 43, 207, DateTimeKind.Unspecified).AddTicks(1901), "Perfil Manager", 0 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Action", "Created_Time", "Description", "IdOperation", "Role", "Update_Time" },
                values: new object[] { 1L, (byte)0, new DateTime(2024, 7, 5, 14, 41, 43, 207, DateTimeKind.Unspecified).AddTicks(2099), "Regra de acesso a tela de Auditoria", null, "ROLE_AUDIT", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created_Time", "IdProfile", "Password" },
                values: new object[] { new DateTime(2024, 7, 5, 14, 41, 43, 207, DateTimeKind.Unspecified).AddTicks(2151), 1L, "AQAQJwAAIzuMrPc+lZG1OhPHDmRaH+KcDI1r3pXeTUyAHmqM6vs=" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdProfile",
                table: "Users",
                column: "IdProfile");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileOperations_Id_Profile_Id_Operation",
                table: "ProfileOperations",
                columns: new[] { "Id_Profile", "Id_Operation" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_IdOperation",
                table: "Roles",
                column: "IdOperation");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAddress_Client_ClientId",
                table: "ClientAddress",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientDocument_Client_ClientId",
                table: "ClientDocument",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Profiles_IdProfile",
                table: "Users",
                column: "IdProfile",
                principalTable: "Profiles",
                principalColumn: "Id");
        }
    }
}
