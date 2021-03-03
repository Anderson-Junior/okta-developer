using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FamilyTreeBuilder.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:btree_gin", ",,")
                .Annotation("Npgsql:PostgresExtension:btree_gist", ",,")
                .Annotation("Npgsql:PostgresExtension:citext", ",,")
                .Annotation("Npgsql:PostgresExtension:cube", ",,")
                .Annotation("Npgsql:PostgresExtension:dblink", ",,")
                .Annotation("Npgsql:PostgresExtension:dict_int", ",,")
                .Annotation("Npgsql:PostgresExtension:dict_xsyn", ",,")
                .Annotation("Npgsql:PostgresExtension:earthdistance", ",,")
                .Annotation("Npgsql:PostgresExtension:fuzzystrmatch", ",,")
                .Annotation("Npgsql:PostgresExtension:hstore", ",,")
                .Annotation("Npgsql:PostgresExtension:intarray", ",,")
                .Annotation("Npgsql:PostgresExtension:ltree", ",,")
                .Annotation("Npgsql:PostgresExtension:pg_stat_statements", ",,")
                .Annotation("Npgsql:PostgresExtension:pg_trgm", ",,")
                .Annotation("Npgsql:PostgresExtension:pgcrypto", ",,")
                .Annotation("Npgsql:PostgresExtension:pgrowlocks", ",,")
                .Annotation("Npgsql:PostgresExtension:pgstattuple", ",,")
                .Annotation("Npgsql:PostgresExtension:tablefunc", ",,")
                .Annotation("Npgsql:PostgresExtension:unaccent", ",,")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .Annotation("Npgsql:PostgresExtension:xml2", ",,");

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying", nullable: true),
                    last_name = table.Column<string>(type: "character varying", nullable: true),
                    sexo = table.Column<string>(type: "character varying", nullable: true),
                    birth_date = table.Column<DateTime>(type: "date", nullable: true),
                    death_date = table.Column<DateTime>(type: "date", nullable: true),
                    father = table.Column<int>(nullable: true),
                    mother = table.Column<int>(nullable: true),
                    data_owner_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.id);
                    table.ForeignKey(
                        name: "person_father_fkey",
                        column: x => x.father,
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "person_mother_fkey",
                        column: x => x.mother,
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_person_father",
                table: "person",
                column: "father");

            migrationBuilder.CreateIndex(
                name: "IX_person_mother",
                table: "person",
                column: "mother");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "person");
        }
    }
}
