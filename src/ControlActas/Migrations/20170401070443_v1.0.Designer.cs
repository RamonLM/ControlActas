using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ControlActas.Models;

namespace ControlActas.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20170401070443_v1.0")]
    partial class v10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControlActas.Models.BookOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<string>("ISBN");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Ordered");

                    b.Property<double>("Price");

                    b.Property<int?>("ProviderId");

                    b.Property<DateTime>("Received");

                    b.Property<int?>("RequestorId");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.HasIndex("RequestorId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ControlActas.Models.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Company");

                    b.Property<string>("Fax");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("ControlActas.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ControlActas.Models.BookOrder", b =>
                {
                    b.HasOne("ControlActas.Models.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId");

                    b.HasOne("ControlActas.Models.User", "Requestor")
                        .WithMany()
                        .HasForeignKey("RequestorId");
                });
        }
    }
}
