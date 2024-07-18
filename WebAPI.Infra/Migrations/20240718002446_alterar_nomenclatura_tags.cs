using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Infra.Migrations
{
    /// <inheritdoc />
    public partial class alterar_nomenclatura_tags : Migration
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

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 2L, 5L, 1L });

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 168, DateTimeKind.Unspecified).AddTicks(4621),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 35, DateTimeKind.Unspecified).AddTicks(7079))
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
                defaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 169, DateTimeKind.Unspecified).AddTicks(1211),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 36, DateTimeKind.Unspecified).AddTicks(2765));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Regions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 169, DateTimeKind.Unspecified).AddTicks(6325),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 36, DateTimeKind.Unspecified).AddTicks(7657));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Profiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 168, DateTimeKind.Unspecified).AddTicks(6944),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 35, DateTimeKind.Unspecified).AddTicks(9069));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Operation",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 170, DateTimeKind.Unspecified).AddTicks(526),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(1326));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Notification",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 170, DateTimeKind.Unspecified).AddTicks(4213),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(4661));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Employees",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 171, DateTimeKind.Unspecified).AddTicks(8324),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 38, DateTimeKind.Unspecified).AddTicks(7289));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 171, DateTimeKind.Unspecified).AddTicks(3603),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 38, DateTimeKind.Unspecified).AddTicks(3400));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailTemplate",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 170, DateTimeKind.Unspecified).AddTicks(9015),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(9324));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailDisplay",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 171, DateTimeKind.Unspecified).AddTicks(1114),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 38, DateTimeKind.Unspecified).AddTicks(1197));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Client",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 170, DateTimeKind.Unspecified).AddTicks(1993),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(2558));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Cities",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 170, DateTimeKind.Unspecified).AddTicks(5227),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(5537));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Ceps",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 169, DateTimeKind.Unspecified).AddTicks(3540),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 36, DateTimeKind.Unspecified).AddTicks(4794));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Audit",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 169, DateTimeKind.Unspecified).AddTicks(7899),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 36, DateTimeKind.Unspecified).AddTicks(9040));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Areas",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 171, DateTimeKind.Unspecified).AddTicks(5581),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 38, DateTimeKind.Unspecified).AddTicks(4802));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "ArchiveType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 170, DateTimeKind.Unspecified).AddTicks(7423),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(7933));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 180, DateTimeKind.Unspecified).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 180, DateTimeKind.Unspecified).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 180, DateTimeKind.Unspecified).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 180, DateTimeKind.Unspecified).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 180, DateTimeKind.Unspecified).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 180, DateTimeKind.Unspecified).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 180, DateTimeKind.Unspecified).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 172, DateTimeKind.Unspecified).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 172, DateTimeKind.Unspecified).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 172, DateTimeKind.Unspecified).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 172, DateTimeKind.Unspecified).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 172, DateTimeKind.Unspecified).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 172, DateTimeKind.Unspecified).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 180, DateTimeKind.Unspecified).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 180, DateTimeKind.Unspecified).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 180, DateTimeKind.Unspecified).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Body", "Created_Time" },
                values: new object[] { "<center>Olá, {0}</center><center>Quero reporta-lo que a sua confirmação de senha foi realizada com sucesso no periodo das 17/07/2024 - 21:24</center><br> ", new DateTime(2024, 7, 17, 21, 24, 46, 180, DateTimeKind.Unspecified).AddTicks(4104) });

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 180, DateTimeKind.Unspecified).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 180, DateTimeKind.Unspecified).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "EmailType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 180, DateTimeKind.Unspecified).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "EmailType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 180, DateTimeKind.Unspecified).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "EmailType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 180, DateTimeKind.Unspecified).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 172, DateTimeKind.Unspecified).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 172, DateTimeKind.Unspecified).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 172, DateTimeKind.Unspecified).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 172, DateTimeKind.Unspecified).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 172, DateTimeKind.Unspecified).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 172, DateTimeKind.Unspecified).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 172, DateTimeKind.Unspecified).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 172, DateTimeKind.Unspecified).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 1L, 1L, 1L },
                column: "RoleTag",
                value: "ROLE_Audit_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 2L, 1L, 1L },
                column: "RoleTag",
                value: "ROLE_Audit_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 3L, 1L, 1L },
                column: "RoleTag",
                value: "ROLE_Audit_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 4L, 1L, 1L },
                column: "RoleTag",
                value: "ROLE_Audit_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 5L, 2L, 1L },
                column: "RoleTag",
                value: "ROLE_Log_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 6L, 2L, 1L },
                column: "RoleTag",
                value: "ROLE_Log_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 7L, 2L, 1L },
                column: "RoleTag",
                value: "ROLE_Log_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 8L, 2L, 1L },
                column: "RoleTag",
                value: "ROLE_Log_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 9L, 3L, 1L },
                column: "RoleTag",
                value: "ROLE_Area_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 10L, 3L, 1L },
                column: "RoleTag",
                value: "ROLE_Area_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 11L, 3L, 1L },
                column: "RoleTag",
                value: "ROLE_Area_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 12L, 3L, 1L },
                column: "RoleTag",
                value: "ROLE_Area_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 13L, 4L, 1L },
                column: "RoleTag",
                value: "ROLE_Operation_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 14L, 4L, 1L },
                column: "RoleTag",
                value: "ROLE_Operation_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 15L, 4L, 1L },
                column: "RoleTag",
                value: "ROLE_Operation_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 16L, 4L, 1L },
                column: "RoleTag",
                value: "ROLE_Operation_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 17L, 5L, 1L },
                column: "RoleTag",
                value: "ROLE_Profile_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 18L, 5L, 1L },
                column: "RoleTag",
                value: "ROLE_Profile_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 19L, 5L, 1L },
                column: "RoleTag",
                value: "ROLE_Profile_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 21L, 6L, 1L },
                column: "RoleTag",
                value: "ROLE_Employee_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 22L, 6L, 1L },
                column: "RoleTag",
                value: "ROLE_Employee_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 23L, 6L, 1L },
                column: "RoleTag",
                value: "ROLE_Employee_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 24L, 6L, 1L },
                column: "RoleTag",
                value: "ROLE_Employee_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 25L, 7L, 1L },
                column: "RoleTag",
                value: "ROLE_User_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 26L, 7L, 1L },
                column: "RoleTag",
                value: "ROLE_User_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 27L, 7L, 1L },
                column: "RoleTag",
                value: "ROLE_User_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 28L, 7L, 1L },
                column: "RoleTag",
                value: "ROLE_User_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 29L, 2L, 2L },
                column: "RoleTag",
                value: "ROLE_Log_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 30L, 2L, 2L },
                column: "RoleTag",
                value: "ROLE_Log_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 31L, 2L, 2L },
                column: "RoleTag",
                value: "ROLE_Log_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 32L, 2L, 2L },
                column: "RoleTag",
                value: "ROLE_Log_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 33L, 3L, 2L },
                column: "RoleTag",
                value: "ROLE_Area_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 34L, 3L, 2L },
                column: "RoleTag",
                value: "ROLE_Area_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 35L, 3L, 2L },
                column: "RoleTag",
                value: "ROLE_Area_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 36L, 3L, 2L },
                column: "RoleTag",
                value: "ROLE_Area_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 37L, 4L, 2L },
                column: "RoleTag",
                value: "ROLE_Operation_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 38L, 4L, 2L },
                column: "RoleTag",
                value: "ROLE_Operation_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 39L, 4L, 2L },
                column: "RoleTag",
                value: "ROLE_Operation_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 40L, 4L, 2L },
                column: "RoleTag",
                value: "ROLE_Operation_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 41L, 5L, 2L },
                column: "RoleTag",
                value: "ROLE_Profile_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 42L, 5L, 2L },
                column: "RoleTag",
                value: "ROLE_Profile_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 43L, 5L, 2L },
                column: "RoleTag",
                value: "ROLE_Profile_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 44L, 5L, 2L },
                column: "RoleTag",
                value: "ROLE_Profile_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 45L, 6L, 2L },
                column: "RoleTag",
                value: "ROLE_Employee_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 46L, 6L, 2L },
                column: "RoleTag",
                value: "ROLE_Employee_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 47L, 6L, 2L },
                column: "RoleTag",
                value: "ROLE_Employee_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 48L, 6L, 2L },
                column: "RoleTag",
                value: "ROLE_Employee_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 49L, 7L, 2L },
                column: "RoleTag",
                value: "ROLE_User_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 50L, 7L, 2L },
                column: "RoleTag",
                value: "ROLE_User_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 51L, 7L, 2L },
                column: "RoleTag",
                value: "ROLE_User_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 52L, 7L, 2L },
                column: "RoleTag",
                value: "ROLE_User_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 53L, 5L, 3L },
                column: "RoleTag",
                value: "ROLE_Profile_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 54L, 5L, 3L },
                column: "RoleTag",
                value: "ROLE_Profile_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 55L, 5L, 3L },
                column: "RoleTag",
                value: "ROLE_Profile_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 56L, 5L, 3L },
                column: "RoleTag",
                value: "ROLE_Profile_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 57L, 6L, 3L },
                column: "RoleTag",
                value: "ROLE_Employee_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 58L, 6L, 3L },
                column: "RoleTag",
                value: "ROLE_Employee_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 59L, 6L, 3L },
                column: "RoleTag",
                value: "ROLE_Employee_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 60L, 6L, 3L },
                column: "RoleTag",
                value: "ROLE_Employee_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 61L, 7L, 3L },
                column: "RoleTag",
                value: "ROLE_User_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 62L, 7L, 3L },
                column: "RoleTag",
                value: "ROLE_User_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 63L, 7L, 3L },
                column: "RoleTag",
                value: "ROLE_User_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 64L, 7L, 3L },
                column: "RoleTag",
                value: "ROLE_User_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 65L, 5L, 4L },
                column: "RoleTag",
                value: "ROLE_Profile_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 66L, 5L, 4L },
                column: "RoleTag",
                value: "ROLE_Profile_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 67L, 5L, 4L },
                column: "RoleTag",
                value: "ROLE_Profile_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 68L, 5L, 4L },
                column: "RoleTag",
                value: "ROLE_Profile_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 69L, 6L, 4L },
                column: "RoleTag",
                value: "ROLE_Employee_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 70L, 6L, 4L },
                column: "RoleTag",
                value: "ROLE_Employee_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 71L, 6L, 4L },
                column: "RoleTag",
                value: "ROLE_Employee_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 72L, 6L, 4L },
                column: "RoleTag",
                value: "ROLE_Employee_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 73L, 7L, 4L },
                column: "RoleTag",
                value: "ROLE_User_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 74L, 7L, 4L },
                column: "RoleTag",
                value: "ROLE_User_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 75L, 7L, 4L },
                column: "RoleTag",
                value: "ROLE_User_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 76L, 7L, 4L },
                column: "RoleTag",
                value: "ROLE_User_VIEW");

            migrationBuilder.InsertData(
                table: "ProfileOperations",
                columns: new[] { "Id", "Id_Operation", "Id_Profile", "IsEnable", "Order", "RoleTag" },
                values: new object[] { 20L, 5L, 1L, true, 3, "ROLE_Profile_VIEW" });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 172, DateTimeKind.Unspecified).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 172, DateTimeKind.Unspecified).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 172, DateTimeKind.Unspecified).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 24, 46, 172, DateTimeKind.Unspecified).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created_Time", "Password" },
                values: new object[] { new DateTime(2024, 7, 17, 21, 24, 46, 172, DateTimeKind.Unspecified).AddTicks(1440), "AQAQJwAAwjOjIlm+T6dxOhFLvSBBN+XWgoUEG++Tf8DkH5/DryQ=" });

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

            migrationBuilder.DeleteData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 20L, 5L, 1L });

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 35, DateTimeKind.Unspecified).AddTicks(7079),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 168, DateTimeKind.Unspecified).AddTicks(4621))
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
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 36, DateTimeKind.Unspecified).AddTicks(2765),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 169, DateTimeKind.Unspecified).AddTicks(1211));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Regions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 36, DateTimeKind.Unspecified).AddTicks(7657),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 169, DateTimeKind.Unspecified).AddTicks(6325));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Profiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 35, DateTimeKind.Unspecified).AddTicks(9069),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 168, DateTimeKind.Unspecified).AddTicks(6944));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Operation",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(1326),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 170, DateTimeKind.Unspecified).AddTicks(526));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Notification",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(4661),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 170, DateTimeKind.Unspecified).AddTicks(4213));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Employees",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 38, DateTimeKind.Unspecified).AddTicks(7289),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 171, DateTimeKind.Unspecified).AddTicks(8324));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 38, DateTimeKind.Unspecified).AddTicks(3400),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 171, DateTimeKind.Unspecified).AddTicks(3603));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailTemplate",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(9324),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 170, DateTimeKind.Unspecified).AddTicks(9015));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailDisplay",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 38, DateTimeKind.Unspecified).AddTicks(1197),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 171, DateTimeKind.Unspecified).AddTicks(1114));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Client",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(2558),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 170, DateTimeKind.Unspecified).AddTicks(1993));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Cities",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(5537),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 170, DateTimeKind.Unspecified).AddTicks(5227));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Ceps",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 36, DateTimeKind.Unspecified).AddTicks(4794),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 169, DateTimeKind.Unspecified).AddTicks(3540));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Audit",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 36, DateTimeKind.Unspecified).AddTicks(9040),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 169, DateTimeKind.Unspecified).AddTicks(7899));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Areas",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 38, DateTimeKind.Unspecified).AddTicks(4802),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 171, DateTimeKind.Unspecified).AddTicks(5581));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "ArchiveType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(7933),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 24, 46, 170, DateTimeKind.Unspecified).AddTicks(7423));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 46, DateTimeKind.Unspecified).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 46, DateTimeKind.Unspecified).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 46, DateTimeKind.Unspecified).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 46, DateTimeKind.Unspecified).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 46, DateTimeKind.Unspecified).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 46, DateTimeKind.Unspecified).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 46, DateTimeKind.Unspecified).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 39, DateTimeKind.Unspecified).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 39, DateTimeKind.Unspecified).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 39, DateTimeKind.Unspecified).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 39, DateTimeKind.Unspecified).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 39, DateTimeKind.Unspecified).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 39, DateTimeKind.Unspecified).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 46, DateTimeKind.Unspecified).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 46, DateTimeKind.Unspecified).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 46, DateTimeKind.Unspecified).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Body", "Created_Time" },
                values: new object[] { "<center>Olá, {0}</center><center>Quero reporta-lo que a sua confirmação de senha foi realizada com sucesso no periodo das 17/07/2024 - 20:27</center><br> ", new DateTime(2024, 7, 17, 20, 27, 58, 46, DateTimeKind.Unspecified).AddTicks(5394) });

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 46, DateTimeKind.Unspecified).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 46, DateTimeKind.Unspecified).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "EmailType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 46, DateTimeKind.Unspecified).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "EmailType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 46, DateTimeKind.Unspecified).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "EmailType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 46, DateTimeKind.Unspecified).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 39, DateTimeKind.Unspecified).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 39, DateTimeKind.Unspecified).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 39, DateTimeKind.Unspecified).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 39, DateTimeKind.Unspecified).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 39, DateTimeKind.Unspecified).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 39, DateTimeKind.Unspecified).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 39, DateTimeKind.Unspecified).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 39, DateTimeKind.Unspecified).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 1L, 1L, 1L },
                column: "RoleTag",
                value: "ROLE_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 2L, 1L, 1L },
                column: "RoleTag",
                value: "ROLE_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 3L, 1L, 1L },
                column: "RoleTag",
                value: "ROLE_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 4L, 1L, 1L },
                column: "RoleTag",
                value: "ROLE_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 5L, 2L, 1L },
                column: "RoleTag",
                value: "ROLE_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 6L, 2L, 1L },
                column: "RoleTag",
                value: "ROLE_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 7L, 2L, 1L },
                column: "RoleTag",
                value: "ROLE_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 8L, 2L, 1L },
                column: "RoleTag",
                value: "ROLE_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 9L, 3L, 1L },
                column: "RoleTag",
                value: "ROLE_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 10L, 3L, 1L },
                column: "RoleTag",
                value: "ROLE_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 11L, 3L, 1L },
                column: "RoleTag",
                value: "ROLE_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 12L, 3L, 1L },
                column: "RoleTag",
                value: "ROLE_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 13L, 4L, 1L },
                column: "RoleTag",
                value: "ROLE_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 14L, 4L, 1L },
                column: "RoleTag",
                value: "ROLE_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 15L, 4L, 1L },
                column: "RoleTag",
                value: "ROLE_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 16L, 4L, 1L },
                column: "RoleTag",
                value: "ROLE_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 17L, 5L, 1L },
                column: "RoleTag",
                value: "ROLE_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 18L, 5L, 1L },
                column: "RoleTag",
                value: "ROLE_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 19L, 5L, 1L },
                column: "RoleTag",
                value: "ROLE_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 21L, 6L, 1L },
                column: "RoleTag",
                value: "ROLE_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 22L, 6L, 1L },
                column: "RoleTag",
                value: "ROLE_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 23L, 6L, 1L },
                column: "RoleTag",
                value: "ROLE_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 24L, 6L, 1L },
                column: "RoleTag",
                value: "ROLE_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 25L, 7L, 1L },
                column: "RoleTag",
                value: "ROLE_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 26L, 7L, 1L },
                column: "RoleTag",
                value: "ROLE_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 27L, 7L, 1L },
                column: "RoleTag",
                value: "ROLE_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 28L, 7L, 1L },
                column: "RoleTag",
                value: "ROLE_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 29L, 2L, 2L },
                column: "RoleTag",
                value: "ROLE_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 30L, 2L, 2L },
                column: "RoleTag",
                value: "ROLE_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 31L, 2L, 2L },
                column: "RoleTag",
                value: "ROLE_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 32L, 2L, 2L },
                column: "RoleTag",
                value: "ROLE_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 33L, 3L, 2L },
                column: "RoleTag",
                value: "ROLE_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 34L, 3L, 2L },
                column: "RoleTag",
                value: "ROLE_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 35L, 3L, 2L },
                column: "RoleTag",
                value: "ROLE_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 36L, 3L, 2L },
                column: "RoleTag",
                value: "ROLE_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 37L, 4L, 2L },
                column: "RoleTag",
                value: "ROLE_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 38L, 4L, 2L },
                column: "RoleTag",
                value: "ROLE_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 39L, 4L, 2L },
                column: "RoleTag",
                value: "ROLE_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 40L, 4L, 2L },
                column: "RoleTag",
                value: "ROLE_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 41L, 5L, 2L },
                column: "RoleTag",
                value: "ROLE_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 42L, 5L, 2L },
                column: "RoleTag",
                value: "ROLE_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 43L, 5L, 2L },
                column: "RoleTag",
                value: "ROLE_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 44L, 5L, 2L },
                column: "RoleTag",
                value: "ROLE_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 45L, 6L, 2L },
                column: "RoleTag",
                value: "ROLE_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 46L, 6L, 2L },
                column: "RoleTag",
                value: "ROLE_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 47L, 6L, 2L },
                column: "RoleTag",
                value: "ROLE_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 48L, 6L, 2L },
                column: "RoleTag",
                value: "ROLE_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 49L, 7L, 2L },
                column: "RoleTag",
                value: "ROLE_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 50L, 7L, 2L },
                column: "RoleTag",
                value: "ROLE_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 51L, 7L, 2L },
                column: "RoleTag",
                value: "ROLE_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 52L, 7L, 2L },
                column: "RoleTag",
                value: "ROLE_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 53L, 5L, 3L },
                column: "RoleTag",
                value: "ROLE_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 54L, 5L, 3L },
                column: "RoleTag",
                value: "ROLE_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 55L, 5L, 3L },
                column: "RoleTag",
                value: "ROLE_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 56L, 5L, 3L },
                column: "RoleTag",
                value: "ROLE_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 57L, 6L, 3L },
                column: "RoleTag",
                value: "ROLE_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 58L, 6L, 3L },
                column: "RoleTag",
                value: "ROLE_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 59L, 6L, 3L },
                column: "RoleTag",
                value: "ROLE_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 60L, 6L, 3L },
                column: "RoleTag",
                value: "ROLE_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 61L, 7L, 3L },
                column: "RoleTag",
                value: "ROLE_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 62L, 7L, 3L },
                column: "RoleTag",
                value: "ROLE_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 63L, 7L, 3L },
                column: "RoleTag",
                value: "ROLE_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 64L, 7L, 3L },
                column: "RoleTag",
                value: "ROLE_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 65L, 5L, 4L },
                column: "RoleTag",
                value: "ROLE_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 66L, 5L, 4L },
                column: "RoleTag",
                value: "ROLE_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 67L, 5L, 4L },
                column: "RoleTag",
                value: "ROLE_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 68L, 5L, 4L },
                column: "RoleTag",
                value: "ROLE_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 69L, 6L, 4L },
                column: "RoleTag",
                value: "ROLE_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 70L, 6L, 4L },
                column: "RoleTag",
                value: "ROLE_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 71L, 6L, 4L },
                column: "RoleTag",
                value: "ROLE_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 72L, 6L, 4L },
                column: "RoleTag",
                value: "ROLE_VIEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 73L, 7L, 4L },
                column: "RoleTag",
                value: "ROLE_NEW");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 74L, 7L, 4L },
                column: "RoleTag",
                value: "ROLE_EDIT");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 75L, 7L, 4L },
                column: "RoleTag",
                value: "ROLE_DELETE");

            migrationBuilder.UpdateData(
                table: "ProfileOperations",
                keyColumns: new[] { "Id", "Id_Operation", "Id_Profile" },
                keyValues: new object[] { 76L, 7L, 4L },
                column: "RoleTag",
                value: "ROLE_VIEW");

            migrationBuilder.InsertData(
                table: "ProfileOperations",
                columns: new[] { "Id", "Id_Operation", "Id_Profile", "IsEnable", "Order", "RoleTag" },
                values: new object[] { 2L, 5L, 1L, true, 3, "ROLE_VIEW" });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 39, DateTimeKind.Unspecified).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 39, DateTimeKind.Unspecified).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 39, DateTimeKind.Unspecified).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 27, 58, 39, DateTimeKind.Unspecified).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created_Time", "Password" },
                values: new object[] { new DateTime(2024, 7, 17, 20, 27, 58, 39, DateTimeKind.Unspecified).AddTicks(515), "AQAQJwAAFSnSFRtk18A0UGvwJBAJvzG4QYLH+vJwleaNzhWuqVw=" });

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
        }
    }
}
