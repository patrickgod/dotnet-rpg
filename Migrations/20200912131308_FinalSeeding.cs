using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_rpg.Migrations
{
    public partial class FinalSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, new byte[] { 76, 113, 67, 63, 173, 141, 47, 228, 23, 179, 116, 32, 48, 135, 183, 214, 102, 188, 82, 78, 163, 180, 235, 104, 189, 199, 123, 71, 213, 183, 38, 181, 114, 166, 95, 186, 249, 88, 36, 30, 254, 253, 162, 83, 138, 77, 89, 26, 212, 236, 138, 138, 10, 151, 48, 21, 112, 93, 37, 184, 38, 5, 206, 97 }, new byte[] { 19, 224, 172, 96, 132, 205, 211, 46, 214, 76, 25, 51, 112, 164, 61, 244, 97, 107, 229, 30, 125, 10, 190, 220, 179, 64, 58, 146, 21, 156, 132, 246, 87, 243, 243, 245, 93, 209, 159, 150, 251, 178, 51, 121, 141, 159, 184, 153, 38, 242, 13, 144, 219, 182, 232, 102, 197, 169, 137, 164, 185, 15, 219, 107, 234, 117, 206, 162, 43, 82, 37, 86, 153, 180, 38, 120, 107, 197, 3, 69, 199, 203, 181, 227, 167, 55, 43, 125, 147, 203, 78, 113, 217, 144, 61, 210, 190, 125, 196, 37, 51, 63, 95, 22, 15, 245, 101, 203, 225, 98, 190, 50, 47, 43, 151, 19, 216, 31, 24, 216, 26, 234, 11, 21, 160, 35, 198, 167 }, "User1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 2, new byte[] { 76, 113, 67, 63, 173, 141, 47, 228, 23, 179, 116, 32, 48, 135, 183, 214, 102, 188, 82, 78, 163, 180, 235, 104, 189, 199, 123, 71, 213, 183, 38, 181, 114, 166, 95, 186, 249, 88, 36, 30, 254, 253, 162, 83, 138, 77, 89, 26, 212, 236, 138, 138, 10, 151, 48, 21, 112, 93, 37, 184, 38, 5, 206, 97 }, new byte[] { 19, 224, 172, 96, 132, 205, 211, 46, 214, 76, 25, 51, 112, 164, 61, 244, 97, 107, 229, 30, 125, 10, 190, 220, 179, 64, 58, 146, 21, 156, 132, 246, 87, 243, 243, 245, 93, 209, 159, 150, 251, 178, 51, 121, 141, 159, 184, 153, 38, 242, 13, 144, 219, 182, 232, 102, 197, 169, 137, 164, 185, 15, 219, 107, 234, 117, 206, 162, 43, 82, 37, 86, 153, 180, 38, 120, 107, 197, 3, 69, 199, 203, 181, 227, 167, 55, 43, 125, 147, 203, 78, 113, 217, 144, 61, 210, 190, 125, 196, 37, 51, 63, 95, 22, 15, 245, 101, 203, 225, 98, 190, 50, 47, 43, 151, 19, 216, 31, 24, 216, 26, 234, 11, 21, 160, 35, 198, 167 }, "User2" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defeats", "Defense", "Fights", "HitPoints", "Intelligence", "Name", "Strength", "UserId", "Victories" },
                values: new object[] { 1, 1, 0, 10, 0, 100, 10, "Frodo", 15, 1, 0 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defeats", "Defense", "Fights", "HitPoints", "Intelligence", "Name", "Strength", "UserId", "Victories" },
                values: new object[] { 2, 2, 0, 5, 0, 100, 20, "Raistlin", 5, 2, 0 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharacterId", "SkillId" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterId", "Damage", "Name" },
                values: new object[] { 1, 1, 20, "The Master Sword" });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterId", "Damage", "Name" },
                values: new object[] { 2, 2, 5, "Crystal Wand" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CharacterSkills",
                keyColumns: new[] { "CharacterId", "SkillId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterSkills",
                keyColumns: new[] { "CharacterId", "SkillId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterSkills",
                keyColumns: new[] { "CharacterId", "SkillId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
