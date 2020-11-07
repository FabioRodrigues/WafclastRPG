using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
using WafclastRPG.Bot.Atributos;
using WafclastRPG.Game;

namespace WafclastRPG.Bot.Comandos.Exibir
{
    public class ComandoExaminar : BaseCommandModule
    {
        public Banco banco;

        [Command("examinar")]
        [Description("Permite examinar um item.\n`#ID` se contra na mochila.")]
        [ComoUsar("examinar [#ID]")]
        [Exemplo("examinar #1")]
        public async Task ComandoExaminarAsync(CommandContext ctx, string idEscolhido = "0")
        {
            await Task.CompletedTask;
        }
    }
}
