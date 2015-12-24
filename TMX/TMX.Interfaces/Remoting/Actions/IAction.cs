/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/7/2014
 * Time: 6:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Remoting.Actions
{
    using System.Collections.Generic;

    /// <summary>
    /// Description of IAction.
    /// </summary>
    public interface IAction
    {
        Dictionary<string, string> Settings { get; set; } 
        bool Run();
    }
}
