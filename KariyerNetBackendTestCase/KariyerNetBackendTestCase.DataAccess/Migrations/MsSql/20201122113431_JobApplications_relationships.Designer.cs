﻿// <auto-generated />
using System;
using KariyerNetBackendTestCase.DataAccess.Implementation.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KariyerNetBackendTestCase.DataAccess.Migrations.MsSql
{
    [DbContext(typeof(KariyerNetBackendTestCaseDbContext))]
    [Migration("20201122113431_JobApplications_relationships")]
    partial class JobApplications_relationships
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("KariyerNetBackendTestCase.Entity.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("CompanyAddress")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("IsActive", "IsDeleted")
                        .HasDatabaseName("Companies_Mgr_NCIndex_22112020")
                        .IsClustered(false);

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("KariyerNetBackendTestCase.Entity.CompanyJobAdvertisement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("AdvertisementName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<short>("CountryId")
                        .HasColumnType("smallint");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<DateTimeOffset>("ExpirationTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnType("bigint");

                    b.Property<int>("TownId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId")
                        .HasDatabaseName("CompanyJobAdvertisement_CompanyId_Mgr_NCIndex_22112020")
                        .IsClustered(false);

                    b.ToTable("CompanyJobAdvertisements");
                });

            modelBuilder.Entity("KariyerNetBackendTestCase.Entity.JobApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApplicationLetter")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<long>("CompanyJobAdvertisementId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsViewed")
                        .HasColumnType("bit");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("ViewTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CompanyJobAdvertisementId");

                    b.HasIndex("IsDeleted")
                        .HasDatabaseName("JobApplications_Mgr_NCIndex_22112020")
                        .IsClustered(false);

                    b.HasIndex("IsViewed")
                        .HasDatabaseName("JobApplications_Mgr_IsViewed_NCIndex_22112020")
                        .IsClustered(false);

                    b.HasIndex("UserId");

                    b.ToTable("JobApplications");
                });

            modelBuilder.Entity("KariyerNetBackendTestCase.Entity.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("BornDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<long?>("UserCvId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("UserCvId");

                    b.HasIndex("IsActive", "IsDeleted")
                        .HasDatabaseName("Users_Mgr_NCIndex_22112020")
                        .IsClustered(false);

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KariyerNetBackendTestCase.Entity.UserCv", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<short>("CountryId")
                        .HasColumnType("smallint");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("SummaryInformation")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("TownId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("UpdatedTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CountryId", "CityId")
                        .HasDatabaseName("UserCv_Mgr_NCIndex_22112020")
                        .IsClustered(false);

                    b.ToTable("UserCv");
                });

            modelBuilder.Entity("KariyerNetBackendTestCase.Entity.UserCvEducation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<short?>("EndYear")
                        .HasColumnType("smallint");

                    b.Property<decimal>("GradeAverage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsAbandoned")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<short>("SchoolLevel")
                        .HasColumnType("smallint");

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<short>("StartYear")
                        .HasColumnType("smallint");

                    b.Property<long>("UserCvId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserCvId")
                        .HasDatabaseName("UserCvEducations_Mgr_NCIndex_22112020")
                        .IsClustered(false);

                    b.ToTable("UserCvEducations");
                });

            modelBuilder.Entity("KariyerNetBackendTestCase.Entity.UserCvWorkingExperience", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<short>("CompanySector")
                        .HasColumnType("smallint");

                    b.Property<short>("CountryId")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<long>("UserCvId")
                        .HasColumnType("bigint");

                    b.Property<string>("WorkDetail")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("UserCvId")
                        .HasDatabaseName("UserCvWorkingExperience_Mgr_NCIndex_22112020")
                        .IsClustered(false);

                    b.ToTable("UserCvWorkingExperiences");
                });

            modelBuilder.Entity("KariyerNetBackendTestCase.Entity.CompanyJobAdvertisement", b =>
                {
                    b.HasOne("KariyerNetBackendTestCase.Entity.Company", "Company")
                        .WithMany("CompanyJobAdvertisements")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("KariyerNetBackendTestCase.Entity.JobApplication", b =>
                {
                    b.HasOne("KariyerNetBackendTestCase.Entity.CompanyJobAdvertisement", "CompanyJobAdvertisement")
                        .WithMany("JobApplications")
                        .HasForeignKey("CompanyJobAdvertisementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KariyerNetBackendTestCase.Entity.User", "User")
                        .WithMany("JobApplications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyJobAdvertisement");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KariyerNetBackendTestCase.Entity.User", b =>
                {
                    b.HasOne("KariyerNetBackendTestCase.Entity.UserCv", "UserCv")
                        .WithMany()
                        .HasForeignKey("UserCvId");

                    b.Navigation("UserCv");
                });

            modelBuilder.Entity("KariyerNetBackendTestCase.Entity.UserCvEducation", b =>
                {
                    b.HasOne("KariyerNetBackendTestCase.Entity.UserCv", "UserCvDetail")
                        .WithMany("EducationDetails")
                        .HasForeignKey("UserCvId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserCvDetail");
                });

            modelBuilder.Entity("KariyerNetBackendTestCase.Entity.UserCvWorkingExperience", b =>
                {
                    b.HasOne("KariyerNetBackendTestCase.Entity.UserCv", "UserCvDetail")
                        .WithMany("WorkingExperiences")
                        .HasForeignKey("UserCvId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserCvDetail");
                });

            modelBuilder.Entity("KariyerNetBackendTestCase.Entity.Company", b =>
                {
                    b.Navigation("CompanyJobAdvertisements");
                });

            modelBuilder.Entity("KariyerNetBackendTestCase.Entity.CompanyJobAdvertisement", b =>
                {
                    b.Navigation("JobApplications");
                });

            modelBuilder.Entity("KariyerNetBackendTestCase.Entity.User", b =>
                {
                    b.Navigation("JobApplications");
                });

            modelBuilder.Entity("KariyerNetBackendTestCase.Entity.UserCv", b =>
                {
                    b.Navigation("EducationDetails");

                    b.Navigation("WorkingExperiences");
                });
#pragma warning restore 612, 618
        }
    }
}
