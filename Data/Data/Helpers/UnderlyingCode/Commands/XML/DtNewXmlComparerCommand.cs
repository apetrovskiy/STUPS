/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 6:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Data
{
    using Commands;
    
    /// <summary>
    /// Description of DtNewXmlComparerCommand.
    /// </summary>
    internal class DtNewXmlComparerCommand : DataCommand
    {
        internal DtNewXmlComparerCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (NewDtXmlComparerCommand)Cmdlet;
            
            XMLHelper.CreateXMLComparer(cmdlet);
        }
    }
}
