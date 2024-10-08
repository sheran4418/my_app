﻿// <auto-generated />
using System;
using Bn_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace My_Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bn_API.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Bn_API.Models.item", b =>
                {
                    b.Property<int>("itid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("itid"));

                    b.Property<string>("bn_num")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("chemical_finish")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("composition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("construction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("d_root")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("entered_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("entered_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("fds_rp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("finish_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gsm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("img_path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("it_width")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mill")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("Decimal(10,2)");

                    b.Property<string>("rack_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("reference_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("row_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("season")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sup_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("test_rp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("weave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("itid");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "5de8c662-15a6-48d5-8b64-39f701f4e36f",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "44d492f9-2626-477c-92d8-83d7de3f4f7f",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("My_Api.Models.OrderHeader", b =>
                {
                    b.Property<int>("ord_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ord_id"));

                    b.Property<string>("Headerstate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ord_id");

                    b.ToTable("orderHeader");
                });

            modelBuilder.Entity("My_Api.Models.OrderLine", b =>
                {
                    b.Property<int>("ordLine_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ordLine_id"));

                    b.Property<string>("Linestate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderHeaderord_id")
                        .HasColumnType("int");

                    b.Property<int?>("headerId")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.Property<int>("qty")
                        .HasColumnType("int");

                    b.HasKey("ordLine_id");

                    b.HasIndex("OrderHeaderord_id");

                    b.ToTable("orderLine");
                });

            modelBuilder.Entity("My_Api.Models.Products", b =>
                {
                    b.Property<int>("prod_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("prod_id"));

                    b.Property<string>("prod_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prod_dateAdded")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prod_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prod_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("prod_price")
                        .HasColumnType("int");

                    b.Property<int>("prod_qty")
                        .HasColumnType("int");

                    b.Property<string>("prod_status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("prod_id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("My_Api.Models.Users", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("user_id"));

                    b.Property<string>("u_email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("u_fname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("u_isactive")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("u_lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("u_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("u_password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("user_id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Bn_API.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Bn_API.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bn_API.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Bn_API.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("My_Api.Models.OrderLine", b =>
                {
                    b.HasOne("My_Api.Models.OrderHeader", "OrderHeader")
                        .WithMany("orderLines")
                        .HasForeignKey("OrderHeaderord_id");

                    b.Navigation("OrderHeader");
                });

            modelBuilder.Entity("My_Api.Models.OrderHeader", b =>
                {
                    b.Navigation("orderLines");
                });
#pragma warning restore 612, 618
        }
    }
}
