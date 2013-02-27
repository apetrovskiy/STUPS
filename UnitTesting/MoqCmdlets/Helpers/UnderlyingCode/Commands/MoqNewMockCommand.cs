/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/20/2012
 * Time: 10:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace MoqCmdlets
{
    using System;
    using System.Management.Automation;
    using Moq;
    using MoqCmdlets.Commands;
    
    /// <summary>
    /// Description of MoqNewMockCommand.
    /// </summary>
    internal class MoqNewMockCommand : MoqCommand
    {
        internal MoqNewMockCommand(CommonCmdletBase cmdlet)
        {
            this.Cmdlet = cmdlet;
        }
        
        internal override void Execute()
//        {}
//        internal void Execute()
        {
            //T t = ((NewMqMockCommand<T>)this.Cmdlet).MockedType;
            this.Cmdlet.WriteVerbose(this.Cmdlet, "001");
            //Type t = typeof((((NewMqMockCommand)this.Cmdlet).MockedType));
            
            // 20130226
            NewMqMockCommand cmdlet =
            //CommonCmdletBase cmdlet =
                (NewMqMockCommand)this.Cmdlet;
                //(CommonCmdletBase)this.Cmdlet;
            // 20130226
            //var t = System.Type.GetType(((NewMqMockCommand)this.Cmdlet).MockedType.GetType().Name);
            var t = System.Type.GetType(cmdlet.MockedType.GetType().Name);
            
            this.Cmdlet.WriteVerbose(this.Cmdlet, "002");
            //System.Runtime.
//Console.WriteLine(t.GetType().Name);
            
            //this.Cmdlet.WriteVerbose(this.Cmdlet, "003");
            
            // 20130226
            //MoqHelper.CreateMock(this.Cmdlet, ref t, ((NewMqMockCommand)this.Cmdlet).Arguments);
            MoqHelper.CreateMock(cmdlet, ref t, cmdlet.Arguments);
            //;//(((NewMqMockCommand)this.Cmdlet).MockedType)
            
            this.Cmdlet.WriteVerbose(this.Cmdlet, "004");
            
            //var aaa = new Mock<t>();
            this.Cmdlet.WriteObject(this.Cmdlet, t);
            
            this.Cmdlet.WriteVerbose(this.Cmdlet, "005");
            
Console.WriteLine("after 01");
            
            //Mock<System.Random> rnd = new Mock<Random>();
            var rnd = new Mock<Random>();
            rnd.Setup(r => r.Next()).Returns(() => 1000);
            rnd.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>())).Returns((int minValue, int maxValue) => (maxValue - minValue) / 2);
            rnd.Setup(r => r.Next(It.IsAny<int>())).Returns((int maxValue) => (maxValue / 2));
            
            this.Cmdlet.WriteObject(this.Cmdlet, rnd);
        }
    }
}
