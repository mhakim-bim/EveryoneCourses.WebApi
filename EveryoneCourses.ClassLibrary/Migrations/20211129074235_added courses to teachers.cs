using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EveryoneCourses.ClassLibrary.Migrations
{
    public partial class addedcoursestoteachers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 11, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 11, 29, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 11, 25, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 11, 25, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
