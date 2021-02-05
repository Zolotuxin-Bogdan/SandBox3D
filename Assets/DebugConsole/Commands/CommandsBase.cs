using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.DebugConsole.Commands
{
    public class CommandsBase
    {
        protected static CommandsBase _Instance;

        public static CommandsBase Instance => _Instance != null ? _Instance : _Instance = new CommandsBase();
        private CommandsBase() { }

        protected Dictionary<string, ICommand> CommandsDictionary =
            new Dictionary<string, ICommand>(StringComparer.OrdinalIgnoreCase);

        public IEnumerable<ICommand> Commands => 
            CommandsDictionary.OrderBy(kv => kv.Key).Select(kv => kv.Value);

        public void RegisterCommand(ICommand command)
        {
            CommandsDictionary[command.Name.ToLower()] = command;
        }

        public string ExecuteCommand(string command, params string[] args)
        {
            try
            {
                ICommand retrievedCommand = GetCommand(command);
                return retrievedCommand.RunCommand(args);
            }
            catch (NoSuchCommandException e)
            {
                return e.Message;
            }
        }

        public bool TryGetCommand(string command, out ICommand result)
        {
            try
            {
                result = GetCommand(command);
                return true;
            }
            catch (NoSuchCommandException)
            {
                result = default(ICommand);
                return false;
            }
        }

        public ICommand GetCommand(string command)
        {
            if (HasCommand(command.ToLower()))
            {
                return CommandsDictionary[command.ToLower()];
            }
            else
            {
                throw new NoSuchCommandException("Command \"" + command + "\" not found.", command);
            }
        }

        private bool HasCommand(string command)
        {
            return CommandsDictionary.ContainsKey(command);
        }
    }
}