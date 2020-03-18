using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MIMS.DAL.Models
{
    public partial class mimsContext : DbContext
    {
        public mimsContext()
        {
        }

        public mimsContext(DbContextOptions<mimsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Deviceslotsmapping> Deviceslotsmapping { get; set; }
        public virtual DbSet<Deviceslotsmaster> Deviceslotsmaster { get; set; }
        public virtual DbSet<Devicetechnicianmapping> Devicetechnicianmapping { get; set; }
        public virtual DbSet<Patientcasedetails> Patientcasedetails { get; set; }
        public virtual DbSet<Patientcaselog> Patientcaselog { get; set; }
        public virtual DbSet<Patientdetails> Patientdetails { get; set; }
        public virtual DbSet<Staffdetails> Staffdetails { get; set; }
        public virtual DbSet<Testcenter> Testcenter { get; set; }
        public virtual DbSet<Testdevices> Testdevices { get; set; }
        public virtual DbSet<Usercredentials> Usercredentials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=mims;Username=postgres;Password=Gmk@539@");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Deviceslotsmapping>(entity =>
            {
                entity.ToTable("deviceslotsmapping", "mims");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('mims.deviceslotsmapping_id_seq'::regclass)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("(1)::bit(1)");

                entity.Property(e => e.Createdby)
                    .HasColumnName("createdby")
                    .HasMaxLength(100);

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Deviceid).HasColumnName("deviceid");

                entity.Property(e => e.Slotid).HasColumnName("slotid");

                entity.Property(e => e.Updatedby)
                    .HasColumnName("updatedby")
                    .HasMaxLength(100);

                entity.Property(e => e.Updatedon).HasColumnName("updatedon");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.Deviceslotsmapping)
                    .HasForeignKey(d => d.Deviceid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("deviceslotsmapping_deviceid_fkey");

                entity.HasOne(d => d.Slot)
                    .WithMany(p => p.Deviceslotsmapping)
                    .HasForeignKey(d => d.Slotid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("deviceslotsmapping_slotid_fkey");
            });

            modelBuilder.Entity<Deviceslotsmaster>(entity =>
            {
                entity.HasKey(e => e.Slotid)
                    .HasName("deviceslotsmaster_pkey");

                entity.ToTable("deviceslotsmaster", "mims");

                entity.Property(e => e.Slotid)
                    .HasColumnName("slotid")
                    .HasDefaultValueSql("nextval('mims.deviceslotsmaster_slotid_seq'::regclass)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("(1)::bit(1)");

                entity.Property(e => e.Createdby)
                    .HasColumnName("createdby")
                    .HasMaxLength(100);

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Fromtime)
                    .HasColumnName("fromtime")
                    .HasMaxLength(50);

                entity.Property(e => e.Totime)
                    .HasColumnName("totime")
                    .HasMaxLength(50);

                entity.Property(e => e.Updatedby)
                    .HasColumnName("updatedby")
                    .HasMaxLength(100);

                entity.Property(e => e.Updatedon).HasColumnName("updatedon");
            });

            modelBuilder.Entity<Devicetechnicianmapping>(entity =>
            {
                entity.ToTable("devicetechnicianmapping", "mims");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('mims.devicetechnicianmapping_id_seq'::regclass)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("(1)::bit(1)");

                entity.Property(e => e.Createdby)
                    .HasColumnName("createdby")
                    .HasMaxLength(100);

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Deviceid).HasColumnName("deviceid");

                entity.Property(e => e.Technicianid).HasColumnName("technicianid");

                entity.Property(e => e.Updatedby)
                    .HasColumnName("updatedby")
                    .HasMaxLength(100);

                entity.Property(e => e.Updatedon).HasColumnName("updatedon");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.Devicetechnicianmapping)
                    .HasForeignKey(d => d.Deviceid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("devicetechnicianmapping_deviceid_fkey");

                entity.HasOne(d => d.Technician)
                    .WithMany(p => p.Devicetechnicianmapping)
                    .HasForeignKey(d => d.Technicianid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("devicetechnicianmapping_technicianid_fkey");
            });

            modelBuilder.Entity<Patientcasedetails>(entity =>
            {
                entity.HasKey(e => e.Caseid)
                    .HasName("patientcasedetails_pkey");

                entity.ToTable("patientcasedetails", "mims");

                entity.Property(e => e.Caseid)
                    .HasColumnName("caseid")
                    .HasDefaultValueSql("nextval('mims.patientcasedetails_caseid_seq'::regclass)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("(1)::bit(1)");

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasMaxLength(5000);

                entity.Property(e => e.Createdby)
                    .HasColumnName("createdby")
                    .HasMaxLength(100);

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Deviceid).HasColumnName("deviceid");

                entity.Property(e => e.Doctorid).HasColumnName("doctorid");

                entity.Property(e => e.Patientid).HasColumnName("patientid");

                entity.Property(e => e.Slotid).HasColumnName("slotid");

                entity.Property(e => e.Updatedby)
                    .HasColumnName("updatedby")
                    .HasMaxLength(100);

                entity.Property(e => e.Updatedon).HasColumnName("updatedon");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.Patientcasedetails)
                    .HasForeignKey(d => d.Deviceid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("patientcasedetails_deviceid_fkey");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Patientcasedetails)
                    .HasForeignKey(d => d.Doctorid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("patientcasedetails_doctorid_fkey");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Patientcasedetails)
                    .HasForeignKey(d => d.Patientid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("patientcasedetails_patientid_fkey");

                entity.HasOne(d => d.Slot)
                    .WithMany(p => p.Patientcasedetails)
                    .HasForeignKey(d => d.Slotid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("patientcasedetails_slotid_fkey");
            });

            modelBuilder.Entity<Patientcaselog>(entity =>
            {
                entity.ToTable("patientcaselog", "mims");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('mims.patientcaselog_id_seq'::regclass)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("(1)::bit(1)");

                entity.Property(e => e.Caseid).HasColumnName("caseid");

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasMaxLength(5000);

                entity.Property(e => e.Createdby)
                    .HasColumnName("createdby")
                    .HasMaxLength(100);

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Iscurrentstatus)
                    .HasColumnName("iscurrentstatus")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("(1)::bit(1)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(200);

                entity.Property(e => e.Updatedby)
                    .HasColumnName("updatedby")
                    .HasMaxLength(100);

                entity.Property(e => e.Updatedon).HasColumnName("updatedon");

                entity.HasOne(d => d.Case)
                    .WithMany(p => p.Patientcaselog)
                    .HasForeignKey(d => d.Caseid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("patientcaselog_caseid_fkey");
            });

            modelBuilder.Entity<Patientdetails>(entity =>
            {
                entity.HasKey(e => e.Patientid)
                    .HasName("patientdetails_pkey");

                entity.ToTable("patientdetails", "mims");

                entity.Property(e => e.Patientid)
                    .HasColumnName("patientid")
                    .HasDefaultValueSql("nextval('mims.patientdetails_patientid_seq'::regclass)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("(1)::bit(1)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(5000);

                entity.Property(e => e.Createdby)
                    .HasColumnName("createdby")
                    .HasMaxLength(100);

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Credentialid).HasColumnName("credentialid");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnName("dateofbirth")
                    .HasColumnType("date");

                entity.Property(e => e.District)
                    .HasColumnName("district")
                    .HasMaxLength(300);

                entity.Property(e => e.Emailid)
                    .IsRequired()
                    .HasColumnName("emailid")
                    .HasMaxLength(250);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(200);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(10);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(200);

                entity.Property(e => e.Middlename)
                    .HasColumnName("middlename")
                    .HasMaxLength(200);

                entity.Property(e => e.Phonenumber)
                    .IsRequired()
                    .HasColumnName("phonenumber")
                    .HasMaxLength(20);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(100);

                entity.Property(e => e.Updatedby)
                    .HasColumnName("updatedby")
                    .HasMaxLength(100);

                entity.Property(e => e.Updatedon).HasColumnName("updatedon");

                entity.HasOne(d => d.Credential)
                    .WithMany(p => p.Patientdetails)
                    .HasForeignKey(d => d.Credentialid)
                    .HasConstraintName("patientdetails_credentialid_fkey");
            });

            modelBuilder.Entity<Staffdetails>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("staffdetails_pkey");

                entity.ToTable("staffdetails", "mims");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasDefaultValueSql("nextval('mims.staffdetails_userid_seq'::regclass)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("(1)::bit(1)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(5000);

                entity.Property(e => e.Createdby)
                    .HasColumnName("createdby")
                    .HasMaxLength(100);

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Credentialid).HasColumnName("credentialid");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnName("dateofbirth")
                    .HasColumnType("date");

                entity.Property(e => e.Emailid)
                    .IsRequired()
                    .HasColumnName("emailid")
                    .HasMaxLength(250);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(200);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(10);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(200);

                entity.Property(e => e.Middlename)
                    .HasColumnName("middlename")
                    .HasMaxLength(200);

                entity.Property(e => e.Phonenumber)
                    .IsRequired()
                    .HasColumnName("phonenumber")
                    .HasMaxLength(20);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasMaxLength(100);

                entity.Property(e => e.Startdate).HasColumnName("startdate");

                entity.Property(e => e.Updatedby)
                    .HasColumnName("updatedby")
                    .HasMaxLength(100);

                entity.Property(e => e.Updatedon).HasColumnName("updatedon");

                entity.HasOne(d => d.Credential)
                    .WithMany(p => p.Staffdetails)
                    .HasForeignKey(d => d.Credentialid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("staffdetails_credentialid_fkey");
            });

            modelBuilder.Entity<Testcenter>(entity =>
            {
                entity.ToTable("testcenter", "mims");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('mims.testcenter_id_seq'::regclass)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("(1)::bit(1)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(5000);

                entity.Property(e => e.Createdby)
                    .HasColumnName("createdby")
                    .HasMaxLength(100);

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.District)
                    .HasColumnName("district")
                    .HasMaxLength(300);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(2000);

                entity.Property(e => e.Startdate).HasColumnName("startdate");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(200);

                entity.Property(e => e.Updatedby)
                    .HasColumnName("updatedby")
                    .HasMaxLength(100);

                entity.Property(e => e.Updatedon).HasColumnName("updatedon");
            });

            modelBuilder.Entity<Testdevices>(entity =>
            {
                entity.HasKey(e => e.Deviceid)
                    .HasName("testdevices_pkey");

                entity.ToTable("testdevices", "mims");

                entity.Property(e => e.Deviceid)
                    .HasColumnName("deviceid")
                    .HasDefaultValueSql("nextval('mims.testdevices_deviceid_seq'::regclass)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("(1)::bit(1)");

                entity.Property(e => e.Createdby)
                    .HasColumnName("createdby")
                    .HasMaxLength(100);

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Devicename)
                    .HasColumnName("devicename")
                    .HasMaxLength(2000);

                entity.Property(e => e.Devicetype)
                    .HasColumnName("devicetype")
                    .HasMaxLength(5000);

                entity.Property(e => e.Locationid).HasColumnName("locationid");

                entity.Property(e => e.Updatedby)
                    .HasColumnName("updatedby")
                    .HasMaxLength(100);

                entity.Property(e => e.Updatedon).HasColumnName("updatedon");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Testdevices)
                    .HasForeignKey(d => d.Locationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("testdevices_locationid_fkey");
            });

            modelBuilder.Entity<Usercredentials>(entity =>
            {
                entity.HasKey(e => e.Credentialid)
                    .HasName("usercredentials_pkey");

                entity.ToTable("usercredentials", "mims");

                entity.Property(e => e.Credentialid)
                    .HasColumnName("credentialid")
                    .HasDefaultValueSql("nextval('mims.usercredentials_credentialid_seq'::regclass)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("(1)::bit(1)");

                entity.Property(e => e.Createdby)
                    .HasColumnName("createdby")
                    .HasMaxLength(100);

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(100);

                entity.Property(e => e.Updatedby)
                    .HasColumnName("updatedby")
                    .HasMaxLength(100);

                entity.Property(e => e.Updatedon).HasColumnName("updatedon");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(100);
            });

            modelBuilder.HasSequence<int>("deviceslotsmapping_id_seq");

            modelBuilder.HasSequence<int>("deviceslotsmaster_slotid_seq");

            modelBuilder.HasSequence<int>("devicetechnicianmapping_id_seq");

            modelBuilder.HasSequence<int>("patientcasedetails_caseid_seq");

            modelBuilder.HasSequence<int>("patientcaselog_id_seq");

            modelBuilder.HasSequence<int>("patientdetails_patientid_seq");

            modelBuilder.HasSequence<int>("staffdetails_userid_seq");

            modelBuilder.HasSequence<int>("testcenter_id_seq");

            modelBuilder.HasSequence<int>("testdevices_deviceid_seq");

            modelBuilder.HasSequence<int>("usercredentials_credentialid_seq");
        }
    }
}
