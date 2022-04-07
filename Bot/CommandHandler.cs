using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace MJackson.Discord.Activities.Bot
{
    public class CommandHandler
    {
        // Readonly variables storing constant bot and command handler
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;

        public CommandHandler(DiscordSocketClient client, CommandService commands)
        {
            _commands = commands;
            _client = client;
        }

        public async Task InstallCommandsAsync()
        {
            // Send all Messages received events to method
            _client.MessageReceived += HandleCommandAsync;
            // Search Assembly for all modules and register their commands
            await _commands.AddModulesAsync(assembly: Assembly.GetEntryAssembly(), services: null);
        }

        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            // Handle the commands
            // Convert message to user message and make sure it wasn't sent by the bot
            var message = messageParam as SocketUserMessage;
            if (message == null) return;
    
            // Prefix length, make sure it starts with prefix, is not the current bot or a bot at all.
            var argPos = 0;
            if (!(message.HasCharPrefix('!', ref argPos) ||
                  message.HasMentionPrefix(_client.CurrentUser, ref argPos)) || message.Author.IsBot) return;
            
            // Get the context from the event
            var context = new SocketCommandContext(_client, message);
            
            // Execute the commands that may match the context
            await _commands.ExecuteAsync
            (
                context: context,
                argPos: argPos,
                services: null
            );
        }
    }
}