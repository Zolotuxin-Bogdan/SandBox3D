namespace Assets.DebugConsole.Commands
{
    public class EchoCommand : ICommand
    {
        public string Name { get; } = "echo";
        public string Description { get; } = "print entered text";
        public string Usage { get; } = "echo [text]";
        public string RunCommand(params string[] args)
        {
            return args.Length == 0 ? " " : string.Join(" ", args);
        }
    }
}