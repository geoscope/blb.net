using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BLB.Domain.Net.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
                throw new Exception("Null migration builder");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "ProductAttributes");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductOptions");

            migrationBuilder.DropTable(
                name: "UserInUserRoles");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Stores");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
                throw new Exception("Null migration builder");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    IsDeleteted = table.Column<bool>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: false),
                    Code = table.Column<string>(maxLength: 25, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    CategoryOwnerId = table.Column<long>(nullable: true),
                    ParentCategoryId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    IsDeleteted = table.Column<bool>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: false),
                    Code = table.Column<string>(maxLength: 25, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Body = table.Column<string>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    ParentPageId = table.Column<long>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    IsDeleteted = table.Column<bool>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    CostPrice = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    PrimaryProductImageId = table.Column<long>(nullable: false),
                    ProductSupplierId = table.Column<long>(nullable: true),
                    Sku = table.Column<string>(maxLength: 50, nullable: true),
                    StockBackOrderEstimatedArrival = table.Column<DateTime>(nullable: true),
                    StockOnBackOrder = table.Column<int>(nullable: false),
                    StockOnHand = table.Column<int>(nullable: false),
                    StockReorderLevel = table.Column<int>(nullable: true),
                    StoreId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    IsDeleteted = table.Column<bool>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: false),
                    Code = table.Column<string>(maxLength: 256, nullable: false),
                    DefaultPercentageMargin = table.Column<float>(nullable: false),
                    DefaultProductImageUri = table.Column<string>(maxLength: 256, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Summary = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    IsDeleteted = table.Column<bool>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: false),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    IsDeleteted = table.Column<bool>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: false),
                    key = table.Column<string>(maxLength: 256, nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    value = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    IsDeleteted = table.Column<bool>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: false),
                    Height = table.Column<int>(nullable: true),
                    ImageFileSize = table.Column<long>(nullable: false),
                    ImageType = table.Column<int>(nullable: false),
                    ProductImageUri = table.Column<string>(maxLength: 256, nullable: false),
                    SortOrder = table.Column<int>(nullable: false, defaultValue: 0),
                    Width = table.Column<int>(nullable: true),
                    ProductId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductOptions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    IsDeleteted = table.Column<bool>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: false),
                    Code = table.Column<string>(maxLength: 25, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOptions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    IsDeleteted = table.Column<bool>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 256, nullable: false),
                    FirstName = table.Column<string>(maxLength: 25, nullable: false),
                    HashedVerificationCode = table.Column<string>(maxLength: 256, nullable: true),
                    IsUserLockedOut = table.Column<bool>(nullable: true),
                    IsUserVerified = table.Column<bool>(nullable: true),
                    LastName = table.Column<string>(maxLength: 25, nullable: true),
                    Password = table.Column<string>(maxLength: 256, nullable: false),
                    StoreId = table.Column<long>(nullable: false),
                    UserLockedEndDate = table.Column<DateTime>(nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    UserSalt = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInUserRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(nullable: false),
                    UserRoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInUserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_ProductId",
                table: "ProductAttributes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptions_ProductId",
                table: "ProductOptions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInUserRoles_UserId",
                table: "UserInUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StoreId",
                table: "Users",
                column: "StoreId");
        }
    }
}