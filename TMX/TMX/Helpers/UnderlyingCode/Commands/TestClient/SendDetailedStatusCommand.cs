/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/3/2014
 * Time: 8:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using Client.Library.Helpers;
    using Client.Library.ObjectModel;
    using Interfaces.Exceptions;
    using Commands;
    using Core.Proxy;

    /// <summary>
    /// Description of SendDetailedStatusCommand.
    /// </summary>
    class SendDetailedStatusCommand : TmxCommand
    {
        internal SendDetailedStatusCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (SendTmxDetailedStatusCommand)Cmdlet;
            // 20150918
            // var statusSender = new StatusSender(new RestRequestCreator());
            // var statusSender = new StatusSender();
            var statusSender = ProxyFactory.Get<StatusSender>();
            try {
                statusSender.Send(cmdlet.Status);
                cmdlet.WriteObject(cmdlet, true);
            }
            catch (SendingDetailedStatusException e) {
                // throw new SendingDetailedStatusException("Failed to send detailed status");
                // throw;
                // cmdlet.WriteError(cmdlet, e.Message, "FailedToSendDetailedStatus", errorc
                // throw;

                // TODO: log only!
            }
        }
    }
}
