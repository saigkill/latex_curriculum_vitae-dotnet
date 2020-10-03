// Copyright (C) 2020 Sascha Manns <Sascha.Manns@outlook.de>
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

// Dependencies

using Microsoft.EntityFrameworkCore;


namespace latex_curriculum_vitae.Data
{
    public class JobApplicationDataDbContext : DbContext
    {
        #region Constructor
        public JobApplicationDataDbContext(DbContextOptions<JobApplicationDataDbContext> options) : base(options)
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
