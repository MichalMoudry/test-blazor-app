using FormCapture.Shared.DbModels;
using FormCapture.Shared.Util.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace FormCapture.Server.DataAccess
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CaptureAppWorkflows> AppWorkflows { get; set; }

        public DbSet<CaptureApplication> CaptureApplications { get; set; }

        public DbSet<Field> Fields { get; set; }

        public DbSet<FieldValue> FieldValues { get; set; }

        public DbSet<ProcessedFile> ProcessedFiles { get; set; }

        public DbSet<Queue> Queue { get; set; }

        public DbSet<WorkflowTaskGrouping> TaskGroupings { get; set; }

        public DbSet<Template> Templates { get; set; }

        public DbSet<UserApps> UserApps { get; set; }

        public DbSet<Workflow> Workflows { get; set; }

        public DbSet<WorkflowTask> WorkflowTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Source:
            //SAINTY, Chris, 2019. Configuring Role-based Authorization with client-side Blazor. Chris Sainty [online]. [vid. 2021-05-05]. Dostupné z: https://chrissainty.com/securing-your-blazor-apps-configuring-role-based-authorization-with-client-side-blazor/
            builder.Entity<IdentityRole>().HasData(new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Workflow admin", NormalizedName = "WORKFLOW ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER", ConcurrencyStamp = Guid.NewGuid().ToString() });

            //Value conversion config
            builder.Entity<Queue>().Property(e => e.Status).HasConversion(i => i.ToString(), i => (QueueStatus)Enum.Parse(typeof(QueueStatus), i));
            builder.Entity<Queue>().Property(e => e.AppWorkflowTaskGroupID).HasConversion(i => i.ToString(), i => (TaskGroupID)Enum.Parse(typeof(TaskGroupID), i));
        }
    }
}