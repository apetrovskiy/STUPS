/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2014
 * Time: 10:21 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
	using PSTestLib;
//    using System.Management.Automation;
    using Castle.DynamicProxy;
    
    /// <summary>
    /// The HighlighterAspect is for commands that return objects of IUIElement or IUIEltCollection types.
    /// </summary>
    public class HighlighterAspect : AbstractInterceptor
    {
        public override void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            
            // if (invocation.TargetType.IsSubclassOf(typeof(UiaCommand)) && null != (invocation.ReturnValue as IUiElement)) { // taboo
            // 20140315
            // if (invocation.TargetType.IsSubclassOf(typeof(UiaCommand))) {
            if (invocation.TargetType.IsSubclassOf(typeof(AbstractCommand))) {
                
                var cmdlet =
                    // 20140315
                    // (invocation.InvocationTarget as UiaCommand).Cmdlet;
                    (invocation.InvocationTarget as AbstractCommand).Cmdlet;
                
                // this works
//                if (null != cmdlet.MyInvocation.MyCommand.OutputType && 0 < cmdlet.MyInvocation.MyCommand.OutputType.Count) {
//                    foreach (var element in cmdlet.MyInvocation.MyCommand.OutputType) {
//                        Console.WriteLine(element.Name);
//                    }
//                }
                
                // this does not work
//                if (cmdlet.MyInvocation.MyCommand.OutputType.Contains(new PSTypeName("UIAutomation.IUiElement[]"))) {
//                
//                    Console.WriteLine("HighlighterAspect: this is the right cmdlet");
//                
//                }
            }
        }
    }
}
