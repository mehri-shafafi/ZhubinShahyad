using GraphQL.Types;

namespace News.Presentation.GQL.Types.News
{
    public class NewsFilterType: InputObjectGraphType
    {
        public NewsFilterType()
        {

            Name =nameof(NewsFilterType);
            Field<IntGraphType>("Id");
            Field<StringGraphType>("SearchTerm");
            Field<DecimalGraphType>("MinPrice");
            Field<DecimalGraphType>("MaxPrice");
            Field<StringGraphType>("Code");
            Field<StringGraphType>("Permalink");
            Field<IntGraphType>("CategoryId");
            Field<IntGraphType>("PageIndex");
            Field<IntGraphType>("PageSize");

        }


    }
}
