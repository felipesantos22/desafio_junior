using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appmedic.Migrations
{
    /// <inheritdoc />
    public partial class AddFoKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logins_Doctors_Id",
                table: "Logins");

            migrationBuilder.DropForeignKey(
                name: "FK_Logins_Patients_Id",
                table: "Logins");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Logins",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Logins",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_Doctors_Id",
                table: "Logins",
                column: "Id",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_Patients_Id",
                table: "Logins",
                column: "Id",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
