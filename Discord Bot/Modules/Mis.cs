using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Discord_Bot.Modules
{
    public class Mis : ModuleBase<SocketCommandContext>
    {
        //[Command("All Post ")]
        //public async Task Echo()
        //{
        //    //[Remainder]string msg
        //    var embed = new EmbedBuilder();
        //    embed.WithTitle(Context.User.Username);
        //    embed.WithDescription(" احترم حالك يرجى عدم السب او الشتم والا سيتم طردك من السيرفر ");
        //    embed.WithColor(Color.Red);
        //    //await Context.Channel.SendMessageAsync("<  " + Context.User.Username + "  >"+" نورت السيرفر ");
        //    await Context.Channel.SendMessageAsync("" , false , embed);
        //}
        [Command("info")]
        public async Task Info()
        {
            //[Remainder]string msg
            var embed = new EmbedBuilder();
            embed.WithTitle("معلومات");
            embed.WithDescription("sendall : Example (#sendall message) : Describe : send message for all members ");
            embed.WithColor(Color.Blue);
            //await Context.Channel.SendMessageAsync("<  " + Context.User.Username + "  >"+" نورت السيرفر ");
            await Context.Channel.SendMessageAsync("", false, embed);
        }
        [Command("sendall")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Hi([Remainder] string arg = "")
        {
            SocketGuildUser[] _Users;
            _Users = new SocketGuildUser[Context.Guild.Users.Count - 1];

            foreach (SocketGuildUser user in Context.Guild.Users)
            {
                try
                {
                    await user.SendMessageAsync(arg);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    continue;
                }
            }
            await Context.Channel.SendMessageAsync("تم الارسال للجميع ...");
        }
    }
}
