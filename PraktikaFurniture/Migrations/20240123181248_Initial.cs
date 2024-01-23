using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace PraktikaFurniture.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    ProductName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ProductCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Unit = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Product_pkey", x => x.ProductID);
                });

            migrationBuilder.Sql(
                "INSERT INTO \"Products\" (\"ProductName\", \"ProductCode\", \"Unit\", \"Quantity\", \"Price\") VALUES " +
                "('Стол', 'STL001', 'шт.', 10, 5000.00)," +
                "('Стул', 'CHR002', 'шт.', 20, 1500.00)," +
                "('Шкаф', 'CBN003', 'шт.', 5, 12000.00)," +
                "('Диван', 'SOF004', 'шт.', 8, 15000.00), " +
                "('Кровать', 'BED005', 'шт.', 12, 20000.00), " +
                "('Стеллаж', 'SHL006', 'шт.', 15, 8000.00), " +
                "('Столик', 'TBL007', 'шт.', 25, 3000.00), " +
                "('Кресло', 'ARM008', 'шт.', 18, 10000.00), " +
                "('Стол письменный', 'DST001', 'шт.', 15, 7000.00), " +
                "('Комод', 'COM002', 'шт.', 10, 8500.00), " +
                "('Зеркало', 'MIR003', 'шт.', 7, 3000.00), " +
                "('Шкаф для посуды', 'CBN004', 'шт.', 6, 11000.00), " +
                "('Полка для книг', 'BKS005', 'шт.', 20, 2500.00), " +
                "('Стул-барный', 'BAR001', 'шт.', 30, 1800.00), " +
                "('Компьютерный стол', 'CDS002', 'шт.', 12, 6500.00), " +
                "('Пенал для одежды', 'WDR003', 'шт.', 8, 7500.00), " +
                "('Книжный шкаф', 'BKS006', 'шт.', 15, 6000.00), " +
                "('Письменный стол', 'WDS007', 'шт.', 10, 8500.00);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
