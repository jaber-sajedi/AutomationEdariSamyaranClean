using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomationEdariSamyaran.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addFewtablr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchivesMoein_ArchivesKoll_IdKoll",
                table: "ArchivesMoein");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchivesTafzilli_ArchivesKoll_IdKoll",
                table: "ArchivesTafzilli");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchivesTafzilli_ArchivesMoein_IdMoein",
                table: "ArchivesTafzilli");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArchivesTafzilli",
                table: "ArchivesTafzilli");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArchivesMoein",
                table: "ArchivesMoein");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArchivesKoll",
                table: "ArchivesKoll");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationSetting",
                table: "ApplicationSetting");

            migrationBuilder.RenameTable(
                name: "ArchivesTafzilli",
                newName: "ArchivesTafzillis");

            migrationBuilder.RenameTable(
                name: "ArchivesMoein",
                newName: "ArchivesMoeins");

            migrationBuilder.RenameTable(
                name: "ArchivesKoll",
                newName: "ArchivesKolls");

            migrationBuilder.RenameTable(
                name: "ApplicationSetting",
                newName: "ApplicationSettings");

            migrationBuilder.RenameIndex(
                name: "IX_ArchivesTafzilli_IdMoein",
                table: "ArchivesTafzillis",
                newName: "IX_ArchivesTafzillis_IdMoein");

            migrationBuilder.RenameIndex(
                name: "IX_ArchivesTafzilli_IdKoll",
                table: "ArchivesTafzillis",
                newName: "IX_ArchivesTafzillis_IdKoll");

            migrationBuilder.RenameIndex(
                name: "IX_ArchivesMoein_IdKoll",
                table: "ArchivesMoeins",
                newName: "IX_ArchivesMoeins_IdKoll");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArchivesTafzillis",
                table: "ArchivesTafzillis",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArchivesMoeins",
                table: "ArchivesMoeins",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArchivesKolls",
                table: "ArchivesKolls",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationSettings",
                table: "ApplicationSettings",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Draftletters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lettersTittel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachedFile = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draftletters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Greatadvices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Writername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Advice = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Greatadvices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LetterRecepiants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecepiantName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterRecepiants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LetterSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterSubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationalRanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganRank = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationalRanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSeller = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdressSeller = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TellSeller = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    MobileSeller = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Letters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LetterNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfView = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LetterType = table.Column<int>(type: "int", nullable: false),
                    IdLetterSubject = table.Column<int>(type: "int", nullable: false),
                    IdSendLetter = table.Column<int>(type: "int", nullable: false),
                    IdReceiveLetters = table.Column<int>(type: "int", nullable: false),
                    AttachedFile = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemporaryDeletion = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Letters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Letters_LetterRecepiants_IdReceiveLetters",
                        column: x => x.IdReceiveLetters,
                        principalTable: "LetterRecepiants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationalCharts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrgan_Rank = table.Column<int>(type: "int", nullable: false),
                    HasAFather = table.Column<bool>(type: "bit", nullable: false),
                    IdFather = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationalCharts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationalCharts_OrganizationalCharts_IdFather",
                        column: x => x.IdFather,
                        principalTable: "OrganizationalCharts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationalCharts_OrganizationalRanks_IdOrgan_Rank",
                        column: x => x.IdOrgan_Rank,
                        principalTable: "OrganizationalRanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Personals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalCode = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    FristName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumShenasname = table.Column<int>(type: "int", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalCode = table.Column<double>(type: "float", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdState = table.Column<int>(type: "int", nullable: true),
                    IdCity = table.Column<int>(type: "int", nullable: true),
                    IdDegreeEducation = table.Column<int>(type: "int", nullable: false),
                    FieldofStudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUnit = table.Column<int>(type: "int", nullable: false),
                    IdOrganRanks = table.Column<int>(type: "int", nullable: false),
                    ContractType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    NumberOfChildren = table.Column<int>(type: "int", nullable: false),
                    InsuranceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postalcode = table.Column<int>(type: "int", nullable: false),
                    StartJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersenelActive = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    TemporaryDeletion = table.Column<bool>(type: "bit", nullable: false),
                    OrganizationalRankId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personals_Cities_IdCity",
                        column: x => x.IdCity,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personals_OrganizationalRanks_IdOrganRanks",
                        column: x => x.IdOrganRanks,
                        principalTable: "OrganizationalRanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personals_OrganizationalRanks_OrganizationalRankId",
                        column: x => x.OrganizationalRankId,
                        principalTable: "OrganizationalRanks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Personals_States_IdState",
                        column: x => x.IdState,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personals_Units_IdUnit",
                        column: x => x.IdUnit,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPersonal = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Localphone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Localphone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Workphone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Workphone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Homephone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Homephone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkplaceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressWorkplace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressHome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneBooks_Personals_IdPersonal",
                        column: x => x.IdPersonal,
                        principalTable: "Personals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPersonal = table.Column<int>(type: "int", nullable: false),
                    UserSettings = table.Column<bool>(type: "bit", nullable: false),
                    UnitsInformation = table.Column<bool>(type: "bit", nullable: false),
                    CompanyInfo = table.Column<bool>(type: "bit", nullable: false),
                    BackupRoot = table.Column<bool>(type: "bit", nullable: false),
                    BackupRestore = table.Column<bool>(type: "bit", nullable: false),
                    OrganizationalRank = table.Column<bool>(type: "bit", nullable: false),
                    OrganizationalChart = table.Column<bool>(type: "bit", nullable: false),
                    Personallist = table.Column<bool>(type: "bit", nullable: false),
                    PersonalReport = table.Column<bool>(type: "bit", nullable: false),
                    RequestLeavemanagement = table.Column<bool>(type: "bit", nullable: false),
                    RequestList = table.Column<bool>(type: "bit", nullable: false),
                    letterSendList = table.Column<bool>(type: "bit", nullable: false),
                    lettersDraft = table.Column<bool>(type: "bit", nullable: false),
                    letterSubject = table.Column<bool>(type: "bit", nullable: false),
                    KollArchives = table.Column<bool>(type: "bit", nullable: false),
                    MoeinArchives = table.Column<bool>(type: "bit", nullable: false),
                    Archives = table.Column<bool>(type: "bit", nullable: false),
                    Seller = table.Column<bool>(type: "bit", nullable: false),
                    UnitsMeasurement = table.Column<bool>(type: "bit", nullable: false),
                    KolGoods = table.Column<bool>(type: "bit", nullable: false),
                    MoeinGoods = table.Column<bool>(type: "bit", nullable: false),
                    Goods = table.Column<bool>(type: "bit", nullable: false),
                    GoodsImportation = table.Column<bool>(type: "bit", nullable: false),
                    GoodsRequests = table.Column<bool>(type: "bit", nullable: false),
                    GoodsDeparture = table.Column<bool>(type: "bit", nullable: false),
                    GoodsImpReport = table.Column<bool>(type: "bit", nullable: false),
                    GoodsCircReport = table.Column<bool>(type: "bit", nullable: false),
                    ProductRequestMessage = table.Column<bool>(type: "bit", nullable: false),
                    RequestLeave = table.Column<bool>(type: "bit", nullable: false),
                    RequestConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    GoodsRequest = table.Column<bool>(type: "bit", nullable: false),
                    Publicmessages = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserPermissions_Personals_IdPersonal",
                        column: x => x.IdPersonal,
                        principalTable: "Personals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Letters_IdReceiveLetters",
                table: "Letters",
                column: "IdReceiveLetters");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationalCharts_IdFather",
                table: "OrganizationalCharts",
                column: "IdFather");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationalCharts_IdOrgan_Rank",
                table: "OrganizationalCharts",
                column: "IdOrgan_Rank");

            migrationBuilder.CreateIndex(
                name: "IX_Personals_IdCity",
                table: "Personals",
                column: "IdCity");

            migrationBuilder.CreateIndex(
                name: "IX_Personals_IdOrganRanks",
                table: "Personals",
                column: "IdOrganRanks");

            migrationBuilder.CreateIndex(
                name: "IX_Personals_IdState",
                table: "Personals",
                column: "IdState");

            migrationBuilder.CreateIndex(
                name: "IX_Personals_IdUnit",
                table: "Personals",
                column: "IdUnit");

            migrationBuilder.CreateIndex(
                name: "IX_Personals_OrganizationalRankId",
                table: "Personals",
                column: "OrganizationalRankId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneBooks_IdPersonal",
                table: "PhoneBooks",
                column: "IdPersonal");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_IdPersonal",
                table: "UserPermissions",
                column: "IdPersonal");

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivesMoeins_ArchivesKolls_IdKoll",
                table: "ArchivesMoeins",
                column: "IdKoll",
                principalTable: "ArchivesKolls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivesTafzillis_ArchivesKolls_IdKoll",
                table: "ArchivesTafzillis",
                column: "IdKoll",
                principalTable: "ArchivesKolls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivesTafzillis_ArchivesMoeins_IdMoein",
                table: "ArchivesTafzillis",
                column: "IdMoein",
                principalTable: "ArchivesMoeins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchivesMoeins_ArchivesKolls_IdKoll",
                table: "ArchivesMoeins");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchivesTafzillis_ArchivesKolls_IdKoll",
                table: "ArchivesTafzillis");

            migrationBuilder.DropForeignKey(
                name: "FK_ArchivesTafzillis_ArchivesMoeins_IdMoein",
                table: "ArchivesTafzillis");

            migrationBuilder.DropTable(
                name: "Draftletters");

            migrationBuilder.DropTable(
                name: "Greatadvices");

            migrationBuilder.DropTable(
                name: "Letters");

            migrationBuilder.DropTable(
                name: "LetterSubjects");

            migrationBuilder.DropTable(
                name: "OrganizationalCharts");

            migrationBuilder.DropTable(
                name: "PhoneBooks");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropTable(
                name: "LetterRecepiants");

            migrationBuilder.DropTable(
                name: "Personals");

            migrationBuilder.DropTable(
                name: "OrganizationalRanks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArchivesTafzillis",
                table: "ArchivesTafzillis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArchivesMoeins",
                table: "ArchivesMoeins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArchivesKolls",
                table: "ArchivesKolls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationSettings",
                table: "ApplicationSettings");

            migrationBuilder.RenameTable(
                name: "ArchivesTafzillis",
                newName: "ArchivesTafzilli");

            migrationBuilder.RenameTable(
                name: "ArchivesMoeins",
                newName: "ArchivesMoein");

            migrationBuilder.RenameTable(
                name: "ArchivesKolls",
                newName: "ArchivesKoll");

            migrationBuilder.RenameTable(
                name: "ApplicationSettings",
                newName: "ApplicationSetting");

            migrationBuilder.RenameIndex(
                name: "IX_ArchivesTafzillis_IdMoein",
                table: "ArchivesTafzilli",
                newName: "IX_ArchivesTafzilli_IdMoein");

            migrationBuilder.RenameIndex(
                name: "IX_ArchivesTafzillis_IdKoll",
                table: "ArchivesTafzilli",
                newName: "IX_ArchivesTafzilli_IdKoll");

            migrationBuilder.RenameIndex(
                name: "IX_ArchivesMoeins_IdKoll",
                table: "ArchivesMoein",
                newName: "IX_ArchivesMoein_IdKoll");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArchivesTafzilli",
                table: "ArchivesTafzilli",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArchivesMoein",
                table: "ArchivesMoein",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArchivesKoll",
                table: "ArchivesKoll",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationSetting",
                table: "ApplicationSetting",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivesMoein_ArchivesKoll_IdKoll",
                table: "ArchivesMoein",
                column: "IdKoll",
                principalTable: "ArchivesKoll",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivesTafzilli_ArchivesKoll_IdKoll",
                table: "ArchivesTafzilli",
                column: "IdKoll",
                principalTable: "ArchivesKoll",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivesTafzilli_ArchivesMoein_IdMoein",
                table: "ArchivesTafzilli",
                column: "IdMoein",
                principalTable: "ArchivesMoein",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
