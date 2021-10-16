using System.Text.Json.Serialization;

namespace Swindler.Client.Contracts
{
    /// <summary>
    /// Encapsulates information about the Mountebank system configuration.
    /// </summary>
    public class SystemConfiguration
    {
        /// <summary>
        /// Gets or sets the Mountebank version number.
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the command line options used to start Mountebank.
        /// </summary>
        [JsonPropertyName("options")]
        public Options Options { get; set; }

        /// <summary>
        /// Gets or sets information about the Mountebank process.
        /// </summary>
        [JsonPropertyName("process")]
        public Process Process { get; set; }
    }
}
