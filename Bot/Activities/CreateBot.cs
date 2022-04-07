using System;
using System.Activities;

namespace MJackson.Discord.Activities.Bot.Activities
{
    public class CreateBot : DiscordActivities
    {
        protected override void Execute(CodeActivityContext context)
        {
            Console.WriteLine("yep?");
        }
    }
}