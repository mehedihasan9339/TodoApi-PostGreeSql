using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class memberrelation25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItem_MemberInfos_memberinfoid",
                schema: "todo",
                table: "TodoItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoItem",
                schema: "todo",
                table: "TodoItem");

            migrationBuilder.RenameTable(
                name: "TodoItem",
                schema: "todo",
                newName: "TodoItems",
                newSchema: "todo");

            migrationBuilder.RenameIndex(
                name: "IX_TodoItem_memberinfoid",
                schema: "todo",
                table: "TodoItems",
                newName: "IX_TodoItems_memberinfoid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoItems",
                schema: "todo",
                table: "TodoItems",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_MemberInfos_memberinfoid",
                schema: "todo",
                table: "TodoItems",
                column: "memberinfoid",
                principalSchema: "todo",
                principalTable: "MemberInfos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_MemberInfos_memberinfoid",
                schema: "todo",
                table: "TodoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoItems",
                schema: "todo",
                table: "TodoItems");

            migrationBuilder.RenameTable(
                name: "TodoItems",
                schema: "todo",
                newName: "TodoItem",
                newSchema: "todo");

            migrationBuilder.RenameIndex(
                name: "IX_TodoItems_memberinfoid",
                schema: "todo",
                table: "TodoItem",
                newName: "IX_TodoItem_memberinfoid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoItem",
                schema: "todo",
                table: "TodoItem",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItem_MemberInfos_memberinfoid",
                schema: "todo",
                table: "TodoItem",
                column: "memberinfoid",
                principalSchema: "todo",
                principalTable: "MemberInfos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
