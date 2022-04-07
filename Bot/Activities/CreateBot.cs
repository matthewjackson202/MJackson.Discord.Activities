using System;
using System.Activities;
using System.ComponentModel;
using Discord.WebSocket;

namespace MJackson.Discord.Activities.Bot.Activities
{
    public class CreateBot : DiscordActivities
    {
        
        [Category("Input")]
        [RequiredArgument]
        public InArgument<string> ClientToken { get; set; }
        
        [Category("Input")]
        [RequiredArgument]
        public InArgument<string> ClientPrefix { get; set; }
        
        [Category("Output")]
        public OutArgument<DiscordSocketClient> DiscordClient { get; set; }
        
        
        protected override void Execute(CodeActivityContext context)
        {
            // Get the application token
            var token = ClientToken.Get(context);
            
            //Get command prefix for bot to respond to
            var prefix = ClientPrefix.Get(context);


        }
    }
}