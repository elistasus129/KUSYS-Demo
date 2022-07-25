using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig2_date : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(1994, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "BirthDate", "CourseId", "FirstName", "LastName" },
                values: new object[] { 2, new DateTime(1994, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CSI102", "ali", "Ramazanoglu" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2004, 7, 22, 20, 16, 11, 212, DateTimeKind.Local).AddTicks(8461));
        }
    }
}
