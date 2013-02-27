/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/20/2012
 * Time: 10:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace MoqCmdlets.Commands
{
    using System;
    using System.Management.Automation;
    using Moq;
    
    /// <summary>
    /// Description of NewMqMockCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "MqMock")]
    public class NewMqMockCommand : CommonCmdletBase
    {
        public NewMqMockCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0,
                   ValueFromPipeline = true)]
        //public T MockedType { get; set; }
        //public RuntimeType MockedType { get; set; }
        public object MockedType { get; set; }
        
        [Parameter(Mandatory = false)]
        public object[] Arguments { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            MoqNewMockCommand command =
                new MoqNewMockCommand(this);
            command.Execute();
            
        }
    }
}
