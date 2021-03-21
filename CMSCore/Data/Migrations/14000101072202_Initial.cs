using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMSCore.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PageGroups",
                columns: table => new
                {
                    PageGroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageGroupTitle = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageGroups", x => x.PageGroupID);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    PageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageGroupID = table.Column<int>(nullable: false),
                    PageTitle = table.Column<string>(maxLength: 500, nullable: false),
                    PageShortText = table.Column<string>(maxLength: 3000, nullable: false),
                    PageText = table.Column<string>(nullable: false),
                    PageDate = table.Column<DateTime>(nullable: false),
                    PageIsPublished = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.PageID);
                    table.ForeignKey(
                        name: "FK_Pages_PageGroups_PageGroupID",
                        column: x => x.PageGroupID,
                        principalTable: "PageGroups",
                        principalColumn: "PageGroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageID = table.Column<int>(nullable: false),
                    AuthorName = table.Column<string>(maxLength: 60, nullable: false),
                    AuthorEmail = table.Column<string>(maxLength: 250, nullable: false),
                    CommentText = table.Column<string>(nullable: false),
                    CommentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_Pages_PageID",
                        column: x => x.PageID,
                        principalTable: "Pages",
                        principalColumn: "PageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PageID",
                table: "Comments",
                column: "PageID");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_PageGroupID",
                table: "Pages",
                column: "PageGroupID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "PageGroups");
        }
    }
}
