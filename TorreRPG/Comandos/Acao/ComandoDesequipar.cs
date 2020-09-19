﻿using TorreRPG.Atributos;
using TorreRPG.Entidades;
using TorreRPG.Entidades.Itens;
using TorreRPG.Enuns;
using TorreRPG.Extensoes;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Linq;
using System.Threading.Tasks;

namespace TorreRPG.Comandos.Acao
{
    public class ComandoDesequipar : BaseCommandModule
    {
        [Command("desequipar")]
        public async Task ComandoDesequiparAsync(CommandContext ctx, string itemString)
        {
            //var jogadorNaoExisteAsync = await ctx.JogadorNaoExisteAsync();
            //if (jogadorNaoExisteAsync) return;

            //var item = string.Empty;
            //switch (itemString.RemoverAcentos().ToLower())
            //{
            //    case "primeira mao":
            //    case "mao principal":
            //    case "primeira":

            //        break;
            //}

            //using (var session = await ModuloBanco.Cliente.StartSessionAsync())
            //{
            //    BancoSession banco = new BancoSession(session);
            //    RPJogador jogador = await banco.GetJogadorAsync(ctx);
            //    RPPersonagem personagem = jogador.Personagem;

            //    bool equipou = false;
            //    // Tenta remover o item
            //    if (personagem.Mochila.TryRemoveItem(indexItem, out RPItem item))
            //    {
            //        // Verifica se o nível do item
            //        if (item.ILevel > personagem.Nivel.Atual)
            //        {
            //            await ctx.RespondAsync($"{ctx.User.Mention}, o seu personagem não tem o nível {item.ILevel.Bold()} para equipar este item!");
            //            return;
            //        }

            //        // Verifica o tipo do item
            //        switch (item.Classe)
            //        {
            //            case RPClasse.Frasco:
            //                // Todas os slots estão equipados?
            //                var pocaoEquipada = personagem.Frascos.ElementAtOrDefault(4);
            //                if (pocaoEquipada != null)
            //                {
            //                    // Avisa
            //                    await ctx.RespondAsync($"{ctx.User.Mention}, você precisa retirar um frasco que está equipado, antes de tentar equipar outro!");
            //                    return;
            //                }

            //                // Equipa
            //                personagem.Frascos.Add(item as RPFrasco);
            //                if (personagem.Zona.Nivel == 0)
            //                    (item as RPFrasco).Resetar();
            //                equipou = true;
            //                break;
            //            case RPClasse.DuasMaoArma:
            //                // Verifica se as duas mão estão equipadas
            //                if (personagem.MaoPrincipal != null)
            //                {
            //                    // Avisa
            //                    await ctx.RespondAsync($"{ctx.User.Mention}, as suas duas mãos já estão ocupadas segurando outro item!");
            //                    return;
            //                }

            //                if (personagem.MaoSecundaria != null)
            //                {
            //                    // Avisa
            //                    await ctx.RespondAsync($"{ctx.User.Mention}, as suas duas mãos já estão ocupadas segurando outro item!");
            //                    return;
            //                }

            //                // Equipa
            //                personagem.Equipar(item);
            //                personagem.MaoPrincipal = item;
            //                equipou = true;
            //                break;
            //            case RPClasse.UmaMaoArma:
            //                // Verifica se a primeira mão estão vazias.
            //                if (personagem.MaoPrincipal == null)
            //                {
            //                    // Equipa
            //                    personagem.Equipar(item);
            //                    personagem.MaoPrincipal = item;
            //                    equipou = true;
            //                    break;
            //                }
            //                // Verifica se a segunda mão está vazia
            //                if (personagem.MaoSecundaria == null && personagem.MaoPrincipal.Classe != RPClasse.DuasMaoArma)
            //                {
            //                    // Equipa
            //                    personagem.Equipar(item);
            //                    personagem.MaoSecundaria = item;
            //                    equipou = true;
            //                    break;
            //                }
            //                // As duas estão ocupadas? Avisa
            //                await ctx.RespondAsync($"{ctx.User.Mention}, as suas duas mãos já estão ocupadas segurando outro item!");
            //                return;
            //            default:
            //                await ctx.RespondAsync($"{ctx.User.Mention}, este item não é equipável!");
            //                return;
            //        }
            //    }
            //    else
            //    {
            //        await ctx.RespondAsync($"{ctx.User.Mention}, #ID não encontrado!");
            //        return;
            //    }

            //    await banco.EditJogadorAsync(jogador);
            //    await session.CommitTransactionAsync();

            //    if (equipou)
            //        await ctx.RespondAsync($"{ctx.User.Mention}, você equipou {item.TipoBaseModificado.Titulo().Bold()}!");
            //}
        }
    }
}
