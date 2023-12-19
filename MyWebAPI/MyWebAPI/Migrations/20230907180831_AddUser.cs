using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebAPI.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonHangCT_HangHoa",
                table: "ChiTietDonHang");

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_UserName",
                table: "NguoiDung",
                column: "UserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DonHangCT_HangHoa ",
                table: "ChiTietDonHang",
                column: "MaHh",
                principalTable: "HangHoa",
                principalColumn: "MaHh",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonHangCT_HangHoa ",
                table: "ChiTietDonHang");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.AddForeignKey(
                name: "FK_DonHangCT_HangHoa",
                table: "ChiTietDonHang",
                column: "MaHh",
                principalTable: "HangHoa",
                principalColumn: "MaHh",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
