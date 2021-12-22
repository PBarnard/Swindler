using System.Collections.Generic;

namespace Swindler.Client.Contracts.Logs
{
    public class SystemLog
    {
        public IList<LogItem> Logs { get; set; }
    }
}
