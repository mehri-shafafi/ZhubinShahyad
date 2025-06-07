using Education.Domain.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Education.Domain.Education.Models
{
    public class TrainingTranslation:BaseEntity
    {
        public int TrainingId { get; set; }
        public string Language { get; set; } // "fa", "en", "ar"

        public string Title { get; set; }
        public string? Description { get; set; }
        public string? ContentUrl { get; set; } // ویدئو یا PDF یا لینک متن

        public Training Training { get; set; }
        public class TrainingTranslationConfiguration : IEntityTypeConfiguration<TrainingTranslation>
        {
            public void Configure(EntityTypeBuilder<TrainingTranslation> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(p => p.TrainingId).IsRequired().HasMaxLength(200);
                builder.Property(p => p.Description).HasMaxLength(500);
                builder.Property(p => p.Language).IsRequired().HasMaxLength(200);
                builder.Property(p => p.Title).IsRequired().HasMaxLength(300);
                builder.Property(p => p.ContentUrl).HasMaxLength(1000);

            }
        }
    }
}