/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/17/2014
 * Time: 7:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

//namespace Tmx
//{
//	using System;
//	using Tmx.Commands;
//	
//	/// <summary>
//	/// Description of StartServerCommand.
//	/// </summary>
//    class StartServerCommand : TmxCommand
//    {
//        internal StartServerCommand(CommonCmdletBase cmdlet) : base (cmdlet)
//        {
//        }
//        
//        internal override void Execute()
//        {
//            var cmdlet = (StartTmxServerCommand)Cmdlet;
//            // 20140721
//            // Control.Start(@"http://localhost:" + cmdlet.Port);
//            Tmx.Server.ServerControl.Start(@"http://localhost:" + cmdlet.Port);
//        }
//    }
//}
