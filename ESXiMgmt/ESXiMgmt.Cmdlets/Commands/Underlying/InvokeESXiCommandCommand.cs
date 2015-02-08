/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/1/2012
 * Time: 10:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

//namespace EsxiMgmt.Cmdlets.Commands
//{
//    using System;
//    using System.Management.Automation;
//        
//    /// <summary>
//    /// Description of InvokeESXiCommandCommand.
//    /// </summary>
//    [Cmdlet(VerbsLifecycle.Invoke, "ESXiCommand")]
//    public class InvokeESXiCommandCommand : ConnectCmdletBase
//    {
//        public InvokeESXiCommandCommand()
//        {
//        }
//        
//        #region Parameters
//        [Parameter(Mandatory = true,
//                   ParameterSetName = "UserInput")]
//        [Parameter(Mandatory = true,
//                   ParameterSetName = "PipelineInput")]
//        public string Command { get; set; }
//        #endregion Parameters
//        
//        protected override void ProcessRecord()
//        {
//            ESXiConnection result = 
//                VMwareHelper.ConnectToServer(
//                    this.InputObject,
//                    this.Server,
//                    this.Port,
//                    this.Username,
//                    this.Password,
//                    this.DatastoreName);
//            //WriteObject(result);
//            
////            while(true)
////            {
////                Console.Write("Enter a command to execute ['Enter' to cancel]: ");
////                string command = Console.ReadLine();
////                if(command=="")break;
////                string output = exec.RunCommand("ls");
////                //string output = shell..RunCommand("ls");
////                Console.WriteLine(output);
////            }
////            Console.Write("Disconnecting...");
////            exec.Close();
//            //shell.Close();
////            Console.WriteLine("Closed: OK");
//
//            System.IO.TextWriter standardWriter = 
//                Console.Out;
//            System.IO.Stream stream = 
//                new System.IO.MemoryStream();
//            System.IO.TextWriter writer = 
//                new System.IO.StreamWriter(stream);
//            Console.SetOut(writer);
//            string output = 
//                result.Ssh.RunCommand(
//                    this.Command);
//            Console.SetOut(standardWriter);
//            WriteObject(output);
//            
//        }
//    }
//}
