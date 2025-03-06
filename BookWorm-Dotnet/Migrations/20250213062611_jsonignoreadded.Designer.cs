﻿// <auto-generated />
using System;
using BookWorm_Dotnet.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookWorm_Dotnet.Migrations
{
    [DbContext(typeof(BookWormDbContext))]
    [Migration("20250213062611_jsonignoreadded")]
    partial class jsonignoreadded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("BookWorm_Dotnet.Models.AttributeMaster", b =>
                {
                    b.Property<int>("AttributeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("attribute_id");

                    b.Property<string>("AttributeName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("attribute_name");

                    b.HasKey("AttributeId")
                        .HasName("PRIMARY");

                    b.ToTable("attribute_master");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.BeneficiaryMaster", b =>
                {
                    b.Property<int>("BenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ben_id");

                    b.Property<string>("BenAccType")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ben_acc_type");

                    b.Property<string>("BenBankAccNo")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ben_bank_acc_no");

                    b.Property<string>("BenBankBranch")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ben_bank_branch");

                    b.Property<string>("BenBankName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ben_bank_name");

                    b.Property<string>("BenEmail")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ben_email");

                    b.Property<string>("BenIfsc")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ben_ifsc");

                    b.Property<string>("BenName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ben_name");

                    b.Property<string>("BenPan")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ben_pan");

                    b.Property<string>("BenPhone")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ben_phone");

                    b.HasKey("BenId")
                        .HasName("PRIMARY");

                    b.ToTable("beneficiary_master");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.CartDetail", b =>
                {
                    b.Property<int>("CartDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cart_details_id");

                    b.Property<int?>("CartId")
                        .HasColumnType("int")
                        .HasColumnName("cart_id");

                    b.Property<ulong>("IsRented")
                        .HasColumnType("bit(1)")
                        .HasColumnName("is_rented");

                    b.Property<ulong>("IsUpdated")
                        .HasColumnType("bit(1)")
                        .HasColumnName("is_updated");

                    b.Property<double>("OfferCost")
                        .HasColumnType("double")
                        .HasColumnName("offer_cost");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int?>("RentNoOfDays")
                        .HasColumnType("int")
                        .HasColumnName("rent_no_of_days");

                    b.HasKey("CartDetailsId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CartId" }, "FK5u7nakxaradawhygg84syvu92");

                    b.HasIndex(new[] { "ProductId" }, "FKlfyc1r1caest795hguh2nto2m");

                    b.ToTable("cart_details");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.CartMaster", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cart_id");

                    b.Property<double?>("Cost")
                        .HasColumnType("double")
                        .HasColumnName("cost");

                    b.Property<long?>("CustomerId")
                        .HasColumnType("bigint")
                        .HasColumnName("customer_id");

                    b.Property<ulong>("IsActive")
                        .HasColumnType("bit(1)")
                        .HasColumnName("is_active");

                    b.HasKey("CartId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CustomerId" }, "FK44sbajofqx6cngygmmwui5igc");

                    b.ToTable("cart_master");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.GenreMaster", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("genre_id");

                    b.Property<string>("GenreDesc")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("genre_desc");

                    b.HasKey("GenreId")
                        .HasName("PRIMARY");

                    b.ToTable("genre_master");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("invoice_id");

                    b.Property<double?>("Amount")
                        .HasColumnType("double")
                        .HasColumnName("amount");

                    b.Property<int?>("CartId")
                        .HasColumnType("int")
                        .HasColumnName("cart_id");

                    b.Property<long?>("CustomerId")
                        .HasColumnType("bigint")
                        .HasColumnName("customer_id");

                    b.Property<DateTime?>("Date")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date");

                    b.HasKey("InvoiceId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CartId" }, "FK74rjp8604l111tb50mbg1ubbd");

                    b.HasIndex(new[] { "CustomerId" }, "FKk9j7m0iwl2u5ccibh3piocfj");

                    b.ToTable("invoice");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.InvoiceDetail", b =>
                {
                    b.Property<int>("InvDtlId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("inv_dtl_id");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int")
                        .HasColumnName("invoice_id");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<int>("RentNoOfDays")
                        .HasColumnType("int")
                        .HasColumnName("rent_no_of_days");

                    b.Property<double?>("RoyaltyAmount")
                        .HasColumnType("double")
                        .HasColumnName("royalty_amount");

                    b.Property<double?>("SellPrice")
                        .HasColumnType("double")
                        .HasColumnName("sell_price");

                    b.Property<string>("TranType")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("tran_type");

                    b.HasKey("InvDtlId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ProductId" }, "FK1anfj9yh7l91txbjf905la63l");

                    b.HasIndex(new[] { "InvoiceId" }, "FKpc7xa72mljy7weoct7uubgjy7");

                    b.ToTable("invoice_details");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.LanguageMaster", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("language_id");

                    b.Property<string>("LanguageDesc")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("language_desc");

                    b.HasKey("LanguageId")
                        .HasName("PRIMARY");

                    b.ToTable("language_master");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.LogEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Exception")
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("LogLevel")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("log_entries", (string)null);
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.MyShelf", b =>
                {
                    b.Property<int>("ShelfId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("shelf_id");

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint")
                        .HasColumnName("customer_id");

                    b.Property<int>("NoOfBooks")
                        .HasColumnType("int")
                        .HasColumnName("no_of_books");

                    b.HasKey("ShelfId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CustomerId" }, "UKa0wjpu0o249cdo2it1dxw19of")
                        .IsUnique();

                    b.ToTable("my_shelf");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.MyShelfDetail", b =>
                {
                    b.Property<int>("ShelfDtlId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("shelf_dtl_id");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasMaxLength(6)
                        .HasColumnType("datetime(6)")
                        .HasColumnName("expiry_date");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int?>("RentId")
                        .HasColumnType("int")
                        .HasColumnName("rent_id");

                    b.Property<int>("ShelfId")
                        .HasColumnType("int")
                        .HasColumnName("shelf_id");

                    b.Property<string>("TranType")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("tran_type");

                    b.HasKey("ShelfDtlId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ShelfId" }, "FK3vkqpj988tywu7bhqeobs2nr5");

                    b.HasIndex(new[] { "RentId" }, "FKbtjwvxhfuon9laskq27fxc7g5");

                    b.HasIndex(new[] { "ProductId" }, "FKnydbo1psmybo0qmv9rvgqo1o6");

                    b.ToTable("my_shelf_details");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.ProductArribute", b =>
                {
                    b.Property<int>("ProductAttributeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("product_attribute_id");

                    b.Property<int?>("AttributeId")
                        .HasColumnType("int")
                        .HasColumnName("attribute_id");

                    b.Property<string>("AttributeValue")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("attribute_value");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.HasKey("ProductAttributeId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "AttributeId" }, "FKbdigfhujyub7ojp7lirf5l6d0");

                    b.HasIndex(new[] { "ProductId" }, "FKeu0ww30gewhci44umhb3we5x1");

                    b.ToTable("product_arribute");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.ProductBeneficiary", b =>
                {
                    b.Property<int>("ProductBeneficiaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("product_beneficiary_id");

                    b.Property<int?>("BeneficiaryId")
                        .HasColumnType("int")
                        .HasColumnName("beneficiary_id");

                    b.Property<double?>("Percentage")
                        .HasColumnType("double")
                        .HasColumnName("percentage");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.HasKey("ProductBeneficiaryId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ProductId" }, "FKimuuqbtoxmdkej3yb1rhq7qoh");

                    b.HasIndex(new[] { "BeneficiaryId" }, "FKivxugs1htmu5356ka6adepyo4");

                    b.ToTable("product_beneficiary");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.ProductMaster", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int")
                        .HasColumnName("genre_id");

                    b.Property<string>("ImgSrc")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("img_src");

                    b.Property<ulong?>("IsRentable")
                        .HasColumnType("bit(1)")
                        .HasColumnName("is_rentable");

                    b.Property<int?>("LanguageId")
                        .HasColumnType("int")
                        .HasColumnName("language_id");

                    b.Property<int?>("MinRentDays")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("min_rent_days")
                        .HasDefaultValueSql("'3'");

                    b.Property<string>("ProductAuthor")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("product_author");

                    b.Property<double?>("ProductBasePrice")
                        .HasColumnType("double")
                        .HasColumnName("product_base_price");

                    b.Property<string>("ProductDescription")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("product_description");

                    b.Property<string>("ProductDescriptionLong")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("product_description_long");

                    b.Property<string>("ProductDescriptionShort")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("product_description_short");

                    b.Property<string>("ProductEnglishName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("product_english_name");

                    b.Property<string>("ProductIsbn")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("product_isbn");

                    b.Property<string>("ProductName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("product_name");

                    b.Property<DateOnly?>("ProductOffPriceExpiryDate")
                        .HasColumnType("date")
                        .HasColumnName("product_off_price_expiry_date");

                    b.Property<double?>("ProductOfferPrice")
                        .HasColumnType("double")
                        .HasColumnName("product_offer_price");

                    b.Property<double?>("ProductSpCost")
                        .HasColumnType("double")
                        .HasColumnName("product_sp_cost");

                    b.Property<double?>("RentPerDay")
                        .HasColumnType("double")
                        .HasColumnName("rent_per_day");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int")
                        .HasColumnName("type_id");

                    b.HasKey("ProductId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "LanguageId" }, "FK98ccg011o5dskuffl8qf7o7kk");

                    b.HasIndex(new[] { "GenreId" }, "FKceskcho96iufjsecekgohckua");

                    b.HasIndex(new[] { "TypeId" }, "FKkqx9yklv6gwn0rx53udabv5bd");

                    b.ToTable("product_master");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.ProductTypeMaster", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("type_id");

                    b.Property<string>("TypeDesc")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("type_desc");

                    b.HasKey("TypeId")
                        .HasName("PRIMARY");

                    b.ToTable("product_type_master");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.RentDetail", b =>
                {
                    b.Property<int>("RentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("rent_id");

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint")
                        .HasColumnName("customer_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<DateOnly>("RentEndDate")
                        .HasColumnType("date")
                        .HasColumnName("rent_end_date");

                    b.Property<double>("RentPrice")
                        .HasColumnType("double")
                        .HasColumnName("rent_price");

                    b.Property<DateOnly>("RentStartDate")
                        .HasColumnType("date")
                        .HasColumnName("rent_start_date");

                    b.HasKey("RentId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CustomerId" }, "FKibhwskuwhrxv3d99r8vyd8xv2");

                    b.HasIndex(new[] { "ProductId" }, "FKkn9g6d3w8jyxy23y1yree59f0");

                    b.ToTable("rent_details");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.RoyaltyCalculation", b =>
                {
                    b.Property<int>("RoyCalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("roy_cal_id");

                    b.Property<int>("BeneficiaryId")
                        .HasColumnType("int")
                        .HasColumnName("beneficiary_id");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int")
                        .HasColumnName("invoice_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<DateOnly>("RoyaltyDate")
                        .HasColumnType("date")
                        .HasColumnName("royalty_date");

                    b.Property<double>("RoyaltyOnSalesPrice")
                        .HasColumnType("double")
                        .HasColumnName("royalty_on_sales_price");

                    b.Property<double>("SalesPrice")
                        .HasColumnType("double")
                        .HasColumnName("sales_price");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("transaction_type");

                    b.HasKey("RoyCalId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "InvoiceId" }, "FK6ef225pnw8r22kw85xfua6hni");

                    b.HasIndex(new[] { "ProductId" }, "FKas49u6dxu8mu28ylsq0cucx1b");

                    b.HasIndex(new[] { "BeneficiaryId" }, "FKk6t36n4hai8yk4uo16c2u4xl5");

                    b.ToTable("royalty_calculation");
                });

            modelBuilder.Entity("CustomerMaster", b =>
                {
                    b.Property<long>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("customer_id");

                    b.Property<int?>("Age")
                        .HasColumnType("int")
                        .HasColumnName("age");

                    b.Property<string>("Customeremail")
                        .HasColumnType("longtext")
                        .HasColumnName("customeremail");

                    b.Property<string>("Customername")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("customername");

                    b.Property<string>("Customerpassword")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("customerpassword");

                    b.Property<DateOnly?>("Dob")
                        .HasColumnType("date")
                        .HasColumnName("dob");

                    b.Property<string>("Pan")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("pan");

                    b.Property<string>("Phonenumber")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("phonenumber");

                    b.HasKey("CustomerId")
                        .HasName("PRIMARY");

                    b.ToTable("customer_master");
                });

            modelBuilder.Entity("UserActivityLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("UserActivityLogs");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.CartDetail", b =>
                {
                    b.HasOne("BookWorm_Dotnet.Models.CartMaster", "Cart")
                        .WithMany("CartDetails")
                        .HasForeignKey("CartId")
                        .HasConstraintName("FK5u7nakxaradawhygg84syvu92");

                    b.HasOne("BookWorm_Dotnet.Models.ProductMaster", "Product")
                        .WithMany("CartDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FKlfyc1r1caest795hguh2nto2m");

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.CartMaster", b =>
                {
                    b.HasOne("CustomerMaster", "Customer")
                        .WithMany("CartMasters")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK44sbajofqx6cngygmmwui5igc");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.Invoice", b =>
                {
                    b.HasOne("BookWorm_Dotnet.Models.CartMaster", "Cart")
                        .WithMany("Invoices")
                        .HasForeignKey("CartId")
                        .HasConstraintName("FK74rjp8604l111tb50mbg1ubbd");

                    b.HasOne("CustomerMaster", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FKk9j7m0iwl2u5ccibh3piocfj");

                    b.Navigation("Cart");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.InvoiceDetail", b =>
                {
                    b.HasOne("BookWorm_Dotnet.Models.Invoice", "Invoice")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("InvoiceId")
                        .HasConstraintName("FKpc7xa72mljy7weoct7uubgjy7");

                    b.HasOne("BookWorm_Dotnet.Models.ProductMaster", "Product")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK1anfj9yh7l91txbjf905la63l");

                    b.Navigation("Invoice");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.MyShelf", b =>
                {
                    b.HasOne("CustomerMaster", "Customer")
                        .WithOne("MyShelf")
                        .HasForeignKey("BookWorm_Dotnet.Models.MyShelf", "CustomerId")
                        .IsRequired()
                        .HasConstraintName("FKcda6p3ku4rwecfvmwjv73hpfv");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.MyShelfDetail", b =>
                {
                    b.HasOne("BookWorm_Dotnet.Models.ProductMaster", "Product")
                        .WithMany("MyShelfDetails")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FKnydbo1psmybo0qmv9rvgqo1o6");

                    b.HasOne("BookWorm_Dotnet.Models.RentDetail", "Rent")
                        .WithMany("MyShelfDetails")
                        .HasForeignKey("RentId")
                        .HasConstraintName("FKbtjwvxhfuon9laskq27fxc7g5");

                    b.HasOne("BookWorm_Dotnet.Models.MyShelf", "Shelf")
                        .WithMany("MyShelfDetails")
                        .HasForeignKey("ShelfId")
                        .IsRequired()
                        .HasConstraintName("FK3vkqpj988tywu7bhqeobs2nr5");

                    b.Navigation("Product");

                    b.Navigation("Rent");

                    b.Navigation("Shelf");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.ProductArribute", b =>
                {
                    b.HasOne("BookWorm_Dotnet.Models.AttributeMaster", "Attribute")
                        .WithMany("ProductArributes")
                        .HasForeignKey("AttributeId")
                        .HasConstraintName("FKbdigfhujyub7ojp7lirf5l6d0");

                    b.HasOne("BookWorm_Dotnet.Models.ProductMaster", "Product")
                        .WithMany("ProductArributes")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FKeu0ww30gewhci44umhb3we5x1");

                    b.Navigation("Attribute");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.ProductBeneficiary", b =>
                {
                    b.HasOne("BookWorm_Dotnet.Models.BeneficiaryMaster", "Beneficiary")
                        .WithMany("ProductBeneficiaries")
                        .HasForeignKey("BeneficiaryId")
                        .HasConstraintName("FKivxugs1htmu5356ka6adepyo4");

                    b.HasOne("BookWorm_Dotnet.Models.ProductMaster", "Product")
                        .WithMany("ProductBeneficiaries")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FKimuuqbtoxmdkej3yb1rhq7qoh");

                    b.Navigation("Beneficiary");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.ProductMaster", b =>
                {
                    b.HasOne("BookWorm_Dotnet.Models.GenreMaster", "Genre")
                        .WithMany("ProductMasters")
                        .HasForeignKey("GenreId")
                        .HasConstraintName("FKceskcho96iufjsecekgohckua");

                    b.HasOne("BookWorm_Dotnet.Models.LanguageMaster", "Language")
                        .WithMany("ProductMasters")
                        .HasForeignKey("LanguageId")
                        .HasConstraintName("FK98ccg011o5dskuffl8qf7o7kk");

                    b.HasOne("BookWorm_Dotnet.Models.ProductTypeMaster", "Type")
                        .WithMany("ProductMasters")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("FKkqx9yklv6gwn0rx53udabv5bd");

                    b.Navigation("Genre");

                    b.Navigation("Language");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.RentDetail", b =>
                {
                    b.HasOne("CustomerMaster", "Customer")
                        .WithMany("RentDetails")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FKibhwskuwhrxv3d99r8vyd8xv2");

                    b.HasOne("BookWorm_Dotnet.Models.ProductMaster", "Product")
                        .WithMany("RentDetails")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FKkn9g6d3w8jyxy23y1yree59f0");

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.RoyaltyCalculation", b =>
                {
                    b.HasOne("BookWorm_Dotnet.Models.BeneficiaryMaster", "Beneficiary")
                        .WithMany("RoyaltyCalculations")
                        .HasForeignKey("BeneficiaryId")
                        .IsRequired()
                        .HasConstraintName("FKk6t36n4hai8yk4uo16c2u4xl5");

                    b.HasOne("BookWorm_Dotnet.Models.Invoice", "Invoice")
                        .WithMany("RoyaltyCalculations")
                        .HasForeignKey("InvoiceId")
                        .IsRequired()
                        .HasConstraintName("FK6ef225pnw8r22kw85xfua6hni");

                    b.HasOne("BookWorm_Dotnet.Models.ProductMaster", "Product")
                        .WithMany("RoyaltyCalculations")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FKas49u6dxu8mu28ylsq0cucx1b");

                    b.Navigation("Beneficiary");

                    b.Navigation("Invoice");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.AttributeMaster", b =>
                {
                    b.Navigation("ProductArributes");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.BeneficiaryMaster", b =>
                {
                    b.Navigation("ProductBeneficiaries");

                    b.Navigation("RoyaltyCalculations");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.CartMaster", b =>
                {
                    b.Navigation("CartDetails");

                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.GenreMaster", b =>
                {
                    b.Navigation("ProductMasters");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.Invoice", b =>
                {
                    b.Navigation("InvoiceDetails");

                    b.Navigation("RoyaltyCalculations");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.LanguageMaster", b =>
                {
                    b.Navigation("ProductMasters");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.MyShelf", b =>
                {
                    b.Navigation("MyShelfDetails");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.ProductMaster", b =>
                {
                    b.Navigation("CartDetails");

                    b.Navigation("InvoiceDetails");

                    b.Navigation("MyShelfDetails");

                    b.Navigation("ProductArributes");

                    b.Navigation("ProductBeneficiaries");

                    b.Navigation("RentDetails");

                    b.Navigation("RoyaltyCalculations");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.ProductTypeMaster", b =>
                {
                    b.Navigation("ProductMasters");
                });

            modelBuilder.Entity("BookWorm_Dotnet.Models.RentDetail", b =>
                {
                    b.Navigation("MyShelfDetails");
                });

            modelBuilder.Entity("CustomerMaster", b =>
                {
                    b.Navigation("CartMasters");

                    b.Navigation("Invoices");

                    b.Navigation("MyShelf");

                    b.Navigation("RentDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
