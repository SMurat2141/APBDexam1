using Microsoft.EntityFrameworkCore;
using APBDProject.API.Entities;

namespace APBDProject.API.Data;

public class AppDbContext : DbContext
{
    public DbSet<TeamMember> TeamMembers => Set<TeamMember>();
    public DbSet<Project>    Projects    => Set<Project>();
    public DbSet<TaskEntity> Tasks       => Set<TaskEntity>();
    public DbSet<TaskType>   TaskTypes   => Set<TaskType>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<TeamMember>().ToTable("TeamMember").HasKey(e => e.IdTeamMember);
        builder.Entity<Project>()   .ToTable("Project")   .HasKey(e => e.IdProject);
        builder.Entity<TaskType>()  .ToTable("TaskType")  .HasKey(e => e.IdTaskType);

        builder.Entity<TaskEntity>(e =>
        {
            e.ToTable("Task");
            e.HasKey(t => t.IdTask);

            e.HasOne(t => t.AssignedTo)
                .WithMany(tm => tm.TasksAssigned)
                .HasForeignKey(t => t.IdAssignedTo);

            e.HasOne(t => t.CreatedBy)
                .WithMany(tm => tm.TasksCreated)
                .HasForeignKey(t => t.IdCreatedBy);

            e.HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.IdProject);

            e.HasOne(t => t.TaskType)
                .WithMany()
                .HasForeignKey(t => t.IdTaskType);
        });
    }
}