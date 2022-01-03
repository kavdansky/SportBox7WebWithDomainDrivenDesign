using Microsoft.EntityFrameworkCore.Migrations;

namespace SportBox7.Infrastructure.Persistence.Migrations
{
    public partial class Migration28122021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Sources_SourceId",
                table: "Articles");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<int>(
                name: "SourceId",
                table: "Articles",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "H1Tag",
                table: "Articles",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Sources_SourceId",
                table: "Articles",
                column: "SourceId",
                principalTable: "Sources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Sources_SourceId",
                table: "Articles");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<int>(
                name: "SourceId",
                table: "Articles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "H1Tag",
                table: "Articles",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 120);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Sources_SourceId",
                table: "Articles",
                column: "SourceId",
                principalTable: "Sources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
