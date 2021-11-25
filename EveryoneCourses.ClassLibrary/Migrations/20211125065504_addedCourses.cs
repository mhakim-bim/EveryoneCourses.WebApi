using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EveryoneCourses.ClassLibrary.Migrations
{
    public partial class addedCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "Name", "Rating", "TotalNumberOfStudents" },
                values: new object[] { 1, "Mohamed Elhakim", 0m, 0 });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "Name", "Rating", "TotalNumberOfStudents" },
                values: new object[] { 2, "Mohamed Nasser", 0m, 0 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "CreatedDate", "NumberOfStudents", "Rating", "TeacherId" },
                values: new object[] { 1, "C# Basics", new DateTime(2021, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), 0, 0m, 1 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "CreatedDate", "NumberOfStudents", "Rating", "TeacherId" },
                values: new object[] { 2, "C# Advanced", new DateTime(2021, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), 0, 0m, 2 });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
