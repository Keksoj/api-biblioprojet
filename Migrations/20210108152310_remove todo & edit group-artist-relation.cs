using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BiblioApi.Migrations
{
    public partial class removetodoeditgroupartistrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumArtistRelations");

            migrationBuilder.DropTable(
                name: "TodoItems");

            migrationBuilder.CreateTable(
                name: "GroupArtistRelations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    ArtistId = table.Column<int>(type: "int", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupArtistRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupArtistRelations_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupArtistRelations_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupArtistRelations_ArtistId",
                table: "GroupArtistRelations",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupArtistRelations_GroupId",
                table: "GroupArtistRelations",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupArtistRelations");

            migrationBuilder.CreateTable(
                name: "AlbumArtistRelations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ArtistId = table.Column<int>(type: "int", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumArtistRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlbumArtistRelations_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlbumArtistRelations_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumArtistRelations_ArtistId",
                table: "AlbumArtistRelations",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumArtistRelations_GroupId",
                table: "AlbumArtistRelations",
                column: "GroupId");
        }
    }
}
