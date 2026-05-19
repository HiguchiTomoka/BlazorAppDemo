using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAppDemo.Migrations
{
    /// <inheritdoc />
    public partial class _20260519DataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActiveRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNo = table.Column<int>(type: "int", nullable: false),
                    ActiveKind = table.Column<int>(type: "int", nullable: false),
                    ActiveName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Reps = table.Column<double>(type: "float", nullable: false),
                    Set = table.Column<double>(type: "float", nullable: false),
                    RunningDistance = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNo = table.Column<int>(type: "int", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    Protein = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Carbs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MealDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNo = table.Column<int>(type: "int", nullable: false),
                    DishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialWeight = table.Column<double>(type: "float", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    Protein = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Carbs = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfoRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNo = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodyWeight = table.Column<double>(type: "float", nullable: false),
                    Bodyheight = table.Column<double>(type: "float", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BasalMetabolism = table.Column<double>(type: "float", nullable: false),
                    PhysicalActivityLevel = table.Column<double>(type: "float", nullable: false),
                    TotalDailyEnergyExpenditure = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfoRecords", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveRecords");

            migrationBuilder.DropTable(
                name: "MealRecords");

            migrationBuilder.DropTable(
                name: "MenuRecords");

            migrationBuilder.DropTable(
                name: "UserInfoRecords");
        }
    }
}
