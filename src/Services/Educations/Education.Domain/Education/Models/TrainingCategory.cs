using Education.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Domain.Education.Models
{
    public class TrainingCategory : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Training> Trainings { get; set; }
        public class TrainingCategoryConfiguration : IEntityTypeConfiguration<TrainingCategory>
        {
            public void Configure(EntityTypeBuilder<TrainingCategory> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(p => p.Name).IsRequired().HasMaxLength(200);



            }
        }
    }

}
