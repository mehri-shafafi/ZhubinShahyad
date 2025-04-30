using GraphQL.Types;

namespace News.Presentation.GQL.Types.News
{
    public class NewsReqType:InputObjectGraphType
    {
        public NewsReqType()
        {
            Name = nameof(NewsReqType);
            Field<IdGraphType>("Id");
            Field<BooleanGraphType>("Active");
            Field<StringGraphType>("Title");
            Field<StringGraphType>("Description");

            Field<StringGraphType>("CoverImageUrl");
            Field<DecimalGraphType>("Price");

            Field<StringGraphType>("Code");
            Field<StringGraphType>("Permalink");
            Field<IntGraphType>("CategoryId");
        }
    }
}
