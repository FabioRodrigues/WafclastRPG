using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
using WafclastRPG.Game;

namespace WafclastRPG.Bot.Comandos.Exibir
{
    public class ComandoEquipamentos : BaseCommandModule
    {
        public Banco banco;

        [Command("equipamentos")]
        [Aliases("eq")]
        [Description("Permite todos os itens equipados no seu personagem. Cada item está separado por `⌈SLOT⌋`.")]
        public async Task ComandoEquipamentosAsync(CommandContext ctx)
        {
            await Task.CompletedTask;
        }
    }
}
