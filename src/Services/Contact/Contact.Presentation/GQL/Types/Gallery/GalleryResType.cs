using Gallery.Domain.Dtos.Gallery;
using GraphQL.Types;

namespace Gallery.Presentation.GQL.Types.Gallery
{
    public class GalleryResType : ObjectGraphType<GalleryResDto>
    {

        public GalleryResType()
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Title_AR, type: typeof(StringGraphType));
            Field(x => x.Title_EN, type: typeof(StringGraphType));
            Field(x => x.Title_FA, type: typeof(StringGraphType));
            Field(x => x.ModificationDateTime, type: typeof(StringGraphType));
            Field(x => x.ServiceType, type: typeof(StringGraphType));
            Field(x => x.ImageUrl, type: typeof(StringGraphType));
            Field(x => x.CreationDateTime, type: typeof(DecimalGraphType));
            Field(x => x.ModificationDateTimeShamsi, type: typeof(IntGraphType));
                  }
    }
}
