using System;
using System.Activities;
using System.ComponentModel;
using System.Threading.Tasks;
using Discord;

namespace MJackson.Discord.Activities.Bot.Activities
{
    public class RetrieveUserById : CodeActivity
    {
        
        
        [Category("Input")] [RequiredArgument] 
        public InArgument<string> UserId { get; set; }

        [Category("Output")] [RequiredArgument] 
        public OutArgument<string> FoundUser { get; set; }


        protected override async void Execute(CodeActivityContext context)
        {

            var userId = UserId.Get(context);
            var userLongId = Convert.ToUInt64(userId);
            
            var userFound = BotHandler.Client.GetUserAsync(userLongId).Result;
            
            Console.WriteLine(userFound);
            FoundUser.Set(context, userFound.Username);
        }
    }
}