using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ajustemigrationenum : Migration
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
                defaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 875, DateTimeKind.Unspecified).AddTicks(9035),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 723, DateTimeKind.Unspecified).AddTicks(5359))
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
                defaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 876, DateTimeKind.Unspecified).AddTicks(5137),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 724, DateTimeKind.Unspecified).AddTicks(2028));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Regions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 876, DateTimeKind.Unspecified).AddTicks(9774),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 724, DateTimeKind.Unspecified).AddTicks(7141));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Profiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 876, DateTimeKind.Unspecified).AddTicks(1130),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 723, DateTimeKind.Unspecified).AddTicks(7643));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Operation",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 877, DateTimeKind.Unspecified).AddTicks(3618),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 725, DateTimeKind.Unspecified).AddTicks(1054));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Notification",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 877, DateTimeKind.Unspecified).AddTicks(7040),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 725, DateTimeKind.Unspecified).AddTicks(4631));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Employees",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 878, DateTimeKind.Unspecified).AddTicks(9365),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 726, DateTimeKind.Unspecified).AddTicks(7530));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 878, DateTimeKind.Unspecified).AddTicks(5739),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 726, DateTimeKind.Unspecified).AddTicks(3498));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailTemplate",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 878, DateTimeKind.Unspecified).AddTicks(1551),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 725, DateTimeKind.Unspecified).AddTicks(9227));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailDisplay",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 878, DateTimeKind.Unspecified).AddTicks(3503),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 726, DateTimeKind.Unspecified).AddTicks(1203));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Client",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 877, DateTimeKind.Unspecified).AddTicks(4962),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 725, DateTimeKind.Unspecified).AddTicks(2502));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Cities",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 877, DateTimeKind.Unspecified).AddTicks(8007),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 725, DateTimeKind.Unspecified).AddTicks(5592));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Ceps",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 876, DateTimeKind.Unspecified).AddTicks(7176),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 724, DateTimeKind.Unspecified).AddTicks(4158));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Audit",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 877, DateTimeKind.Unspecified).AddTicks(1212),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 724, DateTimeKind.Unspecified).AddTicks(8642));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Areas",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 878, DateTimeKind.Unspecified).AddTicks(7241),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 726, DateTimeKind.Unspecified).AddTicks(4997));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "ArchiveType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 878, DateTimeKind.Unspecified).AddTicks(78),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 725, DateTimeKind.Unspecified).AddTicks(7721));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 886, DateTimeKind.Unspecified).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 886, DateTimeKind.Unspecified).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 886, DateTimeKind.Unspecified).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 886, DateTimeKind.Unspecified).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 886, DateTimeKind.Unspecified).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 886, DateTimeKind.Unspecified).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 886, DateTimeKind.Unspecified).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 879, DateTimeKind.Unspecified).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 879, DateTimeKind.Unspecified).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 879, DateTimeKind.Unspecified).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 879, DateTimeKind.Unspecified).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 879, DateTimeKind.Unspecified).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 879, DateTimeKind.Unspecified).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created_Time", "Title" },
                values: new object[] { new DateTime(2024, 7, 24, 16, 11, 33, 886, DateTimeKind.Unspecified).AddTicks(8144), "value" });

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Body", "Created_Time", "Subject", "Title" },
                values: new object[] { "<center>Olá, {0}</center><center>Conforme sua solicitação enviamos este email para que você possa concluir sua solicitação de troca de senha. Clique no botão abaixo.</center><br> ", new DateTime(2024, 7, 24, 16, 11, 33, 886, DateTimeKind.Unspecified).AddTicks(8144), "{0} - Solicitação de troca de senha", "value" });

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Body", "Created_Time", "Subject", "Title" },
                values: new object[] { "<center>Olá, {0}</center><center>Conforme sua solicitação enviamos este email para que você possa concluir sua solicitação de esqueci a senha. Clique no botão abaixo.</center><br> ", new DateTime(2024, 7, 24, 16, 11, 33, 886, DateTimeKind.Unspecified).AddTicks(8144), "{0} - Esqueci a senha", "value" });

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Body", "Created_Time" },
                values: new object[] { "<center>Olá, {0}</center><center>Quero reporta-lo que a sua confirmação de senha foi realizada com sucesso no periodo das 24/07/2024 - 16:11</center><br> ", new DateTime(2024, 7, 24, 16, 11, 33, 886, DateTimeKind.Unspecified).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 886, DateTimeKind.Unspecified).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 886, DateTimeKind.Unspecified).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "EmailType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 886, DateTimeKind.Unspecified).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "EmailType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 886, DateTimeKind.Unspecified).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "EmailType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 886, DateTimeKind.Unspecified).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 879, DateTimeKind.Unspecified).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 879, DateTimeKind.Unspecified).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 879, DateTimeKind.Unspecified).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 879, DateTimeKind.Unspecified).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 879, DateTimeKind.Unspecified).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 879, DateTimeKind.Unspecified).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 879, DateTimeKind.Unspecified).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 879, DateTimeKind.Unspecified).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 879, DateTimeKind.Unspecified).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 879, DateTimeKind.Unspecified).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 879, DateTimeKind.Unspecified).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 24, 16, 11, 33, 879, DateTimeKind.Unspecified).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created_Time", "Password" },
                values: new object[] { new DateTime(2024, 7, 24, 16, 11, 33, 879, DateTimeKind.Unspecified).AddTicks(2092), "AQAQJwAAOqFduMDzhs3W1PUfOoMrpN2Qy6IfTpdV1sjbVt4yV/4=" });

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
                defaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 723, DateTimeKind.Unspecified).AddTicks(5359),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 875, DateTimeKind.Unspecified).AddTicks(9035))
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
                defaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 724, DateTimeKind.Unspecified).AddTicks(2028),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 876, DateTimeKind.Unspecified).AddTicks(5137));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Regions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 724, DateTimeKind.Unspecified).AddTicks(7141),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 876, DateTimeKind.Unspecified).AddTicks(9774));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Profiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 723, DateTimeKind.Unspecified).AddTicks(7643),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 876, DateTimeKind.Unspecified).AddTicks(1130));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Operation",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 725, DateTimeKind.Unspecified).AddTicks(1054),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 877, DateTimeKind.Unspecified).AddTicks(3618));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Notification",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 725, DateTimeKind.Unspecified).AddTicks(4631),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 877, DateTimeKind.Unspecified).AddTicks(7040));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Employees",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 726, DateTimeKind.Unspecified).AddTicks(7530),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 878, DateTimeKind.Unspecified).AddTicks(9365));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 726, DateTimeKind.Unspecified).AddTicks(3498),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 878, DateTimeKind.Unspecified).AddTicks(5739));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailTemplate",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 725, DateTimeKind.Unspecified).AddTicks(9227),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 878, DateTimeKind.Unspecified).AddTicks(1551));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "EmailDisplay",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 726, DateTimeKind.Unspecified).AddTicks(1203),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 878, DateTimeKind.Unspecified).AddTicks(3503));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Client",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 725, DateTimeKind.Unspecified).AddTicks(2502),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 877, DateTimeKind.Unspecified).AddTicks(4962));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Cities",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 725, DateTimeKind.Unspecified).AddTicks(5592),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 877, DateTimeKind.Unspecified).AddTicks(8007));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Ceps",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 724, DateTimeKind.Unspecified).AddTicks(4158),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 876, DateTimeKind.Unspecified).AddTicks(7176));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Audit",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 724, DateTimeKind.Unspecified).AddTicks(8642),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 877, DateTimeKind.Unspecified).AddTicks(1212));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "Areas",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 726, DateTimeKind.Unspecified).AddTicks(4997),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 878, DateTimeKind.Unspecified).AddTicks(7241));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_Time",
                table: "ArchiveType",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 7, 17, 21, 29, 36, 725, DateTimeKind.Unspecified).AddTicks(7721),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 7, 24, 16, 11, 33, 878, DateTimeKind.Unspecified).AddTicks(78));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 734, DateTimeKind.Unspecified).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 734, DateTimeKind.Unspecified).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 734, DateTimeKind.Unspecified).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 734, DateTimeKind.Unspecified).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 734, DateTimeKind.Unspecified).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 734, DateTimeKind.Unspecified).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "ArchiveType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 734, DateTimeKind.Unspecified).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 727, DateTimeKind.Unspecified).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 727, DateTimeKind.Unspecified).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 727, DateTimeKind.Unspecified).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 727, DateTimeKind.Unspecified).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 727, DateTimeKind.Unspecified).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 727, DateTimeKind.Unspecified).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created_Time", "Title" },
                values: new object[] { new DateTime(2024, 7, 17, 21, 29, 36, 734, DateTimeKind.Unspecified).AddTicks(6601), "Boas vindas" });

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Body", "Created_Time", "Subject", "Title" },
                values: new object[] { "<center>Olá, {0}</center><center>Conforme sua solicitação enviamos este email para que você possa concluir sua solicitação de esqueci a senha. Clique no botão abaixo.</center><br> ", new DateTime(2024, 7, 17, 21, 29, 36, 734, DateTimeKind.Unspecified).AddTicks(6601), "{0} - Esqueci a senha", "Esqueci a senha" });

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Body", "Created_Time", "Subject", "Title" },
                values: new object[] { "<center>Olá, {0}</center><center>Conforme sua solicitação enviamos este email para que você possa concluir sua solicitação de troca de senha. Clique no botão abaixo.</center><br> ", new DateTime(2024, 7, 17, 21, 29, 36, 734, DateTimeKind.Unspecified).AddTicks(6601), "{0} - Solicitação de troca de senha", "Troca de senha" });

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Body", "Created_Time" },
                values: new object[] { "<center>Olá, {0}</center><center>Quero reporta-lo que a sua confirmação de senha foi realizada com sucesso no periodo das 17/07/2024 - 21:29</center><br> ", new DateTime(2024, 7, 17, 21, 29, 36, 734, DateTimeKind.Unspecified).AddTicks(6601) });

            migrationBuilder.UpdateData(
                table: "EmailDisplay",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 734, DateTimeKind.Unspecified).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "EmailTemplate",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 734, DateTimeKind.Unspecified).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "EmailType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 734, DateTimeKind.Unspecified).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "EmailType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 734, DateTimeKind.Unspecified).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "EmailType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 734, DateTimeKind.Unspecified).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 727, DateTimeKind.Unspecified).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 727, DateTimeKind.Unspecified).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 727, DateTimeKind.Unspecified).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 727, DateTimeKind.Unspecified).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 727, DateTimeKind.Unspecified).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 727, DateTimeKind.Unspecified).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 727, DateTimeKind.Unspecified).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 727, DateTimeKind.Unspecified).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 727, DateTimeKind.Unspecified).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 727, DateTimeKind.Unspecified).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 727, DateTimeKind.Unspecified).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Created_Time",
                value: new DateTime(2024, 7, 17, 21, 29, 36, 727, DateTimeKind.Unspecified).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created_Time", "Password" },
                values: new object[] { new DateTime(2024, 7, 17, 21, 29, 36, 727, DateTimeKind.Unspecified).AddTicks(357), "AQAQJwAA/wCRq0UTMoDgMZlfMbNe1iX5yWDgo++SwBFrVNwUUZU=" });

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
