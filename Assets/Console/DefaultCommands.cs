using Assets.Console.Commands;
using UnityEngine;

namespace Assets.Console
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