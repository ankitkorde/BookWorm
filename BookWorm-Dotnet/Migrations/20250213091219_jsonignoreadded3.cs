using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookWorm_Dotnet.Migrations
{
    /// <inheritdoc />
    public partial class jsonignoreadded3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_updated",
                table: "cart_details");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ulong>(
                name: "is_updated",
                table: "cart_details",
                type: "bit(1)",
                nullable: false,
                defaultValue: 0ul);
        }
    }
}
