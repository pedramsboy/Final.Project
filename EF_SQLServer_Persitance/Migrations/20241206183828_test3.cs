using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_SQLServer_Persitance.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "Nvarchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "PostText",
                table: "Posts",
                type: "Nvarchar(Max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Nvarchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "PostText",
                table: "Posts",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Nvarchar(Max)");
        }
    }
}
