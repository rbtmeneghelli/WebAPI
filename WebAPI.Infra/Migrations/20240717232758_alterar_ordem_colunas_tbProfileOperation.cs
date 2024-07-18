using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Infra.Migrations
{
    /// <inheritdoc />
    public partial class alterar_ordem_colunas_tbProfileOperation : Migration
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 35, DateTimeKind.Unspecified).AddTicks(7079),
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
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 36, DateTimeKind.Unspecified).AddTicks(2765),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 499, DateTimeKind.Unspecified).AddTicks(2821));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Regions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 36, DateTimeKind.Unspecified).AddTicks(7657),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 499, DateTimeKind.Unspecified).AddTicks(9507));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Profiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 35, DateTimeKind.Unspecified).AddTicks(9069),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 498, DateTimeKind.Unspecified).AddTicks(8840));

            migrationBuilder.AlterColumn<string>(
                name: "RoleTag",
                table: "ProfileOperations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "ProfileOperations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<bool>(
                name: "IsEnable",
                table: "ProfileOperations",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<long>(
                name: "Id_Operation",
                table: "ProfileOperations",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<long>(
                name: "Id_Profile",
                table: "ProfileOperations",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "ProfileOperations",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Relational:ColumnOrder", 0)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Operation",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(1326),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 500, DateTimeKind.Unspecified).AddTicks(5486));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Notification",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(4661),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 501, DateTimeKind.Unspecified).AddTicks(1381));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Employees",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 38, DateTimeKind.Unspecified).AddTicks(7289),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(4338));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 38, DateTimeKind.Unspecified).AddTicks(3400),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(593));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailTemplate",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(9324),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 501, DateTimeKind.Unspecified).AddTicks(6290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailDisplay",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 38, DateTimeKind.Unspecified).AddTicks(1197),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 501, DateTimeKind.Unspecified).AddTicks(8285));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Client",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(2558),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 500, DateTimeKind.Unspecified).AddTicks(7678));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Cities",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(5537),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 501, DateTimeKind.Unspecified).AddTicks(2457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Ceps",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 36, DateTimeKind.Unspecified).AddTicks(4794),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 499, DateTimeKind.Unspecified).AddTicks(5059));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Audit",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 36, DateTimeKind.Unspecified).AddTicks(9040),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 500, DateTimeKind.Unspecified).AddTicks(1610));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Areas",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 38, DateTimeKind.Unspecified).AddTicks(4802),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(2172));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "ArchiveType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(7933),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 501, DateTimeKind.Unspecified).AddTicks(4786));

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 498, DateTimeKind.Unspecified).AddTicks(6531),
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
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 499, DateTimeKind.Unspecified).AddTicks(2821),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 36, DateTimeKind.Unspecified).AddTicks(2765));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Regions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 499, DateTimeKind.Unspecified).AddTicks(9507),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 36, DateTimeKind.Unspecified).AddTicks(7657));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Profiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 498, DateTimeKind.Unspecified).AddTicks(8840),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 35, DateTimeKind.Unspecified).AddTicks(9069));

            migrationBuilder.AlterColumn<string>(
                name: "RoleTag",
                table: "ProfileOperations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "ProfileOperations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<bool>(
                name: "IsEnable",
                table: "ProfileOperations",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false)
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<long>(
                name: "Id_Operation",
                table: "ProfileOperations",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<long>(
                name: "Id_Profile",
                table: "ProfileOperations",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "ProfileOperations",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("Relational:ColumnOrder", 0)
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Operation",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 500, DateTimeKind.Unspecified).AddTicks(5486),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(1326));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Notification",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 501, DateTimeKind.Unspecified).AddTicks(1381),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(4661));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Employees",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(4338),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 38, DateTimeKind.Unspecified).AddTicks(7289));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(593),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 38, DateTimeKind.Unspecified).AddTicks(3400));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailTemplate",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 501, DateTimeKind.Unspecified).AddTicks(6290),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(9324));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailDisplay",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 501, DateTimeKind.Unspecified).AddTicks(8285),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 38, DateTimeKind.Unspecified).AddTicks(1197));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Client",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 500, DateTimeKind.Unspecified).AddTicks(7678),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(2558));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Cities",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 501, DateTimeKind.Unspecified).AddTicks(2457),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(5537));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Ceps",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 499, DateTimeKind.Unspecified).AddTicks(5059),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 36, DateTimeKind.Unspecified).AddTicks(4794));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Audit",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 500, DateTimeKind.Unspecified).AddTicks(1610),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 36, DateTimeKind.Unspecified).AddTicks(9040));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Areas",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 502, DateTimeKind.Unspecified).AddTicks(2172),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 38, DateTimeKind.Unspecified).AddTicks(4802));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "ArchiveType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 20, 21, 52, 501, DateTimeKind.Unspecified).AddTicks(4786),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 20, 27, 58, 37, DateTimeKind.Unspecified).AddTicks(7933));

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
