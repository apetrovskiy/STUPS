/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/27/2013
 * Time: 11:18 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Data.Commands
{
    using System.Management.Automation;
    using System.Reflection;
    
    /// <summary>
    /// Description of GetDtSomethingCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "DtSomething")]
    public class GetDtSomethingCommand : PSCmdlet
    {
        [Parameter(Mandatory = true,
                   ValueFromPipeline = true,
                   Position = 0)]
        public object InputObject { get; set; }
        
        protected override void ProcessRecord()
        {
            
            if (null != this.InputObject) {
                
                this.WriteObject(this.InputObject.GetType().Name);
                
                PropertyInfo[] properties =
                    this.InputObject.GetType().GetProperties();
                
                if (null != properties) {
                    
                    foreach (PropertyInfo prop in properties) {
                        
                        this.WriteObject(prop.Name + "\t" + prop.PropertyType.Name);
                    }
                }
                
                this.WriteObject("Properties:" + "\t" + ((PSObject)this.InputObject).Properties.GetType().Name);
                foreach (var prop in ((PSObject)this.InputObject).Properties) {
                    
                    this.WriteObject(prop.Name + "\t" + prop.Value);
                    
                }
                
                
            }
            
        }
    }
}
