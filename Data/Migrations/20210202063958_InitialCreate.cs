using Microsoft.EntityFrameworkCore.Migrations;

namespace KarTech.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CPUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<double>(type: "float", nullable: false),
                    Benchmark = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GPUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<double>(type: "float", nullable: false),
                    Benchmark = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValueGb = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CPUId = table.Column<int>(type: "int", nullable: true),
                    GPUId = table.Column<int>(type: "int", nullable: true),
                    RamId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IsLaptop = table.Column<bool>(type: "bit", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Computers_CPUs_CPUId",
                        column: x => x.CPUId,
                        principalTable: "CPUs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Computers_GPUs_GPUId",
                        column: x => x.GPUId,
                        principalTable: "GPUs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Computers_Rams_RamId",
                        column: x => x.RamId,
                        principalTable: "Rams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValueGb = table.Column<int>(type: "int", nullable: false),
                    IsSSD = table.Column<bool>(type: "bit", nullable: false),
                    ComputerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storages_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Computers_CPUId",
                table: "Computers",
                column: "CPUId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_GPUId",
                table: "Computers",
                column: "GPUId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_RamId",
                table: "Computers",
                column: "RamId");

            migrationBuilder.CreateIndex(
                name: "IX_Storages_ComputerId",
                table: "Storages",
                column: "ComputerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "CPUs");

            migrationBuilder.DropTable(
                name: "GPUs");

            migrationBuilder.DropTable(
                name: "Rams");
        }
    }
}
