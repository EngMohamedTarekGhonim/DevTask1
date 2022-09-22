using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.AppDbContext
{
    public partial class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DepartmentModel> Departments { get; set; }
        public virtual DbSet<ReminderModel> Reminders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentModel>(entity =>
            {
                entity.ToTable("Department");

                entity.HasIndex(e => e.MainDepartmentId);

                entity.HasOne(d => d.MainDepartment)
                    .WithMany(p => p.SubDepartments)
                    .HasForeignKey(d => d.MainDepartmentId);
            });

        }


    }
}
