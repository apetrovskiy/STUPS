/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 8/21/2012
 * Time: 3:14 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX.Commands
{
    using System.Management.Automation;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of InvokeSeWebElementDragAndDropCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "SeWebElementDragAndDrop")] //, DefaultParameterSetName = "Method")]
    [OutputType(typeof(IWebElement))]
    public class InvokeSeWebElementDragAndDropCommand : ActionsCmdletBase
    {
        public InvokeSeWebElementDragAndDropCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true)]
        public IWebElement TargetElement { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            checkInputWebElementOnly(InputObject);
            
            SeHelper.DragAndDropOnElement(
                this, 
                ((IWebElement[])InputObject),
                ((IWebElement)TargetElement));
        }
    }
}
