using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class UserSkillConfiguration : IEntityTypeConfiguration<UserSkill>
    {
        public void Configure(EntityTypeBuilder<UserSkill> builder)
        {
            builder
                .ToTable("UserSkills");

            builder
                .HasKey(u => u.Id);

            builder
                .HasOne(s => s.User)
                .WithMany(u => u.Skills)
                .HasForeignKey(s => s.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
