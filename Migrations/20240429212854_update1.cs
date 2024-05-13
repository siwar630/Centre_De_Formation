using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Centre_de_formation.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formations_Cours_CoursId",
                table: "Formations");

            migrationBuilder.AlterColumn<int>(
                name: "CoursId",
                table: "Formations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Formations_Cours_CoursId",
                table: "Formations",
                column: "CoursId",
                principalTable: "Cours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formations_Cours_CoursId",
                table: "Formations");

            migrationBuilder.AlterColumn<int>(
                name: "CoursId",
                table: "Formations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Formations_Cours_CoursId",
                table: "Formations",
                column: "CoursId",
                principalTable: "Cours",
                principalColumn: "Id");
        }
    }
}
