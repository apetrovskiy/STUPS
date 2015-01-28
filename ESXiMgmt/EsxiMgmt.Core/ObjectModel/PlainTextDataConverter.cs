/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/23/2015
 * Time: 5:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Core.ObjectModel
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using Renci.SshNet;
    // TODO: refactoring in SD
    // using EsxiMgmt.Core.Interfaces;
    using Interfaces;
    // using EsxiMgmt.Core.Types;
    using Types;
    
    /// <summary>
    /// Description of PlainTextDataConverter.
    /// </summary>
    public class PlainTextDataConverter
    {
        const string vmId = @"(?m)(?n)(?<=^)\d+(?=\s\s+)";
        const string vmName = @"(?m)(?n)(?i)(?<=^[\d]+\s+)[^\s].*[^\s](?=\s+\[)";
        const string vmFile = @"(?m)(?n)(?i)(?<=.*\s+)\[[^\]]+\].*\.vmx(?=\s\s+\w)";
        const string vmGuestOs = @"";
        const string vmVersion = @"";
        const string vmAnnotation = @"";
//        string _esxiHostname;
//        
//        public PlainTextDataConverter(string esxiHostname)
//        {
//            _esxiHostname = esxiHostname;
//        }
        
        public List<IEsxiVirtualMachine> GetMachines(string plainTextData, string server)
        {
            var resultList = new List<IEsxiVirtualMachine>();
            
            using (var stringReader = new StringReader(plainTextData)) {
                string line = stringReader.ReadLine();
                line = string.Empty;
                while ((line = stringReader.ReadLine()) != null)
                {
                    resultList.Add(
                        new VirtualMachine {
                            Id = getVirtualMachineId(line),
                            Name = getVirtualMachineName(line),
                            Path = getVirtualMachinePath(line),
                            Server = server
                        });
                }
                stringReader.Close();
            }
            
            return resultList;
        }
        
//        public bool RemoveMachine(string plainTextData, string esxiHostname)
//        {
//            
//            
//            return true;
//        }
        
        int getVirtualMachineId(string line)
        {
            return Convert.ToInt32(Regex.Match(line, vmId).Value);
        }
        
        string getVirtualMachineName(string line)
        {
            return Regex.Match(line, vmName).Value;
        }
        
        string getVirtualMachinePath(string line)
        {
            return Regex.Match(line, vmFile).Value;
        }
    }
}
