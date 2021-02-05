namespace Assets.DebugConsole.Commands
{
    public interface ICommand
    {
        string Name { get; }
        string Description { get; }
        string Usage { get;  }
        string RunCommand(params string[] args);
    }
}