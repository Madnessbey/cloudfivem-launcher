using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRPC;
using DiscordRPC.Logging;

namespace MaintenanceDiscordRPC
{
    class Program
    {
        public static DiscordRpcClient client;

        static void Main(string[] args)
        {
            client = new DiscordRpcClient("711984686108508171");

            client.OnReady += (sender, e) =>
            {
                Console.WriteLine("Received Ready from user {0}", e.User.Username);
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine("Received Update! {0}", e.Presence);
            };

            client.Initialize();

            Secrets secrets = new Secrets()
            {
                JoinSecret = "MTI4NzM0OjFpMmhuZToxMjMxMjM= ",
                SpectateSecret = "MTIzNDV8MTIzNDV8MTMyNDU0"
            };

            Party party = new Party()
            {
                ID = Secrets.CreateFriendlySecret(new Random()),
                //ID = "ae488379-351d-4a4f-ad32-2b9b01c91657",
                Size = 1,
                Max = 64
            };

            //Give the game some time so we have a nice countdown
            Timestamps timestamps = new Timestamps()
            {
                Start = DateTime.UtcNow
            };

            client.RegisterUriScheme("711984686108508171");

            client.SetSubscription(EventType.Join | EventType.Spectate | EventType.JoinRequest);

            client.SetPresence(new RichPresence()
            {
                Details = "sadRP",
                State = "sadRP",
                Assets = new Assets()
                {
                    LargeImageKey = "sadRP",
                    LargeImageText = "Galaksinin En Kötüsü",
                    SmallImageKey = "küçük resim id",
                    SmallImageText = "küçük resim mesajı"
                },
                Secrets = secrets,
                Party = party,
                Timestamps = timestamps
            });

            Console.ReadKey();
        }
    }
}