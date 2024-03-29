﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MissingPeople.Infrastructure.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MissingPeople.Infrastructure.Migrations
{
    [DbContext(typeof(MissingPeopleDbContext))]
    [Migration("20220123220936_tests")]
    partial class tests
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("MissingPeople.Core.Entities.Dictionaries.DictCity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("CordinateX")
                        .HasColumnType("double precision");

                    b.Property<double>("CordinateY")
                        .HasColumnType("double precision");

                    b.Property<int>("IdentifierTeryt")
                        .HasColumnType("integer");

                    b.Property<string>("Latitude")
                        .HasColumnType("text");

                    b.Property<string>("Longitude")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("DictCities");
                });

            modelBuilder.Entity("MissingPeople.Core.Entities.Dictionaries.DictEye", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DictEyes");
                });

            modelBuilder.Entity("MissingPeople.Core.Entities.Dictionaries.DictProvince", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DictProvinces");
                });

            modelBuilder.Entity("MissingPeople.Core.Entities.Peoples.DangerOfLife", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsAtRisk")
                        .HasColumnType("boolean");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("DangersOfLife");
                });

            modelBuilder.Entity("MissingPeople.Core.Entities.Peoples.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasIdentityOptions(1274L, null, null, null, null, null)
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("DateOfDisappear")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("DictCityID")
                        .HasColumnType("integer");

                    b.Property<int?>("DictEyeID")
                        .HasColumnType("integer");

                    b.Property<bool>("IsWaiting")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("SecondName")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<int>("YearOfBirth")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DictCityID");

                    b.HasIndex("DictEyeID");

                    b.ToTable("People");
                });

            modelBuilder.Entity("MissingPeople.Core.Entities.Peoples.PersonDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClothesDescription")
                        .HasColumnType("text");

                    b.Property<int?>("HeightFrom")
                        .HasColumnType("integer");

                    b.Property<int?>("HeightTo")
                        .HasColumnType("integer");

                    b.Property<string>("OtherDetails")
                        .HasColumnType("text");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer");

                    b.Property<string>("ScarsDescription")
                        .HasColumnType("text");

                    b.Property<string>("TatoosDescription")
                        .HasColumnType("text");

                    b.Property<int?>("WeightFrom")
                        .HasColumnType("integer");

                    b.Property<int?>("WeightTo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("PersonDetails");
                });

            modelBuilder.Entity("MissingPeople.Core.Entities.Peoples.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("MissingPeople.Core.Entities.Dictionaries.DictCity", b =>
                {
                    b.HasOne("MissingPeople.Core.Entities.Dictionaries.DictProvince", "Provinces")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provinces");
                });

            modelBuilder.Entity("MissingPeople.Core.Entities.Peoples.DangerOfLife", b =>
                {
                    b.HasOne("MissingPeople.Core.Entities.Peoples.Person", "Person")
                        .WithOne("DangerOfLife")
                        .HasForeignKey("MissingPeople.Core.Entities.Peoples.DangerOfLife", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MissingPeople.Core.Entities.Peoples.Person", b =>
                {
                    b.HasOne("MissingPeople.Core.Entities.Dictionaries.DictCity", "DictCity")
                        .WithMany("People")
                        .HasForeignKey("DictCityID");

                    b.HasOne("MissingPeople.Core.Entities.Dictionaries.DictEye", "DictEye")
                        .WithMany("Persons")
                        .HasForeignKey("DictEyeID");

                    b.Navigation("DictCity");

                    b.Navigation("DictEye");
                });

            modelBuilder.Entity("MissingPeople.Core.Entities.Peoples.PersonDetail", b =>
                {
                    b.HasOne("MissingPeople.Core.Entities.Peoples.Person", "Person")
                        .WithOne("PersonDetail")
                        .HasForeignKey("MissingPeople.Core.Entities.Peoples.PersonDetail", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MissingPeople.Core.Entities.Peoples.Picture", b =>
                {
                    b.HasOne("MissingPeople.Core.Entities.Peoples.Person", "Person")
                        .WithMany("Pictures")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MissingPeople.Core.Entities.Dictionaries.DictCity", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("MissingPeople.Core.Entities.Dictionaries.DictEye", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("MissingPeople.Core.Entities.Dictionaries.DictProvince", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("MissingPeople.Core.Entities.Peoples.Person", b =>
                {
                    b.Navigation("DangerOfLife");

                    b.Navigation("PersonDetail");

                    b.Navigation("Pictures");
                });
#pragma warning restore 612, 618
        }
    }
}
