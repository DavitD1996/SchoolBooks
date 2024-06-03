﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolBooks.Context;

#nullable disable

namespace SchoolBooks.Migrations
{
    [DbContext(typeof(SchoolBooksContext))]
    [Migration("20240603070604_test")]
    partial class test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookPupil", b =>
                {
                    b.Property<string>("BooksId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PupilsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BooksId", "PupilsId");

                    b.HasIndex("PupilsId");

                    b.ToTable("BookPupil");
                });

            modelBuilder.Entity("SchoolBooks.Entities.Book", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PublisherName");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("SchoolBooks.Entities.Publisher", b =>
                {
                    b.Property<string>("PublisherName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PublisherName");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("SchoolBooks.Entities.Pupil", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SchoolName");

                    b.ToTable("Pupils");
                });

            modelBuilder.Entity("SchoolBooks.Entities.School", b =>
                {
                    b.Property<string>("SchoolName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SchoolName");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("BookPupil", b =>
                {
                    b.HasOne("SchoolBooks.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolBooks.Entities.Pupil", null)
                        .WithMany()
                        .HasForeignKey("PupilsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolBooks.Entities.Book", b =>
                {
                    b.HasOne("SchoolBooks.Entities.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("SchoolBooks.Entities.Pupil", b =>
                {
                    b.HasOne("SchoolBooks.Entities.School", "School")
                        .WithMany("Pupils")
                        .HasForeignKey("SchoolName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("SchoolBooks.Entities.Publisher", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("SchoolBooks.Entities.School", b =>
                {
                    b.Navigation("Pupils");
                });
#pragma warning restore 612, 618
        }
    }
}
