using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessApp.API.Migrations
{
    public partial class CreatingMacrosDbWithAuth : Migration
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
                    UserFk = table.Column<Guid>(nullable: false),
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
                    CustomMacros = table.Column<bool>(nullable: false),
                    UserFk = table.Column<Guid>(nullable: false),
                    IsFirstTime = table.Column<string>(nullable: true)
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
                    MealName = table.Column<string>(maxLength: 50, nullable: true),
                    UserFk = table.Column<Guid>(nullable: false)
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
                    MealName = table.Column<string>(maxLength: 50, nullable: true),
                    UserFk = table.Column<Guid>(nullable: false)
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
                    Uid = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Salt = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    Height = table.Column<int>(nullable: true),
                    Weight = table.Column<int>(nullable: true),
                    Frequency = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: true),
                    Goal = table.Column<int>(nullable: true)
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
