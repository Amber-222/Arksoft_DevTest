using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArkSoft_MVC.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    custID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "0, 1"),
                    custName = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    custAddress = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    custTelephone = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    custContactName = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    custContactEmail = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    vatNumber = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.custID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
