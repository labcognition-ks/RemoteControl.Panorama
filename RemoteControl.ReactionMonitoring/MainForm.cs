using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RemoteControl.ReactionMonitoring.Structures;

namespace RemoteControl.ReactionMonitoring
{
    public partial class MainForm : Form
    {
        private RemoteControl? remoteControl;
        private Listener? auxListener;

        public MainForm()
        {
            InitializeComponent();

            this.numericUpDownTimeout.Value = RemoteControl.DefaultCommunicationTimeout_ms;
            this.numericUpDownCommandTimeout.Value = RemoteControl.DefaultCommandTimeout_ms;
            this.textBoxResponseLog.ReadOnly = true;
            this.EnableCommandButtons(false);
        }

        private void buttonStart_Click(object sender, EventArgs e) =>
            SendCommand(RemoteControl.CmdStart, this.comboBoxReaction.Text);

        private void buttonPause_Click(object sender, EventArgs e) =>
            SendCommand(RemoteControl.CmdPause, this.comboBoxReaction.Text);

        private void buttonResume_Click(object sender, EventArgs e) =>
            SendCommand(RemoteControl.CmdResume, this.comboBoxReaction.Text);

        private void buttonStop_Click(object sender, EventArgs e) =>
            SendCommand(RemoteControl.CmdStop, this.comboBoxReaction.Text);

        private void buttonGetReactions_Click(object sender, EventArgs e) =>
            SendCommand(RemoteControl.CmdGetReactions);

        private void SendCommand(string command, string? reactionConfig = null)
        {
            var timeoutToken = new CancellationTokenSource(Convert.ToInt32(this.numericUpDownTimeout.Value));
            Task.Run(() => this.SendCommandAsync(command, timeoutToken.Token, reactionConfig), timeoutToken.Token);
        }

        private async Task SendCommandAsync(string command, CancellationToken cancellationToken, string? reactionConfig = null)
        {
            if (this.remoteControl == null) {
                return;
            }

            this.Invoke((Action)(() => this.EnableCommandButtons(false)));
            this.Invoke((Action)(() => this.AddResponseLog("Sending", command)));
            this.remoteControl.SetTimeout(Convert.ToInt32(this.numericUpDownTimeout.Value));
            try {
                string? message = null;
                string? messageType = null;
                if (reactionConfig == null) {
                    // get available reaction config file paths
                    var reactions = await this.remoteControl.Client.Get<string[]>(new Request(command), cancellationToken);
                    message = reactions.Message;
                    messageType = reactions.MessageType;
                    this.Invoke((Action)(() => this.comboBoxReaction.DataSource = reactions.Result));
                } else {
                    // run action on selected reaction config
                    var response = await this.remoteControl.Client.Post<CommandSettings, string>(
                        new Request(command),
                        new CommandSettings {
                            FilePath = reactionConfig,
                            Timeout_ms = Convert.ToInt32(this.numericUpDownCommandTimeout.Value),
                        },
                        cancellationToken);
                    message = response.Message;
                    messageType = response.MessageType;
                }

                this.Invoke((Action)(() => this.AddResponseLog(messageType, message)));
                this.Invoke((Action)(() => this.EnableCommandButtons(true)));
            } catch (OperationCanceledException) {
                this.Invoke((Action)(() => this.AddResponseLog("Error", $"Failed due to communication timeout ({Convert.ToInt32(this.numericUpDownTimeout.Value)} ms)")));
            } catch (TimeoutException) {
                this.Invoke((Action)(() => this.AddResponseLog("Error", $"Failed due to communication timeout ({Convert.ToInt32(this.numericUpDownTimeout.Value)} ms)")));
            } catch (Exception exc) {
                this.Invoke((Action)(() => this.AddResponseLog("Error", $"Communication error: {exc.Message}")));
            }

            this.Invoke((Action)(() => this.EnableCommandButtons(true)));
        }

        private void comboBoxReaction_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EnableCommandButtons(bool enabled)
        {
            this.buttonGetReactions.Enabled = enabled;
            var controlButtonsEnabled = enabled && this.comboBoxReaction.Items.Count > 0;
            this.buttonPause.Enabled = controlButtonsEnabled;
            this.buttonResume.Enabled = controlButtonsEnabled;
            this.buttonStart.Enabled = controlButtonsEnabled;
            this.buttonStop.Enabled = controlButtonsEnabled;
        }

        private void textBoxCmdDir_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBoxResponseDir_TextChanged(object sender, EventArgs e)
        {
        }

        private void buttonInit_Click(object sender, EventArgs e)
        {
            this.UpdateRemoteControl();
            this.UpdateAuxListener();
        }

