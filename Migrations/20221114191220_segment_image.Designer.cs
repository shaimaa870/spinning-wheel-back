// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using spinning_wheel.Core;

#nullable disable

namespace spinningwheel.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221114191220_segment_image")]
    partial class segmentimage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("spinning_wheel.Core.Domain.SpinningWheel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("spinningWheels");
                });

            modelBuilder.Entity("spinning_wheel.Core.Domain.WheelSegment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reward")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpinningWheelId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TextColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SpinningWheelId");

                    b.ToTable("wheelSegments");
                });

            modelBuilder.Entity("spinning_wheel.Core.Domain.WheelSegment", b =>
                {
                    b.HasOne("spinning_wheel.Core.Domain.SpinningWheel", "SpinningWheel")
                        .WithMany("Segments")
                        .HasForeignKey("SpinningWheelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SpinningWheel");
                });

            modelBuilder.Entity("spinning_wheel.Core.Domain.SpinningWheel", b =>
                {
                    b.Navigation("Segments");
                });
#pragma warning restore 612, 618
        }
    }
}
