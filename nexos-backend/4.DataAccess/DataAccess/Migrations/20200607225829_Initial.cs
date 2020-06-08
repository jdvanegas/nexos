using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "nexos");

            migrationBuilder.CreateTable(
                name: "Hospital",
                schema: "nexos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                schema: "nexos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    SecurityNumber = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                schema: "nexos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CredentialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_Hospital_HospitalId",
                        column: x => x.HospitalId,
                        principalSchema: "nexos",
                        principalTable: "Hospital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorPatient",
                schema: "nexos",
                columns: table => new
                {
                    DoctorId = table.Column<long>(nullable: false),
                    PatientId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPatient", x => new { x.DoctorId, x.PatientId });
                    table.ForeignKey(
                        name: "FK_DoctorPatient_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "nexos",
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorPatient_Patient_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "nexos",
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "nexos",
                table: "Hospital",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Hospital de Kennedy" },
                    { 2L, "Hospital San Juan de Dios" },
                    { 3L, "Hospital Meissen" }
                });

            migrationBuilder.InsertData(
                schema: "nexos",
                table: "Patient",
                columns: new[] { "Id", "LastName", "Name", "Phone", "PostalCode", "SecurityNumber" },
                values: new object[] { 1L, "Morales", "Ariel", "3210987654", "654321", "16220614" });

            migrationBuilder.InsertData(
                schema: "nexos",
                table: "Doctor",
                columns: new[] { "Id", "CredentialNumber", "HospitalId", "LastName", "Name" },
                values: new object[] { 1L, "16220614", 1L, "Morales", "Ariel" });

            migrationBuilder.InsertData(
                schema: "nexos",
                table: "DoctorPatient",
                columns: new[] { "DoctorId", "PatientId" },
                values: new object[] { 1L, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_HospitalId",
                schema: "nexos",
                table: "Doctor",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPatient_PatientId",
                schema: "nexos",
                table: "DoctorPatient",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorPatient",
                schema: "nexos");

            migrationBuilder.DropTable(
                name: "Doctor",
                schema: "nexos");

            migrationBuilder.DropTable(
                name: "Patient",
                schema: "nexos");

            migrationBuilder.DropTable(
                name: "Hospital",
                schema: "nexos");
        }
    }
}
