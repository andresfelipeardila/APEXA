﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApexaApp.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advisors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    SIN = table.Column<string>(type: "TEXT", maxLength: 9, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    HealthStatus = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advisors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advisors_SIN",
                table: "Advisors",
                column: "SIN",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advisors");
        }
    }
}
