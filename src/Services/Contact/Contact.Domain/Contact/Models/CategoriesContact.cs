using Contact.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contact.Domain.Contact.Models;
public class CategoriesContact : BaseEntity<int>
{
    public string Name_FA { get; set; }
    public string Name_EN { get; set; }
    public string Name_AR { get; set; }


    public ICollection<ContactEntity> ContactEntities { get; set; } = new List<ContactEntity>();
    public class CategoriesGalleryConfiguration : IEntityTypeConfiguration<CategoriesContact>
    {
        public void Configure(EntityTypeBuilder<CategoriesContact> builder)
        {

            builder.Property(p => p.Name_AR).HasMaxLength(2000);
            builder.Property(p => p.Name_EN).HasMaxLength(2000);
            builder.Property(p => p.Name_FA).HasMaxLength(2000);


        }


    }
}
