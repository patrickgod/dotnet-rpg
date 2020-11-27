using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_rpg.Migrations
{
    public partial class EFCore5ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Damage = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Role = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "Player")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    HitPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    Strength = table.Column<int>(type: "INTEGER", nullable: false),
                    Defense = table.Column<int>(type: "INTEGER", nullable: false),
                    Intelligence = table.Column<int>(type: "INTEGER", nullable: false),
                    Class = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fights = table.Column<int>(type: "INTEGER", nullable: false),
                    Victories = table.Column<int>(type: "INTEGER", nullable: false),
                    Defeats = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSkill",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "INTEGER", nullable: false),
                    SkillsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSkill", x => new { x.CharactersId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_CharacterSkill_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Damage = table.Column<int>(type: "INTEGER", nullable: false),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapons_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 1, 30, "Fireball" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 2, 20, "Frenzy" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Damage", "Name" },
                values: new object[] { 3, 50, "Blizzard" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, new byte[] { 212, 119, 118, 182, 190, 246, 237, 132, 3, 79, 106, 235, 251, 70, 134, 11, 76, 236, 87, 93, 196, 139, 255, 118, 49, 126, 243, 1, 53, 201, 173, 127, 244, 98, 181, 59, 254, 102, 105, 78, 181, 71, 212, 191, 240, 52, 117, 194, 138, 34, 53, 99, 76, 243, 169, 43, 238, 226, 207, 65, 16, 129, 109, 122 }, new byte[] { 39, 13, 100, 61, 173, 117, 172, 15, 92, 246, 105, 141, 103, 14, 40, 58, 196, 49, 101, 14, 177, 226, 141, 108, 220, 91, 41, 94, 130, 175, 142, 37, 57, 197, 1, 58, 74, 97, 64, 169, 162, 98, 91, 128, 131, 18, 106, 199, 130, 249, 44, 227, 29, 17, 218, 205, 29, 162, 1, 234, 38, 252, 41, 208, 18, 77, 229, 10, 192, 244, 26, 163, 130, 188, 187, 194, 66, 62, 223, 199, 1, 224, 235, 68, 159, 199, 236, 14, 184, 187, 24, 172, 52, 56, 2, 134, 181, 63, 134, 171, 217, 71, 252, 213, 6, 22, 235, 240, 16, 67, 23, 247, 13, 207, 132, 157, 204, 226, 137, 15, 4, 16, 90, 6, 20, 90, 196, 47 }, "User1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 2, new byte[] { 212, 119, 118, 182, 190, 246, 237, 132, 3, 79, 106, 235, 251, 70, 134, 11, 76, 236, 87, 93, 196, 139, 255, 118, 49, 126, 243, 1, 53, 201, 173, 127, 244, 98, 181, 59, 254, 102, 105, 78, 181, 71, 212, 191, 240, 52, 117, 194, 138, 34, 53, 99, 76, 243, 169, 43, 238, 226, 207, 65, 16, 129, 109, 122 }, new byte[] { 39, 13, 100, 61, 173, 117, 172, 15, 92, 246, 105, 141, 103, 14, 40, 58, 196, 49, 101, 14, 177, 226, 141, 108, 220, 91, 41, 94, 130, 175, 142, 37, 57, 197, 1, 58, 74, 97, 64, 169, 162, 98, 91, 128, 131, 18, 106, 199, 130, 249, 44, 227, 29, 17, 218, 205, 29, 162, 1, 234, 38, 252, 41, 208, 18, 77, 229, 10, 192, 244, 26, 163, 130, 188, 187, 194, 66, 62, 223, 199, 1, 224, 235, 68, 159, 199, 236, 14, 184, 187, 24, 172, 52, 56, 2, 134, 181, 63, 134, 171, 217, 71, 252, 213, 6, 22, 235, 240, 16, 67, 23, 247, 13, 207, 132, 157, 204, 226, 137, 15, 4, 16, 90, 6, 20, 90, 196, 47 }, "User2" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defeats", "Defense", "Fights", "HitPoints", "Intelligence", "Name", "Strength", "UserId", "Victories" },
                values: new object[] { 1, 1, 0, 10, 0, 100, 10, "Frodo", 15, 1, 0 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defeats", "Defense", "Fights", "HitPoints", "Intelligence", "Name", "Strength", "UserId", "Victories" },
                values: new object[] { 2, 2, 0, 5, 0, 100, 20, "Raistlin", 5, 2, 0 });

            migrationBuilder.InsertData(
                table: "CharacterSkill",
                columns: new[] { "CharactersId", "SkillsId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "CharacterSkill",
                columns: new[] { "CharactersId", "SkillsId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "CharacterSkill",
                columns: new[] { "CharactersId", "SkillsId" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterId", "Damage", "Name" },
                values: new object[] { 1, 1, 20, "The Master Sword" });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterId", "Damage", "Name" },
                values: new object[] { 2, 2, 5, "Crystal Wand" });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UserId",
                table: "Characters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkill_SkillsId",
                table: "CharacterSkill",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_CharacterId",
                table: "Weapons",
                column: "CharacterId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterSkill");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
