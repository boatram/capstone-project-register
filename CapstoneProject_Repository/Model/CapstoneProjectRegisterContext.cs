using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace CapstoneProject.Repository.Model
{
    public partial class CapstoneProjectRegisterContext : DbContext
    {
        public CapstoneProjectRegisterContext()
        {
        }

        public CapstoneProjectRegisterContext(DbContextOptions<CapstoneProjectRegisterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GroupProject> GroupProjects { get; set; }
        public virtual DbSet<Lecturer> Lecturers { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentInGroup> StudentInGroups { get; set; }
        public virtual DbSet<StudentInSemester> StudentInSemesters { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<TopicOfLecturer> TopicOfLecturers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var strConn = config["ConnectionStrings:CapstoneProjectRegisterDB"];
            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<GroupProject>(entity =>
            {
                entity.ToTable("GroupProject");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.GroupProjects)
                    .HasForeignKey(d => d.SemesterId)
                    .HasConstraintName("FK__GroupProj__Semes__29572725");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.GroupProjects)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("FK__GroupProj__Topic__2A4B4B5E");
            });

            modelBuilder.Entity<Lecturer>(entity =>
            {
                entity.ToTable("Lecturer");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("Semester");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Avatar).IsUnicode(false);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentInGroup>(entity =>
            {
                entity.ToTable("StudentInGroup");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.JoinDate).HasColumnType("date");

                entity.Property(e => e.Role).HasMaxLength(20);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.StudentInGroups)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__StudentIn__Group__2F10007B");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentInGroups)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__StudentIn__Stude__300424B4");
            });

            modelBuilder.Entity<StudentInSemester>(entity =>
            {
                entity.ToTable("StudentInSemester");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.StudentInSemesters)
                    .HasForeignKey(d => d.SemesterId)
                    .HasConstraintName("FK__StudentIn__Semes__33D4B598");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentInSemesters)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__StudentIn__Stude__32E0915F");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.SemesterId)
                    .HasConstraintName("FK__Topic__SemesterI__267ABA7A");
            });

            modelBuilder.Entity<TopicOfLecturer>(entity =>
            {
                entity.ToTable("TopicOfLecturer");

                entity.Property(e => e.IsSuperLecturer).HasColumnName("isSuperLecturer");

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.TopicOfLecturers)
                    .HasForeignKey(d => d.LecturerId)
                    .HasConstraintName("FK__TopicOfLe__Lectu__38996AB5");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.TopicOfLecturers)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("FK__TopicOfLe__Topic__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
