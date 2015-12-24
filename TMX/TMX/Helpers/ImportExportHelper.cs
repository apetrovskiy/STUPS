/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/21/2014
 * Time: 1:08 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Interfaces;
    
    /// <summary>
    /// Description of ImportExportHelper.
    /// </summary>
    public class ImportExportHelper
    {
        #region Test settings
        public static void ExportTestSettings(
            // 20140720
            SettingsCmdletBase cmdlet,
            // ISettingsCmdletBaseDataObject cmdlet,
            string path,
            string[] variableNames)
        {
            try {
                var rootElement = new XElement("variables");
                
                foreach (var variableName in variableNames) {
                    var variable = cmdlet.SessionState.PSVariable.Get(variableName);
                    try {
                        if (string.IsNullOrEmpty(variable.Name)) continue;
                        // if (null != variable.Name && string.Empty != variable.Name) {
                        var variableElement =
                            new XElement("variable",
                                new XAttribute("name", variable.Name),
                                new XAttribute("value", variable.Value));
                        rootElement.Add(variableElement);

                        /*
                        if (!string.IsNullOrEmpty(variable.Name)) {
                        // if (null != variable.Name && string.Empty != variable.Name) {
                            XElement variableElement =
                                new XElement("variable",
                                             new XAttribute("name", variable.Name),
                                             new XAttribute("value", variable.Value));
                            rootElement.Add(variableElement);
                        }
                        */
                    }
                    catch (Exception eVariable) {
                        // 20140720
//                        cmdlet.WriteError(
//                            cmdlet,
//                            "Unable to export variable '" +
//                            variableName +
//                            "'.",
//                            "FailedToExportVariable",
//                            ErrorCategory.InvalidArgument,
//                            false);
                        throw new Exception(
                            "Unable to export variable '" +
                            variableName +
                            "'.");
                    }
                }
                
                var document = new XDocument();
                document.Add(rootElement);
                document.Save(path);
            }
            catch (Exception eCreateDocument) {
                // 20140720
//                cmdlet.WriteError(
//                    cmdlet,
//                    "Unable to save XML report to the file '" +
//                    path +
//                    "'. " + 
//                    eCreateDocument.Message,
//                    "FailedToSaveReport",
//                    ErrorCategory.InvalidOperation,
//                    true);
                throw new Exception(
                    "Unable to save XML report to the file '" +
                    path +
                    "'. " + 
                    eCreateDocument.Message);
            }
        }
        
        public static void ImportTestSettings(
            ISettingsCmdletBaseDataObject cmdlet,
            string path,
            string[] variableNames)
        {
            XElement wholeXML =
                XElement.Load(path);
            
            // default result
            Func<IEnumerable<string>, XElement, bool> query = (variableNamesCollection, variableElement) => true;
            
//            cmdlet.WriteVerbose(cmdlet, "checking the VariableName list");
            if (null != variableNames && variableNames.Any()) {
//                cmdlet.WriteVerbose(cmdlet, "the VariableName list is not empty");
                query = (variableNamesCollection, variableElement) => variableNamesCollection.Contains(variableElement.Attribute((XName)"name").Value);
            }
            
//            cmdlet.WriteVerbose(cmdlet, "getting the variables collection");
            var variablesCollection = 
                from variableElement in wholeXML.Elements()
                where query(((IEnumerable<string>)variableNames), variableElement)
                    select variableElement;
            
//            cmdlet.WriteVerbose(cmdlet, "collection created");
            
            if (null == variablesCollection || !variablesCollection.Any()) {
//                cmdlet.WriteVerbose(cmdlet, "there are no variables to import");
                return;
            }
            
            // 20140721
            // TmxHelper.ImportVariables(cmdlet, variablesCollection);
            // 20160116
            // ImportExportHelper.ImportVariables(cmdlet, variablesCollection);
        }
        
        // 20160116
        /*
        public static bool ImportVariables(
            // 20140720
            // SettingsCmdletBase cmdlet,
            ISettingsCmdletBaseDataObject cmdlet,
            IEnumerable<XElement> variablesCollection)
        {
            bool result = false;
            
            foreach (XElement element in variablesCollection) {
                
                string variableName = string.Empty;
                
                try {
                
                    variableName =
                            element.Attribute((XName)"name").Value;
                    
//                    cmdlet.WriteVerbose(cmdlet, "importing the '" + variableName + "' variable");
                    
                    string variableValue =
                        string.Empty;
                    try {
                        variableValue =
                            element.Attribute((XName)"value").Value;
                    }
                    catch {
                        // nothing to do
                    }
                        
                    //ScopedItemOptions.AllScope
                    //ScopedItemOptions.Constant
                    //ScopedItemOptions.None
                    //ScopedItemOptions.Private
                    //ScopedItemOptions.ReadOnly
                    //ScopedItemOptions.Unspecified
                
                    var variable = 
                        new PSVariable(
                            variableName,
                            variableValue);
                    cmdlet.SessionState.PSVariable.Set(variable);
                }
                catch (Exception eLoadingVariable) {
                    // 20140720
//                    cmdlet.WriteError(
//                        cmdlet,
//                        "Unable to load variable '" +
//                        variableName +
//                        "'. " +
//                        eLoadingVariable.Message,
//                        "FailedToLoadVariable",
//                        ErrorCategory.InvalidData,
//                        false);
                    throw new Exception(
                        "Unable to load variable '" +
                        variableName +
                        "'. " +
                        eLoadingVariable.Message);
                }
            }

            return result;
        }
        */
        #endregion Test settings
    }
}
