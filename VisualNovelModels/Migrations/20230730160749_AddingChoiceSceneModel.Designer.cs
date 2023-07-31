﻿// <auto-generated />
using System;
using ConsoleTesting.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsoleTesting.Migrations
{
    [DbContext(typeof(ESContext))]
    [Migration("20230730160749_AddingChoiceSceneModel")]
    partial class AddingChoiceSceneModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("ChoiceMadeChoicesCondition", b =>
                {
                    b.Property<Guid>("ChoicesId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MadeChoicesConditionsId")
                        .HasColumnType("TEXT");

                    b.HasKey("ChoicesId", "MadeChoicesConditionsId");

                    b.HasIndex("MadeChoicesConditionsId");

                    b.ToTable("ChoiceMadeChoicesCondition");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Base.Choice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ChoiceSceneId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChoiceSceneId");

                    b.ToTable("Choices");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Base.Condition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("TransitionId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TransitionId");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("ConsoleTesting.Models.Base.Ending", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Endings");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Base.Scene", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("ConsoleTesting.Models.Player.PlayerEndingProgress", b =>
                {
                    b.Property<Guid>("EndingId")
                        .HasColumnType("TEXT");

                    b.Property<int>("CurrentPoints")
                        .HasColumnType("INTEGER");

                    b.HasKey("EndingId");

                    b.ToTable("PlayerEndings");
                });

            modelBuilder.Entity("ConsoleTesting.Models.SceneParts.Transition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ChoiceSceneId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TargetSceneId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChoiceSceneId");

                    b.HasIndex("TargetSceneId");

                    b.ToTable("Transitions");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Conditions.EndingPointsCondition", b =>
                {
                    b.HasBaseType("ConsoleTesting.Models.Base.Condition");

                    b.Property<Guid>("EndingId")
                        .HasColumnType("TEXT");

                    b.Property<int>("PointsRequired")
                        .HasColumnType("INTEGER");

                    b.HasIndex("EndingId");

                    b.ToTable("EndingPointsConditions", t =>
                        {
                            t.HasCheckConstraint("Points_bigger_than_0", "PointsRequired > 0");
                        });
                });

            modelBuilder.Entity("ConsoleTesting.Models.Conditions.MadeChoicesCondition", b =>
                {
                    b.HasBaseType("ConsoleTesting.Models.Base.Condition");

                    b.ToTable("MadeChoicesConditions");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Scenes.ChoiceScene", b =>
                {
                    b.HasBaseType("ConsoleTesting.Models.Base.Scene");

                    b.ToTable("ChoiceScenes");
                });

            modelBuilder.Entity("ChoiceMadeChoicesCondition", b =>
                {
                    b.HasOne("ConsoleTesting.Models.Base.Choice", null)
                        .WithMany()
                        .HasForeignKey("ChoicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsoleTesting.Models.Conditions.MadeChoicesCondition", null)
                        .WithMany()
                        .HasForeignKey("MadeChoicesConditionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConsoleTesting.Models.Base.Choice", b =>
                {
                    b.HasOne("ConsoleTesting.Models.Scenes.ChoiceScene", null)
                        .WithMany("Choices")
                        .HasForeignKey("ChoiceSceneId");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Base.Condition", b =>
                {
                    b.HasOne("ConsoleTesting.Models.SceneParts.Transition", null)
                        .WithMany("Conditions")
                        .HasForeignKey("TransitionId");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Player.PlayerEndingProgress", b =>
                {
                    b.HasOne("ConsoleTesting.Models.Base.Ending", "Ending")
                        .WithOne()
                        .HasForeignKey("ConsoleTesting.Models.Player.PlayerEndingProgress", "EndingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ending");
                });

            modelBuilder.Entity("ConsoleTesting.Models.SceneParts.Transition", b =>
                {
                    b.HasOne("ConsoleTesting.Models.Scenes.ChoiceScene", null)
                        .WithMany("Transitions")
                        .HasForeignKey("ChoiceSceneId");

                    b.HasOne("ConsoleTesting.Models.Base.Scene", "TargetScene")
                        .WithMany()
                        .HasForeignKey("TargetSceneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TargetScene");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Conditions.EndingPointsCondition", b =>
                {
                    b.HasOne("ConsoleTesting.Models.Base.Ending", "Ending")
                        .WithMany()
                        .HasForeignKey("EndingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ending");
                });

            modelBuilder.Entity("ConsoleTesting.Models.SceneParts.Transition", b =>
                {
                    b.Navigation("Conditions");
                });

            modelBuilder.Entity("ConsoleTesting.Models.Scenes.ChoiceScene", b =>
                {
                    b.Navigation("Choices");

                    b.Navigation("Transitions");
                });
#pragma warning restore 612, 618
        }
    }
}
