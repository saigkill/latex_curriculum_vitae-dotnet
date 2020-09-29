using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace latex_curriculum_vitae.Data
{
    public class JobApplicationDbContext : DbContext
    {
        #region Constructor
        public JobApplicationDbContext(DbContextOptions<JobApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        #endregion

        #region Public Properties
        public DbSet<JobApplicationData> JobApplications { get; set; }
        #endregion

        #region Overridden methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobApplicationData>().HasData(GetJobApplications());
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region Private methods
        private JobApplicationData[] GetJobApplications()
        {
            return new JobApplicationData[]
            {
                new JobApplicationData {Id = 1, City = "Mayen", Company = "Test GmbH", ContactName = "Mascha Sanns"}
            };
        }
        #endregion
    }
}
