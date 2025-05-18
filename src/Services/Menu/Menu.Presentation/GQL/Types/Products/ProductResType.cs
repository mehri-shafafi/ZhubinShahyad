using GraphQL.Types;
using Menus.Domain.Dtos.Menu;

namespace Menus.Presentation.GQL.Types.Menu
{
    public class MenuResType : ObjectGraphType<MenuResDto>
    {

        public MenuResType()
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.ParentId, type: typeof(StringGraphType));
            Field(x => x.Parent, type: typeof(StringGraphType));
            Field(x => x.Slug, type: typeof(StringGraphType));
            Field(x => x.Title, type: typeof(StringGraphType));
            Field(x => x.Url, type: typeof(StringGraphType));
            
        }
    }
}
