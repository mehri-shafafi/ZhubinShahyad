using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Education.Domain.Base;

namespace Education.Domain.Education.Models
{
    public class Training : BaseEntity
    {
        public DateTime PublishDate { get; set; }
        public string? ThumbnailUrl { get; set; } // عکس شاخص
        public TrainingType Type { get; set; } // نوع آموزش (متن، ویدیو، کاتالوگ)

        public int CategoryId { get; set; }
        public TrainingCategory trainingCategory { get; set; }

        public ICollection<TrainingTranslation> Translations { get; set; } = new List<TrainingTranslation>();


        public class TrainingConfiguration : IEntityTypeConfiguration<Training>
        {
            public void Configure(EntityTypeBuilder<Training> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(p => p.PublishDate).IsRequired();
                builder.Property(p => p.ThumbnailUrl).HasMaxLength(500);
                builder.Property(p => p.Type).IsRequired();

                // Relationships
                builder.HasOne(p => p.trainingCategory)
                       .WithMany(a => a.Trainings)
                       .HasForeignKey(p => p.CategoryId);

                

            }
        }
    }
}
public enum TrainingType
{
    Video = 0,
    Catalog = 1, // PDF
    Article = 2  // متن
}
