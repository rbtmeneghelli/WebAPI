using System;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Infra.Migrations
{
    /// <inheritdoc />
    public partial class create_view_by_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                             CREATE OR ALTER VIEW vw_Total_Records_By_Table AS
                             SELECT
                             (SELECT COUNT(1) from Cities) AS TotalCities,
                             (SELECT COUNT(1) from Client) AS TotalClients,
                             (SELECT COUNT(1) from Users) AS TotalUsers
                            ");
            migrationBuilder.Sql(@"
                             CREATE OR ALTER VIEW vw_Total_Records
                             AS
                             SELECT 
                             (SELECT COUNT(1) from Cities) +
                             (SELECT COUNT(1) from Client) +
                             (SELECT COUNT(1) from Users) AS Total
                            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS vw_Total_Records");
            migrationBuilder.Sql("DROP VIEW IF EXISTS vw_Total_Records_By_Table");
        }
    }
}
