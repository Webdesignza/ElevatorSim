using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElevatorSim.Migrations
{
    /// <inheritdoc />
    public partial class webdes28_ElevatorSimDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    entBuildingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.entBuildingId);
                });

            migrationBuilder.CreateTable(
                name: "LoadType",
                columns: table => new
                {
                    entLoadTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoadDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadType", x => x.entLoadTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Shaft",
                columns: table => new
                {
                    entShaftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShaftDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    entBuildingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shaft", x => x.entShaftId);
                    table.ForeignKey(
                        name: "FK_Shaft_Building_entBuildingId",
                        column: x => x.entBuildingId,
                        principalTable: "Building",
                        principalColumn: "entBuildingId");
                });

            migrationBuilder.CreateTable(
                name: "ElevatorType",
                columns: table => new
                {
                    entElevatorTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElevatorTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElevatorTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxLoad = table.Column<int>(type: "int", nullable: false),
                    LoadTypeentLoadTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElevatorType", x => x.entElevatorTypeId);
                    table.ForeignKey(
                        name: "FK_ElevatorType_LoadType_LoadTypeentLoadTypeId",
                        column: x => x.LoadTypeentLoadTypeId,
                        principalTable: "LoadType",
                        principalColumn: "entLoadTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Floor",
                columns: table => new
                {
                    entFloorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloorDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    entBuildingId = table.Column<int>(type: "int", nullable: true),
                    entShaftId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floor", x => x.entFloorId);
                    table.ForeignKey(
                        name: "FK_Floor_Building_entBuildingId",
                        column: x => x.entBuildingId,
                        principalTable: "Building",
                        principalColumn: "entBuildingId");
                    table.ForeignKey(
                        name: "FK_Floor_Shaft_entShaftId",
                        column: x => x.entShaftId,
                        principalTable: "Shaft",
                        principalColumn: "entShaftId");
                });

            migrationBuilder.CreateTable(
                name: "Elevator",
                columns: table => new
                {
                    entElevatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElevatorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElevatorType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShaftentShaftId = table.Column<int>(type: "int", nullable: false),
                    blnIsMoving = table.Column<bool>(type: "bit", nullable: false),
                    blnIsGoingUp = table.Column<bool>(type: "bit", nullable: false),
                    CurrentFloorentFloorId = table.Column<int>(type: "int", nullable: false),
                    CurrentLoadCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elevator", x => x.entElevatorId);
                    table.ForeignKey(
                        name: "FK_Elevator_Floor_CurrentFloorentFloorId",
                        column: x => x.CurrentFloorentFloorId,
                        principalTable: "Floor",
                        principalColumn: "entFloorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Elevator_Shaft_ShaftentShaftId",
                        column: x => x.ShaftentShaftId,
                        principalTable: "Shaft",
                        principalColumn: "entShaftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elevator_CurrentFloorentFloorId",
                table: "Elevator",
                column: "CurrentFloorentFloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Elevator_ShaftentShaftId",
                table: "Elevator",
                column: "ShaftentShaftId");

            migrationBuilder.CreateIndex(
                name: "IX_ElevatorType_LoadTypeentLoadTypeId",
                table: "ElevatorType",
                column: "LoadTypeentLoadTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Floor_entBuildingId",
                table: "Floor",
                column: "entBuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Floor_entShaftId",
                table: "Floor",
                column: "entShaftId");

            migrationBuilder.CreateIndex(
                name: "IX_Shaft_entBuildingId",
                table: "Shaft",
                column: "entBuildingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elevator");

            migrationBuilder.DropTable(
                name: "ElevatorType");

            migrationBuilder.DropTable(
                name: "Floor");

            migrationBuilder.DropTable(
                name: "LoadType");

            migrationBuilder.DropTable(
                name: "Shaft");

            migrationBuilder.DropTable(
                name: "Building");
        }
    }
}
