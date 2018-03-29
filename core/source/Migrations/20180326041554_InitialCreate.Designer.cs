﻿// <auto-generated />
using FantasyWorldCup.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace FantasyWorldCup.Core.Migrations
{
    [DbContext(typeof(TournamentContext))]
    [Migration("20180326041554_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("FantasyWorldCup.Core.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("Schedule");

                    b.Property<int>("Status");

                    b.Property<string>("TeamAId");

                    b.Property<int>("TeamAScore");

                    b.Property<string>("TeamBId");

                    b.Property<int>("TeamBScore");

                    b.Property<int>("TournamentId");

                    b.HasKey("Id");

                    b.HasIndex("TeamAId");

                    b.HasIndex("TeamBId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("FantasyWorldCup.Core.Models.Team", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("FantasyWorldCup.Core.Models.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("FantasyWorldCup.Core.Models.Match", b =>
                {
                    b.HasOne("FantasyWorldCup.Core.Models.Team", "TeamA")
                        .WithMany()
                        .HasForeignKey("TeamAId");

                    b.HasOne("FantasyWorldCup.Core.Models.Team", "TeamB")
                        .WithMany()
                        .HasForeignKey("TeamBId");

                    b.HasOne("FantasyWorldCup.Core.Models.Tournament", "Tournament")
                        .WithMany("Matches")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}