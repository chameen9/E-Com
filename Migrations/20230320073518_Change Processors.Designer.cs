﻿// <auto-generated />
using System;
using E_Com.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_Com.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230320073518_Change Processors")]
    partial class ChangeProcessors
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("E_Com.Models.Data.MemoryDevices", b =>
                {
                    b.Property<int>("MemoryDeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("MemoryBrand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MemoryName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MemoryType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("MemoryDeviceId");

                    b.ToTable("MemoryDevices");
                });

            modelBuilder.Entity("E_Com.Models.Data.OperatingSytems", b =>
                {
                    b.Property<int>("OSId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("OSBrand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OSEdition")
                        .HasColumnType("longtext");

                    b.Property<string>("OSVersion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("OSId");

                    b.ToTable("OperatingSytems");
                });

            modelBuilder.Entity("E_Com.Models.Data.Processors", b =>
                {
                    b.Property<int>("ProcessorTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ProcessorBrand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProcessorGeneration")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProcessorSpeed")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProcessorType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ProcessorTypeId");

                    b.ToTable("Processors");
                });

            modelBuilder.Entity("E_Com.Models.Data.Products", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MemoryDeviceId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OSId")
                        .HasColumnType("int");

                    b.Property<int>("OperatingSytemsOSId")
                        .HasColumnType("int");

                    b.Property<int>("ProcessorTypeId")
                        .HasColumnType("int");

                    b.Property<int>("StorageDeviceId")
                        .HasColumnType("int");

                    b.Property<int>("VGADeviceId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("MemoryDeviceId");

                    b.HasIndex("OperatingSytemsOSId");

                    b.HasIndex("ProcessorTypeId");

                    b.HasIndex("StorageDeviceId");

                    b.HasIndex("VGADeviceId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("E_Com.Models.Data.StorageDevices", b =>
                {
                    b.Property<int>("StorageDeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("StorageDeviceName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StrageDeviceCapacity")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StrageDeviceType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("StorageDeviceId");

                    b.ToTable("StorageDevices");
                });

            modelBuilder.Entity("E_Com.Models.Data.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Paswword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.HasIndex("TypeId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("E_Com.Models.Data.UserTypes", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("TypeId");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("E_Com.Models.Data.VGADevices", b =>
                {
                    b.Property<int>("VGADeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("VGABrand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("VGARefreshRate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("VGAVRAMSize")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("VGADeviceId");

                    b.ToTable("VGADevices");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("E_Com.Models.Data.Products", b =>
                {
                    b.HasOne("E_Com.Models.Data.MemoryDevices", "MemoryDevices")
                        .WithMany("Products")
                        .HasForeignKey("MemoryDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Com.Models.Data.OperatingSytems", "OperatingSytems")
                        .WithMany("Products")
                        .HasForeignKey("OperatingSytemsOSId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Com.Models.Data.Processors", "Processors")
                        .WithMany("Products")
                        .HasForeignKey("ProcessorTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Com.Models.Data.StorageDevices", "StorageDevices")
                        .WithMany()
                        .HasForeignKey("StorageDeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Com.Models.Data.VGADevices", "VGADevices")
                        .WithMany("Products")
                        .HasForeignKey("VGADeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MemoryDevices");

                    b.Navigation("OperatingSytems");

                    b.Navigation("Processors");

                    b.Navigation("StorageDevices");

                    b.Navigation("VGADevices");
                });

            modelBuilder.Entity("E_Com.Models.Data.User", b =>
                {
                    b.HasOne("E_Com.Models.Data.UserTypes", "UserTypes")
                        .WithMany("User")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserTypes");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_Com.Models.Data.MemoryDevices", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("E_Com.Models.Data.OperatingSytems", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("E_Com.Models.Data.Processors", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("E_Com.Models.Data.UserTypes", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("E_Com.Models.Data.VGADevices", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
