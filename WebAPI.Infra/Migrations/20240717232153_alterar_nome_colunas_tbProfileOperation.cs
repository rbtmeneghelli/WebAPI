using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Infra.Migrations
{
    /// <inheritdoc />
    public partial class alterar_nome_colunas_tbProfileOperation : Migration
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

            migrationBuilder.RenameColumn(
                name: "CanUpdate",
                table: "ProfileOperations",
                newName: "RoleTag");

            migrationBuilder.RenameColumn(
                name: "CanResearch",
                table: "ProfileOperations",
                newName: "IsEnable");

            migrationBuilder.RenameColumn(
                name: "CanCreate",
                table: "ProfileOperations",
                newName: "Order");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 498, DateTimeKind.Unspecified).AddTicks(6531),
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "States",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 499, DateTimeKind.Unspecified).AddTicks(2821),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 56, DateTimeKind.Unspecified).AddTicks(5926));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Regions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 499, DateTimeKind.Unspecified).AddTicks(9507),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(385));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Profiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 498, DateTimeKind.Unspecified).AddTicks(8840),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 56, DateTimeKind.Unspecified).AddTicks(2392));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Operation",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 500, DateTimeKind.Unspecified).AddTicks(5486),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(4196));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Notification",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 501, DateTimeKind.Unspecified).AddTicks(1381),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(7469));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Employees",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(4338),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(3695));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(593),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 58, DateTimeKind.Unspecified).AddTicks(9773));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailTemplate",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 501, DateTimeKind.Unspecified).AddTicks(6290),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 58, DateTimeKind.Unspecified).AddTicks(2663));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailDisplay",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 501, DateTimeKind.Unspecified).AddTicks(8285),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 58, DateTimeKind.Unspecified).AddTicks(6111));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Client",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 500, DateTimeKind.Unspecified).AddTicks(7678),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(5459));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Cities",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 501, DateTimeKind.Unspecified).AddTicks(2457),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(8389));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Ceps",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 499, DateTimeKind.Unspecified).AddTicks(5059),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 56, DateTimeKind.Unspecified).AddTicks(7922));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Audit",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 500, DateTimeKind.Unspecified).AddTicks(1610),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(1827));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Areas",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(2172),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(1564));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "ArchiveType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 501, DateTimeKind.Unspecified).AddTicks(4786),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 58, DateTimeKind.Unspecified).AddTicks(365));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 511, DateTimeKind.Unspecified).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 511, DateTimeKind.Unspecified).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 511, DateTimeKind.Unspecified).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 511, DateTimeKind.Unspecified).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 511, DateTimeKind.Unspecified).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 511, DateTimeKind.Unspecified).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 511, DateTimeKind.Unspecified).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 511, DateTimeKind.Unspecified).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 511, DateTimeKind.Unspecified).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 511, DateTimeKind.Unspecified).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Body", "Created_Time" },
                values: new object[] { "<center>Olá, {0}</center><center>Quero reporta-lo que a sua confirmação de senha foi realizada com sucesso no periodo das 17/07/2024 - 20:21</center><br> ", new DateTime(2024, 7, 17, 20, 21, 52, 511, DateTimeKind.Unspecified).AddTicks(8180) });

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 511, DateTimeKind.Unspecified).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 511, DateTimeKind.Unspecified).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "EmailType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 511, DateTimeKind.Unspecified).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "EmailType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 511, DateTimeKind.Unspecified).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "EmailType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 511, DateTimeKind.Unspecified).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created_Time", "Password" },
                values: new object[] { new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(7754), "AQAQJwAA93pirr32DIKlLHn/j3jcubaQABr4CBID2u6NtLe21O4=" });

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

            migrationBuilder.RenameColumn(
                name: "RoleTag",
                table: "ProfileOperations",
                newName: "CanUpdate");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "ProfileOperations",
                newName: "CanCreate");

            migrationBuilder.RenameColumn(
                name: "IsEnable",
                table: "ProfileOperations",
                newName: "CanResearch");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 56, DateTimeKind.Unspecified).AddTicks(381),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 498, DateTimeKind.Unspecified).AddTicks(6531))
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
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 499, DateTimeKind.Unspecified).AddTicks(2821));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Regions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(385),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 499, DateTimeKind.Unspecified).AddTicks(9507));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Profiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 56, DateTimeKind.Unspecified).AddTicks(2392),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 498, DateTimeKind.Unspecified).AddTicks(8840));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Operation",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(4196),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 500, DateTimeKind.Unspecified).AddTicks(5486));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Notification",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(7469),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 501, DateTimeKind.Unspecified).AddTicks(1381));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Employees",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(3695),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(4338));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 58, DateTimeKind.Unspecified).AddTicks(9773),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(593));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailTemplate",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 58, DateTimeKind.Unspecified).AddTicks(2663),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 501, DateTimeKind.Unspecified).AddTicks(6290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailDisplay",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 58, DateTimeKind.Unspecified).AddTicks(6111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 501, DateTimeKind.Unspecified).AddTicks(8285));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Client",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(5459),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 500, DateTimeKind.Unspecified).AddTicks(7678));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Cities",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(8389),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 501, DateTimeKind.Unspecified).AddTicks(2457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Ceps",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 56, DateTimeKind.Unspecified).AddTicks(7922),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 499, DateTimeKind.Unspecified).AddTicks(5059));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Audit",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 57, DateTimeKind.Unspecified).AddTicks(1827),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 500, DateTimeKind.Unspecified).AddTicks(1610));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Areas",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(1564),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(2172));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "ArchiveType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 18, 6, 13, 58, DateTimeKind.Unspecified).AddTicks(365),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 501, DateTimeKind.Unspecified).AddTicks(4786));

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

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791));

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
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 66, DateTimeKind.Unspecified).AddTicks(8596));

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

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created_Time", "Password" },
                values: new object[] { new DateTime(2024, 7, 17, 18, 6, 13, 59, DateTimeKind.Unspecified).AddTicks(6791), "AQAQJwAAWZP/MOTfE6cyYfLhnLYWyaXYJVZNxvah7zQCA9mJQRM=" });

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
