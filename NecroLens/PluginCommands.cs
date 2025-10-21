using System;
using Dalamud.Game.Command;
using NecroLens.Data;

namespace NecroLens;

public class PluginCommands : IDisposable
{
    public PluginCommands()
    {
        CommandManager.AddHandler("/necrolens",
            new CommandInfo((_, _) => Plugin.ShowMainWindow())
            {
                HelpMessage = Strings.PluginCommands_OpenOverlay_Help,
                ShowInHelp = true
            });

        CommandManager.AddHandler("/necrolenscfg",
            new CommandInfo((_, _) => Plugin.ShowConfigWindow())
            {
                HelpMessage = Strings.PluginCommands_OpenConfig_Help,
                ShowInHelp = true
            });
        
        CommandManager.AddHandler("/openchest",
            new CommandInfo((_, _) => DungeonService.TryNearestOpenChest())
            {
                HelpMessage = Strings.PluginCommands_OpenChest_Help,
                ShowInHelp = true
            });
        
        CommandManager.AddHandler("/pomander",
            new CommandInfo((_, args) => DungeonService.OnPomanderCommand(args))
            {
                HelpMessage = "使用给定名称的魔陶器/魔科学器",
                ShowInHelp = true
            });
    }

    public void Dispose()
    {
        CommandManager.RemoveHandler("/necrolens");
        CommandManager.RemoveHandler("/necrolenscfg");
        CommandManager.RemoveHandler("/openchest");
        CommandManager.RemoveHandler("/pomander");
    }
}
