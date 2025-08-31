using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CybersecDomain.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<uint>(
                name: "profile_id",
                table: "Profiles",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<uint>(
                name: "MainTaskId",
                table: "Main_task",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<uint>(
                name: "LogoId",
                table: "Logos",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<uint>(
                name: "KnowledgeId",
                table: "Knowledge",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<uint>(
                name: "KeySkillId",
                table: "KeySkills",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<uint>(
                name: "DeliverableId",
                table: "Deliverable",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<uint>(
                name: "AlternativeTitleId",
                table: "Alternative_Title",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<uint>(
                name: "profile_id",
                table: "Profiles",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<uint>(
                name: "MainTaskId",
                table: "Main_task",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<uint>(
                name: "LogoId",
                table: "Logos",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<uint>(
                name: "KnowledgeId",
                table: "Knowledge",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<uint>(
                name: "KeySkillId",
                table: "KeySkills",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<uint>(
                name: "DeliverableId",
                table: "Deliverable",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<uint>(
                name: "AlternativeTitleId",
                table: "Alternative_Title",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }
    }
}
