using Abp.Dependency;
using GraphQL.Types;
using GraphQL.Utilities;
using Google.YouTube.Queries.Container;
using System;

namespace Google.YouTube.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IServiceProvider provider) :
            base(provider)
        {
            Query = provider.GetRequiredService<QueryContainer>();
        }
    }
}