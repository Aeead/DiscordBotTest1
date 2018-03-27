using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord.Commands;

namespace Discord_Bot
{
    class CommandHandler
    {
        DiscordSocketClient _Client;
        CommandService _Service;

        public async Task InitAsync(DiscordSocketClient _client)
        {
            _Client = _client;
            _Service = new CommandService();
            await _Service.AddModulesAsync(Assembly.GetEntryAssembly());
            _Client.MessageReceived += HandelCommand;
        }

        private async Task HandelCommand(SocketMessage Soc)
        {
            var msg = Soc as SocketUserMessage;

            if (msg == null)
                return;

            var context = new SocketCommandContext(_Client , msg);
            int argpos = 0;

            if (msg.HasStringPrefix(Config._Bot.CmdPrefix , ref argpos) || msg.HasMentionPrefix(_Client.CurrentUser , ref argpos))
            {
                var result = await _Service.ExecuteAsync(context, argpos);
                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }
    }
}
