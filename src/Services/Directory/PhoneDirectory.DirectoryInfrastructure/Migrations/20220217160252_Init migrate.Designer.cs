// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PhoneDirectory.DirectoryInfrastructure;

#nullable disable

namespace PhoneDirectory.DirectoryInfrastructure.Migrations
{
    [DbContext(typeof(DirectoryDbContext))]
    [Migration("20220217160252_Init migrate")]
    partial class Initmigrate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PhoneDirectory.DirectoryApplicationCore.Domain.PersonAggregate.ContactInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("InformationContent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("InformationType")
                        .HasColumnType("integer");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("ContactInformations");
                });

            modelBuilder.Entity("PhoneDirectory.DirectoryApplicationCore.Domain.PersonAggregate.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PhoneDirectory.DirectoryApplicationCore.Domain.PersonAggregate.ContactInformation", b =>
                {
                    b.HasOne("PhoneDirectory.DirectoryApplicationCore.Domain.PersonAggregate.Person", null)
                        .WithMany("ContactInformations")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PhoneDirectory.DirectoryApplicationCore.Domain.PersonAggregate.Person", b =>
                {
                    b.Navigation("ContactInformations");
                });
#pragma warning restore 612, 618
        }
    }
}
