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
        
        //Start the bot without blocking the main thread
        public async Task StartAsync(string token)
        {
            // Setup a new client
            Client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                AlwaysDownloadUsers = true,
                GatewayIntents = GatewayIntents.All
            });
            // Spawn CommandService to manage the commands
            var commandService = new CommandService();
            // Log event being handled by Log method 
            Client.Log += Log;

            //Login, set the handler, and setup the commands
            await Client.LoginAsync(TokenType.Bot, token);
            
            // Waits until the bot is online to proceed
            await Client.StartAsync();

        }

        private Task Log(LogMessage logMessage)
        {
            // Send all logs to Console
            Console.WriteLine(logMessage);
            return Task.CompletedTask;
        }
        
    }
}