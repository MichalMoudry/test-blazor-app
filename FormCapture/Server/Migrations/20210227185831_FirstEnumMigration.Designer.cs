﻿// <auto-generated />
using System;
using FormCapture.Server.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FormCapture.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210227185831_FirstEnumMigration")]
    partial class FirstEnumMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FormCapture.Shared.DbModels.CaptureAppWorkflows", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<string>("AppID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("WorkflowID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkflowName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("AppWorkflows");
                });

            modelBuilder.Entity("FormCapture.Shared.DbModels.CaptureApplication", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<string>("Locale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CaptureApplications");
                });

            modelBuilder.Entity("FormCapture.Shared.DbModels.Field", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<bool>("IsIdentifying")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemplateID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.Property<int>("Xposition")
                        .HasColumnType("int");

                    b.Property<int>("Yposition")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("FormCapture.Shared.DbModels.Notification", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("NotificationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipientID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("FormCapture.Shared.DbModels.ProcessedFile", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Content")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QueueID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("ProcessedFiles");
                });

            modelBuilder.Entity("FormCapture.Shared.DbModels.Queue", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<string>("AppID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppWorkflowTaskGroupID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Queue");
                });

            modelBuilder.Entity("FormCapture.Shared.DbModels.Template", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<string>("AppID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Xdimension")
                        .HasColumnType("int");

                    b.Property<int>("Ydimension")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("FormCapture.Shared.DbModels.UserApps", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<string>("ApplicationID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("UserApps");
                });

            modelBuilder.Entity("FormCapture.Shared.DbModels.UserSetting", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<string>("SettingKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SettingValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("UserSettings");
                });

            modelBuilder.Entity("FormCapture.Shared.DbModels.Workflow", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Workflows");
                });

            modelBuilder.Entity("FormCapture.Shared.DbModels.WorkflowTask", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Content")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("WorkflowTasks");
                });

            modelBuilder.Entity("FormCapture.Shared.DbModels.WorkflowTaskGrouping", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExecutionOrderNumber")
                        .HasColumnType("int");

                    b.Property<string>("TaskGroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("WorkflowID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TaskGroupings");
                });

            modelBuilder.Entity("FormCapture.Shared.DbModels.WorkflowTaskParameter", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<string>("ParameterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParemeterValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("WorkflowTaskParameters");
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

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "80cf0060-15a0-48b1-abdb-d3477bf590c1",
                            ConcurrencyStamp = "06c557bd-3f50-4660-bfcf-dd836e822557",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "05d537cd-0d5a-4af0-b939-6c1147da7d22",
                            ConcurrencyStamp = "f06053fd-8885-4655-a5de-3167f4fa04e7",
                            Name = "Workflow admin",
                            NormalizedName = "WORKFLOW ADMIN"
                        },
                        new
                        {
                            Id = "4d75db4e-f192-4093-9720-4012803ebd5c",
                            ConcurrencyStamp = "e24bd948-a4f7-4ce7-8f29-1cc97c5e56a9",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
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

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
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

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
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

                    b.ToTable("AspNetUserTokens");
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
#pragma warning restore 612, 618
        }
    }
}
