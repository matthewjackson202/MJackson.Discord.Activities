using System;
using System.Activities;
using System.ComponentModel;
using System.Linq;
using Discord;
using Discord.WebSocket;

namespace MJackson.Discord.Activities.RetrieveDiscordEntity
{
    public class RetrieveUserByNameDiscriminator : CodeActivity
    {
        // Setup inputs and outputs
        [Category("Input")] [RequiredArgument]
        public InArgument<string> UserName { get; set; }

        [Category("Input")]
        [RequiredArgument]
        public InArgument<string> UserDiscriminator { get; set; }
        
        [Category("Output")]
        public OutArgument<string> UserId { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var bot = CreateBot.client;
            
            foreach (var guild in bot.Guilds)
            {
                // Go through all guilds looking for the user 
                var users = guild.Users.Where(x => x.Username == UserName.Get(context))
                    .Where(x => x.Discriminator == UserDiscriminator.Get(context)).ToList();
                if (!users.Any()) continue;
                // Set context and return
                UserId.Set(context, users.First().Id.ToString());
                return;
            }
            // Nothing was returned therefore it is null.
            UserId.Set(context, null);
        }
    }
}