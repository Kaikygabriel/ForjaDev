using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForjaDev.Api.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Links",
                table: "member",
                newName: "links");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "links",
                table: "member",
                newName: "Links");
        }
    }
}
