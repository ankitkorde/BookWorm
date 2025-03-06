using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookWorm_Dotnet.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "attribute_master",
                columns: table => new
                {
                    attribute_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    attribute_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.attribute_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "beneficiary_master",
                columns: table => new
                {
                    ben_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ben_acc_type = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ben_bank_acc_no = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ben_bank_branch = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ben_bank_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ben_email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ben_ifsc = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ben_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ben_pan = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ben_phone = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ben_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "customer_master",
                columns: table => new
                {
                    customer_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    age = table.Column<int>(type: "int", nullable: true),
                    customeremail = table.Column<string>(type: "varchar(255)", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    customername = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    customerpassword = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dob = table.Column<DateOnly>(type: "date", nullable: true),
                    pan = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phonenumber = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.customer_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "genre_master",
                columns: table => new
                {
                    genre_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    genre_desc = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.genre_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "language_master",
                columns: table => new
                {
                    language_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    language_desc = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.language_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "product_type_master",
                columns: table => new
                {
                    type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    type_desc = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.type_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "cart_master",
                columns: table => new
                {
                    cart_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cost = table.Column<double>(type: "double", nullable: true),
                    is_active = table.Column<ulong>(type: "bit(1)", nullable: false),
                    customer_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.cart_id);
                    table.ForeignKey(
                        name: "FK44sbajofqx6cngygmmwui5igc",
                        column: x => x.customer_id,
                        principalTable: "customer_master",
                        principalColumn: "customer_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "my_shelf",
                columns: table => new
                {
                    shelf_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    no_of_books = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.shelf_id);
                    table.ForeignKey(
                        name: "FKcda6p3ku4rwecfvmwjv73hpfv",
                        column: x => x.customer_id,
                        principalTable: "customer_master",
                        principalColumn: "customer_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "product_master",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    is_rentable = table.Column<ulong>(type: "bit(1)", nullable: true),
                    min_rent_days = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'3'"),
                    product_author = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    product_base_price = table.Column<double>(type: "double", nullable: true),
                    product_description_long = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    product_description_short = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    product_english_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    product_isbn = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    product_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    product_off_price_expiry_date = table.Column<DateOnly>(type: "date", nullable: true),
                    product_offer_price = table.Column<double>(type: "double", nullable: true),
                    product_sp_cost = table.Column<double>(type: "double", nullable: true),
                    rent_per_day = table.Column<double>(type: "double", nullable: true),
                    genre_id = table.Column<int>(type: "int", nullable: true),
                    language_id = table.Column<int>(type: "int", nullable: true),
                    type_id = table.Column<int>(type: "int", nullable: true),
                    product_description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    img_src = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.product_id);
                    table.ForeignKey(
                        name: "FK98ccg011o5dskuffl8qf7o7kk",
                        column: x => x.language_id,
                        principalTable: "language_master",
                        principalColumn: "language_id");
                    table.ForeignKey(
                        name: "FKceskcho96iufjsecekgohckua",
                        column: x => x.genre_id,
                        principalTable: "genre_master",
                        principalColumn: "genre_id");
                    table.ForeignKey(
                        name: "FKkqx9yklv6gwn0rx53udabv5bd",
                        column: x => x.type_id,
                        principalTable: "product_type_master",
                        principalColumn: "type_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "invoice",
                columns: table => new
                {
                    invoice_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    amount = table.Column<double>(type: "double", nullable: true),
                    date = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                    cart_id = table.Column<int>(type: "int", nullable: true),
                    customer_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.invoice_id);
                    table.ForeignKey(
                        name: "FK74rjp8604l111tb50mbg1ubbd",
                        column: x => x.cart_id,
                        principalTable: "cart_master",
                        principalColumn: "cart_id");
                    table.ForeignKey(
                        name: "FKk9j7m0iwl2u5ccibh3piocfj",
                        column: x => x.customer_id,
                        principalTable: "customer_master",
                        principalColumn: "customer_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "cart_details",
                columns: table => new
                {
                    cart_details_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    is_rented = table.Column<ulong>(type: "bit(1)", nullable: false),
                    is_updated = table.Column<ulong>(type: "bit(1)", nullable: false),
                    offer_cost = table.Column<double>(type: "double", nullable: false),
                    rent_no_of_days = table.Column<int>(type: "int", nullable: true),
                    cart_id = table.Column<int>(type: "int", nullable: true),
                    product_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.cart_details_id);
                    table.ForeignKey(
                        name: "FK5u7nakxaradawhygg84syvu92",
                        column: x => x.cart_id,
                        principalTable: "cart_master",
                        principalColumn: "cart_id");
                    table.ForeignKey(
                        name: "FKlfyc1r1caest795hguh2nto2m",
                        column: x => x.product_id,
                        principalTable: "product_master",
                        principalColumn: "product_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "product_arribute",
                columns: table => new
                {
                    product_attribute_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    attribute_value = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    attribute_id = table.Column<int>(type: "int", nullable: true),
                    product_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.product_attribute_id);
                    table.ForeignKey(
                        name: "FKbdigfhujyub7ojp7lirf5l6d0",
                        column: x => x.attribute_id,
                        principalTable: "attribute_master",
                        principalColumn: "attribute_id");
                    table.ForeignKey(
                        name: "FKeu0ww30gewhci44umhb3we5x1",
                        column: x => x.product_id,
                        principalTable: "product_master",
                        principalColumn: "product_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "product_beneficiary",
                columns: table => new
                {
                    product_beneficiary_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    percentage = table.Column<double>(type: "double", nullable: true),
                    beneficiary_id = table.Column<int>(type: "int", nullable: true),
                    product_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.product_beneficiary_id);
                    table.ForeignKey(
                        name: "FKimuuqbtoxmdkej3yb1rhq7qoh",
                        column: x => x.product_id,
                        principalTable: "product_master",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FKivxugs1htmu5356ka6adepyo4",
                        column: x => x.beneficiary_id,
                        principalTable: "beneficiary_master",
                        principalColumn: "ben_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "rent_details",
                columns: table => new
                {
                    rent_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    rent_end_date = table.Column<DateOnly>(type: "date", nullable: false),
                    rent_price = table.Column<double>(type: "double", nullable: false),
                    rent_start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    customer_id = table.Column<long>(type: "bigint", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.rent_id);
                    table.ForeignKey(
                        name: "FKibhwskuwhrxv3d99r8vyd8xv2",
                        column: x => x.customer_id,
                        principalTable: "customer_master",
                        principalColumn: "customer_id");
                    table.ForeignKey(
                        name: "FKkn9g6d3w8jyxy23y1yree59f0",
                        column: x => x.product_id,
                        principalTable: "product_master",
                        principalColumn: "product_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "invoice_details",
                columns: table => new
                {
                    inv_dtl_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    rent_no_of_days = table.Column<int>(type: "int", nullable: false),
                    royalty_amount = table.Column<double>(type: "double", nullable: true),
                    sell_price = table.Column<double>(type: "double", nullable: true),
                    tran_type = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    invoice_id = table.Column<int>(type: "int", nullable: true),
                    product_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.inv_dtl_id);
                    table.ForeignKey(
                        name: "FK1anfj9yh7l91txbjf905la63l",
                        column: x => x.product_id,
                        principalTable: "product_master",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FKpc7xa72mljy7weoct7uubgjy7",
                        column: x => x.invoice_id,
                        principalTable: "invoice",
                        principalColumn: "invoice_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "royalty_calculation",
                columns: table => new
                {
                    roy_cal_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    royalty_date = table.Column<DateOnly>(type: "date", nullable: false),
                    royalty_on_sales_price = table.Column<double>(type: "double", nullable: false),
                    sales_price = table.Column<double>(type: "double", nullable: false),
                    transaction_type = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    beneficiary_id = table.Column<int>(type: "int", nullable: false),
                    invoice_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.roy_cal_id);
                    table.ForeignKey(
                        name: "FK6ef225pnw8r22kw85xfua6hni",
                        column: x => x.invoice_id,
                        principalTable: "invoice",
                        principalColumn: "invoice_id");
                    table.ForeignKey(
                        name: "FKas49u6dxu8mu28ylsq0cucx1b",
                        column: x => x.product_id,
                        principalTable: "product_master",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FKk6t36n4hai8yk4uo16c2u4xl5",
                        column: x => x.beneficiary_id,
                        principalTable: "beneficiary_master",
                        principalColumn: "ben_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "my_shelf_details",
                columns: table => new
                {
                    shelf_dtl_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    expiry_date = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                    tran_type = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    rent_id = table.Column<int>(type: "int", nullable: true),
                    shelf_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.shelf_dtl_id);
                    table.ForeignKey(
                        name: "FK3vkqpj988tywu7bhqeobs2nr5",
                        column: x => x.shelf_id,
                        principalTable: "my_shelf",
                        principalColumn: "shelf_id");
                    table.ForeignKey(
                        name: "FKbtjwvxhfuon9laskq27fxc7g5",
                        column: x => x.rent_id,
                        principalTable: "rent_details",
                        principalColumn: "rent_id");
                    table.ForeignKey(
                        name: "FKnydbo1psmybo0qmv9rvgqo1o6",
                        column: x => x.product_id,
                        principalTable: "product_master",
                        principalColumn: "product_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "FK5u7nakxaradawhygg84syvu92",
                table: "cart_details",
                column: "cart_id");

            migrationBuilder.CreateIndex(
                name: "FKlfyc1r1caest795hguh2nto2m",
                table: "cart_details",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "FK44sbajofqx6cngygmmwui5igc",
                table: "cart_master",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "UK8g722plphbq8gh7lih8ua6ada",
                table: "customer_master",
                column: "customeremail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK74rjp8604l111tb50mbg1ubbd",
                table: "invoice",
                column: "cart_id");

            migrationBuilder.CreateIndex(
                name: "FKk9j7m0iwl2u5ccibh3piocfj",
                table: "invoice",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "FK1anfj9yh7l91txbjf905la63l",
                table: "invoice_details",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "FKpc7xa72mljy7weoct7uubgjy7",
                table: "invoice_details",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "UKa0wjpu0o249cdo2it1dxw19of",
                table: "my_shelf",
                column: "customer_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK3vkqpj988tywu7bhqeobs2nr5",
                table: "my_shelf_details",
                column: "shelf_id");

            migrationBuilder.CreateIndex(
                name: "FKbtjwvxhfuon9laskq27fxc7g5",
                table: "my_shelf_details",
                column: "rent_id");

            migrationBuilder.CreateIndex(
                name: "FKnydbo1psmybo0qmv9rvgqo1o6",
                table: "my_shelf_details",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "FKbdigfhujyub7ojp7lirf5l6d0",
                table: "product_arribute",
                column: "attribute_id");

            migrationBuilder.CreateIndex(
                name: "FKeu0ww30gewhci44umhb3we5x1",
                table: "product_arribute",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "FKimuuqbtoxmdkej3yb1rhq7qoh",
                table: "product_beneficiary",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "FKivxugs1htmu5356ka6adepyo4",
                table: "product_beneficiary",
                column: "beneficiary_id");

            migrationBuilder.CreateIndex(
                name: "FK98ccg011o5dskuffl8qf7o7kk",
                table: "product_master",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "FKceskcho96iufjsecekgohckua",
                table: "product_master",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "FKkqx9yklv6gwn0rx53udabv5bd",
                table: "product_master",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "FKibhwskuwhrxv3d99r8vyd8xv2",
                table: "rent_details",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "FKkn9g6d3w8jyxy23y1yree59f0",
                table: "rent_details",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "FK6ef225pnw8r22kw85xfua6hni",
                table: "royalty_calculation",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "FKas49u6dxu8mu28ylsq0cucx1b",
                table: "royalty_calculation",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "FKk6t36n4hai8yk4uo16c2u4xl5",
                table: "royalty_calculation",
                column: "beneficiary_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cart_details");

            migrationBuilder.DropTable(
                name: "invoice_details");

            migrationBuilder.DropTable(
                name: "my_shelf_details");

            migrationBuilder.DropTable(
                name: "product_arribute");

            migrationBuilder.DropTable(
                name: "product_beneficiary");

            migrationBuilder.DropTable(
                name: "royalty_calculation");

            migrationBuilder.DropTable(
                name: "my_shelf");

            migrationBuilder.DropTable(
                name: "rent_details");

            migrationBuilder.DropTable(
                name: "attribute_master");

            migrationBuilder.DropTable(
                name: "invoice");

            migrationBuilder.DropTable(
                name: "beneficiary_master");

            migrationBuilder.DropTable(
                name: "product_master");

            migrationBuilder.DropTable(
                name: "cart_master");

            migrationBuilder.DropTable(
                name: "language_master");

            migrationBuilder.DropTable(
                name: "genre_master");

            migrationBuilder.DropTable(
                name: "product_type_master");

            migrationBuilder.DropTable(
                name: "customer_master");
        }
    }
}
