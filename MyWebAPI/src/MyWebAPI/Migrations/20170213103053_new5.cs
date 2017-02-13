using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebAPI.Migrations
{
    public partial class new5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Story_Users_UsersId",
                table: "Story");

            migrationBuilder.AlterColumn<int>(
                name: "UsersId",
                table: "Story",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Story_Users_UsersId",
                table: "Story",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Story_Users_UsersId",
                table: "Story");

            migrationBuilder.AlterColumn<int>(
                name: "UsersId",
                table: "Story",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Story_Users_UsersId",
                table: "Story",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
