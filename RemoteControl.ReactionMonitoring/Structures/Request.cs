using LC.Communicator;

namespace RemoteControl.ReactionMonitoring.Structures
{
    class Request : IRequest
    {
        public Request(string command)
        {
            this.Command = command;
        }

        public string Command { get; set; }
        public string? Parameter { get; set; }
    }
}
