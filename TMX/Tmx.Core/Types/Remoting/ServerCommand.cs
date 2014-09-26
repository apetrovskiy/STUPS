/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/26/2014
 * Time: 8:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core.Types.Remoting
{
    using System;
    using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of ServerCommand.
    /// </summary>
    public class ServerCommand : IServerCommand
    {
        public ServerControlCommands Command { get; set; }
        public string Data { get; set; }
    }
}
