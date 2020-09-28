﻿using TorreRPG.Entidades;
using TorreRPG.Extensoes;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace TorreRPG.Comandos.Exibir
{
    public class ComandoMonstros : BaseCommandModule
    {
        [Command("monstros")]
        [Description("Permite ver os monstros que estão na sua frente.")]
        public async Task ComandoMonstrosAsync(CommandContext ctx)
        {
            var jogadorNaoExisteAsync = await ctx.JogadorNaoExisteAsync();
            if (jogadorNaoExisteAsync) return;

            RPJogador jogador = await ModuloBanco.GetJogadorAsync(ctx);
            RPPersonagem personagem = jogador.Personagem;

            if (personagem.Zona.Monstros == null)
            {
                await ctx.RespondAsync($"{ctx.User.Mention}, você não está em combate! Explore uma zona!");
                return;
            }

            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            embed.WithAuthor($"{ctx.User.Username} - {personagem.Nome}", iconUrl: ctx.User.AvatarUrl);

            for (int i = 0; i < personagem.Zona.Monstros.Count; i++)
            {
                var monstro = personagem.Zona.Monstros[i];
                embed.AddField($"`#{i}`{monstro.Nome.Titulo().Bold()}", $"{monstro.Vida.Text()} vida.", true);
            }
            await ctx.RespondAsync(embed: embed.Build());
        }
    }
}