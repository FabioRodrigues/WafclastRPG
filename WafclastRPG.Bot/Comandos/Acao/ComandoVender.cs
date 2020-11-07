using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
using WafclastRPG.Bot.Atributos;
using WafclastRPG.Game;

namespace WafclastRPG.Bot.Comandos.Acao
{
    class ComandoVender : BaseCommandModule
    {

        [Command("vender")]
        [Description("Permite vender um item.")]
        [ComoUsar("vender [#ID]")]
        [Exemplo("vender #1")]
        [Cooldown(1, 2, CooldownBucketType.User)]
        public async Task ComandoVenderAsync(CommandContext ctx, string stringId = "")
        {
            await Task.CompletedTask;
        }
    }

}

