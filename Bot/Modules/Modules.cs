using System;
using System.Threading.Tasks;
using Discord.Commands;

namespace MJackson.Discord.Activities.Bot.Modules
{
    public class Modules
    {
        // Modules are collection of commands automatically found on Login
        public class AdminModule : ModuleBase<SocketCommandContext>
        {
            // Command to simply repeat what the user says in any channel. 
            [Command("say")]
            [Summary("Echoes message")]
            public Task SayAsync([Remainder] [Summary("Text to echo")] string echo) => ReplyAsync(echo);

            // Stops the program with a command.
            [Command("stop")]
            [Summary("Stop the bot")]
            public Task StopCAsync()
            {
                ReplyAsync("Alright. Goodbye! ");
                Environment.Exit(0);
                return BotHandler.Client.StopAsync();
            }
        }
    }
}