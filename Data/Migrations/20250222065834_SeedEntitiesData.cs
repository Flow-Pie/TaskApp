using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedEntitiesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskStatus",
                table: "taskHistories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "UserId", "DateRegistered", "Email", "FirstName", "LastName", "Password", "Role", "Username" },
                values: new object[] { 3, new DateTime(2025, 2, 22, 9, 58, 32, 903, DateTimeKind.Local).AddTicks(3754), "johndoe@example.com", "John", "Doe", "password123", "Admin", "John Doe" });

            migrationBuilder.InsertData(
                table: "tasks",
                columns: new[] { "TaskId", "Status", "TaskDate", "TaskDescription", "TaskPriority", "TaskTitle", "UserId", "dateCreated" },
                values: new object[] { 1, true, new DateTime(2025, 2, 22, 9, 58, 32, 862, DateTimeKind.Local).AddTicks(3524), "Task 1 Description", "High", "Task 1", 3, new DateOnly(2025, 2, 22) });

            migrationBuilder.InsertData(
                table: "calendars",
                columns: new[] { "CalendarId", "EndTime", "EventTitle", "StartTime", "TasksId" },
                values: new object[] { 1, "11:00 AM", "Calendar 1 Event Title", "10:00 AM", 1 });

            migrationBuilder.InsertData(
                table: "reminders",
                columns: new[] { "ReminderId", "ReminderDate", "TasksId", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 2, 22, 9, 58, 32, 904, DateTimeKind.Local).AddTicks(1851), 1, new DateTime(2025, 2, 22, 9, 58, 32, 904, DateTimeKind.Local).AddTicks(2452) });

            migrationBuilder.InsertData(
                table: "taskHistories",
                columns: new[] { "TaskHistoryId", "TaskStatus", "TasksId", "UpdatedAt" },
                values: new object[] { 1, 0, 1, new DateTime(2025, 2, 22, 9, 58, 32, 903, DateTimeKind.Local).AddTicks(8601) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "calendars",
                keyColumn: "CalendarId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "reminders",
                keyColumn: "ReminderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "taskHistories",
                keyColumn: "TaskHistoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tasks",
                keyColumn: "TaskId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "TaskStatus",
                table: "taskHistories");
        }
    }
}
