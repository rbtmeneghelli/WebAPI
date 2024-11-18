using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.InfraStructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ajustespontuaisdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Configuration_EmailTemplateSettings_Configuration_EmailSettings_EmailSettingsId",
                table: "Configuration_EmailTemplateSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlPanel_ClientAddress_ControlPanel_Client_ClientId",
                table: "ControlPanel_ClientAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlPanel_ClientDocument_ControlPanel_Client_ClientId",
                table: "ControlPanel_ClientDocument");

            migrationBuilder.DropIndex(
                name: "IX_Configuration_EmailTemplateSettings_EmailSettingsId",
                table: "Configuration_EmailTemplateSettings");

            migrationBuilder.DropColumn(
                name: "EmailSettingsId",
                table: "Configuration_EmailTemplateSettings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_User",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 9, DateTimeKind.Unspecified).AddTicks(3385),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 221, DateTimeKind.Unspecified).AddTicks(2863))
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ControlPanel_UserHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "ControlPanel_UserHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_State",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 12, DateTimeKind.Unspecified).AddTicks(3791),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 224, DateTimeKind.Unspecified).AddTicks(5308));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Region",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 12, DateTimeKind.Unspecified).AddTicks(8285),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(216));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Profile",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 9, DateTimeKind.Unspecified).AddTicks(5449),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 221, DateTimeKind.Unspecified).AddTicks(5190));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Operation",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 9, DateTimeKind.Unspecified).AddTicks(2122),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 221, DateTimeKind.Unspecified).AddTicks(1567));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ControlPanel_Notification",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(2024),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(4416));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Employee",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 8, DateTimeKind.Unspecified).AddTicks(9397),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 220, DateTimeKind.Unspecified).AddTicks(8759));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Client",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 9, DateTimeKind.Unspecified).AddTicks(9300),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 221, DateTimeKind.Unspecified).AddTicks(9209));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_City",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(2915),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(5321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Cep",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 12, DateTimeKind.Unspecified).AddTicks(5800),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 224, DateTimeKind.Unspecified).AddTicks(7495));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Audit",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 12, DateTimeKind.Unspecified).AddTicks(9708),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(1783));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Area",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 8, DateTimeKind.Unspecified).AddTicks(7218),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 220, DateTimeKind.Unspecified).AddTicks(6534));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_RequiredPasswordSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 11, DateTimeKind.Unspecified).AddTicks(7754),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 223, DateTimeKind.Unspecified).AddTicks(8841));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_LogSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 11, DateTimeKind.Unspecified).AddTicks(5285),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 223, DateTimeKind.Unspecified).AddTicks(6327));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_LayoutSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 11, DateTimeKind.Unspecified).AddTicks(2547),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 223, DateTimeKind.Unspecified).AddTicks(3402))
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_ExpirationPasswordSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 11, DateTimeKind.Unspecified).AddTicks(431),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 223, DateTimeKind.Unspecified).AddTicks(1163));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EnvironmentTypeSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 11, DateTimeKind.Unspecified).AddTicks(9351),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 224, DateTimeKind.Unspecified).AddTicks(583));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EmailTemplateSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 10, DateTimeKind.Unspecified).AddTicks(1600),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 222, DateTimeKind.Unspecified).AddTicks(1620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EmailSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 10, DateTimeKind.Unspecified).AddTicks(5827),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 222, DateTimeKind.Unspecified).AddTicks(6329));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EmailDisplaySettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 10, DateTimeKind.Unspecified).AddTicks(3564),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 222, DateTimeKind.Unspecified).AddTicks(3815));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_AuthenticationSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 10, DateTimeKind.Unspecified).AddTicks(8219),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 222, DateTimeKind.Unspecified).AddTicks(8868));

            migrationBuilder.UpdateData(
                table: "Configuration_AuthenticationSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_AuthenticationSettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_AuthenticationSettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_AuthenticationSettings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_AuthenticationSettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_EmailDisplaySettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_EmailDisplaySettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_EmailDisplaySettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_EmailDisplaySettings",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Body", "CreateDate" },
                values: new object[] { "<center>Olá, {0}</center><center>Quero reporta-lo que a sua confirmação de senha foi realizada com sucesso no periodo das 24/09/2024 - 23:59</center><br> ", new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668) });

            migrationBuilder.UpdateData(
                table: "Configuration_EmailDisplaySettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_EmailSettings",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "Password" },
                values: new object[] { new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668), "6OoM0cUjWAU44NxS5aRWlQ==" });

            migrationBuilder.UpdateData(
                table: "Configuration_EmailSettings",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "Password" },
                values: new object[] { new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668), "Hr7KLRbaYNpZWzMHmyb69w==" });

            migrationBuilder.UpdateData(
                table: "Configuration_EmailSettings",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreateDate", "Password" },
                values: new object[] { new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668), "fUUts0fVgdK++dJH5TsFhA==" });

            migrationBuilder.UpdateData(
                table: "Configuration_EmailTemplateSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_EnvironmentTypeSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_EnvironmentTypeSettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_EnvironmentTypeSettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_EnvironmentTypeSettings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_EnvironmentTypeSettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_ExpirationPasswordSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_ExpirationPasswordSettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_ExpirationPasswordSettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_ExpirationPasswordSettings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_ExpirationPasswordSettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_LogSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_LogSettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_LogSettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_LogSettings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_LogSettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_RequiredPasswordSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_RequiredPasswordSettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_RequiredPasswordSettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_RequiredPasswordSettings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Configuration_RequiredPasswordSettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 22, DateTimeKind.Unspecified).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Employee",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Profile",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Profile",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Profile",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Profile",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "ControlPanel_User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "Password" },
                values: new object[] { new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(5006), "AQAQJwAAGUUKC7PwwYOCmVFu0Wq/Lj8Tci4Zt15h3B2XtPtdsms=" });

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPanel_ClientAddress_ControlPanel_Client_ClientId",
                table: "ControlPanel_ClientAddress",
                column: "ClientId",
                principalTable: "ControlPanel_Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPanel_ClientDocument_ControlPanel_Client_ClientId",
                table: "ControlPanel_ClientDocument",
                column: "ClientId",
                principalTable: "ControlPanel_Client",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlPanel_ClientAddress_ControlPanel_Client_ClientId",
                table: "ControlPanel_ClientAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlPanel_ClientDocument_ControlPanel_Client_ClientId",
                table: "ControlPanel_ClientDocument");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_User",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 221, DateTimeKind.Unspecified).AddTicks(2863),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 9, DateTimeKind.Unspecified).AddTicks(3385))
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ControlPanel_UserHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "ControlPanel_UserHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_State",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 224, DateTimeKind.Unspecified).AddTicks(5308),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 12, DateTimeKind.Unspecified).AddTicks(3791));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Region",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(216),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 12, DateTimeKind.Unspecified).AddTicks(8285));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Profile",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 221, DateTimeKind.Unspecified).AddTicks(5190),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 9, DateTimeKind.Unspecified).AddTicks(5449));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Operation",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 221, DateTimeKind.Unspecified).AddTicks(1567),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 9, DateTimeKind.Unspecified).AddTicks(2122));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ControlPanel_Notification",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(4416),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(2024));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Employee",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 220, DateTimeKind.Unspecified).AddTicks(8759),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 8, DateTimeKind.Unspecified).AddTicks(9397));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Client",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 221, DateTimeKind.Unspecified).AddTicks(9209),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 9, DateTimeKind.Unspecified).AddTicks(9300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_City",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(5321),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(2915));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Cep",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 224, DateTimeKind.Unspecified).AddTicks(7495),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 12, DateTimeKind.Unspecified).AddTicks(5800));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Audit",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(1783),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 12, DateTimeKind.Unspecified).AddTicks(9708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Area",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 220, DateTimeKind.Unspecified).AddTicks(6534),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 8, DateTimeKind.Unspecified).AddTicks(7218));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_RequiredPasswordSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 223, DateTimeKind.Unspecified).AddTicks(8841),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 11, DateTimeKind.Unspecified).AddTicks(7754));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_LogSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 223, DateTimeKind.Unspecified).AddTicks(6327),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 11, DateTimeKind.Unspecified).AddTicks(5285));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_LayoutSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 223, DateTimeKind.Unspecified).AddTicks(3402),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 11, DateTimeKind.Unspecified).AddTicks(2547))
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", null)
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_ExpirationPasswordSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 223, DateTimeKind.Unspecified).AddTicks(1163),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 11, DateTimeKind.Unspecified).AddTicks(431));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EnvironmentTypeSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 224, DateTimeKind.Unspecified).AddTicks(583),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 11, DateTimeKind.Unspecified).AddTicks(9351));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EmailTemplateSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 222, DateTimeKind.Unspecified).AddTicks(1620),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 10, DateTimeKind.Unspecified).AddTicks(1600));

            migrationBuilder.AddColumn<long>(
                name: "EmailSettingsId",
                table: "Configuration_EmailTemplateSettings",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EmailSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 222, DateTimeKind.Unspecified).AddTicks(6329),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 10, DateTimeKind.Unspecified).AddTicks(5827));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EmailDisplaySettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 222, DateTimeKind.Unspecified).AddTicks(3815),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 10, DateTimeKind.Unspecified).AddTicks(3564));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_AuthenticationSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 22, 21, 8, 7, 222, DateTimeKind.Unspecified).AddTicks(8868),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 10, DateTimeKind.Unspecified).AddTicks(8219));

            migrationBuilder.UpdateData(
                table: "Configuration_AuthenticationSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_AuthenticationSettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_AuthenticationSettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_AuthenticationSettings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_AuthenticationSettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_EmailDisplaySettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_EmailDisplaySettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_EmailDisplaySettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_EmailDisplaySettings",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Body", "CreateDate" },
                values: new object[] { "<center>Olá, {0}</center><center>Quero reporta-lo que a sua confirmação de senha foi realizada com sucesso no periodo das 22/09/2024 - 21:08</center><br> ", new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660) });

            migrationBuilder.UpdateData(
                table: "Configuration_EmailDisplaySettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_EmailSettings",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "Password" },
                values: new object[] { new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), "S3b7D2vFThf5+uQEQlU0Yw==" });

            migrationBuilder.UpdateData(
                table: "Configuration_EmailSettings",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "Password" },
                values: new object[] { new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), "zdCkZ5yXfN6rVPJ8G34oRw==" });

            migrationBuilder.UpdateData(
                table: "Configuration_EmailSettings",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreateDate", "Password" },
                values: new object[] { new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), "V1p2qYzM2lX6PZbP4A6ctQ==" });

            migrationBuilder.UpdateData(
                table: "Configuration_EmailTemplateSettings",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "EmailSettingsId" },
                values: new object[] { new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660), null });

            migrationBuilder.UpdateData(
                table: "Configuration_EnvironmentTypeSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_EnvironmentTypeSettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_EnvironmentTypeSettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_EnvironmentTypeSettings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_EnvironmentTypeSettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_ExpirationPasswordSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_ExpirationPasswordSettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_ExpirationPasswordSettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_ExpirationPasswordSettings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_ExpirationPasswordSettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_LogSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_LogSettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_LogSettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_LogSettings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_LogSettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_RequiredPasswordSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_RequiredPasswordSettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_RequiredPasswordSettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_RequiredPasswordSettings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "Configuration_RequiredPasswordSettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 234, DateTimeKind.Unspecified).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Employee",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Profile",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Profile",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Profile",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Profile",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "ControlPanel_User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "Password" },
                values: new object[] { new DateTime(2024, 9, 22, 21, 8, 7, 225, DateTimeKind.Unspecified).AddTicks(7416), "AQAQJwAA6Qe8bt7a6+WlUjOtloEbMHYIKxQi163Q3aAyeio6v94=" });

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_EmailTemplateSettings_EmailSettingsId",
                table: "Configuration_EmailTemplateSettings",
                column: "EmailSettingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Configuration_EmailTemplateSettings_Configuration_EmailSettings_EmailSettingsId",
                table: "Configuration_EmailTemplateSettings",
                column: "EmailSettingsId",
                principalTable: "Configuration_EmailSettings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPanel_ClientAddress_ControlPanel_Client_ClientId",
                table: "ControlPanel_ClientAddress",
                column: "ClientId",
                principalTable: "ControlPanel_Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlPanel_ClientDocument_ControlPanel_Client_ClientId",
                table: "ControlPanel_ClientDocument",
                column: "ClientId",
                principalTable: "ControlPanel_Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
