using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MyWebAPI.Models;

namespace MyWebAPI.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20170214102234_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyWebAPI.Models.AccessToken", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Token");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("AccessToken");
                });

            modelBuilder.Entity("MyWebAPI.Models.Story", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.Property<int?>("UsersId");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("Story");
                });

            modelBuilder.Entity("MyWebAPI.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Firstname");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyWebAPI.Models.AccessToken", b =>
                {
                    b.HasOne("MyWebAPI.Models.Users", "Users")
                        .WithOne("AccessToken")
                        .HasForeignKey("MyWebAPI.Models.AccessToken", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyWebAPI.Models.Story", b =>
                {
                    b.HasOne("MyWebAPI.Models.Users", "Users")
                        .WithMany("Story")
                        .HasForeignKey("UsersId");
                });
        }
    }
}
