using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Category.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    parent_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    avatar = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, defaultValue: ""),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    priority = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    valid_flg = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    del_flg = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    created_by = table.Column<string>(type: "text", nullable: false, defaultValue: ""),
                    last_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    last_modified_by = table.Column<string>(type: "text", nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
