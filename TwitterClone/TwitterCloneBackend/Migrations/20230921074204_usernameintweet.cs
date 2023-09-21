using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitterCloneBackend.Migrations
{
    /// <inheritdoc />
    public partial class usernameintweet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Tweets",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Tweets");
        }
    }
}
