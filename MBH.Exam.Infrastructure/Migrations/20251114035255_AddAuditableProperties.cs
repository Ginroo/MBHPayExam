using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MBH.Exam.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditableProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ClientSessions",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.CreateIndex(
                name: "IX_ClientSessions_ClientName_SessionDate",
                table: "ClientSessions",
                columns: new[] { "ClientName", "SessionDate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ClientSessions_ClientName_SessionDate",
                table: "ClientSessions");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ClientSessions",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);
        }
    }
}
