using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TamaDotNet.Server.Migrations
{
    public partial class UpdateTama : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "lastMood",
                table: "Tamas",
                newName: "LastMood");

            migrationBuilder.RenameColumn(
                name: "lastFed",
                table: "Tamas",
                newName: "LastFed");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Tamas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastMood",
                table: "Tamas",
                newName: "lastMood");

            migrationBuilder.RenameColumn(
                name: "LastFed",
                table: "Tamas",
                newName: "lastFed");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Tamas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TamaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Tamas_TamaId",
                        column: x => x.TamaId,
                        principalTable: "Tamas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TamaId",
                table: "Users",
                column: "TamaId",
                unique: true);
        }
    }
}
