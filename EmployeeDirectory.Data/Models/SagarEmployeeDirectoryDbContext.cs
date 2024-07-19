using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectory.Data.Models;

public partial class SagarEmployeeDirectoryDbContext : DbContext
{
    public SagarEmployeeDirectoryDbContext()
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=sql-dev;Initial Catalog=Sagar_EmployeeDirectory_DB_CodeFirst;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Department");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Employee");

            entity.HasIndex(e => e.EmpId).IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50);
            entity.Property(e => e.EmpId)
                .HasMaxLength(10);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50);
            entity.Property(e => e.LastName)
                .HasMaxLength(50);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(20);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Manager).WithMany(p => p.Employees)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employee__Manage");

            entity.HasOne(d => d.Project).WithMany(p => p.Employees)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__Employee__Project");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Location");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Manager");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.Employee).WithMany(p => p.Managers)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Manager__Employee");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Project");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Role");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(200);
            entity.Property(e => e.Name)
                .HasMaxLength(100);

            entity.HasOne(d => d.Department).WithMany(p => p.Roles)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Role__Department");

            entity.HasOne(d => d.Location).WithMany(p => p.Roles)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Role__Location");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
