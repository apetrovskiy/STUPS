/*
 * Created by SharpDevelop.
Alexander Petrovskiy
 * Date: 12/7/2014
 * Time: 6:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core.Types.Remoting
{
    using System;
    using Tmx.Interfaces.Remoting;
    
    /// <summary>
    /// Description of TestRunAction.
    /// </summary>
    public class TestRunAction : IAction
    {
        public bool Run()
        {
            return true;
        }
    }
}
