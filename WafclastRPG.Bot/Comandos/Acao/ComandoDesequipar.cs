using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
using WafclastRPG.Game;
using WafclastRPG.Bot.Atributos;

namespace WafclastRPG.Bot.Comandos.Acao
{
    public class ComandoDesequipar : BaseCommandModule
    {
        public Banco banco;

        [Command("desequipar")]
        [Description("Permite desequipar um item. Veja no equipamentos os `⌈SLOTS⌋` disponíveis.")]
        [ComoUsar("desequipar <slot>")]
        [Exemplo("desequipar mão principal")]
        [Exemplo("desequipar segunda mão")]
        public async Task ComandoDesequiparAsync(CommandContext ctx, [RemainingText] string itemString = "")
        {
            await Task.CompletedTask;
        }
    }
}
