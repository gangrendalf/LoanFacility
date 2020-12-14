﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(LoanFacilityContext))]
    partial class LoanFacilityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Core.Entities.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("InterestPerYearId")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("MaxAmount")
                        .HasColumnType("uint(6)");

                    b.Property<ushort>("MaxDuration")
                        .HasColumnType("ushort(2)");

                    b.Property<uint>("MinAmount")
                        .HasColumnType("uint(6)");

                    b.Property<ushort>("MinDuration")
                        .HasColumnType("ushort(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("InterestPerYearId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("Core.Entities.Rate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Interest")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("Core.Entities.Loan", b =>
                {
                    b.HasOne("Core.Entities.Rate", "InterestPerYear")
                        .WithMany()
                        .HasForeignKey("InterestPerYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InterestPerYear");
                });
#pragma warning restore 612, 618
        }
    }
}
