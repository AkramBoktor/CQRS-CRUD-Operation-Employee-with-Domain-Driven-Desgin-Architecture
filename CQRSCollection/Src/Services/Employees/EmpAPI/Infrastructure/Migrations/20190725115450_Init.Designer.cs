﻿// <auto-generated />
using Emp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Employee.Infrastructure.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20190725115450_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:emp.EmployeeDb", "'EmployeeDb', 'emp', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Emp.Domain.AggregatesModel.EmployeeAggregate.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "EmployeeDb")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "emp")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Description");

                    b.Property<int>("EmployeeLevelId");

                    b.Property<int>("EmployeePositionId");

                    b.Property<string>("ImagePath");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EmployeeLevelId");

                    b.HasIndex("EmployeePositionId");

                    b.ToTable("Employees","emp");
                });

            modelBuilder.Entity("Emp.Domain.AggregatesModel.EmployeeAggregate.EmployeeLevel", b =>
                {
                    b.Property<int>("Id")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Employeelevel","emp");
                });

            modelBuilder.Entity("Emp.Domain.AggregatesModel.EmployeeAggregate.EmployeePosition", b =>
                {
                    b.Property<int>("Id")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("EmployeePosition","emp");
                });

            modelBuilder.Entity("Emp.Domain.AggregatesModel.EmployeeAggregate.Employee", b =>
                {
                    b.HasOne("Emp.Domain.AggregatesModel.EmployeeAggregate.EmployeeLevel", "EmployeeLevel")
                        .WithMany()
                        .HasForeignKey("EmployeeLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Emp.Domain.AggregatesModel.EmployeeAggregate.EmployeePosition", "EmployeePosition")
                        .WithMany()
                        .HasForeignKey("EmployeePositionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Emp.Domain.AggregatesModel.EmployeeAggregate.Address", "Address", b1 =>
                        {
                            b1.Property<int>("EmployeeId");

                            b1.Property<string>("City");

                            b1.Property<string>("Country");

                            b1.Property<string>("Street");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employees","emp");

                            b1.HasOne("Emp.Domain.AggregatesModel.EmployeeAggregate.Employee")
                                .WithOne("Address")
                                .HasForeignKey("Emp.Domain.AggregatesModel.EmployeeAggregate.Address", "EmployeeId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
