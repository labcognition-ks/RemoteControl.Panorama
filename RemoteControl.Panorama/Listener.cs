using System;
using System.IO;
using LC.Communicator;
using LC.Communicator.ByFile;
using LC.Communicator.ByFile.Structures;

namespace RemoteControl.Panorama
{
    /// <summary>
    /// This class implements and auxillary channel listener which is permanently listening
    /// on a monitored directory for incoming Json files
    /// </summary>
    /// <remarks>
    /// Please use a separate directory per monitored channel!
    /// Otherwise one of the other listeners might catch your files.
    /// </remarks>
    public class Listener
    {
        private Receiver<Response<Content[]>>? receiver;
        private Action<string?, string?>? AddLogHandler;

        public Listener(string commandDirectory, int timeout_ms, Action<string?, string?> AddLogHandler)
        {
            this.ReceiverParameter = new CommunicationParameter {
                FileExtension = RemoteControl.FileExtension,
                MonitoredDirectory = commandDirectory,
                Timeout_ms = timeout_ms,
            };

            this.AddLogHandler = AddLogHandler;
        }

        public bool DeleteFileAfterInterpretation { get; set; } = true;
        public CommunicationParameter ReceiverParameter { get; set; }

        public void Start()
        {
            this.receiver = new Receiver<Response<Content[]>> {
                DeleteFileAfterInterpretation = DeleteFileAfterInterpretation,
                ReceiverParameter = this.ReceiverParameter
            };

            this.receiver.Start();
            this.receiver.OnFileCreated += this.Receiver_OnFileCreated;
        }

        public void Stop()
        {
            this.receiver?.Stop();
            this.receiver = null;
        }

        private void Receiver_OnFileCreated(object sender, FileSystemEventArgs e)
        {
            var response = sender as Response<Content[]>;
            if (response == null) {
                this.AddLog(Sender.MsgError, $"The auxillary response file '{e.FullPath}' could not be interpreted!");
                return;
            }

            var message = response.Message ?? "Success";
            AddLog(response.MessageType, $"Reading file '{e.FullPath}' - {message}");
            // unwrap results
            if (response.Result == null) {
                this.AddLog(response.MessageType, $"No result");
                return;
            }

            int i = 0;
            message = "\r\n";
            foreach (var item in response.Result) {
                message += $"Content[{i}]: {item.Name}: {item.Value} ({item.ValueType})\r\n";
                i++;
            }

            this.AddLog("", message);
        }

        private void AddLog(string? messageType, string? message)
        {
            if (this.AddLogHandler != null) {
                this.AddLogHandler(messageType, message);
            }
        }
    }
}
