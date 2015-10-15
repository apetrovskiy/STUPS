namespace Tmx.Commands.TestClient
{
    using System.Management.Automation;

    [Cmdlet(VerbsCommunications.Receive, "TmxCommonDataItemsCollection")]
    public class ReceiveTmxCommonDataItemsCollection : ClientCmdletBase
    {
        protected override void BeginProcessing()
        {
            var command = new ReceiveCommonDataItemsCollectionCommand(this);
            command.Execute();
        }
    }
}