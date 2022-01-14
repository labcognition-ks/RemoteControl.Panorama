using System.IO;
using LC.Communicator;
using LC.Communicator.ByFile;
using LC.Communicator.ByFile.Structures;

namespace RemoteControl.ReactionMonitoring
{
    class RemoteControl
    {
        public const string FileExtension = ".json";

        /// <summary>
        /// max. time granted for sned and receive operations.
        /// </summary>
        public const int DefaultCommunicationTimeout_ms = 10000;

        /// <summary>
        /// max. time granted on controlled software side to run
        /// the requested action and send a response.
        /// </summary>
        /// <remarks>In case a measurement with an instrument is
        /// ongoing an operation might take some time to return a response!</remarks>
        public const int DefaultCommandTimeout_ms = 5000;

        // Supported command names
        public const string CmdGetReactions = "GetReactions";
        public const string CmdStart = "Start";
        public const string CmdStop = "Stop";
        public const string CmdPause = "Pause";
        public const string CmdResume = "Resume";

        public RemoteControl(string commandDirectory, string responseDirectory, int timeout_ms)
        {
            var sendParameter = new CommunicationParameter {
                FileExtension = FileExtension,
                MonitoredDirectory = commandDirectory,
                Timeout_ms = timeout_ms,
            };

            var receiveParameter = new CommunicationParameter {
                FileExtension = FileExtension,
                MonitoredDirectory = responseDirectory,
                Timeout_ms = timeout_ms,
            };

            this.Client = new Client {
                SenderParameter = sendParameter,
                ReceiverParameter = receiveParameter,
            };
        }

        public Client Client { get; set; }

        public void SetTimeout(int timeout_ms)
        {
            if (this.Client?.SenderParameter != null) {
                this.Client.SenderParameter.Timeout_ms = timeout_ms;
            }

            if (this.Client?.ReceiverParameter != null) {
                this.Client.ReceiverParameter.Timeout_ms = timeout_ms;
            }
        }

        public static void SetDirectory(ICommunicationParameter? parameter, string directory)
        {
            var comParameter = parameter as CommunicationParameter;
            if (comParameter != null) {
                comParameter.MonitoredDirectory = directory;
            }
        }
    }
}
