using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElevatorSim.Migrations
{
    /// <inheritdoc />
    public partial class ElevatorSimDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.BuildingId);
                });

            migrationBuilder.CreateTable(
                name: "Errors",
                columns: table => new
                {
                    ErrorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErrorNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Errors", x => x.ErrorId);
                });

            migrationBuilder.CreateTable(
                name: "LoadType",
                columns: table => new
                {
                    LoadTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoadDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadType", x => x.LoadTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Floor",
                columns: table => new
                {
                    FloorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloorDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floor", x => x.FloorId);
                    table.ForeignKey(
                        name: "FK_Floor_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shaft",
                columns: table => new
                {
                    ShaftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShaftDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shaft", x => x.ShaftId);
                    table.ForeignKey(
                        name: "FK_Shaft_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElevatorType",
                columns: table => new
                {
                    ElevatorTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElevatorTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElevatorTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxLoad = table.Column<int>(type: "int", nullable: false),
                    LoadTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElevatorType", x => x.ElevatorTypeId);
                    table.ForeignKey(
                        name: "FK_ElevatorType_LoadType_LoadTypeId",
                        column: x => x.LoadTypeId,
                        principalTable: "LoadType",
                        principalColumn: "LoadTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Elevator",
                columns: table => new
                {
                    ElevatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElevatorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElevatorTypeId = table.Column<int>(type: "int", nullable: false),
                    ShaftId = table.Column<int>(type: "int", nullable: false),
                    IsMoving = table.Column<bool>(type: "bit", nullable: false),
                    IsGoingUp = table.Column<bool>(type: "bit", nullable: false),
                    CurrentFloorFloorId = table.Column<int>(type: "int", nullable: false),
                    CurrentLoadCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elevator", x => x.ElevatorId);
                    table.ForeignKey(
                        name: "FK_Elevator_ElevatorType_ElevatorTypeId",
                        column: x => x.ElevatorTypeId,
                        principalTable: "ElevatorType",
                        principalColumn: "ElevatorTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Elevator_Floor_CurrentFloorFloorId",
                        column: x => x.CurrentFloorFloorId,
                        principalTable: "Floor",
                        principalColumn: "FloorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Elevator_Shaft_ShaftId",
                        column: x => x.ShaftId,
                        principalTable: "Shaft",
                        principalColumn: "ShaftId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elevator_CurrentFloorFloorId",
                table: "Elevator",
                column: "CurrentFloorFloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Elevator_ElevatorTypeId",
                table: "Elevator",
                column: "ElevatorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Elevator_ShaftId",
                table: "Elevator",
                column: "ShaftId");

            migrationBuilder.CreateIndex(
                name: "IX_ElevatorType_LoadTypeId",
                table: "ElevatorType",
                column: "LoadTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Floor_BuildingId",
                table: "Floor",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Shaft_BuildingId",
                table: "Shaft",
                column: "BuildingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elevator");

            migrationBuilder.DropTable(
                name: "Errors");

            migrationBuilder.DropTable(
                name: "ElevatorType");

            migrationBuilder.DropTable(
                name: "Floor");

            migrationBuilder.DropTable(
                name: "Shaft");

            migrationBuilder.DropTable(
                name: "LoadType");

            migrationBuilder.DropTable(
                name: "Building");
        }
    }
}
