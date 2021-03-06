﻿using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;

namespace WafclastRPG.Bot.Extensoes
{
    public static class DiscordEmbedBuilderExtension
    {
        public static DiscordEmbedBuilder Criar(this DiscordEmbedBuilder embed, DiscordUser user)
        {
            embed.WithAuthor(user.Username, iconUrl: user.AvatarUrl);
            embed.WithFooter("Se estiver perdido digite !ajuda.", "https://cdn.discordapp.com/attachments/736163626934861845/742671714386968576/help_animated_x4_1.gif");
            return embed;
        }

        public static DiscordEmbedBuilder Criar(this DiscordEmbedBuilder embed, CommandContext ctx)
            => Criar(embed, ctx.User);
    }
}
