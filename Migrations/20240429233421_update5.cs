using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Centre_de_formation.Migrations
{
    /// <inheritdoc />
    public partial class update5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Formateurs_FormateurId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Formations_FormationId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Salles_SalleId",
                table: "Sessions");

            migrationBuilder.AlterColumn<int>(
                name: "SalleId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FormationId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FormateurId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Formateurs_FormateurId",
                table: "Sessions",
                column: "FormateurId",
                principalTable: "Formateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Formations_FormationId",
                table: "Sessions",
                column: "FormationId",
                principalTable: "Formations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Salles_SalleId",
                table: "Sessions",
                column: "SalleId",
                principalTable: "Salles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Formateurs_FormateurId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Formations_FormationId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Salles_SalleId",
                table: "Sessions");

            migrationBuilder.AlterColumn<int>(
                name: "SalleId",
                table: "Sessions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FormationId",
                table: "Sessions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FormateurId",
                table: "Sessions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Formateurs_FormateurId",
                table: "Sessions",
                column: "FormateurId",
                principalTable: "Formateurs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Formations_FormationId",
                table: "Sessions",
                column: "FormationId",
                principalTable: "Formations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Salles_SalleId",
                table: "Sessions",
                column: "SalleId",
                principalTable: "Salles",
                principalColumn: "Id");
        }
    }
}
