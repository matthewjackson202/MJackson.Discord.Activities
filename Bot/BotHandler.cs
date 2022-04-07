using System;
using System.Activities;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace MJackson.Discord.Activities.Bot
{
    public class BotHandler
    {

        public static DiscordSocketClient Client;
        
        public async Task StartAsync(string token)
        {
            Client = new DiscordSocketClient();
            var commandService = new CommandService();
            Client.Log += Log;
            
            await Client.LoginAsync(TokenType.Bot, token);
            var handler = new CommandHandler(Client, commandService);
            await handler.InstallCommandsAsync();

            await Client.StartAsync();

        }

        private Task Log(LogMessage logMessage)
        {
            Console.WriteLine(logMessage);
            return Task.CompletedTask;
        }
        
    }
}