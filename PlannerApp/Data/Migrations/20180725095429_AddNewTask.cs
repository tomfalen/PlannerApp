using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PlannerApp.Data.Migrations
{
    public partial class AddNewTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "TaskList");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TaskList",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "TaskList",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "TaskList",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "TaskList");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "TaskList");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TaskList",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "TaskList",
                nullable: false,
                defaultValue: 0);
        }
    }
}
