using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace CommanderGQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))] //added to make AppDbContext multithreaded
        //[UseProjection] //Needs to be added because to fetch child objects
         //Needed only when Type aand Resolvers are not defined
         [UseFiltering]
         [UseSorting]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }

        [UseDbContext(typeof(AppDbContext))] //added to make AppDbContext multithreaded
        //[UseProjection] //Needs to be added because to fetch child objects
         //Needed only when Type aand Resolvers are not defined
        [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommands([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }
    }
}