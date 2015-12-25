/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/12/2014
 * Time: 7:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Hap.Helpers.Commands
{
    /// <summary>
	/// Description of HapCommand.
	/// </summary>
	public abstract class HapCommand
	{
		public HapCommand(CommonCmdletBase cmdlet)
		{
			Cmdlet = cmdlet;
		}
		
		internal CommonCmdletBase Cmdlet { get; set; }
        public abstract void Execute();
	}
}
