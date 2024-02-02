﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TBlog.Data;

namespace TBlog.Migrations
{
    [DbContext(typeof(TBlogDbContext))]
    [Migration("20231015173936_Primary")]
    partial class Primary
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TBlog.Data.Category", b =>
                {
                    b.Property<int>("CId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TBlog.Data.Post", b =>
                {
                    b.Property<int>("PId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PAudio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PCId")
                        .HasColumnType("int");

                    b.Property<bool>("PChecked")
                        .HasColumnType("bit");

                    b.Property<string>("PDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PLikes")
                        .HasColumnType("int");

                    b.Property<string>("PLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PMins")
                        .HasColumnType("int");

                    b.Property<string>("PPicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PSId")
                        .HasColumnType("int");

                    b.Property<bool>("PShow")
                        .HasColumnType("bit");

                    b.Property<string>("PSubtitle")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("PTDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PTitle")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("PType")
                        .HasColumnType("int");

                    b.Property<int>("PUId")
                        .HasColumnType("int");

                    b.Property<int>("PViews")
                        .HasColumnType("int");

                    b.HasKey("PId");

                    b.HasIndex("PCId");

                    b.HasIndex("PSId");

                    b.HasIndex("PUId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("TBlog.Data.Site", b =>
                {
                    b.Property<int>("SId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SPersianName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SPic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SId");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("TBlog.Data.Tag", b =>
                {
                    b.Property<int>("TId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("TBlog.Data.TagPost", b =>
                {
                    b.Property<int>("TPId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PId")
                        .HasColumnType("int");

                    b.Property<int>("TId")
                        .HasColumnType("int");

                    b.HasKey("TPId");

                    b.ToTable("TagPosts");
                });

            modelBuilder.Entity("TBlog.Data.User", b =>
                {
                    b.Property<int>("UId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UBio")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UIP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UMail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UPass")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("UPic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URegDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TBlog.Data.Post", b =>
                {
                    b.HasOne("TBlog.Data.Category", "Category")
                        .WithMany()
                        .HasForeignKey("PCId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TBlog.Data.Site", "Site")
                        .WithMany()
                        .HasForeignKey("PSId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TBlog.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("PUId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Site");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
