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
        public OutArgument<DiscordSocketClient> FirstNumber { get; set; }
        
        
        protected override void Execute(CodeActivityContext context)
        {
            Console.WriteLine("yep?");
        }
    }
}