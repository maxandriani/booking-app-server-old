using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookingApp.Server.Migrations
{
    public partial class Setup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "payments");

            migrationBuilder.EnsureSchema(
                name: "bookings");

            migrationBuilder.EnsureSchema(
                name: "places");

            migrationBuilder.CreateTable(
                name: "accounts",
                schema: "payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false, comment: "Nome da conta contábil")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "places",
                schema: "places",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false, comment: "Nome do local/casa a reservar")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_places", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                schema: "bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlaceId = table.Column<int>(type: "integer", nullable: false),
                    Start = table.Column<DateOnly>(type: "date", nullable: false),
                    Finish = table.Column<DateOnly>(type: "date", nullable: false),
                    ReservationCode = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "Código de reserva externo"),
                    ReservedTo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "Nome do responsável")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookings_places_PlaceId",
                        column: x => x.PlaceId,
                        principalSchema: "places",
                        principalTable: "places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contact_info",
                schema: "bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookingId = table.Column<int>(type: "integer", nullable: false),
                    Kind = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false, comment: "Tipo de contato relacionado"),
                    Value = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "Dado do contato")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact_info", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contact_info_bookings_BookingId",
                        column: x => x.BookingId,
                        principalSchema: "bookings",
                        principalTable: "bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                schema: "payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlaceId = table.Column<int>(type: "integer", nullable: false, comment: "Imóvel relacionado a transação."),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    BookingId = table.Column<int>(type: "integer", nullable: true, comment: "Se essa transação está vinculada a uma locação."),
                    When = table.Column<DateOnly>(type: "date", nullable: false),
                    ConfirmedAt = table.Column<DateOnly>(type: "date", nullable: true),
                    Amount = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payments_accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "payments",
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_payments_bookings_BookingId",
                        column: x => x.BookingId,
                        principalSchema: "bookings",
                        principalTable: "bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_payments_places_PlaceId",
                        column: x => x.PlaceId,
                        principalSchema: "places",
                        principalTable: "places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "accounts_idx_un_name",
                schema: "payments",
                table: "accounts",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "booking_idx_place_filter",
                schema: "bookings",
                table: "bookings",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "booking_idx_search_by_name",
                schema: "bookings",
                table: "bookings",
                column: "ReservedTo");

            migrationBuilder.CreateIndex(
                name: "booking_idx_searh_by_code",
                schema: "bookings",
                table: "bookings",
                column: "ReservationCode");

            migrationBuilder.CreateIndex(
                name: "booking_idx_time_search",
                schema: "bookings",
                table: "bookings",
                columns: new[] { "Start", "Finish" });

            migrationBuilder.CreateIndex(
                name: "IX_contact_info_BookingId",
                schema: "bookings",
                table: "contact_info",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "payments_idx_search_by_account",
                schema: "payments",
                table: "payments",
                columns: new[] { "AccountId", "When" });

            migrationBuilder.CreateIndex(
                name: "payments_idx_search_by_booking",
                schema: "payments",
                table: "payments",
                columns: new[] { "BookingId", "When" });

            migrationBuilder.CreateIndex(
                name: "payments_idx_search_by_place",
                schema: "payments",
                table: "payments",
                columns: new[] { "PlaceId", "When" });

            migrationBuilder.CreateIndex(
                name: "places_idx_un_autocomplete",
                schema: "places",
                table: "places",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contact_info",
                schema: "bookings");

            migrationBuilder.DropTable(
                name: "payments",
                schema: "payments");

            migrationBuilder.DropTable(
                name: "accounts",
                schema: "payments");

            migrationBuilder.DropTable(
                name: "bookings",
                schema: "bookings");

            migrationBuilder.DropTable(
                name: "places",
                schema: "places");
        }
    }
}
