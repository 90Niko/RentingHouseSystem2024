﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentingHouseSystem;

#nullable disable

namespace RentingHouseSystem.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240403173852_New")]
    partial class New
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RentingHouseSystem.Infrastructure.Data.Models.Agent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Agent identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Agent's phone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User Identifier");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Agents");

                    b.HasComment("House Agent");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PhoneNumber = "+359888888888",
                            UserId = "dea12856-c198-4129-b3f3-b893d8395082"
                        },
                        new
                        {
                            Id = 3,
                            PhoneNumber = "+359888888887",
                            UserId = "f5563c5e-d780-4bce-812d-408f2c079ae2"
                        });
                });

            modelBuilder.Entity("RentingHouseSystem.Infrastructure.Data.Models.AplicationUser", b =>
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

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

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

                    b.HasData(
                        new
                        {
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d3eaddd7-394e-4ef1-a8b2-5fd54482ef65",
                            Email = "agent@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Agent",
                            LastName = "Agentov",
                            LockoutEnabled = false,
                            NormalizedEmail = "agent@mail.com",
                            NormalizedUserName = "agent@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEAZLsqG7TqgXfWecSOWuFVOWJNSA8sFcOYmGlMXAq3p0Htgrv1p4wekXmJw+7A+MAQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6fa16f1d-fbc3-4c11-86fd-2346b02ff1a5",
                            TwoFactorEnabled = false,
                            UserName = "agent@mail.com"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4a659012-94d8-4530-a102-5cfceb82aaf5",
                            Email = "guest@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Guest",
                            LastName = "Guestov",
                            LockoutEnabled = false,
                            NormalizedEmail = "guest@mail.com",
                            NormalizedUserName = "guest@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAED+0EGVF8NEMWaOUieldzWER3QIjeq2dGSLrASYN0IrAPY6nunanOuHBl9qkg+5vaw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d070327c-212c-4189-8b66-cb697eb8b3ed",
                            TwoFactorEnabled = false,
                            UserName = "guest@mail.com"
                        },
                        new
                        {
                            Id = "f5563c5e-d780-4bce-812d-408f2c079ae2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7d28e9fc-b239-445b-9084-d819839eaa7c",
                            Email = "admin@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Great",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@mail.com",
                            NormalizedUserName = "admin@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEOfPsDo+KWv+Y4nViOvIvL74zR+YycFQeY8tYAybSDd35bI9I0mjeH577MO7ubz6vg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f1bc9a4f-fa8d-49e0-9b08-ad696dbea921",
                            TwoFactorEnabled = false,
                            UserName = "admin@mail.com"
                        });
                });

            modelBuilder.Entity("RentingHouseSystem.Infrastructure.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Category Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Category name");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasComment("House category");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Name = "Duplex"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Single-Family"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Cottage"
                        });
                });

            modelBuilder.Entity("RentingHouseSystem.Infrastructure.Data.Models.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("House Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasComment("House address");

                    b.Property<int>("AgentId")
                        .HasColumnType("int")
                        .HasComment("Agent identifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Category identifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("House description");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("House image url");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit")
                        .HasComment("Is approved by the admin");

                    b.Property<decimal>("PricePerMonth")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Monthly price");

                    b.Property<string>("RenterId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User id of the renterer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Title");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("RenterId");

                    b.ToTable("Houses");

                    b.HasComment("House to rent");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Address = "Boyana Neighbourhood, Sofia, Bulgaria",
                            AgentId = 1,
                            CategoryId = 2,
                            Description = "This luxurious house is everything you will need. It is just excellent.",
                            ImageUrl = "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg",
                            IsApproved = false,
                            PricePerMonth = 2000.00m,
                            Title = "Grand House"
                        },
                        new
                        {
                            Id = 1,
                            Address = "North London, UK (near the border)",
                            AgentId = 1,
                            CategoryId = 3,
                            Description = "A big house for your whole family. Don't miss to buy a house with three bedrooms.",
                            ImageUrl = "https://www.luxury-architecture.net/wp-content/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg",
                            IsApproved = false,
                            PricePerMonth = 2100.00m,
                            RenterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            Title = "Big House Marina"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Near the Sea Garden in Burgas, Bulgaria",
                            AgentId = 1,
                            CategoryId = 2,
                            Description = "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.",
                            ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1",
                            IsApproved = false,
                            PricePerMonth = 1200.00m,
                            Title = "Family House Comfort"
                        });
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
                    b.HasOne("RentingHouseSystem.Infrastructure.Data.Models.AplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RentingHouseSystem.Infrastructure.Data.Models.AplicationUser", null)
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

                    b.HasOne("RentingHouseSystem.Infrastructure.Data.Models.AplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RentingHouseSystem.Infrastructure.Data.Models.AplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentingHouseSystem.Infrastructure.Data.Models.Agent", b =>
                {
                    b.HasOne("RentingHouseSystem.Infrastructure.Data.Models.AplicationUser", "User")
                        .WithOne("Agent")
                        .HasForeignKey("RentingHouseSystem.Infrastructure.Data.Models.Agent", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RentingHouseSystem.Infrastructure.Data.Models.House", b =>
                {
                    b.HasOne("RentingHouseSystem.Infrastructure.Data.Models.Agent", "Agent")
                        .WithMany("Houses")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RentingHouseSystem.Infrastructure.Data.Models.Category", "Category")
                        .WithMany("Houses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RentingHouseSystem.Infrastructure.Data.Models.AplicationUser", "Renter")
                        .WithMany()
                        .HasForeignKey("RenterId");

                    b.Navigation("Agent");

                    b.Navigation("Category");

                    b.Navigation("Renter");
                });

            modelBuilder.Entity("RentingHouseSystem.Infrastructure.Data.Models.Agent", b =>
                {
                    b.Navigation("Houses");
                });

            modelBuilder.Entity("RentingHouseSystem.Infrastructure.Data.Models.AplicationUser", b =>
                {
                    b.Navigation("Agent");
                });

            modelBuilder.Entity("RentingHouseSystem.Infrastructure.Data.Models.Category", b =>
                {
                    b.Navigation("Houses");
                });
#pragma warning restore 612, 618
        }
    }
}