using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFM.Migrations
{
    public partial class AddingSplitsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transaction-splits",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "text", nullable: false),
                    CategoryCode = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction-splits", x => new { x.TransactionId, x.CategoryCode });
                    table.ForeignKey(
                        name: "FK_transaction-splits_categories_CategoryCode",
                        column: x => x.CategoryCode,
                        principalTable: "categories",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transaction-splits_transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transaction-splits_CategoryCode",
                table: "transaction-splits",
                column: "CategoryCode");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_transactions_categories_catCode",
            //    table: "transactions",
            //    column: "catCode",
            //    principalTable: "categories",
            //    principalColumn: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_categories_catCode",
                table: "transactions");

            migrationBuilder.DropTable(
                name: "transaction-splits");
        }
    }
}
