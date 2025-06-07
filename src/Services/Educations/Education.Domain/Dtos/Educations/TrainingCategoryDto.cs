using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Domain.Base;

namespace Education.Domain.Education.Dtos
{
    public class TrainingCategoryDto :BaseEntity
    {
        public string Name { get; set; }
        public int TrainingId { get; set; }
        public string Language { get; set; } // "fa", "en", "ar"

        public string Title { get; set; }
        public string? Description { get; set; }
        public string? ContentUrl { get; set; } // ویدئو یا PDF یا لینک متن


    }

}
