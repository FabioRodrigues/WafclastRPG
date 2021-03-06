﻿using DSharpPlus;
using DSharpPlus.EventArgs;
using System.Threading;
using System.Threading.Tasks;
using WafclastRPG.Bot.Config;

namespace WafclastRPG.Bot.Eventos
{
    public class GuildMemberRemoved
    {
        public static Task Event(DiscordClient c, GuildMemberRemoveEventArgs e, BotInfo botInfo)
        {
            Interlocked.Decrement(ref botInfo.Membros);
            return Task.CompletedTask;
        }
    }
}