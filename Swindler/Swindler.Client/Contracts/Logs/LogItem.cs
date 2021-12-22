using System;

namespace Swindler.Client.Contracts.Logs
{
    public class LogItem
    {
        public string Level { get; set; }

        public string Message { get; set; }

        public DateTime Timestamp { get; set; }

        public override string ToString()
        {
            return Message;
        }
    }
}
