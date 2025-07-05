using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PresenceLoggingService.Migrations
{
    /// <inheritdoc />
    public partial class FixedLastShift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Shifts_LastShiftId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_LastShiftId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "LastShiftId",
                table: "Employees",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LastShiftId",
                table: "Employees",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LastShiftId",
                table: "Employees",
                column: "LastShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Shifts_LastShiftId",
                table: "Employees",
                column: "LastShiftId",
                principalTable: "Shifts",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