        private void UpdateRemoteControl()
        {
            var enabled = Directory.Exists(this.textBoxCmdDir.Text) &&
                Directory.Exists(this.textBoxResponseDir.Text);

            // on directory changes release current remote control
            if (this.remoteControl?.Client != null) {
                RemoteControl.SetDirectory(this.remoteControl.Client.SenderParameter, this.textBoxCmdDir.Text);
                RemoteControl.SetDirectory(this.remoteControl.Client.ReceiverParameter, this.textBoxResponseDir.Text);
            }

            // initialize new remoteControl
            if (this.remoteControl == null &&
                enabled) {
                this.remoteControl = new RemoteControl(
                    this.textBoxCmdDir.Text,
                    this.textBoxResponseDir.Text,
                    Convert.ToInt32(this.numericUpDownTimeout.Value));
            }

            this.comboBoxReaction.DataSource = null;
            enabled = enabled ? this.CleanupDirectory(this.textBoxResponseDir.Text, this.textBoxResponseLog) : enabled;
            if (!enabled) {
                this.remoteControl = null;
            }

            this.AddResponseLog("Initialize", enabled ? "Success" : "Failed");
            this.EnableCommandButtons(enabled);
        }

        private void UpdateAuxListener()
        {
            var enabled = Directory.Exists(this.textBoxAuxDir.Text);

            // on directory changes release current listener
            if (this.auxListener != null) {
                RemoteControl.SetDirectory(this.auxListener.ReceiverParameter, this.textBoxAuxDir.Text);
            }

            // initialize new listener
            if (this.auxListener == null &&
                enabled) {
                this.auxListener = new Listener(this.textBoxAuxDir.Text, Convert.ToInt32(this.numericUpDownTimeout.Value), this.AddAuxLog);
            }

            enabled = enabled ? this.CleanupDirectory(this.textBoxAuxDir.Text, this.textBoxAuxLog) : enabled;
            if (!enabled) {
                this.auxListener = null;
            }

            this.AddAuxLog("Initialize", enabled ? "Success" : "Failed");
        }

        private bool CleanupDirectory(string directory, TextBox log)
        {
            this.AddLog("Cleaning", directory, log);
            var files = Directory.EnumerateFiles(directory, $"*{RemoteControl.FileExtension}").ToArray();
            var text = $"There are {files.Length} '*{RemoteControl.FileExtension}' files in the monitored directory '{this.textBoxResponseDir.Text}'!\r\n\r\nDo you want to delete them?";
            if (files.Length > 0) {
                if (DialogResult.Yes == MessageBox.Show(text, "WARNING", MessageBoxButtons.YesNo)) {
                    foreach (var file in files) {
                        var success = "Success";
                        try {
                            File.Delete(file);
                        } catch {
                            success = "Failed";
                        }

                        this.AddLog("Deleting", $"{file} - {success}", log);
                    }

                    return true;
                }

                // Manual cleanup required before the user can continue!
                // Otherwise monitoring does not work properly.
                MessageBox.Show($"Please delete all '*{RemoteControl.FileExtension}' files in the monitored directory '{this.textBoxResponseDir.Text}' and click the Initialize button again!");
                return false;
            }

            return true;
        }

        private void AddAuxLog(string? messageType, string? message) =>
            this.Invoke((Action)(() => this.AddLog(messageType, message, this.textBoxAuxLog)));

        private void AddResponseLog(string? messageType, string? message) =>
            this.AddLog(messageType, message, this.textBoxResponseLog);

        private void AddLog(string? messageType, string? message, TextBox log)
        {
            var line = string.Format("{0} {1,-12}: {2}\r\n", DateTime.Now.ToString(), messageType == null ? "Error" : messageType, message == null ? "Success" : message);
            log.Text += line;
        }

        private void buttonBrowseCommandDir_Click(object sender, EventArgs e) =>
            this.textBoxCmdDir.Text = GetDirectory(this.textBoxCmdDir.Text);

        private void buttonBrowseResponseDir_Click(object sender, EventArgs e) =>
            this.textBoxResponseDir.Text = GetDirectory(this.textBoxResponseDir.Text);

        private void buttonBrowseAuxDir_Click(object sender, EventArgs e) =>
            this.textBoxAuxDir.Text = GetDirectory(this.textBoxAuxDir.Text);

        private static string GetDirectory(string initialDir)
        {
            var form = new FolderBrowserDialog();
            form.SelectedPath = initialDir;
            form.ShowNewFolderButton = false;
            if (DialogResult.OK == form.ShowDialog()) {
                return form.SelectedPath;
            }

            return initialDir;
        }

        private void textBoxResponseLog_TextChanged(object sender, EventArgs e)
        {
            // auto scroll down to the end
            this.textBoxResponseLog.SelectionStart = this.textBoxResponseLog.Text.Length;
            this.textBoxResponseLog.ScrollToCaret();
        }

        private void textBoxAuxLog_TextChanged(object sender, EventArgs e)
        {
            // auto scroll down to the end
            this.textBoxAuxLog.SelectionStart = this.textBoxAuxLog.Text.Length;
            this.textBoxAuxLog.ScrollToCaret();
        }
    }
}
