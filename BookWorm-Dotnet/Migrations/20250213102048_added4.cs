using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookWorm_Dotnet.Migrations
{
    /// <inheritdoc />
    public partial class added4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "is_rentable",
                table: "product_master",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(ulong),
                oldType: "bit(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                table: "cart_master",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "is_rented",
                table: "cart_details",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit(1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<ulong>(
                name: "is_rentable",
                table: "product_master",
                type: "bit(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<ulong>(
                name: "is_active",
                table: "cart_master",
                type: "bit(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<ulong>(
                name: "is_rented",
                table: "cart_details",
                type: "bit(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }
    }
}
