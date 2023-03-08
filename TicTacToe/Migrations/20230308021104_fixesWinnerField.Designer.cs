﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicTacToe.Models.Context;

#nullable disable

namespace TicTacToe.Migrations
{
    [DbContext(typeof(TicTacToeContext))]
    [Migration("20230308021104_fixesWinnerField")]
    partial class fixesWinnerField
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TicTacToe.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2023, 3, 8, 2, 11, 3, 851, DateTimeKind.Utc).AddTicks(8329))
                        .HasColumnName("created");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("creator");

                    b.Property<string>("CurrentTurnTeam")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("current_turn_team");

                    b.Property<string>("GameArea")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("{\"1\":\"\",\"2\":\"\",\"3\":\"\",\"4\":\"\",\"5\":\"\",\"6\":\"\",\"7\":\"\",\"8\":\"\",\"9\":\"\"}")
                        .HasColumnName("game_area");

                    b.Property<string>("PlayersInRoom")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("{\"X\":\"\",\"O\":\"\"}")
                        .HasColumnName("players_in_room");

                    b.Property<string>("RoomCode")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("room_code");

                    b.Property<string>("Winner")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("winner");

                    b.HasKey("Id");

                    b.HasIndex("RoomCode")
                        .IsUnique();

                    b.ToTable("rooms", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}