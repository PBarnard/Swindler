using System.Text.Json.Serialization;

namespace Swindler.Client.Contracts
{
    /// <summary>
    /// Encapsulates information about the running Mountebank process.
    /// </summary>
    public class Process
    {
        /// <summary>
        /// Gets or sets the machine's processor architecture.
        /// </summary>
        [JsonPropertyName("architecture")]
        public string Architecture { get; set; }

        /// <summary>
        /// Gets or sets the current working directory used to start Mountebank.
        /// </summary>
        [JsonPropertyName("cwd")]
        public string CurrentWorkingDirectory { get; set; }

        /// <summary>
        /// Gets or sets the total heap allocated to the Mountebank process.
        /// </summary>
        [JsonPropertyName("heapTotal")]
        public long HeapTotal { get; set; }

        /// <summary>
        /// Gets or sets the used heap size of the Mountebank process.
        /// </summary>
        [JsonPropertyName("heapUsed")]
        public long HeapUsed { get; set; }

        /// <summary>
        /// Gets or sets the node version.
        /// </summary>
        [JsonPropertyName("nodeVersion")]
        public string NodeVersion { get; set; }

        /// <summary>
        /// Gets or sets the machine's operating system.
        /// </summary>
        [JsonPropertyName("platform")]
        public string Platform { get; set; }

        /// <summary>
        /// Gets or sets the Resident Set Size of the Mountebank process.
        /// </summary>
        [JsonPropertyName("rss")]
        public long ResidentSetSize { get; set; }

        /// <summary>
        /// Gets or sets the number of seconds that the Mountebank process has been running.
        /// </summary>
        [JsonPropertyName("uptime")]
        public decimal Uptime { get; set; }
    }
}
