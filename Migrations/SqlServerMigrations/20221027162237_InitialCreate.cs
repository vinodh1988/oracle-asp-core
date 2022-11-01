using Microsoft.EntityFrameworkCore.Migrations;

namespace OracleAPI.Migrations.SqlServerMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HR");

            migrationBuilder.CreateTable(
                name: "PEOPLE",
                schema: "HR",
                columns: table => new
                {
                    sno = table.Column<short>(type: "NUMBER(5)", nullable: false),
                    name = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    city = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_sno", x => x.sno);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PEOPLE",
                schema: "HR");
        }
    }
}
