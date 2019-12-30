﻿// <auto-generated />
using System;
using BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEnd.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("BackEnd.Data.Attendee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.HasKey("ID");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Attendees");
                });

            modelBuilder.Entity("BackEnd.Data.Conference", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.HasKey("ID");

                    b.ToTable("Conferences");
                });

            modelBuilder.Entity("BackEnd.Data.ConferenceAttendee", b =>
                {
                    b.Property<int>("ConferenceID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AttendeeID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ConferenceID", "AttendeeID");

                    b.HasIndex("AttendeeID");

                    b.ToTable("ConferenceAttendee");
                });

            modelBuilder.Entity("BackEnd.Data.Session", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Abstract")
                        .HasColumnType("TEXT")
                        .HasMaxLength(4000);

                    b.Property<int>("ConferenceID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<int?>("TrackId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("ConferenceID");

                    b.HasIndex("TrackId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("BackEnd.Data.SessionAttendee", b =>
                {
                    b.Property<int>("SessionID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AttendeeID")
                        .HasColumnType("INTEGER");

                    b.HasKey("SessionID", "AttendeeID");

                    b.HasIndex("AttendeeID");

                    b.ToTable("SessionAttendee");
                });

            modelBuilder.Entity("BackEnd.Data.SessionSpeaker", b =>
                {
                    b.Property<int>("SessionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpeakerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SessionId", "SpeakerId");

                    b.HasIndex("SpeakerId");

                    b.ToTable("SessionSpeaker");
                });

            modelBuilder.Entity("BackEnd.Data.SessionTag", b =>
                {
                    b.Property<int>("SessionID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagID")
                        .HasColumnType("INTEGER");

                    b.HasKey("SessionID", "TagID");

                    b.HasIndex("TagID");

                    b.ToTable("SessionTag");
                });

            modelBuilder.Entity("BackEnd.Data.Speaker", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .HasColumnType("TEXT")
                        .HasMaxLength(4000);

                    b.Property<int?>("ConferenceID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<string>("WebSite")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000);

                    b.HasKey("ID");

                    b.HasIndex("ConferenceID");

                    b.ToTable("Speakers");
                });

            modelBuilder.Entity("BackEnd.Data.Tag", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(32);

                    b.HasKey("ID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("BackEnd.Data.Track", b =>
                {
                    b.Property<int>("TrackID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ConferenceID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.HasKey("TrackID");

                    b.HasIndex("ConferenceID");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("BackEnd.Data.ConferenceAttendee", b =>
                {
                    b.HasOne("BackEnd.Data.Attendee", "Attendee")
                        .WithMany("ConferenceAttendees")
                        .HasForeignKey("AttendeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Data.Conference", "Conference")
                        .WithMany("ConferenceAttendees")
                        .HasForeignKey("ConferenceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEnd.Data.Session", b =>
                {
                    b.HasOne("BackEnd.Data.Conference", "Conference")
                        .WithMany("Sessions")
                        .HasForeignKey("ConferenceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Data.Track", "Track")
                        .WithMany("Sessions")
                        .HasForeignKey("TrackId");
                });

            modelBuilder.Entity("BackEnd.Data.SessionAttendee", b =>
                {
                    b.HasOne("BackEnd.Data.Attendee", "Attendee")
                        .WithMany("SessionsAttendees")
                        .HasForeignKey("AttendeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Data.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEnd.Data.SessionSpeaker", b =>
                {
                    b.HasOne("BackEnd.Data.Session", "Session")
                        .WithMany("SessionSpeakers")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Data.Speaker", "Speaker")
                        .WithMany("SessionSpeakers")
                        .HasForeignKey("SpeakerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEnd.Data.SessionTag", b =>
                {
                    b.HasOne("BackEnd.Data.Session", "Session")
                        .WithMany("SessionTags")
                        .HasForeignKey("SessionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Data.Tag", "Tag")
                        .WithMany("SessionTags")
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEnd.Data.Speaker", b =>
                {
                    b.HasOne("BackEnd.Data.Conference", null)
                        .WithMany("Speakers")
                        .HasForeignKey("ConferenceID");
                });

            modelBuilder.Entity("BackEnd.Data.Track", b =>
                {
                    b.HasOne("BackEnd.Data.Conference", "Conference")
                        .WithMany("Tracks")
                        .HasForeignKey("ConferenceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
