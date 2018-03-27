using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace Discord_Bot
{
    class Program
    {
        DiscordSocketClient _client;
        CommandHandler _cmd;

        static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult();

        public async Task StartAsync()
        {
            if (Config._Bot.Token == "" || Config._Bot.Token == null) return;

            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = Discord.LogSeverity.Verbose
            });

            _client.Log += Log;
            
            await _client.LoginAsync(Discord.TokenType.Bot, Config._Bot.Token);
            await _client.StartAsync();

            _cmd = new CommandHandler();
            await _cmd.InitAsync(_client);
            await Task.Delay(-1);
            Console.ReadKey();
        }

        private async Task Log(Discord.LogMessage msg)
        {
            Console.WriteLine(msg.Message);
        }
    }
}
