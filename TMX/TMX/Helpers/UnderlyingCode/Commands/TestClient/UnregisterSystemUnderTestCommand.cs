/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/25/2014
 * Time: 6:15 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using Client.Library.Helpers;
    using Client.Library.ObjectModel;
    using Commands;
    using Core.Proxy;

    /// <summary>
    /// Description of UnregisterSystemUnderTestCommand.
    /// </summary>
    class UnregisterSystemUnderTestCommand : TmxCommand
    {
        internal UnregisterSystemUnderTestCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (UnregisterTmxSystemUnderTestCommand)Cmdlet;
            // 20150918
            // var registration = new Registration(new RestRequestCreator());
            // var registration = new Registration();
            var registration = ProxyFactory.Get<Registration>();
            registration.UnregisterClient();
        }
    }
}
