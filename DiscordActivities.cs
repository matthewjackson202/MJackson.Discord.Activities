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

        public static DiscordSocketClient _client;
        
        [Category("Input")] [RequiredArgument] 
        public InArgument<string> ClientToken { get; set; }

        [Category("Input")] [RequiredArgument] 
        public InArgument<string> ClientPrefix { get; set; }

        /*
        [Category("Output")] 
        public OutArgument<DiscordSocketClient> DiscordClient { get; set; }*/


        protected override async void Execute(CodeActivityContext context)
        {
            // Get the application token
            var token = ClientToken.Get(context);

            //Get command prefix for bot to respond to
            var prefix = ClientPrefix.Get(context);

            var botHandler = new BotHandler();
            await botHandler.StartAsync(token);
            _client = BotHandler.Client;
            
            await Task.Delay(-1);

            
        }
    }
}