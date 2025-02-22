using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixDynamicValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "reminders",
                keyColumn: "ReminderId",
                keyValue: 1,
                columns: new[] { "ReminderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 22, 11, 24, 23, 928, DateTimeKind.Local).AddTicks(2986), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2021) });

            migrationBuilder.UpdateData(
                table: "taskHistories",
                keyColumn: "TaskHistoryId",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "tasks",
                keyColumn: "TaskId",
                keyValue: 1,
                columns: new[] { "TaskDate", "dateCreated" },
                values: new object[] { new DateTime(2025, 2, 22, 11, 24, 23, 906, DateTimeKind.Local).AddTicks(8415), new DateOnly(2023, 10, 1) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "DateRegistered",
                value: new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "reminders",
                keyColumn: "ReminderId",
                keyValue: 1,
                columns: new[] { "ReminderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 22, 9, 58, 32, 904, DateTimeKind.Local).AddTicks(1851), new DateTime(2025, 2, 22, 9, 58, 32, 904, DateTimeKind.Local).AddTicks(2452) });

            migrationBuilder.UpdateData(
                table: "taskHistories",
                keyColumn: "TaskHistoryId",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 2, 22, 9, 58, 32, 903, DateTimeKind.Local).AddTicks(8601));

            migrationBuilder.UpdateData(
                table: "tasks",
                keyColumn: "TaskId",
                keyValue: 1,
                columns: new[] { "TaskDate", "dateCreated" },
                values: new object[] { new DateTime(2025, 2, 22, 9, 58, 32, 862, DateTimeKind.Local).AddTicks(3524), new DateOnly(2025, 2, 22) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "DateRegistered",
                value: new DateTime(2025, 2, 22, 9, 58, 32, 903, DateTimeKind.Local).AddTicks(3754));
        }
    }
}
