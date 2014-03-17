/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/15/2014
 * Time: 9:21 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib
{
    using System;
    
    /// <summary>
    /// Description of AbstractCommand.
    /// </summary>
    // public abstract class AbstractCommand
    public class AbstractCommand
    {
        public AbstractCommand(PSCmdletBase cmdlet)
        {
            Cmdlet = cmdlet;
        }
        
        // internal PSCmdletBase Cmdlet { get; set; }
        public virtual PSCmdletBase Cmdlet { get; set; }
        // public abstract void Execute();
        public virtual void Execute()
        {
            
        }
    }
}
