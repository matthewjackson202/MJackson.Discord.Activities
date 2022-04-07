using System;
using System.Threading.Tasks;
using Discord.Commands;

namespace MJackson.Discord.Activities.Bot.Modules
{
    public class Modules
    {
        public class AdminModule : ModuleBase<SocketCommandContext>
        {
            [Command("say")]
            [Summary("Echoes message")]
            public Task SayAsync([Remainder] [Summary("Text to echo")] string echo) => ReplyAsync(echo);

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