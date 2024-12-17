using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_SQLServer_Persitance.Migrations
{
    /// <inheritdoc />
    public partial class Test10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_AspNetUsers_UserId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_UserId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Prescriptions");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Prescriptions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_AuthorId",
                table: "Prescriptions",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_AspNetUsers_AuthorId",
                table: "Prescriptions",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_AspNetUsers_AuthorId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_AuthorId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Prescriptions");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Prescriptions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_UserId",
                table: "Prescriptions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_AspNetUsers_UserId",
                table: "Prescriptions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
