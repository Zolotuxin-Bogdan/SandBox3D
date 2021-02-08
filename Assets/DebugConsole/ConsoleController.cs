using System.Linq;
using Assets.DebugConsole.Commands;
using UnityEngine;

namespace Assets.DebugConsole
{
    [RequireComponent(typeof(ConsoleController))]
    public class ConsoleController : MonoBehaviour
    {
        public ConsoleGUI Gui;
        protected InputSystem.InputSystem inputSystem;

        private void Start()
        {
            inputSystem = InputSystem.InputSystem.instance;
            inputSystem.OnKeyPressed += InputCallback;
        }

        private void OnEnable()
        {
            Gui.OnSubmitCommand += ExecuteCommand;
        }

        private void OnDisable()
        {
            Gui.OnSubmitCommand -= ExecuteCommand;
        }

        protected void InputCallback()
        {
            if (inputSystem.IsConsoleKeyPressed())
                Gui.OpenConsole();
            if (inputSystem.IsOpenSettingsKeyPressed())
                Gui.CloseConsole();
        }

        protected void ExecuteCommand(string input)
        {
            var parts = input.Split(' ');
            var command = parts[0];
            Gui.Log(CommandsBase.Instance.ExecuteCommand(command, parts.Skip(1).ToArray()));
        }
    }
}