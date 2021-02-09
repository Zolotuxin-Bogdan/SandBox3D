using System;
using System.Runtime.Serialization;

namespace Assets.Console
{
    /// <summary>
    /// An exception thrown when attempting to retrieve a command that does not exist.
    /// </summary>
    [Serializable]
    public class NoSuchCommandException : Exception
    {
        public string Command { get; private set; }
        public NoSuchCommandException() : base() { }
        public NoSuchCommandException(string message) : base(message) { }
        public NoSuchCommandException(string message, string command)
            : base(message)
        {
            Command = command;
        }

        public NoSuchCommandException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info != null)
                Command = info.GetString("command");
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info != null)
            {
                info.AddValue("command", Command);
            }
        }
    }
}