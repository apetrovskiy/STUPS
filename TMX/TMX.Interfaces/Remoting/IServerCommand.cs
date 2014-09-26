/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/26/2014
 * Time: 8:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Remoting
{
    using System;
    using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of IServerCommand.
    /// </summary>
    public interface IServerCommand
    {
        ServerControlCommands Command { get; set; }
        string Data { get; set; }
    }
}
