using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
using WafclastRPG.Bot.Atributos;
using WafclastRPG.Game;

namespace WafclastRPG.Bot.Comandos.Acao
{
    public class ComandoEquipar : BaseCommandModule
    {
        public Banco banco;

        [Command("equipar")]
        [Aliases("e")]
        [Description("Permite equipar um item.\n`#ID` se contra na mochila.")]
        [ComoUsar("equipar [#ID]")]
        [Exemplo("equipar #1")]
        public async Task ComandoEquiparAsync(CommandContext ctx, string stringIndexItem = "0")
        {
            await Task.CompletedTask;
        }
    }
}
