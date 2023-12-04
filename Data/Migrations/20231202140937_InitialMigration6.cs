using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectGym_management.Data.Migrations
{
    public partial class InitialMigration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscountedMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountedMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountedMembers_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountedMembers_MembersSubscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "MembersSubscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscountedMembers_DiscountId",
                table: "DiscountedMembers",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountedMembers_SubscriptionId",
                table: "DiscountedMembers",
                column: "SubscriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountedMembers");
        }
    }
}
