using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormCapture.Shared.DbModels;

namespace FormCapture.Server.DataAccess
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CaptureApplication> CaptureApplications { get; set; }

        public DbSet<AppWorkflow> Workflows { get; set; }

        public DbSet<UserApps> UserApps { get; set; }

        public DbSet<UserSetting> UserSettings { get; set; }

        public DbSet<AppWorkflowGroup> WorkflowGroups { get; set; }

        public DbSet<AppWorkflowTask> WorkflowTasks { get; set; }

        public DbSet<AppWorkflowTaskGrouping> WorkflowTaskGrouping { get; set; }

        public DbSet<CaptureAppWorkflows> CaptureAppWorkflows { get; set; }

        public DbSet<Queue> Queue { get; set; }

        public DbSet<Metadata> Metadata { get; set; }

        public DbSet<Batch> Batches { get; set; }

        public DbSet<ProcessedFile> ProcessedFiles { get; set; }
    }
}