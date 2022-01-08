# Remote Control for Reaction Monitoring Module

This application demonstrates programmatic remote control of the reaction
monitoring module used in panorama products by a thrid party application.

The demo application includes a C# sample implementation indicating how
integration might be done in third party applications.

# Copyright
Copyright (c) 2022 by LabCognition, Analytical Software GmbH & Co. KG

All rights reserved.

# Version History
## 0.1.0
This is the initial version of the remote control.
It is working with the following software:

| Software Name     | Version (internal Version) |
|-------------------|----------------------------|

# Functional Overview
A third party application may send commands to LabCognition software's reaction
monitoring module to remote control a particular reaction run.

The LabCognition software must be started to ensure commands are accepted.

A reaction run must be configured in a way, that interactions with the user do
**not** occur (e.g. reference measurement request).

Available reaction control commands basically mimic button click actions within
the reaction run window (Start, Stop, Pause, Resume).

In addition, available reaction runs registered within the software can be read
out programmatically.

Communication is bi-directional, whereby the third party software may send
commands and receives responses accordingly.

## Sending Commands and receiving Responses
The desired command is sent by dropping a *.Json file into the configured
command directory.

The command file name specifies the command to be executed.

The following commands are supported (see below for details):
- GetReactions
- Start
- Pause
- Resume
- Stop

The command file content may be empty or include parameters as Json objects such
as the file path of the reaction run the command shall be applied (see below).

The LabCognition software will automatically delete the command file after the
command has been interpreted.

In return a response file is dropped as an answer to a command into the response
directory after the software has received and interpreted the command.

The response file name is exactly the same as the command file name.

The response file includes a Json object containing any results, a message and
the message type.

You must take care of deleting the files in the response directory within your
third party application.

Otherwise the files will be automatically overwritten on the next response.

**NOTE: While operating the reaction monitoring module remotely, the user still
has the possibility to interact with the software via the user interface!**

## Error Handling and Logging
Basically, the remote control is completely silent if the reaction run is
configured in a proper way and no obvious error occurs during the reaction run.

In other words, if sent commands do not comply with the requirements, nothing
happens in the software.

### NLog Logging
In case the remote control configuration is inclomplete or erroneous, errors and
warnings can be tracked in the application's NLog log file.

The log file is written into the file
*C:\ProgramData\\\<COMPANY\>\\\<SOFTWARE\>\Logs\\\<SOFTWARE\>-RX.log* by
default.

You may use an NLog.Config file to adapt the log level accordingly, which must
be located in the LabCognition software executable folder.

Adapt the variable *"pre"* to contain the software executable name (without
extension), the variable "Path" to contain the proper company name and the
minimum log level in the *"RX"* rules (currently set to "Warn").

An Example Nlog.Config file is the following:

    <?xml version="1.0" encoding="utf-8"?>
    <nlog xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">

        <!--
            See https://github.com/nlog/nlog/wiki/Configuration-file for
            information on customizing logging rules and outputs.

            or

            http://stackoverflow.com/questions/4091606/most-useful-nlog-configurations
            http://www.danesparza.net/2014/06/things-your-dad-never-told-you-about-nlog/
        -->

        <variable name="pre" value="SOFTWARE"/>
        <variable name="Path" value="${specialfolder:CommonApplicationData}/COMPANY/${pre}/Logs"/>
        <variable name="ext" value=".log"/>

        <targets>
            <target name="LC" xsi:type="File" fileName ="${Path}/${pre}${ext}"/>
            <target name="RX" xsi:type="File" fileName ="${Path}/${pre}-RX${ext}"/>
            <target name="Instrument" xsi:type="File" fileName="${Path}/${pre}-Instrument${ext}"/>
        </targets>

        <rules>
            <!-- Root Log Level -->
            <logger name="*" minlevel="Error" writeTo="LC"/>
            <logger name="LabCognition.ReactionMonitoring.RemoteControl" minlevel="Warn" writeTo="RX"/>
            <logger name="LabCognition.ReactionMonitoring.FileWatcher" minlevel="Warn" writeTo="RX"/>
        
            <logger name="FTIRInst" minlevel="Error" writeTo="Instrument"/>
        </rules>
    </nlog>

### Responses
The response file includes errors and warnings in the same way as the NLog log
file (see below).

# Requirements

## Product License
Using the reaction monitoring module and remote control requires a valid license
of the software and the reaction monitoring add-on module.

## Software Development
LabCognition software is a C# .NET application.
However, since there is no direct integration, linking or referencing of
software components required, the third party application may be programmed in
any other language.

# Prerequisites
Remote control must be configured in the LabCognition software prior to using it
from your third party application.

## Modify *App.Exe.Config* File
Remote control configuration is done in the LabCognition software's
*App.Exe.Config* file.

It is located in the installation directory of the LabCognition software.
(*App* must be replaced by the software executable name, e.g.
*Panorama.exe.config*!)

- Open the *App.Exe.Config* with a text editor in Administrator mode

    **NOTE: You must be an administrator to modify files in the installation
    directory!**

- Add the following keys aywhere in the *Configuration* section:

      <add key="RXRemoteControlCommandDirectory" value="c:\myPath\RXCommand"/>

      <add key="RXRemoteControlResponseDirectory" value="c:\myPath\RXResponse"/>

      <add key="RXRemoteControlCommunicationTimeout" value="10000"/>

