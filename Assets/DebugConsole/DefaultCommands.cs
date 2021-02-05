using Assets.DebugConsole.Commands;
using UnityEngine;

namespace Assets.DebugConsole
{
    public class DefaultCommands : MonoBehaviour
    {
        private void Start()
        {
            CommandsBase.Instance.RegisterCommand(new HelpCommand());
            CommandsBase.Instance.RegisterCommand(new EchoCommand());
        }
    }
}