using Education.Domain.Base;

namespace Education.Domain.Education.Dtos
{
    public class TrainingTranslationDto : BaseEntity
    {
        public int TrainingId { get; set; }
        public string Language { get; set; } // "fa", "en", "ar"

        public string Title { get; set; }
        public string? Description { get; set; }
        public string? ContentUrl { get; set; } // ویدئو یا PDF یا لینک متن

    }
}