using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Swindler.Client.Contracts
{
    /// <summary>
    /// Represents the options for running Mountebank.
    /// </summary>
    public class Options
    {
        public Options()
        {
            IpWhitelist = new List<string>();
        }

        /// <summary>
        /// Gets or sets a value indicating whether to allow Mountebank to support JavaScript injection for predicates, stub 
        /// responses, behavior decoration, wait behavior functions and TCP request resolution.
        /// </summary>
        /// <remarks>
        /// Allowing injection means that an attacker can run random code on the machine running Mountebank. Please see the 
        /// security page for tips on securing your system.
        /// </remarks>
        [JsonPropertyName("allowInjection")]
        public bool AllowInjection { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to include a matches array with each stub in the body of a GET imposter 
        /// response for debugging why a particular stub did or did not match a request.
        /// </summary>
        [JsonPropertyName("debug")]
        public bool Debug { get; set; }

        /// <summary>
        /// Gets or sets the collection of whitelisted IP addresses.
        /// </summary>
        [JsonPropertyName("ipWhitelist")]
        public List<string> IpWhitelist { get; }

        /// <summary>
        /// Gets or sets a value indicting whether Mountebank (only allows requests from the local machine? - FIND OUT)
        /// </summary>
        [JsonPropertyName("localOnly")]
        public bool LocalOnly { get; set; }

        /// <summary>
        /// Gets or sets the name of the Mountebank log file.
        /// </summary>
        [JsonPropertyName("logfile")]
        public string LogFile { get; set; }

        /// <summary>
        /// Gets or sets the logging level, one of debug, info, warn or error.
        /// </summary>
        [JsonPropertyName("loglevel")]
        public string LogLevel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Mountebank should remember all requests for mock verification. 
        /// </summary>
        /// <remarks>
        /// Note that this represents a memory leak for any long running Mountebank process, as requests are never forgotten.
        /// </remarks>
        [JsonPropertyName("mock")]
        public bool Mock { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a log file should be written to.
        /// </summary>
        [JsonPropertyName("noLogFile")]
        public bool NoLogFile { get; set; }

        [JsonPropertyName("origin")]
        public bool Origin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to (parse? - FIND OUT).
        /// </summary>
        [JsonPropertyName("noParse")]
        public bool NoParse { get; set; }

        /// <summary>
        /// Gets or sets the port to run the main mountebank server on. Defaults to 2525.
        /// </summary>
        [JsonPropertyName("port")]
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the file where the pid (process id) is stored for the stop command.
        /// </summary>
        [JsonPropertyName("pidfile")]
        public string ProcessIdFile { get; set; }

        /// <summary>
        /// Gets or sets the name of the protocols file.
        /// </summary>
        [JsonPropertyName("protofile")]
        public string ProtocolFile { get; set; }
    }
}
