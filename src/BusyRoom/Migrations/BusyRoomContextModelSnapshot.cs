using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using BusyRoom.Models;

namespace BusyRoom.Migrations
{
    [DbContext(typeof(BusyRoomContext))]
    partial class BusyRoomContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BusyRoom.Models.OccupyState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsBusy");

                    b.Property<int>("RoomId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("BusyRoom.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("BusyRoom.Models.OccupyState", b =>
                {
                    b.HasOne("BusyRoom.Models.Room")
                        .WithMany()
                        .HasForeignKey("RoomId");
                });
        }
    }
}
