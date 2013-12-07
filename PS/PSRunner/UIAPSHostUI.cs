/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/12/2012
 * Time: 9:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSRunner
{
    using System;
    using System.Management.Automation;
    using System.Management.Automation.Host;
    using System.Management.Automation.Runspaces;
    using System.Collections;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of UiaPSHostUI.
    /// </summary>
    public class UiaPSHostUI //: PSHostUserInterface
    {
        public UiaPSHostUI()
        {
        }
        
//        public abstract void WriteDebugLine(string message);
//        public abstract void WriteVerboseLine(string message);
//        public abstract void WriteWarningLine(string message);
//        public abstract void WriteProgress(long sourceId, ProgressRecord record);
//        public abstract void WriteErrorLine(string value);
//        public abstract void Write(string value);
//        public abstract void Write(ConsoleColor foregroundColor, ConsoleColor
//        backgroundColor, string value);
//        public virtual void WriteLine();
//        public abstract void WriteLine(string value);
//        public virtual void WriteLine(ConsoleColor foregroundColor, ConsoleColor
//        backgroundColor, string value);
//        public abstract PSHostRawUserInterface RawUI { get; }
//        public abstract Dictionary<string, PSObject> Prompt(string caption, string
//        message, Collection<FieldDescription> descriptions);
//        public abstract int PromptForChoice(string caption, string message,
//        Collection<ChoiceDescription> choices, int defaultChoice);
//        public abstract PSCredential PromptForCredential(string caption, string
//        message, string userName, string targetName);
//        public abstract PSCredential PromptForCredential(string caption, string
//        message, string userName, string targetName, PSCredentialTypes
//        allowedCredentialTypes, PSCredentialUIOptions options);
//        public abstract string ReadLine();
//        public abstract SecureString ReadLineAsSecureString();
        
        public void WriteDebugLine(string message)
        {
            
        }
        
        public void WriteVerboseLine(string message)
        {
            
        }
        
        public void WriteWarningLine(string message)
        {
            
        }
        
        public void WriteProgress(
            long sourceId, 
            ProgressRecord record)
        {
            
        }
        
        public void WriteErrorLine(string value)
        {
            
        }
        
        public void Write(string value)
        {
            
        }
        
        public void Write(
            ConsoleColor foregroundColor, 
            ConsoleColor backgroundColor, 
            string value)
        {
            
        }
        
        public virtual void WriteLine()
        {
            
        }
        
        public void WriteLine(string value)
        {
            
        }
        
        public virtual void WriteLine(
            ConsoleColor foregroundColor, 
            ConsoleColor backgroundColor, 
            string value)
        {
            
        }
        
        //public PSHostRawUserInterface RawUI { get; }
        
        public Dictionary<string, PSObject> Prompt(
            string caption, 
            string message, 
            ICollection<FieldDescription> descriptions)
        {
            return (new Dictionary<string, PSObject>());
//            System.Collections.Generic.Dictionary
            //System.Collections.Generic.ICollection
        }
        
        public int PromptForChoice(
            string caption, 
            string message,
            ICollection<ChoiceDescription> choices, 
            int defaultChoice)
        {
            return 0;
        }
        
//        public PSCredential PromptForCredential(
//            string caption, 
//            string message, 
//            string userName, 
//            string targetName)
//        {
//            return (new PSCredential(string.Empty, string.Empty));
//        }
//        
//        public PSCredential PromptForCredential(
//            string caption, 
//            string message, 
//            string userName, 
//            string targetName, 
//            PSCredentialTypes allowedCredentialTypes, 
//            PSCredentialUIOptions options)
//        {
//            return (new PSCredential(string.Empty, string.Empty));
//        }
        
        public string ReadLine()
        {
            return string.Empty;
        }
        
//        public SecureString ReadLineAsSecureString()
//        {
//            
//        }
        
    }
}
