using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizQuest.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class fix11_BasicEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizResults_Users_UserId1",
                table: "QuizResults");

            migrationBuilder.DropIndex(
                name: "IX_QuizResults_UserId1",
                table: "QuizResults");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "QuizResults");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "QuizResults",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizResults_UserId",
                table: "QuizResults",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizResults_Users_UserId",
                table: "QuizResults",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizResults_Users_UserId",
                table: "QuizResults");

            migrationBuilder.DropIndex(
                name: "IX_QuizResults_UserId",
                table: "QuizResults");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "QuizResults",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "QuizResults",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizResults_UserId1",
                table: "QuizResults",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizResults_Users_UserId1",
                table: "QuizResults",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
