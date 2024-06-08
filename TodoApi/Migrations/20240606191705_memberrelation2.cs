using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class memberrelation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_MemberInfos_MemberInfoId",
                table: "TodoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoItems",
                table: "TodoItems");

            migrationBuilder.EnsureSchema(
                name: "todo");

            migrationBuilder.RenameTable(
                name: "MemberInfos",
                newName: "MemberInfos",
                newSchema: "todo");

            migrationBuilder.RenameTable(
                name: "TodoItems",
                newName: "TodoItem",
                newSchema: "todo");

            migrationBuilder.RenameColumn(
                name: "Phone",
                schema: "todo",
                table: "MemberInfos",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "todo",
                table: "MemberInfos",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                schema: "todo",
                table: "MemberInfos",
                newName: "dateofbirth");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "todo",
                table: "MemberInfos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "todo",
                table: "TodoItem",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "MemberInfoId",
                schema: "todo",
                table: "TodoItem",
                newName: "memberinfoid");

            migrationBuilder.RenameColumn(
                name: "IsComplete",
                schema: "todo",
                table: "TodoItem",
                newName: "iscomplete");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "todo",
                table: "TodoItem",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_TodoItems_MemberInfoId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "MemberInfos",
                schema: "todo",
                newName: "MemberInfos");

            migrationBuilder.RenameTable(
                name: "TodoItem",
                schema: "todo",
                newName: "TodoItems");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "MemberInfos",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "MemberInfos",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "dateofbirth",
                table: "MemberInfos",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "MemberInfos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "TodoItems",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "memberinfoid",
                table: "TodoItems",
                newName: "MemberInfoId");

            migrationBuilder.RenameColumn(
                name: "iscomplete",
                table: "TodoItems",
                newName: "IsComplete");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TodoItems",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_TodoItem_memberinfoid",
                table: "TodoItems",
                newName: "IX_TodoItems_MemberInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoItems",
                table: "TodoItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_MemberInfos_MemberInfoId",
                table: "TodoItems",
                column: "MemberInfoId",
                principalTable: "MemberInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
