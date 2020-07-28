using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amos.VTUCORE3._1.Migrations
{
    public partial class updatemodel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Refund_Transactions_AspNetUsers_UserProfileId",
                table: "Refund_Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistory_AspNetUsers_UserProfileId",
                table: "TransactionHistory");

            migrationBuilder.DropIndex(
                name: "IX_TransactionHistory_UserProfileId",
                table: "TransactionHistory");

            migrationBuilder.DropIndex(
                name: "IX_Refund_Transactions_UserProfileId",
                table: "Refund_Transactions");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "TransactionHistory");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Refund_Transactions");

            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionDate",
                table: "TransactionHistory",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TransactionHistory",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StaffUserId",
                table: "Refund_Transactions",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_UserId",
                table: "TransactionHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Refund_Transactions_StaffUserId",
                table: "Refund_Transactions",
                column: "StaffUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Refund_Transactions_AspNetUsers_StaffUserId",
                table: "Refund_Transactions",
                column: "StaffUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistory_AspNetUsers_UserId",
                table: "TransactionHistory",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Refund_Transactions_AspNetUsers_StaffUserId",
                table: "Refund_Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistory_AspNetUsers_UserId",
                table: "TransactionHistory");

            migrationBuilder.DropIndex(
                name: "IX_TransactionHistory_UserId",
                table: "TransactionHistory");

            migrationBuilder.DropIndex(
                name: "IX_Refund_Transactions_StaffUserId",
                table: "Refund_Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionDate",
                table: "TransactionHistory");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TransactionHistory");

            migrationBuilder.AddColumn<string>(
                name: "UserProfileId",
                table: "TransactionHistory",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StaffUserId",
                table: "Refund_Transactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserProfileId",
                table: "Refund_Transactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_UserProfileId",
                table: "TransactionHistory",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Refund_Transactions_UserProfileId",
                table: "Refund_Transactions",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Refund_Transactions_AspNetUsers_UserProfileId",
                table: "Refund_Transactions",
                column: "UserProfileId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistory_AspNetUsers_UserProfileId",
                table: "TransactionHistory",
                column: "UserProfileId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
