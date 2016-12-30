namespace UIAutomation
{
    public class Resource
    {
        public const string GetWindowCommand_Error_Timeout = @"Failed to get window in {0} milliseconds by: process name: '{1}', process Id: {2}, window title: '{3}', automationId: '{4}', className: '{5}'.";
        public const string GetWindowCommand_Error_Unknown_error = @"Unknown error in '{0}' ProcessRecord";
        public const string GetWindowCommand_Error_wrong_input = @"Neither ProcessName nor window Name are provided. Or ProcessId == 0";
        public const string GetWindowCommand_Verbose_no_processName__name__processid_or_process_was_supplied = @"no processName, name, processid or process was supplied";
    }
}