using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ajustespontuaisdbII : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 830, DateTimeKind.Unspecified).AddTicks(1934),
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
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 833, DateTimeKind.Unspecified).AddTicks(6983),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 12, DateTimeKind.Unspecified).AddTicks(3791));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Region",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 834, DateTimeKind.Unspecified).AddTicks(2409),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 12, DateTimeKind.Unspecified).AddTicks(8285));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Profile",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 830, DateTimeKind.Unspecified).AddTicks(4229),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 9, DateTimeKind.Unspecified).AddTicks(5449));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Operation",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 830, DateTimeKind.Unspecified).AddTicks(499),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 9, DateTimeKind.Unspecified).AddTicks(2122));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ControlPanel_Notification",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 834, DateTimeKind.Unspecified).AddTicks(7028),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(2024));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Employee",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 829, DateTimeKind.Unspecified).AddTicks(7473),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 8, DateTimeKind.Unspecified).AddTicks(9397));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Client",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 830, DateTimeKind.Unspecified).AddTicks(8617),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 9, DateTimeKind.Unspecified).AddTicks(9300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_City",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 834, DateTimeKind.Unspecified).AddTicks(8080),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(2915));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Cep",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 833, DateTimeKind.Unspecified).AddTicks(9496),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 12, DateTimeKind.Unspecified).AddTicks(5800));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Audit",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 834, DateTimeKind.Unspecified).AddTicks(4086),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 12, DateTimeKind.Unspecified).AddTicks(9708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Area",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 829, DateTimeKind.Unspecified).AddTicks(5018),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 8, DateTimeKind.Unspecified).AddTicks(7218));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_RequiredPasswordSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 832, DateTimeKind.Unspecified).AddTicks(9185),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 11, DateTimeKind.Unspecified).AddTicks(7754));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_LogSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 832, DateTimeKind.Unspecified).AddTicks(6403),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 11, DateTimeKind.Unspecified).AddTicks(5285));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_LayoutSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 832, DateTimeKind.Unspecified).AddTicks(3052),
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
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 832, DateTimeKind.Unspecified).AddTicks(776),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 11, DateTimeKind.Unspecified).AddTicks(431));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EnvironmentTypeSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 833, DateTimeKind.Unspecified).AddTicks(1539),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 11, DateTimeKind.Unspecified).AddTicks(9351));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EmailTemplateSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 831, DateTimeKind.Unspecified).AddTicks(1134),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 10, DateTimeKind.Unspecified).AddTicks(1600));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EmailSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 831, DateTimeKind.Unspecified).AddTicks(5793),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 10, DateTimeKind.Unspecified).AddTicks(5827));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EmailDisplaySettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 831, DateTimeKind.Unspecified).AddTicks(3300),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 10, DateTimeKind.Unspecified).AddTicks(3564));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_AuthenticationSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 831, DateTimeKind.Unspecified).AddTicks(8424),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 10, DateTimeKind.Unspecified).AddTicks(8219));

            migrationBuilder.UpdateData(
                table: "Configuration_AuthenticationSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_AuthenticationSettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_AuthenticationSettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_AuthenticationSettings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_AuthenticationSettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_EmailDisplaySettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_EmailDisplaySettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_EmailDisplaySettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_EmailDisplaySettings",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Body", "CreateDate" },
                values: new object[] { "<center>Olá, {0}</center><center>Quero reporta-lo que a sua confirmação de senha foi realizada com sucesso no periodo das 25/09/2024 - 11:58</center><br> ", new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607) });

            migrationBuilder.UpdateData(
                table: "Configuration_EmailDisplaySettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_EmailSettings",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "Password" },
                values: new object[] { new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607), "hbKJts0N2t/PQ+WEogpJwA==" });

            migrationBuilder.UpdateData(
                table: "Configuration_EmailSettings",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "Password" },
                values: new object[] { new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607), "nwoazrP5XQqDvORHb9WcTw==" });

            migrationBuilder.UpdateData(
                table: "Configuration_EmailSettings",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreateDate", "Password" },
                values: new object[] { new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607), "3GL/nPiFw03wEfF7rNUSfA==" });

            migrationBuilder.UpdateData(
                table: "Configuration_EmailTemplateSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_EnvironmentTypeSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_EnvironmentTypeSettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_EnvironmentTypeSettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_EnvironmentTypeSettings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_EnvironmentTypeSettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_ExpirationPasswordSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_ExpirationPasswordSettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_ExpirationPasswordSettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_ExpirationPasswordSettings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_ExpirationPasswordSettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_LogSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_LogSettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_LogSettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_LogSettings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_LogSettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_RequiredPasswordSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_RequiredPasswordSettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_RequiredPasswordSettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_RequiredPasswordSettings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Configuration_RequiredPasswordSettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 843, DateTimeKind.Unspecified).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 835, DateTimeKind.Unspecified).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 835, DateTimeKind.Unspecified).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 835, DateTimeKind.Unspecified).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 835, DateTimeKind.Unspecified).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 835, DateTimeKind.Unspecified).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 835, DateTimeKind.Unspecified).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Employee",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 835, DateTimeKind.Unspecified).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 835, DateTimeKind.Unspecified).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 835, DateTimeKind.Unspecified).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 835, DateTimeKind.Unspecified).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 835, DateTimeKind.Unspecified).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 835, DateTimeKind.Unspecified).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 835, DateTimeKind.Unspecified).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 835, DateTimeKind.Unspecified).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Profile",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 835, DateTimeKind.Unspecified).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Profile",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 835, DateTimeKind.Unspecified).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Profile",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 835, DateTimeKind.Unspecified).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Profile",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 11, 58, 9, 835, DateTimeKind.Unspecified).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "ControlPanel_User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "Password" },
                values: new object[] { new DateTime(2024, 9, 25, 11, 58, 9, 835, DateTimeKind.Unspecified).AddTicks(681), "AQAQJwAAq25Z4BtQMK/DiFy0tlqoO1VOkseCyyuGLT0XdIGklSY=" });

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
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 9, DateTimeKind.Unspecified).AddTicks(3385),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 830, DateTimeKind.Unspecified).AddTicks(1934))
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
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 833, DateTimeKind.Unspecified).AddTicks(6983));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Region",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 12, DateTimeKind.Unspecified).AddTicks(8285),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 834, DateTimeKind.Unspecified).AddTicks(2409));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Profile",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 9, DateTimeKind.Unspecified).AddTicks(5449),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 830, DateTimeKind.Unspecified).AddTicks(4229));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Operation",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 9, DateTimeKind.Unspecified).AddTicks(2122),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 830, DateTimeKind.Unspecified).AddTicks(499));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ControlPanel_Notification",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(2024),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 834, DateTimeKind.Unspecified).AddTicks(7028));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Employee",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 8, DateTimeKind.Unspecified).AddTicks(9397),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 829, DateTimeKind.Unspecified).AddTicks(7473));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Client",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 9, DateTimeKind.Unspecified).AddTicks(9300),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 830, DateTimeKind.Unspecified).AddTicks(8617));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_City",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 13, DateTimeKind.Unspecified).AddTicks(2915),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 834, DateTimeKind.Unspecified).AddTicks(8080));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Cep",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 12, DateTimeKind.Unspecified).AddTicks(5800),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 833, DateTimeKind.Unspecified).AddTicks(9496));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Audit",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 12, DateTimeKind.Unspecified).AddTicks(9708),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 834, DateTimeKind.Unspecified).AddTicks(4086));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Area",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 8, DateTimeKind.Unspecified).AddTicks(7218),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 829, DateTimeKind.Unspecified).AddTicks(5018));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_RequiredPasswordSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 11, DateTimeKind.Unspecified).AddTicks(7754),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 832, DateTimeKind.Unspecified).AddTicks(9185));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_LogSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 11, DateTimeKind.Unspecified).AddTicks(5285),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 832, DateTimeKind.Unspecified).AddTicks(6403));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_LayoutSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 11, DateTimeKind.Unspecified).AddTicks(2547),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 832, DateTimeKind.Unspecified).AddTicks(3052))
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
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 832, DateTimeKind.Unspecified).AddTicks(776));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EnvironmentTypeSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 11, DateTimeKind.Unspecified).AddTicks(9351),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 833, DateTimeKind.Unspecified).AddTicks(1539));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EmailTemplateSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 10, DateTimeKind.Unspecified).AddTicks(1600),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 831, DateTimeKind.Unspecified).AddTicks(1134));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EmailSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 10, DateTimeKind.Unspecified).AddTicks(5827),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 831, DateTimeKind.Unspecified).AddTicks(5793));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EmailDisplaySettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 10, DateTimeKind.Unspecified).AddTicks(3564),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 831, DateTimeKind.Unspecified).AddTicks(3300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_AuthenticationSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 24, 23, 59, 11, 10, DateTimeKind.Unspecified).AddTicks(8219),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 831, DateTimeKind.Unspecified).AddTicks(8424));

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
