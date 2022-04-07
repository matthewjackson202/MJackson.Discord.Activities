using System;
using System.Activities;
using System.ComponentModel;
using System.Threading.Tasks;
using Discord;

namespace MJackson.Discord.Activities.Bot.Activities
{
    public class RetrieveUserById : CodeActivity
    {
        
        // Setup inputs and outputs
        [Category("Input")] [RequiredArgument] 
        public InArgument<string> UserId { get; set; }

        [Category("Output")] [RequiredArgument] 
        public OutArgument<string> FoundUser { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            //Get the users id from the context
            var userId = UserId.Get(context);
            //Conver to long for Discord.Net
            var userLongId = Convert.ToUInt64(userId);
            
            //Async get the user from the static bot the sequence is using.
            var userFound = BotHandler.Client.GetUserAsync(userLongId).Result;
            
            // Set the output to the users name. 
            FoundUser.Set(context, userFound.Username);
        }
    }
}