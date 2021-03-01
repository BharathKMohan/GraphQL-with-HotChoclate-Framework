using System.Linq;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGQL.GraphQL.Commands
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
           descriptor.Description("Indicates the command line to be executed for the command");

           descriptor
            .Field(c => c.Platform)
            .ResolveWith<Resolvers>(p => p.GetPlatform(default!,default!))
            .UseDbContext<AppDbContext>()
            .Description("This is the platform that the command is associated with");

        }

        private class Resolvers
        {
            public Platform GetPlatform(Command command, [ScopedService] AppDbContext context)
            {
                return context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);
            }
        }
    }
}