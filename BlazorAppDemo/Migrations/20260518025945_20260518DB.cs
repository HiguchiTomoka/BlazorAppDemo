using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAppDemo.Migrations
{
    /// <inheritdoc />
    public partial class _20260518DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserNo",
                table: "MealRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "UserDetailInfoRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserNo = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    BodyWeight = table.Column<double>(type: "float", nullable: false),
                    Age = table.Column<double>(type: "float", nullable: false),
                    ExerciseIntensity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetailInfoRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfoRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "MenuRecords");

            migrationBuilder.DropTable(
                name: "UserDetailInfoRecords");

            migrationBuilder.DropTable(
                name: "UserInfoRecords");

            migrationBuilder.DropColumn(
                name: "UserNo",
                table: "MealRecords");
        }
    }
}
