using LC.Communicator;

namespace RemoteControl.Panorama.Structures
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
