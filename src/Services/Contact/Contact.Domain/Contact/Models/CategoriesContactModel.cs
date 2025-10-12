using Contact.Domain.Base;

namespace Contact.Domain.Contact.Models;
public class CategoriesContactModel : BaseEntity<int>
{
    public string Name_FA { get; set; }
    public string Name_EN { get; set; }
    public string Name_AR { get; set; }


    public ICollection<ContactEntity> ContactEntities { get; set; } = new List<ContactEntity>();

}
