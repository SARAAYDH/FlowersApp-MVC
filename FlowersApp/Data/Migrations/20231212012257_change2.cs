using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowersApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class change2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlowerPicture",
                table: "Flowers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FlowerPicture",
                table: "Flowers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
