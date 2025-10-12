using Contact.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contact.Domain.Contact.Models;
public class ContactModel : BaseEntity<int>
{

    public string Name { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public string CategoryName { get; set; }
    public bool IsRead { get; set; }
    public int CategoryId { get; set; } // کلید خارجی

    public CategoriesContact Category { get; set; } // این باید وجود داشته باشه

}
