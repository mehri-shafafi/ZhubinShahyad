using Education.Domain.Base;

namespace Education.Domain.Education.Dtos
{
    public class TrainingDto : BaseEntity
    {
       
        public int TrainingId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Language { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string Type { get; set; }
        public DateTime PublishDate { get; set; }


    }
}

