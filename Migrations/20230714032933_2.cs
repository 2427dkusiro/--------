using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace 新しいフォルダー.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_amounts",
                table: "amounts");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "user_info");

            migrationBuilder.RenameTable(
                name: "amounts",
                newName: "user_amount");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_info",
                table: "user_info",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_amount",
                table: "user_amount",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_user_info",
                table: "user_info");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_amount",
                table: "user_amount");

            migrationBuilder.RenameTable(
                name: "user_info",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "user_amount",
                newName: "amounts");

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_amounts",
                table: "amounts",
                column: "id");
        }
    }
}
