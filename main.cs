using Discord;
using Discord.Commands;


namespace DiscoBot {
    class Program {
        static void Main(string[] args) {
            MyBot bot = new MyBot();
        }
    }
    class MyBot {
        DiscordClient discord;
        public MyBot() {
            discord = new DiscordClient(x => {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x => {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            var commands = discord.GetService<CommandService>();

            commands.CreateCommand("hello")
                .Do(async(e) => {
                    await e.Channel.SendMessage("hi");
                });
                
            discord.ExecuteAndWait(async () => {
                await discord.Connect(""); // TOKEN HERE
            });
        }
        private void Log(object sender, LogMessageEventArgs e) {
            Console.WriteLine(e.Message);
        }
    }
}
