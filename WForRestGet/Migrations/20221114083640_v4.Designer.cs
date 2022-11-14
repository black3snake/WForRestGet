﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WForRestGet.DataModel;

namespace WForRestGet.Migrations
{
    [DbContext(typeof(DataModelContext))]
    [Migration("20221114083640_v4")]
    partial class v4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WForRestGet.DataModel.Answer", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("AnswerDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("AnswerType")
                        .IsRequired()
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnswerDescription = "Автоответа статус неизвестен",
                            AnswerType = "AN"
                        },
                        new
                        {
                            Id = 2,
                            AnswerDescription = "Exception на установку ответа",
                            AnswerType = "AA"
                        },
                        new
                        {
                            Id = 3,
                            AnswerDescription = "Автоответ установлен",
                            AnswerType = "AG"
                        },
                        new
                        {
                            Id = 4,
                            AnswerDescription = "Автоответ установлен пользователем",
                            AnswerType = "AU"
                        });
                });

            modelBuilder.Entity("WForRestGet.DataModel.Datauser", b =>
                {
                    b.Property<string>("FimSyncKey")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("AccountName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<DateTime?>("DateIn")
                        .HasColumnType("date");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("Disabled")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("EmployeeNumber")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("LeaveEnd")
                        .HasColumnType("date");

                    b.Property<int?>("LeaveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("LeaveStart")
                        .HasColumnType("date");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("FimSyncKey");

                    b.HasIndex("AnswerId");

                    b.HasIndex("LeaveId");

                    b.ToTable("Datausers");
                });

            modelBuilder.Entity("WForRestGet.DataModel.Leave", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("LeaveDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("LeaveType")
                        .IsRequired()
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.ToTable("Leaves");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LeaveDescription = "отпуск",
                            LeaveType = "VC"
                        },
                        new
                        {
                            Id = 2,
                            LeaveDescription = "больничный",
                            LeaveType = "SL"
                        },
                        new
                        {
                            Id = 3,
                            LeaveDescription = "командировка",
                            LeaveType = "BT"
                        },
                        new
                        {
                            Id = 4,
                            LeaveDescription = "декретный отпуск",
                            LeaveType = "DV"
                        });
                });

            modelBuilder.Entity("WForRestGet.DataModel.Datauser", b =>
                {
                    b.HasOne("WForRestGet.DataModel.Answer", "Answer")
                        .WithMany("Datausers")
                        .HasForeignKey("AnswerId");

                    b.HasOne("WForRestGet.DataModel.Leave", "Leave")
                        .WithMany("Datausers")
                        .HasForeignKey("LeaveId");
                });
#pragma warning restore 612, 618
        }
    }
}
