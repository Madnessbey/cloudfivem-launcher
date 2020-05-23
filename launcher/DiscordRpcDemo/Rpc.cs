using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRPC;
using DiscordRPC.Logging;

namespace MaintenanceDiscordRPC
{
    class Rpc
    {
        public static DiscordRpcClient client;

        internal static void SetupRpc()
        {
            client = new DiscordRpcClient("652538071530864653");

            client.Initialize();

            Secrets secrets = new Secrets()
            {
                JoinSecret = "MTI4NzM0OjFpMmhuZToxMjMxMjM",
                SpectateSecret = "MTIzNDV8MTIzNDV8MTMyNDU0"
            };

            Party party = new Party()
            {
                ID = Secrets.CreateFriendlySecret(new Random()),
                Size = 1,
                Max = 64
            };

            //Give the game some time so we have a nice countdown
            Timestamps timestamps = new Timestamps()
            {
                Start = DateTime.UtcNow
            };

            client.RegisterUriScheme("652538071530864653");

            client.SetSubscription(EventType.Join | EventType.Spectate | EventType.JoinRequest);

            client.SetPresence(new RichPresence()
            {
                Details = "Sunucuya Bağlanıyor.",
                State = "Launcher Giriş Ekranında...",
                Assets = new Assets()
                {
                    LargeImageKey = "fadesx",
                    LargeImageText = "khchosting.com",
                    SmallImageKey = "tikfade",
                    SmallImageText = "discord.gg/adonisrp"
                },
                Secrets = secrets,
                Party = party,
                Timestamps = timestamps
            });
        }
    }
}