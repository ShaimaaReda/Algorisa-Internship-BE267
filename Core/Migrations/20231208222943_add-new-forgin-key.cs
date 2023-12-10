using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class addnewforginkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "Appointment",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AspNetUsers_DoctorId",
                table: "Appointment",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {   migrationBuilder.CreateIndex(
                name: "IX_Appointment_DoctorId1",
                table: "Appointment",
                column: "DoctorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AspNetUsers_DoctorId1",
                table: "Appointment",
                column: "DoctorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
