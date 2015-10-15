namespace Tmx
{
    using Client.Library.ObjectModel;
    using Commands.TestClient;
    using Core;
    using Core.Proxy;
    using Interfaces.Exceptions;

    class ReceiveCommonDataItemsCollectionCommand : TmxCommand
    {
        internal ReceiveCommonDataItemsCollectionCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (ReceiveTmxCommonDataItemsCollection)Cmdlet;
            var commonDataLoader = ProxyFactory.Get<CommonDataLoader>();
            try {
                commonDataLoader.Load();
                cmdlet.WriteObject(true);
            }
                // TODO: create a new exception
            catch (SendingCommonDataItemException e) {
                // throw new Exception("Failed to send data with key '" + cmdlet.Key + "'. " + e.Message);
                throw;
            }
        }
    }
}