using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appmedic.Migrations
{
    /// <inheritdoc />
    public partial class create_relations_address_patient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "ViaCep",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ViaCep_PatientId",
                table: "ViaCep",
                column: "PatientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ViaCep_Patients_PatientId",
                table: "ViaCep",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ViaCep_Patients_PatientId",
                table: "ViaCep");

            migrationBuilder.DropIndex(
                name: "IX_ViaCep_PatientId",
                table: "ViaCep");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "ViaCep");
        }
    }
}
