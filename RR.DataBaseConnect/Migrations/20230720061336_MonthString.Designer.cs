﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RR.DataBaseConnect;

#nullable disable

namespace RR.DataBaseConnect.Migrations
{
    [DbContext(typeof(DataBaseAccess))]
    [Migration("20230720061336_MonthString")]
    partial class MonthString
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RR.Models.EmployeeInfo.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserPassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.HasIndex("UserPassId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("RR.Models.EmployeeInfo.EmployeeRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmpId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("IdOfRole")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RoleId");

                    b.ToTable("EmployeeRoles");
                });

            modelBuilder.Entity("RR.Models.EmployeeInfo.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("RR.Models.EmployeeInfo.UserNamePassword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("employeeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserNamePassword");
                });

            modelBuilder.Entity("RR.Models.OtherRewardsInfo.LeadCitation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CampaignId")
                        .HasColumnType("int");

                    b.Property<string>("Citation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NominatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.ToTable("LeadCitation");
                });

            modelBuilder.Entity("RR.Models.OtherRewardsInfo.LeadCitationReplies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<int>("LeadCitationId")
                        .HasColumnType("int");

                    b.Property<string>("NominatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReplierId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReplyCitation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("LeadCitationId");

                    b.ToTable("LeadCitationReplies");
                });

            modelBuilder.Entity("RR.Models.OtherRewardsInfo.OtherRewardResults", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AwardCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CampId")
                        .HasColumnType("int");

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<string>("CampaignName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IfOfNomination")
                        .HasColumnType("int");

                    b.Property<string>("NominatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NomineeEmpId")
                        .HasColumnType("int");

                    b.Property<string>("NomineeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RewardId")
                        .HasColumnType("int");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.Property<string>("VoterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CampId");

                    b.HasIndex("IfOfNomination");

                    b.HasIndex("NomineeEmpId");

                    b.ToTable("OtherRewardResults");
                });

            modelBuilder.Entity("RR.Models.OtherRewardsInfo.OtherRewards", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AwardCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("IdOFCampaign")
                        .HasColumnType("int");

                    b.Property<int?>("IdOfCitation")
                        .HasColumnType("int");

                    b.Property<string>("Month")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NominatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomineeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RewardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("IdOFCampaign");

                    b.HasIndex("IdOfCitation");

                    b.ToTable("OtherRewards");
                });

            modelBuilder.Entity("RR.Models.PeerToPeerInfo.PeerToPeer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AwardCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<string>("Citation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Month")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NominatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomineeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PeerToPeerResultsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PeerToPeerResultsId");

                    b.ToTable("PeerToPeer");
                });

            modelBuilder.Entity("RR.Models.PeerToPeerInfo.PeerToPeerResults", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Citation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdOfCampaign")
                        .HasColumnType("int");

                    b.Property<int?>("IdOfNominee")
                        .HasColumnType("int");

                    b.Property<string>("NominatorId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomineeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("awardCategory")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdOfCampaign");

                    b.HasIndex("IdOfNominee");

                    b.ToTable("PeerToPeerResults");
                });

            modelBuilder.Entity("RR.Models.Rewards_Campaigns.AwardCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdOfReward")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RewardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RewardId");

                    b.ToTable("AwardCategory");
                });

            modelBuilder.Entity("RR.Models.Rewards_Campaigns.Campaigns", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CampaignName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RewardId")
                        .HasColumnType("int");

                    b.Property<int?>("RewardTypesId")
                        .HasColumnType("int");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("votingDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RewardTypesId");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("RR.Models.Rewards_Campaigns.RewardType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RewardTypes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RewardType");
                });

            modelBuilder.Entity("RR.Models.EmployeeInfo.Employee", b =>
                {
                    b.HasOne("RR.Models.EmployeeInfo.UserNamePassword", "UserNamePassword")
                        .WithMany()
                        .HasForeignKey("UserPassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserNamePassword");
                });

            modelBuilder.Entity("RR.Models.EmployeeInfo.EmployeeRoles", b =>
                {
                    b.HasOne("RR.Models.EmployeeInfo.Employee", null)
                        .WithMany("Roles")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("RR.Models.EmployeeInfo.Roles", "role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("role");
                });

            modelBuilder.Entity("RR.Models.OtherRewardsInfo.LeadCitation", b =>
                {
                    b.HasOne("RR.Models.Rewards_Campaigns.Campaigns", "Campaigns")
                        .WithMany()
                        .HasForeignKey("CampaignId");

                    b.Navigation("Campaigns");
                });

            modelBuilder.Entity("RR.Models.OtherRewardsInfo.LeadCitationReplies", b =>
                {
                    b.HasOne("RR.Models.Rewards_Campaigns.Campaigns", "Campaigns")
                        .WithMany()
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RR.Models.OtherRewardsInfo.LeadCitation", null)
                        .WithMany("LeadCitationReplies")
                        .HasForeignKey("LeadCitationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaigns");
                });

            modelBuilder.Entity("RR.Models.OtherRewardsInfo.OtherRewardResults", b =>
                {
                    b.HasOne("RR.Models.Rewards_Campaigns.Campaigns", "Campaigns")
                        .WithMany()
                        .HasForeignKey("CampId");

                    b.HasOne("RR.Models.OtherRewardsInfo.OtherRewards", "OtherRewards")
                        .WithMany()
                        .HasForeignKey("IfOfNomination");

                    b.HasOne("RR.Models.EmployeeInfo.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("NomineeEmpId");

                    b.Navigation("Campaigns");

                    b.Navigation("Employee");

                    b.Navigation("OtherRewards");
                });

            modelBuilder.Entity("RR.Models.OtherRewardsInfo.OtherRewards", b =>
                {
                    b.HasOne("RR.Models.EmployeeInfo.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("RR.Models.Rewards_Campaigns.Campaigns", "Campaigns")
                        .WithMany()
                        .HasForeignKey("IdOFCampaign")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RR.Models.OtherRewardsInfo.LeadCitation", "LeadCitation")
                        .WithMany()
                        .HasForeignKey("IdOfCitation");

                    b.Navigation("Campaigns");

                    b.Navigation("Employee");

                    b.Navigation("LeadCitation");
                });

            modelBuilder.Entity("RR.Models.PeerToPeerInfo.PeerToPeer", b =>
                {
                    b.HasOne("RR.Models.Rewards_Campaigns.Campaigns", "Campaigns")
                        .WithMany()
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RR.Models.EmployeeInfo.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("RR.Models.PeerToPeerInfo.PeerToPeerResults", "PeerToPeerResults")
                        .WithMany()
                        .HasForeignKey("PeerToPeerResultsId");

                    b.Navigation("Campaigns");

                    b.Navigation("Employee");

                    b.Navigation("PeerToPeerResults");
                });

            modelBuilder.Entity("RR.Models.PeerToPeerInfo.PeerToPeerResults", b =>
                {
                    b.HasOne("RR.Models.Rewards_Campaigns.Campaigns", "campaigns")
                        .WithMany()
                        .HasForeignKey("IdOfCampaign")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RR.Models.EmployeeInfo.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("IdOfNominee");

                    b.Navigation("Employee");

                    b.Navigation("campaigns");
                });

            modelBuilder.Entity("RR.Models.Rewards_Campaigns.AwardCategory", b =>
                {
                    b.HasOne("RR.Models.Rewards_Campaigns.RewardType", "RewardType")
                        .WithMany()
                        .HasForeignKey("RewardId");

                    b.Navigation("RewardType");
                });

            modelBuilder.Entity("RR.Models.Rewards_Campaigns.Campaigns", b =>
                {
                    b.HasOne("RR.Models.Rewards_Campaigns.RewardType", "RewardTypes")
                        .WithMany()
                        .HasForeignKey("RewardTypesId");

                    b.Navigation("RewardTypes");
                });

            modelBuilder.Entity("RR.Models.EmployeeInfo.Employee", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("RR.Models.OtherRewardsInfo.LeadCitation", b =>
                {
                    b.Navigation("LeadCitationReplies");
                });
#pragma warning restore 612, 618
        }
    }
}
