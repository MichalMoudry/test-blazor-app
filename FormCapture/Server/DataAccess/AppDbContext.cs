using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormCapture.Shared.DbModels;
using Microsoft.AspNetCore.Identity;
using FormCapture.Shared.Util.Enums;

namespace FormCapture.Server.DataAccess
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Workflow admin", NormalizedName = "WORKFLOW ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER", ConcurrencyStamp = Guid.NewGuid().ToString() });

            //Value conversion config
            builder.Entity<Queue>().Property(e => e.Status).HasConversion(i => i.ToString(), i => (QueueStatus)Enum.Parse(typeof(QueueStatus), i));
            builder.Entity<Notification>().Property(e => e.NotificationType).HasConversion(i => i.ToString(), i => (NotificationType)Enum.Parse(typeof(NotificationType), i));
            builder.Entity<Queue>().Property(e => e.AppWorkflowTaskGroupID).HasConversion(i => i.ToString(), i => (TaskGroupID)Enum.Parse(typeof(TaskGroupID), i));
        }

        public DbSet<CaptureApplication> CaptureApplications { get; set; }

        public DbSet<UserApps> UserApps { get; set; }

        public DbSet<UserSetting> UserSettings { get; set; }

        public DbSet<WorkflowTask> WorkflowTasks { get; set; }

        public DbSet<Queue> Queue { get; set; }

        public DbSet<ProcessedFile> ProcessedFiles { get; set; }

        public DbSet<Workflow> Workflows { get; set; }

        public DbSet<WorkflowTaskGrouping> TaskGroupings { get; set; }

        public DbSet<CaptureAppWorkflows> AppWorkflows { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Template> Templates { get; set; }

        public DbSet<Field> Fields { get; set; }

        public DbSet<WorkflowTaskParameter> WorkflowTaskParameters { get; set; }

        public DbSet<FieldValue> FieldValues { get; set; }
    }
}