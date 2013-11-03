/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 6:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Data.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of NewDtXmlComparerCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "DtXmlComparer")]
    public class NewDtXmlComparerCommand : XMLCmdletBase
    {
        protected override void BeginProcessing()
        {
            DtNewXmlComparerCommand command =
                new DtNewXmlComparerCommand(this);
            command.Execute();
        }
    }
}
