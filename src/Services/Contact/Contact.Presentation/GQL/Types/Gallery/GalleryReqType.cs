using GraphQL.Types;

namespace Gallery.Presentation.GQL.Types.Gallery
{
    public class GalleryReqType : InputObjectGraphType
    {
        public GalleryReqType()
        {
            Name = nameof(GalleryReqType);
            Field<IdGraphType>("Id");

      
        }
    }
}
