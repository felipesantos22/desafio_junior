﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using appmedic.Infrastructure.Data;

#nullable disable

namespace appmedic.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231215032415_AddFoKey")]
    partial class AddFoKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("appmedic.Domain.Entities.Consultation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatienteId");

                    b.ToTable("Consultations");
                });

            modelBuilder.Entity("appmedic.Domain.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("varchar(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CRM")
                        .IsUnique();

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("appmedic.Domain.Entities.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId")
                        .IsUnique();

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("appmedic.Domain.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("appmedic.Domain.Entities.Consultation", b =>
                {
                    b.HasOne("appmedic.Domain.Entities.Doctor", "Doctor")
                        .WithMany("Consultations")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("appmedic.Domain.Entities.Patient", "Patient")
                        .WithMany("Consultations")
                        .HasForeignKey("PatienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("appmedic.Domain.Entities.Login", b =>
                {
                    b.HasOne("appmedic.Domain.Entities.Doctor", "Doctor")
                        .WithOne("Login")
                        .HasForeignKey("appmedic.Domain.Entities.Login", "DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("appmedic.Domain.Entities.Patient", "Patient")
                        .WithOne("Login")
                        .HasForeignKey("appmedic.Domain.Entities.Login", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("appmedic.Domain.Entities.Doctor", b =>
                {
                    b.Navigation("Consultations");

                    b.Navigation("Login")
                        .IsRequired();
                });

            modelBuilder.Entity("appmedic.Domain.Entities.Patient", b =>
                {
                    b.Navigation("Consultations");

                    b.Navigation("Login")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
