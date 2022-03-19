using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Intro
{
    public class WorkerConfig : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.ToTable("Employees");       // set table name in db
            builder.Property(w => w.Name)
                   .IsRequired()                // set not null
                   .HasMaxLength(200)           // set max length(NVarChar(200))
                   .HasColumnName("FirstName"); // set column name in db
            builder.Property(w => w.Surname)
                   .IsRequired()
                   .HasMaxLength(200)
                   .HasColumnName("LastName");
            builder.Ignore(w => w.FullName);    // only in model
            builder.Property(w => w.Address).HasMaxLength(350);

            // Relationship configurations

            // Relationship Type: 1...* (One to Many)
            builder.HasOne(w => w.Department)
                   .WithMany(d => d.Workers)
                   .IsRequired();
            // Relationship Type: 0/1...* (Zero or One to Many)
            builder.HasOne(w => w.Country)
                   .WithMany(d => d.Workers)
                   .IsRequired(false);
            // Relationship Type: *...* (Many to Many)
            builder.HasMany(w => w.Projects)
                   .WithMany(p => p.Workers);
        }
    }
}
