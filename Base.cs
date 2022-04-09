using System;
using System.Activities;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Discord.WebSocket;
using MJackson.Discord.Activities.Bot;

namespace MJackson.Discord.Activities
{
    public class CreateBot : CodeActivity
    {

        public static DiscordSocketClient client;
        
        [Category("Input")] [RequiredArgument] 
        public InArgument<string> ClientToken { get; set; }

        protected override async void Execute(CodeActivityContext context)
        {
            // Get the application token
            var token = ClientToken.Get(context);
            
            var botHandler = new BotHandler();
            await botHandler.StartAsync(token);
            client = BotHandler.Client;
            
        }
    }
}