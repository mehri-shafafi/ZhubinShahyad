using BaseProject.Domain.Common.Extensions;
using Gallery.Domain.Base;

namespace Gallery.Domain.Dtos.Gallery;


public class GalleryResDto : GalleryDto
{
    public string Title_FA { get; set; }
    public string Title_EN { get; set; }
    public string Title_AR { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreationDateTime { get; set; } 
    public DateTime ModificationDateTime { get; set; }
    public string CreationDateTimeShamsi { get; set; } 
    public string ModificationDateTimeShamsi { get; set; } 

}
public class GalleryReqDto : GalleryDto
{

    public int Id { get; set; }

}

public class GalleryDto : BaseEntity<int>
{
    public int Id { get; set; }           
    public string ServiceType { get; set; }   
    public string Title_FA { get; set; }       
    public string Title_EN { get; set; }       
    public string Title_AR { get; set; }        
    public string ImageUrl { get; set; }

}
