using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixDynamicValuesV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "reminders",
                keyColumn: "ReminderId",
                keyValue: 1,
                column: "ReminderDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "tasks",
                keyColumn: "TaskId",
                keyValue: 1,
                column: "TaskDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2022));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "reminders",
                keyColumn: "ReminderId",
                keyValue: 1,
                column: "ReminderDate",
                value: new DateTime(2025, 2, 22, 11, 24, 23, 928, DateTimeKind.Local).AddTicks(2986));

            migrationBuilder.UpdateData(
                table: "tasks",
                keyColumn: "TaskId",
                keyValue: 1,
                column: "TaskDate",
                value: new DateTime(2025, 2, 22, 11, 24, 23, 906, DateTimeKind.Local).AddTicks(8415));
        }
    }
}
