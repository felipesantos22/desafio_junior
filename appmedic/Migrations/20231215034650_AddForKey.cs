using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appmedic.Migrations
{
    /// <inheritdoc />
    public partial class AddForKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logins_Doctors_DoctorId",
                table: "Logins");

            migrationBuilder.DropForeignKey(
                name: "FK_Logins_Patients_PatientId",
                table: "Logins");

            migrationBuilder.DropIndex(
                name: "IX_Logins_DoctorId",
                table: "Logins");

            migrationBuilder.DropIndex(
                name: "IX_Logins_PatientId",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Logins");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Logins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Logins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Logins_DoctorId",
                table: "Logins",
                column: "DoctorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logins_PatientId",
                table: "Logins",
                column: "PatientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_Doctors_DoctorId",
                table: "Logins",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_Patients_PatientId",
                table: "Logins",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
