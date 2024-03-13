using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConferenceAttendees.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReferralSources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferralSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ReferralSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendees_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendees_JobRoles_JobRoleId",
                        column: x => x.JobRoleId,
                        principalTable: "JobRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendees_ReferralSources_ReferralSourceId",
                        column: x => x.ReferralSourceId,
                        principalTable: "ReferralSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b66910d4-f789-473d-b997-16efabdcb5d3"), "Female" },
                    { new Guid("c2a3bf8d-4340-4adc-85a3-a0be30d572f2"), "Male" }
                });

            migrationBuilder.InsertData(
                table: "JobRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0713d4d5-5560-4d36-b1ec-5bca0f52268a"), "Sales" },
                    { new Guid("14c05cd3-7064-46b4-9d61-d003942d4c05"), "Operations" },
                    { new Guid("825e19cc-89e1-4f7e-86a7-776efe3a403e"), "Supervisor" },
                    { new Guid("e42f1629-367f-42b6-b75c-36a391f7816e"), "Manager" }
                });

            migrationBuilder.InsertData(
                table: "ReferralSources",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1dbdadbb-3175-44bb-a3aa-fc95b6bfd44f"), "Newspaper Article" },
                    { new Guid("2930ec25-e259-49d6-be38-930b0c5a07dc"), "Internet Advertisement" },
                    { new Guid("5295ecec-bb38-48f0-b6ab-f51ad57d38bd"), "Television" },
                    { new Guid("f2118fcd-7413-42f7-b4cc-a2f6089145c4"), "Other" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_GenderId",
                table: "Attendees",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_JobRoleId",
                table: "Attendees",
                column: "JobRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_ReferralSourceId",
                table: "Attendees",
                column: "ReferralSourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "JobRoles");

            migrationBuilder.DropTable(
                name: "ReferralSources");
        }
    }
}