- Modify the directories in both keys to your preferred command and response
  directory.
    
    **NOTE: It is strongly recommended to use two different directories for the
    commands and responses! You must have read and write permission to those
    directories. Directories will be created automatically if missing.**

- Modify the communication timeout in Milliseconds to the desired value.

    **NOTE: The timeout will be used for interpretation of an incoming command
    message.**

## Prepare and Start the Reaction Run
The following steps are required to make remote control work without error or
user interaction:

- Start the LabCognition software
- Open the reaction run you would like to remote control from the *Reaction
  Monitoring->Run Reaction* sub-menu and verify, it will run without user
  interaction

    **NOTE: Make sure the reaction run is configured in a way, that no user
    interaction is required when clicking the *Start* button within the reaction
    window.**

- Close the reaction run window again (optional)
- Now start your third party application and send desired commands for this
  reaction run (e.g. Start)
- Receive corresponding reesponses by monitoring the response directory from
  your application
- Make sure to clean up the response directory

# Third Party Software Development
## Commands
Command file may have parameters to specify the reaction run settings.

### Command Settings
Such parameters are:

- FilePath = specifies the rooted file path of the *.reactionConfig file of the
  reaction run to be controlled
- Timeout_ms = Timeout in Milliseconds to allow the command to be executed. In
  caes the command is not completed within the timeout time, it will be
  automatically aborted.

**NOTE: The sample application includes the *CommandSettings* class to carry
these settings.**

### Response
A corresponding response file is created after the command has been processed.
It contains:

- Result = includes any result outputs such as the paths of the *.reactionConfig
  files as string[]; default value = null
- Message = In case of any warning or error the filed contains the message,
  which is the same as the log file message. Default value = null
- MessageType = indicates the priority of the message being
  - Info (default)
  - Warn = Warning; the application might have received a command, which could
    not be executed
  - Error = Failure; executing the command failed for the reasons specified in
    the Message field

**NOTE: The sample application includes the *Response* class to carry these
results.**

The following commands and responses are supported:

### GetReactions
This command returns a list of all configured reaction runs within the
LabCognition software. Basically, it is the same list as shown in the *Reaction
Monitoring->Run Reaction* sub-menu.

#### Command File
- Filename = GetReactions.json
- Content = \<empty\>

#### Response File
- Filename = GetReactions.json
- Content = Response

    ***Example:***

    `
    {
        "Result" = ["C:\\myReactionRuns\\Reaction1.reactionConfig", "C:\\myReactionRuns\\Reaction2.reactionConfig"],
        "MessageType" = "Info",
        "Message" = null
    }
    `

### Start
This command starts the desired reaction run.

**NOTE: In case the reaction is already running, the command is processed but
nothing happens and a warning is returned.**

#### Command File
- Filename = Start.json
- Content = CommandSettings

    ***Example:***

    `
    {
    "FilePath": "C:\\myReactionRuns\\Reaction1.reactionConfig",
    "Timeout_ms": 10000
    }
    `

#### Response File
- Filename = Start.json
- Content = Response

    ***Example: OK***

    `
    {
        "Result" = null,
        "MessageType" = "Info",
        "Message" = null
    }
    `

    ***Example: Error***

    `
    {
        "Result" = null,
        "MessageType" = "Error",
        "Message" = "The error message is provided here"
    }
    `

### Stop
This command stops the desired reaction run.

**NOTE: In case the reaction is not running, the command is processed but
nothing happens and a warning is returned.**

#### Command File
- Filename = Stop.json
- Content = CommandSettings

    ***Example:***

    `
    {
    "FilePath": "C:\\myReactionRuns\\Reaction1.reactionConfig",
    "Timeout_ms": 10000
    }
    `

#### Response File
- Filename = Stop.json
- Content = Response

    ***Example: OK***

    `
    {
        "Result" = null,
        "MessageType" = "Info",
        "Message" = null
    }
    `

### Pause
This command pauses the desired reaction run.

**NOTE: The reaction must be running to pause it. In case it is not running, the
command is processed but nothing happens and a warning is returned.**

**NOTE: A paused reaction run can either be stopped or resumed.**

#### Command File
- Filename = Pause.json
- Content = CommandSettings

    ***Example:***

    `
    {
    "FilePath": "C:\\myReactionRuns\\Reaction1.reactionConfig",
    "Timeout_ms": 10000
    }
    `

#### Response File
- Filename = Pause.json
- Content = Response

    ***Example: OK***

    `
    {
        "Result" = null,
        "MessageType" = "Info",
        "Message" = null
    }
    `

### Resume
This command resumes the desired paused reaction run.

**NOTE: The reaction must be paused to resume it. In case it is not paused, the
command is processed but nothing happens and a warning is returned.**

#### Command File
- Filename = Resume.json
- Content = CommandSettings

    ***Example:***

    `
    {
    "FilePath": "C:\\myReactionRuns\\Reaction1.reactionConfig",
    "Timeout_ms": 10000
    }
    `

#### Response File
- Filename = Resume.json
- Content = Response

    ***Example: OK***

    `
    {
        "Result" = null,
        "MessageType" = "Info",
        "Message" = null
    }
    `
