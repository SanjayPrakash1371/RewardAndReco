using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RR.DataBaseConnect.Migrations
{
    /// <inheritdoc />
    public partial class NomineeVoteChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtherRewards_OtherRewardResults_IdOfResult",
                table: "OtherRewards");

            migrationBuilder.DropIndex(
                name: "IX_OtherRewards_IdOfResult",
                table: "OtherRewards");

            migrationBuilder.DropColumn(
                name: "IdOfResult",
                table: "OtherRewards");

            migrationBuilder.AddColumn<int>(
                name: "IfOfNomination",
                table: "OtherRewardResults",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoterId",
                table: "OtherRewardResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_OtherRewardResults_IfOfNomination",
                table: "OtherRewardResults",
                column: "IfOfNomination");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherRewardResults_OtherRewards_IfOfNomination",
                table: "OtherRewardResults",
                column: "IfOfNomination",
                principalTable: "OtherRewards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtherRewardResults_OtherRewards_IfOfNomination",
                table: "OtherRewardResults");

            migrationBuilder.DropIndex(
                name: "IX_OtherRewardResults_IfOfNomination",
                table: "OtherRewardResults");

            migrationBuilder.DropColumn(
                name: "IfOfNomination",
                table: "OtherRewardResults");

            migrationBuilder.DropColumn(
                name: "VoterId",
                table: "OtherRewardResults");

            migrationBuilder.AddColumn<int>(
                name: "IdOfResult",
                table: "OtherRewards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OtherRewards_IdOfResult",
                table: "OtherRewards",
                column: "IdOfResult");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherRewards_OtherRewardResults_IdOfResult",
                table: "OtherRewards",
                column: "IdOfResult",
                principalTable: "OtherRewardResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
