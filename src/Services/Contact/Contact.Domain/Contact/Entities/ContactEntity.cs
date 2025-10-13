using Contact.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contact.Domain.Contact.Models;
public class ContactEntity : BaseEntity<int>
{

    public string Name { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public string Phone { get; set; }
    public bool IsRead { get; set; }
    public int CategoryId { get; set; }

    public CategoriesContact Category { get; set; } // این باید وجود داشته باشه

    public class ContactConfiguration : IEntityTypeConfiguration<ContactEntity>
    {
        public void Configure(EntityTypeBuilder<ContactEntity> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(2000).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(2000).IsRequired();
            builder.Property(p => p.Subject).HasMaxLength(400).IsRequired();
            builder.Property(p => p.Message).HasMaxLength(2000).IsRequired();
            builder.Property(p => p.Phone).HasMaxLength(11).IsRequired();
            builder.Property(p => p.Message).HasMaxLength(2000).IsRequired();
         
            // تعریف رابطه با CategoriesContact
            builder.HasOne(p => p.Category)
                   .WithMany() // اگر CategoriesContact لیستی از ContactEntityها را ندارد
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

        }


    }
}
