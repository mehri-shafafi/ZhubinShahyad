using Menus.Domain.Base;
using Menus.Domain.Menu.Models;

namespace Menus.Domain.Dtos.Menu;

public class MenuResDto : MenuDto
{
    public string Title { get; set; } // e.g., "صفحه اصلی"
    public string Slug { get; set; } // e.g., "home"


}

public class MenuDto : BaseEntity<int>
{
    public int Id { get; set; }
    public string Title { get; set; } // e.g., "صفحه اصلی"
    public string Slug { get; set; } // e.g., "home"
    public string Url { get; set; } // e.g., "/home"
    public int? ParentId { get; set; } // For submenus
    public MenuItem? Parent { get; set; }

}
