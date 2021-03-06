﻿using System.Text;

namespace Assets.Console.Commands
{
    public class HelpCommand : ICommand
    {
        public string Name { get; } = "help";

        public string Description { get; } =
            "Display the list of available commands or details about a specific command";
        
        public string Usage { get; } = "help [command]";
        
        public string RunCommand(params string[] args)
        {
            return args.Length == 0 ? DisplayCommands() : DisplayCommandDetails(args[0]);
        }

        protected StringBuilder commandList = new StringBuilder();

        protected string DisplayCommands()
        {
            var commands = CommandsBase.Instance.Commands;
            commandList.Clear();
            commandList.Append("\t\t    <b><color=green>Available commands</color></b>\n");
            foreach (var command in commands)
            {
                commandList.Append(string.Format("    <b>/{0}</b> - {1}\n", command.Usage, command.Description));
            }

            commandList.Append(
                "<color=yellow>To display details about a specific command,type '/help' followed by the command name</color>");
            return commandList.ToString();
        }

        protected string DisplayCommandDetails(string commandName)
        {
            string formatting = "<b>/{0}</b>  -   {1}";
            try
            {
                var command = CommandsBase.Instance.GetCommand(commandName);
                return string.Format(formatting,command.Usage, command.Description);
            }
            catch (NoSuchCommandException e)
            {
                return string.Format("Declaration about '{0}' not found. Is it valid command?", e.Command);
            }
        } 
    }
}