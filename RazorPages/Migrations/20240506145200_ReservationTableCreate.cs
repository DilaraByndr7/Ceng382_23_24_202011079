using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;


#nullable disable

namespace RazorPages.Migrations
{
    public partial class ReservationTableCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.CreateTable(
            name: "Reservations",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false) 
                .Annotation("SqlServer:Identity", "1,1"),

                ReserverName = table.Column<string>(type:"nvarchar(max)", nullable: true),

                Room = table.Column<string>(type:"nvarchar(max)", nullable: true),

                Date = table.Column<DateTime>(nullable: false)
            },
            constraints: table =>
            {
            
                table.PrimaryKey("PK_Reservations", t => t.Id);
            
                   
            });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Reservations");
        }
    }

}
