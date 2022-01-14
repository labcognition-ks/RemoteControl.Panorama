namespace RemoteControl.Panorama.Structures
{
    /// <summary>
    /// wrapper to carry the reaction config file path
    /// and timout fo executing the desired command
    /// </summary>
    /// <remarks>
    /// This class must not be changed since it
    /// is implemented in the controlled application in
    /// the same way!</remarks>
    public class CommandSettings
    {
        /// <summary>
        /// The rooted file path of the applicable reactionConfig file.
        /// </summary>
        public string? FilePath { get; set; }

        /// <summary>
        /// The timeout in Milliseconds on the LabCognition software
        /// side to perform the requested operation.
        /// </summary>
        /// <remarks>
        /// The communication timeout must be greater than this timeout!
        /// </remarks>
        public int Timeout_ms { get; set; }
    }
}
