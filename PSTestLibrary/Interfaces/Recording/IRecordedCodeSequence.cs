/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 10/7/2012
 * Time: 6:57 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib
{
    using System;
    
    /// <summary>
    /// Description of IRecordedCodeSequence.
    /// </summary>
    public interface IRecordedCodeSequence
    {
        System.Collections.Generic.List<IRecordedItem> Items { get; set; }
        System.Collections.Generic.List<string> Header { get; set; }
        System.Collections.Generic.List<string> Data { get; set; }
        System.Collections.Generic.List<string> Footer { get; set; }
        System.Collections.Generic.List<string> Code { get; set; }
        bool ReadyToProduceCode { get; set; }
        bool CodeProduced { get; set; }
        
        bool ContainsDataItem();
        string GenerateCode(CodeAmount codeAmount);
    }
}
