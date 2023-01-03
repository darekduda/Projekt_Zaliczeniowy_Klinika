using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Klinika.Data.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    IdAdresu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Miejscowosc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KodPocztowy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ulica = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumerDomu = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    NumerMieszkania = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.IdAdresu);
                });

            migrationBuilder.CreateTable(
                name: "GeneralAdress",
                columns: table => new
                {
                    IdAdresu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Miasto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ulica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodPocztowy = table.Column<string>(type: "nvarchar(max)", maxLength: 7, nullable: false),
                    Numer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PozycjaWyswietlania = table.Column<int>(type: "int", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralAdress", x => x.IdAdresu);
                });

            migrationBuilder.CreateTable(
                name: "GeneralContact",
                columns: table => new
                {
                    IdKontaktu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TytułKontakt = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NumerTelefonu = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    NazwaKontaktu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PozycjaWyswietlania = table.Column<int>(type: "int", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralContact", x => x.IdKontaktu);
                });

            migrationBuilder.CreateTable(
                name: "GeneralGallery",
                columns: table => new
                {
                    IdGeneralGallery = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    imgPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralGallery", x => x.IdGeneralGallery);
                });

            migrationBuilder.CreateTable(
                name: "GeneralParameter",
                columns: table => new
                {
                    IdGeneralParametr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralParameter", x => x.IdGeneralParametr);
                });

            migrationBuilder.CreateTable(
                name: "OpeningHours",
                columns: table => new
                {
                    IdGodzinyOtwarcia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dzien = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GodzinaOtwarciaOd = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    GodzinaOtwarciaDo = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    PozycjaWyswietlania = table.Column<int>(type: "int", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningHours", x => x.IdGodzinyOtwarcia);
                });

            migrationBuilder.CreateTable(
                name: "Plec",
                columns: table => new
                {
                    IdPlec = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CzyAktywna = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plec", x => x.IdPlec);
                });

            migrationBuilder.CreateTable(
                name: "PoradniaTyp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoradniaTyp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoradniaZabieg",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPoradnia = table.Column<int>(type: "int", nullable: false),
                    IdZabieg = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoradniaZabieg", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specjalizacja",
                columns: table => new
                {
                    IdSpecjalizacja = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CzyAktywna = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specjalizacja", x => x.IdSpecjalizacja);
                });

            migrationBuilder.CreateTable(
                name: "TytulNaukowy",
                columns: table => new
                {
                    IdTytułNaukowy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CzyAktywna = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TytulNaukowy", x => x.IdTytułNaukowy);
                });

            migrationBuilder.CreateTable(
                name: "Zabieg",
                columns: table => new
                {
                    IdZabiegu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cena = table.Column<double>(type: "float", nullable: false),
                    Przeciwwskazania = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Przygotowania = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CzasTrwania = table.Column<TimeSpan>(type: "time", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zabieg", x => x.IdZabiegu);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownik",
                columns: table => new
                {
                    IdUzytkownika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumerPESEL = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    PlecId = table.Column<int>(type: "int", nullable: false),
                    AdresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownik", x => x.IdUzytkownika);
                    table.ForeignKey(
                        name: "FK_Uzytkownik_Adres_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adres",
                        principalColumn: "IdAdresu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uzytkownik_Plec_PlecId",
                        column: x => x.PlecId,
                        principalTable: "Plec",
                        principalColumn: "IdPlec",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Poradnia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CzyAktywna = table.Column<bool>(type: "bit", nullable: false),
                    PoradniaTypId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poradnia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poradnia_PoradniaTyp_PoradniaTypId",
                        column: x => x.PoradniaTypId,
                        principalTable: "PoradniaTyp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lekarz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    PlecId = table.Column<int>(type: "int", nullable: false),
                    AdresId = table.Column<int>(type: "int", nullable: false),
                    TytulNaukowyId = table.Column<int>(type: "int", nullable: false),
                    SpecjalizacjaId = table.Column<int>(type: "int", nullable: false),
                    PoradniaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lekarz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lekarz_Adres_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adres",
                        principalColumn: "IdAdresu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lekarz_Plec_PlecId",
                        column: x => x.PlecId,
                        principalTable: "Plec",
                        principalColumn: "IdPlec",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lekarz_Poradnia_PoradniaId",
                        column: x => x.PoradniaId,
                        principalTable: "Poradnia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lekarz_Specjalizacja_SpecjalizacjaId",
                        column: x => x.SpecjalizacjaId,
                        principalTable: "Specjalizacja",
                        principalColumn: "IdSpecjalizacja",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lekarz_TytulNaukowy_TytulNaukowyId",
                        column: x => x.TytulNaukowyId,
                        principalTable: "TytulNaukowy",
                        principalColumn: "IdTytułNaukowy",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wizyty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacjentId = table.Column<int>(type: "int", nullable: true),
                    LekarzId = table.Column<int>(type: "int", nullable: true),
                    ZabiegId = table.Column<int>(type: "int", nullable: true),
                    PoradniaId = table.Column<int>(type: "int", nullable: true),
                    DataWizyty = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UzytkownikIdUzytkownika = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wizyty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wizyty_Lekarz_LekarzId",
                        column: x => x.LekarzId,
                        principalTable: "Lekarz",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Wizyty_Poradnia_PoradniaId",
                        column: x => x.PoradniaId,
                        principalTable: "Poradnia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Wizyty_Uzytkownik_UzytkownikIdUzytkownika",
                        column: x => x.UzytkownikIdUzytkownika,
                        principalTable: "Uzytkownik",
                        principalColumn: "IdUzytkownika");
                    table.ForeignKey(
                        name: "FK_Wizyty_Zabieg_ZabiegId",
                        column: x => x.ZabiegId,
                        principalTable: "Zabieg",
                        principalColumn: "IdZabiegu");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lekarz_AdresId",
                table: "Lekarz",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Lekarz_PlecId",
                table: "Lekarz",
                column: "PlecId");

            migrationBuilder.CreateIndex(
                name: "IX_Lekarz_PoradniaId",
                table: "Lekarz",
                column: "PoradniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lekarz_SpecjalizacjaId",
                table: "Lekarz",
                column: "SpecjalizacjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lekarz_TytulNaukowyId",
                table: "Lekarz",
                column: "TytulNaukowyId");

            migrationBuilder.CreateIndex(
                name: "IX_Poradnia_PoradniaTypId",
                table: "Poradnia",
                column: "PoradniaTypId");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownik_AdresId",
                table: "Uzytkownik",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownik_PlecId",
                table: "Uzytkownik",
                column: "PlecId");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_LekarzId",
                table: "Wizyty",
                column: "LekarzId");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_PoradniaId",
                table: "Wizyty",
                column: "PoradniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_UzytkownikIdUzytkownika",
                table: "Wizyty",
                column: "UzytkownikIdUzytkownika");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_ZabiegId",
                table: "Wizyty",
                column: "ZabiegId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralAdress");

            migrationBuilder.DropTable(
                name: "GeneralContact");

            migrationBuilder.DropTable(
                name: "GeneralGallery");

            migrationBuilder.DropTable(
                name: "GeneralParameter");

            migrationBuilder.DropTable(
                name: "OpeningHours");

            migrationBuilder.DropTable(
                name: "PoradniaZabieg");

            migrationBuilder.DropTable(
                name: "Wizyty");

            migrationBuilder.DropTable(
                name: "Lekarz");

            migrationBuilder.DropTable(
                name: "Uzytkownik");

            migrationBuilder.DropTable(
                name: "Zabieg");

            migrationBuilder.DropTable(
                name: "Poradnia");

            migrationBuilder.DropTable(
                name: "Specjalizacja");

            migrationBuilder.DropTable(
                name: "TytulNaukowy");

            migrationBuilder.DropTable(
                name: "Adres");

            migrationBuilder.DropTable(
                name: "Plec");

            migrationBuilder.DropTable(
                name: "PoradniaTyp");
        }
    }
}
