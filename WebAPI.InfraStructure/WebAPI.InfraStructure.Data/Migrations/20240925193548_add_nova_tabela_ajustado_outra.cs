using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.InfraStructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_nova_tabela_ajustado_outra : Migration
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

            migrationBuilder.DropColumn(
                name: "BannerMobile",
                table: "Configuration_LayoutSettings")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade");

            migrationBuilder.DropColumn(
                name: "BannerWeb",
                table: "Configuration_LayoutSettings")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade");

            migrationBuilder.DropColumn(
                name: "LogoMobile",
                table: "Configuration_LayoutSettings")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade");

            migrationBuilder.DropColumn(
                name: "LogoWeb",
                table: "Configuration_LayoutSettings")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_User",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 585, DateTimeKind.Unspecified).AddTicks(1487),
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
                defaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 588, DateTimeKind.Unspecified).AddTicks(3402),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 833, DateTimeKind.Unspecified).AddTicks(6983));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Region",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 588, DateTimeKind.Unspecified).AddTicks(8462),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 834, DateTimeKind.Unspecified).AddTicks(2409));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Profile",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 585, DateTimeKind.Unspecified).AddTicks(3441),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 830, DateTimeKind.Unspecified).AddTicks(4229));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Operation",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 585, DateTimeKind.Unspecified).AddTicks(271),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 830, DateTimeKind.Unspecified).AddTicks(499));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ControlPanel_Notification",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(2136),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 834, DateTimeKind.Unspecified).AddTicks(7028));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Employee",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 584, DateTimeKind.Unspecified).AddTicks(7688),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 829, DateTimeKind.Unspecified).AddTicks(7473));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Client",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 585, DateTimeKind.Unspecified).AddTicks(7388),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 830, DateTimeKind.Unspecified).AddTicks(8617));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_City",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(3010),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 834, DateTimeKind.Unspecified).AddTicks(8080));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Cep",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 588, DateTimeKind.Unspecified).AddTicks(6021),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 833, DateTimeKind.Unspecified).AddTicks(9496));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Audit",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 588, DateTimeKind.Unspecified).AddTicks(9865),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 834, DateTimeKind.Unspecified).AddTicks(4086));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Area",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 584, DateTimeKind.Unspecified).AddTicks(5613),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 829, DateTimeKind.Unspecified).AddTicks(5018));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_RequiredPasswordSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 587, DateTimeKind.Unspecified).AddTicks(5195),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 832, DateTimeKind.Unspecified).AddTicks(9185));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_LogSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 587, DateTimeKind.Unspecified).AddTicks(2579),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 832, DateTimeKind.Unspecified).AddTicks(6403));

            migrationBuilder.AlterColumn<double>(
                name: "MaxImageFileSize",
                table: "Configuration_LayoutSettings",
                type: "float",
                nullable: false,
                defaultValue: 20.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 20)
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

            migrationBuilder.AlterColumn<double>(
                name: "MaxDocumentFileSize",
                table: "Configuration_LayoutSettings",
                type: "float",
                nullable: false,
                defaultValue: 20.0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 20)
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
                table: "Configuration_LayoutSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 587, DateTimeKind.Unspecified).AddTicks(216),
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
                defaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 586, DateTimeKind.Unspecified).AddTicks(8233),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 832, DateTimeKind.Unspecified).AddTicks(776));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EnvironmentTypeSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 587, DateTimeKind.Unspecified).AddTicks(6750),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 833, DateTimeKind.Unspecified).AddTicks(1539));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EmailTemplateSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 585, DateTimeKind.Unspecified).AddTicks(9571),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 831, DateTimeKind.Unspecified).AddTicks(1134));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EmailSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 586, DateTimeKind.Unspecified).AddTicks(3600),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 831, DateTimeKind.Unspecified).AddTicks(5793));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EmailDisplaySettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 586, DateTimeKind.Unspecified).AddTicks(1443),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 831, DateTimeKind.Unspecified).AddTicks(3300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_AuthenticationSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 586, DateTimeKind.Unspecified).AddTicks(6178),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 831, DateTimeKind.Unspecified).AddTicks(8424));

            migrationBuilder.CreateTable(
                name: "Configuration_UploadSettings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 588, DateTimeKind.Unspecified).AddTicks(977)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    LogoWeb = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    LogoWebDescription = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    BannerWeb = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    BannerWebDescription = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    LogoMobile = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    LogoMobileDescription = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    BannerMobile = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    BannerMobileDescription = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IdEnvironmentType = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration_UploadSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configuration_UploadSettings_Configuration_EnvironmentTypeSettings_IdEnvironmentType",
                        column: x => x.IdEnvironmentType,
                        principalTable: "Configuration_EnvironmentTypeSettings",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Configuration_AuthenticationSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_AuthenticationSettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_AuthenticationSettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_AuthenticationSettings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_AuthenticationSettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_EmailDisplaySettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_EmailDisplaySettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_EmailDisplaySettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_EmailDisplaySettings",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Body", "CreateDate" },
                values: new object[] { "<center>Olá, {0}</center><center>Quero reporta-lo que a sua confirmação de senha foi realizada com sucesso no periodo das 25/09/2024 - 16:35</center><br> ", new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630) });

            migrationBuilder.UpdateData(
                table: "Configuration_EmailDisplaySettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_EmailSettings",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "Password" },
                values: new object[] { new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630), "aG1gF2tcOXu1Szt1Cf3Jxw==" });

            migrationBuilder.UpdateData(
                table: "Configuration_EmailSettings",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreateDate", "Password" },
                values: new object[] { new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630), "uVGS150KhN+seynw64cocQ==" });

            migrationBuilder.UpdateData(
                table: "Configuration_EmailSettings",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreateDate", "Password" },
                values: new object[] { new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630), "FXs1SsF26JSapyaIiAR2nA==" });

            migrationBuilder.UpdateData(
                table: "Configuration_EmailTemplateSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_EnvironmentTypeSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_EnvironmentTypeSettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_EnvironmentTypeSettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_EnvironmentTypeSettings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_EnvironmentTypeSettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_ExpirationPasswordSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_ExpirationPasswordSettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_ExpirationPasswordSettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_ExpirationPasswordSettings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_ExpirationPasswordSettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.InsertData(
                table: "Configuration_LayoutSettings",
                columns: new[] { "Id", "CreateDate", "DocumentFileContentToUpload", "IdEnvironmentType", "ImageFileContentToUpload", "MaxDocumentFileSize", "MaxImageFileSize", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630), ".pdf,.doc,.docx", 1L, ".jpg,.jpeg,.png", 20.0, 20.0, true, null },
                    { 2L, new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630), ".pdf,.doc,.docx", 2L, ".jpg,.jpeg,.png", 20.0, 20.0, true, null },
                    { 3L, new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630), ".pdf,.doc,.docx,.txt", 3L, ".jpg,.jpeg,.png", 20.0, 20.0, true, null },
                    { 4L, new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630), ".pdf,.doc,.docx,.txt", 4L, ".jpg,.jpeg,.png", 20.0, 20.0, true, null },
                    { 5L, new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630), ".pdf,.doc,.docx,.txt", 5L, ".jpg,.jpeg,.png", 20.0, 20.0, true, null }
                });

            migrationBuilder.UpdateData(
                table: "Configuration_LogSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_LogSettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_LogSettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_LogSettings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_LogSettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_RequiredPasswordSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_RequiredPasswordSettings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_RequiredPasswordSettings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_RequiredPasswordSettings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Configuration_RequiredPasswordSettings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 597, DateTimeKind.Unspecified).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Area",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Employee",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Operation",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Profile",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Profile",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Profile",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "ControlPanel_Profile",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreateDate",
                value: new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "ControlPanel_User",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreateDate", "Password" },
                values: new object[] { new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(5293), "AQAQJwAAudCPmQGUyNHlxeNTPewed9VWDoJlFIxJz457UcjE9jI=" });

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_UploadSettings_IdEnvironmentType",
                table: "Configuration_UploadSettings",
                column: "IdEnvironmentType",
                unique: true,
                filter: "[IdEnvironmentType] IS NOT NULL");

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

            migrationBuilder.DropTable(
                name: "Configuration_UploadSettings");

            migrationBuilder.DeleteData(
                table: "Configuration_LayoutSettings",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Configuration_LayoutSettings",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Configuration_LayoutSettings",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Configuration_LayoutSettings",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Configuration_LayoutSettings",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_User",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 830, DateTimeKind.Unspecified).AddTicks(1934),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 585, DateTimeKind.Unspecified).AddTicks(1487))
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
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 588, DateTimeKind.Unspecified).AddTicks(3402));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Region",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 834, DateTimeKind.Unspecified).AddTicks(2409),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 588, DateTimeKind.Unspecified).AddTicks(8462));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Profile",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 830, DateTimeKind.Unspecified).AddTicks(4229),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 585, DateTimeKind.Unspecified).AddTicks(3441));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Operation",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 830, DateTimeKind.Unspecified).AddTicks(499),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 585, DateTimeKind.Unspecified).AddTicks(271));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ControlPanel_Notification",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 834, DateTimeKind.Unspecified).AddTicks(7028),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(2136));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Employee",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 829, DateTimeKind.Unspecified).AddTicks(7473),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 584, DateTimeKind.Unspecified).AddTicks(7688));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Client",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 830, DateTimeKind.Unspecified).AddTicks(8617),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 585, DateTimeKind.Unspecified).AddTicks(7388));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_City",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 834, DateTimeKind.Unspecified).AddTicks(8080),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 589, DateTimeKind.Unspecified).AddTicks(3010));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Cep",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 833, DateTimeKind.Unspecified).AddTicks(9496),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 588, DateTimeKind.Unspecified).AddTicks(6021));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Audit",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 834, DateTimeKind.Unspecified).AddTicks(4086),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 588, DateTimeKind.Unspecified).AddTicks(9865));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ControlPanel_Area",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 829, DateTimeKind.Unspecified).AddTicks(5018),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 584, DateTimeKind.Unspecified).AddTicks(5613));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_RequiredPasswordSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 832, DateTimeKind.Unspecified).AddTicks(9185),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 587, DateTimeKind.Unspecified).AddTicks(5195));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_LogSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 832, DateTimeKind.Unspecified).AddTicks(6403),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 587, DateTimeKind.Unspecified).AddTicks(2579));

            migrationBuilder.AlterColumn<int>(
                name: "MaxImageFileSize",
                table: "Configuration_LayoutSettings",
                type: "int",
                nullable: false,
                defaultValue: 20,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 20.0)
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

            migrationBuilder.AlterColumn<int>(
                name: "MaxDocumentFileSize",
                table: "Configuration_LayoutSettings",
                type: "int",
                nullable: false,
                defaultValue: 20,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 20.0)
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
                table: "Configuration_LayoutSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 832, DateTimeKind.Unspecified).AddTicks(3052),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 587, DateTimeKind.Unspecified).AddTicks(216))
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

            migrationBuilder.AddColumn<byte[]>(
                name: "BannerMobile",
                table: "Configuration_LayoutSettings",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0])
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade");

            migrationBuilder.AddColumn<byte[]>(
                name: "BannerWeb",
                table: "Configuration_LayoutSettings",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0])
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade");

            migrationBuilder.AddColumn<byte[]>(
                name: "LogoMobile",
                table: "Configuration_LayoutSettings",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0])
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade");

            migrationBuilder.AddColumn<byte[]>(
                name: "LogoWeb",
                table: "Configuration_LayoutSettings",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0])
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "Configuration_LayoutSettingsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "TerminoValidade")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "InicioValidade");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_ExpirationPasswordSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 832, DateTimeKind.Unspecified).AddTicks(776),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 586, DateTimeKind.Unspecified).AddTicks(8233));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EnvironmentTypeSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 833, DateTimeKind.Unspecified).AddTicks(1539),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 587, DateTimeKind.Unspecified).AddTicks(6750));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EmailTemplateSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 831, DateTimeKind.Unspecified).AddTicks(1134),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 585, DateTimeKind.Unspecified).AddTicks(9571));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EmailSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 831, DateTimeKind.Unspecified).AddTicks(5793),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 586, DateTimeKind.Unspecified).AddTicks(3600));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_EmailDisplaySettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 831, DateTimeKind.Unspecified).AddTicks(3300),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 586, DateTimeKind.Unspecified).AddTicks(1443));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Configuration_AuthenticationSettings",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 25, 11, 58, 9, 831, DateTimeKind.Unspecified).AddTicks(8424),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 25, 16, 35, 47, 586, DateTimeKind.Unspecified).AddTicks(6178));

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
