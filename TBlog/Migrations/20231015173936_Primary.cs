using Microsoft.EntityFrameworkCore.Migrations;

namespace TBlog.Migrations
{
    public partial class Primary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CId);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    SId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SPersianName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SPic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.SId);
                });

            migrationBuilder.CreateTable(
                name: "TagPosts",
                columns: table => new
                {
                    TPId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TId = table.Column<int>(type: "int", nullable: false),
                    PId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagPosts", x => x.TPId);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UPass = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    UMail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UIP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UBio = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    URegDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UPic = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PSId = table.Column<int>(type: "int", nullable: false),
                    PCId = table.Column<int>(type: "int", nullable: false),
                    PUId = table.Column<int>(type: "int", nullable: false),
                    PTitle = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    PText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PSubtitle = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    PDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PTDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PPicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PType = table.Column<int>(type: "int", nullable: false),
                    PAudio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PViews = table.Column<int>(type: "int", nullable: false),
                    PLikes = table.Column<int>(type: "int", nullable: false),
                    PMins = table.Column<int>(type: "int", nullable: false),
                    PShow = table.Column<bool>(type: "bit", nullable: false),
                    PChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PId);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_PCId",
                        column: x => x.PCId,
                        principalTable: "Categories",
                        principalColumn: "CId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Sites_PSId",
                        column: x => x.PSId,
                        principalTable: "Sites",
                        principalColumn: "SId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Users_PUId",
                        column: x => x.PUId,
                        principalTable: "Users",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PCId",
                table: "Posts",
                column: "PCId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PSId",
                table: "Posts",
                column: "PSId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PUId",
                table: "Posts",
                column: "PUId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "TagPosts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
