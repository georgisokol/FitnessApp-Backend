using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.API.Migrations
{
    public partial class CreatingMacrosDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyMacroIntakeHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Protein = table.Column<int>(maxLength: 4, nullable: false),
                    Carbs = table.Column<int>(maxLength: 4, nullable: false),
                    Fats = table.Column<int>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyMacroIntakeHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyMacroTargets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    TProtein = table.Column<int>(nullable: false),
                    TCarbs = table.Column<int>(nullable: false),
                    TFats = table.Column<int>(nullable: false),
                    RProtein = table.Column<int>(nullable: false),
                    RCarbs = table.Column<int>(nullable: false),
                    RFats = table.Column<int>(nullable: false),
                    CustomMacros = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyMacroTargets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealMacros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Protein = table.Column<int>(maxLength: 4, nullable: false),
                    Carbs = table.Column<int>(maxLength: 4, nullable: false),
                    Fats = table.Column<int>(maxLength: 4, nullable: false),
                    MealName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealMacros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SavedMeals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Protein = table.Column<int>(maxLength: 4, nullable: false),
                    Carbs = table.Column<int>(maxLength: 4, nullable: false),
                    Fats = table.Column<int>(maxLength: 4, nullable: false),
                    MealName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedMeals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Frequency = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Goal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyMacroIntakeHistory");

            migrationBuilder.DropTable(
                name: "DailyMacroTargets");

            migrationBuilder.DropTable(
                name: "MealMacros");

            migrationBuilder.DropTable(
                name: "SavedMeals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
