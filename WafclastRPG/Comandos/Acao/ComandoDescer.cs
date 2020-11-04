﻿using WafclastRPG.Game.Entidades;
using WafclastRPG.Game.Extensoes;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
using WafclastRPG.Game.Services;
using WafclastRPG.Game.BancoItens;
using System;

namespace WafclastRPG.Game.Comandos.Acao
{
    public class ComandoDescer : BaseCommandModule
    {
        public Banco banco;

        [Command("descer")]
        [Description("Permite descer um andar da torre. Encontra novos inimigos!")]
        public async Task ComandoDescerAsync(CommandContext ctx)
        {
            // Verifica se existe o jogador,
            var (naoCriouPersonagem, personagemNaoModificar) = await banco.VerificarJogador(ctx);
            if (naoCriouPersonagem) return;

            int inimigos = 0;
            using (var session = await banco.Client.StartSessionAsync())
            {
                BancoSession banco = new BancoSession(session);
                RPJogador jogador = await banco.GetJogadorAsync(ctx);
                RPPersonagem personagem = jogador.Personagem;

                if (personagem.IsPortalAberto)
                {
                    personagem.Zona.Monstros.Clear();
                    personagem.IsPortalAberto = false;
                }
                else if (personagem.Zona.Monstros.Count != 0)
                {
                    await ctx.RespondAsync($"{ctx.User.Mention}, você precisa eliminar todos os montros para descer!");
                    return;
                }

                bool temMonstros = RPMetadata.MonstrosNomes.ContainsKey(personagem.Zona.Nivel + 1);
                if (temMonstros)
                {

                    inimigos = personagem.Zona.TrocarZona(personagem.VelocidadeAtaque.Modificado, personagem.Zona.Nivel + 1);

                    await banco.EditJogadorAsync(jogador);
                    await session.CommitTransactionAsync();
                    await ctx.RespondAsync($"{ctx.User.Mention}, apareceu {inimigos} monstro na sua frente!");
                }
                else
                {
                    await ctx.RespondAsync($"{ctx.User.Mention}, não existe mais zonas para avançar!");
                }

            }
        }
    }
}