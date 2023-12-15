using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appmedic.Migrations
{
    /// <inheritdoc />
    public partial class AddForeiKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Logins_LoginId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Logins_LoginId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_LoginId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_LoginId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "LoginId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "LoginId",
                table: "Doctors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoginId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoginId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_LoginId",
                table: "Patients",
                column: "LoginId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_LoginId",
                table: "Doctors",
                column: "LoginId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Logins_LoginId",
                table: "Doctors",
                column: "LoginId",
                principalTable: "Logins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Logins_LoginId",
                table: "Patients",
                column: "LoginId",
                principalTable: "Logins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
