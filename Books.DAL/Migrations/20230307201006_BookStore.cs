using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Books.DAL.Migrations
{
    /// <inheritdoc />
    public partial class BookStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Name", "Author", "Description", "ReleaseDate", "Price" },
                values: new object[,]
                {
                    { "Загадочное происшествие в Стайлзе", "Агата Кристи", "Описание книги", "1920-10-01 00:00:00.0000000", "89.99" },
                    { "Убийство Роджера Экройда", "Агата Кристи", "Описание книги", "1926-06-01 00:00:00.0000000", "35.01" },
                    { "Собака Баскервилей", "Артур Конан Дойл", "Описание книги", "1902-03-25 00:00:00.0000000", "59.99" },
                    { "Знак четырех", "Артур Конан Дойл", "Описание книги", "1890-02-01 00:00:00.0000000", "69.99" },
                    { "Левиафан ", "Борис Акунин", "Описание книги", "1998-01-01 00:00:00.0000000", "35.55" },
                    { "Статский советник", "Борис Акунин", "Описание книги", "1999-05-21 00:00:00.0000000", "21.32" },
                    { "Девушка в лабиринте", "Донато Карризи", "Описание книги", "2017-12-04 00:00:00.0000000", "71.32" },
                    { "Подсказчик", "Донато Карризи", "Описание книги", "2009-01-15 00:00:00.0000000", "55.13" },
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_BookId",
                table: "OrderItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
