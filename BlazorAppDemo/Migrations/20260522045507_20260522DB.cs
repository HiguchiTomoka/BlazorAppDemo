using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAppDemo.Migrations
{
    /// <inheritdoc />
    public partial class _20260522DB : Migration
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ActiveKind = table.Column<int>(type: "int", nullable: false),
                    ActiveName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActiveDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CaloriesBurned = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WasteRate = table.Column<int>(type: "int", nullable: false),
                    Energy = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Protein = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Carbohydrate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Retinol = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Bcarotene = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VitaminB1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VitaminB2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VitaminC = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VitaminD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VitaminE = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SaltEquivalent = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Calories = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialWeight = table.Column<double>(type: "float", nullable: false),
                    Calories = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Protein = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Carbs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VitaminA = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VitaminB1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VitaminB2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VitaminC = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VitaminD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VitaminE = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SaltEquivalent = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetsRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mets = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ActiveNameJa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionJa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActiveNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetsRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfoRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Foods");

            migrationBuilder.DropTable(
                name: "MealRecords");

            migrationBuilder.DropTable(
                name: "MenuRecords");

            migrationBuilder.DropTable(
                name: "MetsRecords");

            migrationBuilder.DropTable(
                name: "UserInfoRecords");
        }
    }
}
