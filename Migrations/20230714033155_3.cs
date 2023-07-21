using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace 新しいフォルダー.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "user_info_id",
                table: "user_amount",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "ix_user_amount_user_info_id",
                table: "user_amount",
                column: "user_info_id");

            migrationBuilder.AddForeignKey(
                name: "fk_user_amount_user_info_user_info_id",
                table: "user_amount",
                column: "user_info_id",
                principalTable: "user_info",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_amount_user_info_user_info_id",
                table: "user_amount");

            migrationBuilder.DropIndex(
                name: "ix_user_amount_user_info_id",
                table: "user_amount");

            migrationBuilder.AlterColumn<long>(
                name: "user_info_id",
                table: "user_amount",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
