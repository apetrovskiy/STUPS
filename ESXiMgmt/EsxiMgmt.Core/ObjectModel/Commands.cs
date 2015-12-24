/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/24/2015
 * Time: 11:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Core.ObjectModel
{
    /// <summary>
    /// Description of Commands.
    /// </summary>
    public class Commands
    {
        public const string GetVirtualMachines = "vim-cmd vmsvc/getallvms";
        public const string UnregisterVirtualMachine = "vim-cmd vmsvc/unregister {0}";
        public const string RemoveVirtualMachine = "vim-cmd vmsvc/destroy {0}";
        public const string StartVirtualMachine = "vim-cmd vmsvc/power.on {0}";
        public const string StopVirtualMachine = "vim-cmd vmsvc/power.on {0}";
        public const string CreateVirtualMachine = "vim-cmd vmsvc/createdummyvm {0} {1}";
    }
}
