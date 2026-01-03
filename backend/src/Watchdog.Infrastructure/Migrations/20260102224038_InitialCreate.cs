using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Watchdog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    RiskLevel = table.Column<int>(type: "integer", nullable: false),
                    KycStatus = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Country", "CreatedAt", "KycStatus", "Name", "RiskLevel" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "Brazil", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, "Cliente Teste", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
