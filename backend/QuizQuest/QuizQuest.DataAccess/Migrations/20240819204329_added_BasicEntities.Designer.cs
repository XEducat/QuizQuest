﻿// <auto-generated />
using System;
using LearnRazor.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace QuizQuest.DataAccess.Migrations
{
    [DbContext(typeof(QuizDbContext))]
    [Migration("20240819204329_added_BasicEntities")]
    partial class added_BasicEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuizQuest.DataAccess.Entites.AnswerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("QuestionId1")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId1");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("QuizQuest.DataAccess.Entites.QuestionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("QuizQuest.DataAccess.Entites.QuizEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("QuizQuest.DataAccess.Entites.QuizResultEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTaken")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("QuizId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("QuizId1")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuizId1");

                    b.HasIndex("UserId");

                    b.ToTable("QuizResults");
                });

            modelBuilder.Entity("QuizQuest.DataAccess.Entites.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QuizQuest.DataAccess.Entites.AnswerEntity", b =>
                {
                    b.HasOne("QuizQuest.DataAccess.Entites.QuestionEntity", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId1");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuizQuest.DataAccess.Entites.QuestionEntity", b =>
                {
                    b.HasOne("QuizQuest.DataAccess.Entites.QuizEntity", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("QuizQuest.DataAccess.Entites.QuizResultEntity", b =>
                {
                    b.HasOne("QuizQuest.DataAccess.Entites.QuizEntity", "Quiz")
                        .WithMany("QuizResults")
                        .HasForeignKey("QuizId1");

                    b.HasOne("QuizQuest.DataAccess.Entites.UserEntity", "User")
                        .WithMany("QuizResults")
                        .HasForeignKey("UserId");

                    b.Navigation("Quiz");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuizQuest.DataAccess.Entites.QuestionEntity", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("QuizQuest.DataAccess.Entites.QuizEntity", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("QuizResults");
                });

            modelBuilder.Entity("QuizQuest.DataAccess.Entites.UserEntity", b =>
                {
                    b.Navigation("QuizResults");
                });
#pragma warning restore 612, 618
        }
    }
}
