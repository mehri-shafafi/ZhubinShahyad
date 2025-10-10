

namespace Contact.Domain.Dtos.Contact;


public class ContactResDto : GalleryDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public bool IsRead { get; set; }
    public int CategoryId { get; set; }
    public DateTime CreationDateTime { get; set; } 
    public DateTime ModificationDateTime { get; set; }
    public string CreationDateTimeShamsi { get; set; } 
    public string ModificationDateTimeShamsi { get; set; } 

}
public class ContactReqDto : ContactDto
{

    public int Id { get; set; }

}

public class ContactDto : BaseEntity<int>
{         
    public string ServiceType { get; set; }   
    public string Title_FA { get; set; }       
    public string Title_EN { get; set; }       
    public string Title_AR { get; set; }        
    public string ImageUrl { get; set; }
    public int CategoriesGalleryId { get; set; }

}
