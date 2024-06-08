using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class memberrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MemberInfoId",
                table: "TodoItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "MemberInfos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberInfos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_MemberInfoId",
                table: "TodoItems",
                column: "MemberInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_MemberInfos_MemberInfoId",
                table: "TodoItems",
                column: "MemberInfoId",
                principalTable: "MemberInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_MemberInfos_MemberInfoId",
                table: "TodoItems");

            migrationBuilder.DropTable(
                name: "MemberInfos");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_MemberInfoId",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "MemberInfoId",
                table: "TodoItems");
        }
    }
}
