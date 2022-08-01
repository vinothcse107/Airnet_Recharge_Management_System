using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airnet_Backend.Migrations
{
      public partial class hi : Migration
      {
            protected override void Up(MigrationBuilder migrationBuilder)
            {
                  migrationBuilder.CreateTable(
                      name: "Plans",
                      columns: table => new
                      {
                            PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                            PlanType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                            PlanName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                            PlanValidity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                            PlanDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                            PlanPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                            PlanOffers = table.Column<string>(type: "nvarchar(max)", nullable: true)
                      },
                      constraints: table =>
                      {
                            table.PrimaryKey("PK_Plans", x => x.PlanId);
                      });

                  migrationBuilder.CreateTable(
                      name: "Users",
                      columns: table => new
                      {
                            Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                            Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                            Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                            MobileNumber = table.Column<long>(type: "bigint", nullable: true),
                            UserRole = table.Column<string>(type: "nvarchar(max)", nullable: true)
                      },
                      constraints: table =>
                      {
                            table.PrimaryKey("PK_Users", x => x.Username);
                      });

                  migrationBuilder.CreateTable(
                      name: "Recharges",
                      columns: table => new
                      {
                            RechargeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                            UserName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                            Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                            Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                            Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                            PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                      },
                      constraints: table =>
                      {
                            table.PrimaryKey("PK_Recharges", x => x.RechargeId);
                            table.ForeignKey(
                          name: "FK_Recharges_Plans_PlanId",
                          column: x => x.PlanId,
                          principalTable: "Plans",
                          principalColumn: "PlanId",
                          onDelete: ReferentialAction.Cascade);
                            table.ForeignKey(
                          name: "FK_Recharges_Users_UserName",
                          column: x => x.UserName,
                          principalTable: "Users",
                          principalColumn: "Username",
                          onDelete: ReferentialAction.Restrict);
                      });

                  migrationBuilder.CreateTable(
                      name: "Reviews",
                      columns: table => new
                      {
                            ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                            Username = table.Column<string>(type: "nvarchar(450)", nullable: true),
                            PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                            ReviewContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                            ReviewRating = table.Column<string>(type: "nvarchar(max)", nullable: true)
                      },
                      constraints: table =>
                      {
                            table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                            table.ForeignKey(
                          name: "FK_Reviews_Plans_PlanId",
                          column: x => x.PlanId,
                          principalTable: "Plans",
                          principalColumn: "PlanId",
                          onDelete: ReferentialAction.Cascade);
                            table.ForeignKey(
                          name: "FK_Reviews_Recharges_ReviewId",
                          column: x => x.ReviewId,
                          principalTable: "Recharges",
                          principalColumn: "RechargeId",
                          onDelete: ReferentialAction.NoAction);
                            table.ForeignKey(
                          name: "FK_Reviews_Users_Username",
                          column: x => x.Username,
                          principalTable: "Users",
                          principalColumn: "Username",
                          onDelete: ReferentialAction.Restrict);
                      });

                  migrationBuilder.CreateIndex(
                      name: "IX_Recharges_PlanId",
                      table: "Recharges",
                      column: "PlanId");

                  migrationBuilder.CreateIndex(
                      name: "IX_Recharges_UserName",
                      table: "Recharges",
                      column: "UserName");

                  migrationBuilder.CreateIndex(
                      name: "IX_Reviews_PlanId",
                      table: "Reviews",
                      column: "PlanId");

                  migrationBuilder.CreateIndex(
                      name: "IX_Reviews_Username",
                      table: "Reviews",
                      column: "Username");
            }

            protected override void Down(MigrationBuilder migrationBuilder)
            {
                  migrationBuilder.DropTable(
                      name: "Reviews");

                  migrationBuilder.DropTable(
                      name: "Recharges");

                  migrationBuilder.DropTable(
                      name: "Plans");

                  migrationBuilder.DropTable(
                      name: "Users");
            }
      }
}
