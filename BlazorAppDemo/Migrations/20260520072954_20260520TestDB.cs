using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAppDemo.Migrations
{
    /// <inheritdoc />
    public partial class _20260520TestDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Energy = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Protein = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Carbohydrate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Retinol = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bcarotene = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VitaminB1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VitaminB2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VitaminC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VitaminD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VitaminE = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");
        }
    }
}
