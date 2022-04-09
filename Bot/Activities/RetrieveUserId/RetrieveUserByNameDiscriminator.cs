using System;
using System.Activities;
using System.ComponentModel;
using System.Linq;
using Discord;
using Discord.WebSocket;

namespace MJackson.Discord.Activities.Bot.Activities.RetrieveUserId
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
                var users = guild.Users.Where(x => x.Username == UserName.Get(context))
                    .Where(x => x.Discriminator == UserDiscriminator.Get(context)).ToList();
                if (users.Any())
                {
                    UserId.Set(context, users.First().Id.ToString());
                    return;
                }
            }
            UserId.Set(context, null);
        }
    }
}