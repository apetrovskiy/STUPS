/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 15/12/2011
 * Time: 10:27 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using System.Management.Automation.Provider;
    using System.Windows.Automation;
    using System.Collections.ObjectModel;
    using UIAutomation.Commands;
    
    /// <summary>
    /// Description of UIAProvider.
    /// </summary>
    [CmdletProvider("UIAProvider", ProviderCapabilities.None)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class UIAProvider : DriveCmdletProvider // ItemCmdletProvider // ContainerCmdletProvider // DriveCmdletProvider // CmdletProvider
    {

        private UIADriveInfo uIAPSDriveInfo; // ???????????????
        private UIADriveInfo rootDrive;
        private RuntimeDefinedParameterDictionary dynamicParameters;

        #region CmdletProvider Overloads
        
        protected override ProviderInfo Start(ProviderInfo providerInfo)
        {
            WriteVerbose("UIAProvider::Start()");
            return providerInfo;
        }
        
        protected override void Stop()
        {
            this.rootDrive = null;
        }

        #endregion CmdletProvider Overloads
        
        #region DriveCmdletProvider Overloads
        
        protected override object NewDriveDynamicParameters()
        {
            try{
                WriteVerbose("UIAProvider::NewDriveDynamicParameters()");
                dynamicParameters =
                    new RuntimeDefinedParameterDictionary();
                Collection<Attribute> atts1 = new Collection<Attribute>();
                ParameterAttribute parameterAttribute1 = new ParameterAttribute();
                parameterAttribute1.Mandatory = true;
                //parameterAttribute1.ParameterSetName = "WindowNameParameterSet";
                atts1.Add(parameterAttribute1);
                AllowEmptyStringAttribute attr1 = new AllowEmptyStringAttribute();
                atts1.Add(attr1);
                dynamicParameters.Add(
                    "WindowName", 
                    new RuntimeDefinedParameter(
                        "WindowName", 
                        typeof(string), 
                        atts1));
                
                Collection<Attribute> atts2 = new Collection<Attribute>();
                ParameterAttribute parameterAttribute2 = new ParameterAttribute();
                parameterAttribute2.Mandatory = true;
                //parameterAttribute2.ParameterSetName = "ProcessNameParameterSet";
                atts2.Add(parameterAttribute2);
                AllowEmptyStringAttribute attr2 = new AllowEmptyStringAttribute();
                atts2.Add(attr2);
                dynamicParameters.Add(
                    "ProcessName", 
                    new RuntimeDefinedParameter(
                        "ProcessName", 
                        typeof(string), 
                        atts2));
                
                Collection<Attribute> atts3 = new Collection<Attribute>();
                ParameterAttribute parameterAttribute3 = new ParameterAttribute();
                parameterAttribute3.Mandatory = true;
                //parameterAttribute3.ParameterSetName = "ProcessIdParameterSet";
                atts3.Add(parameterAttribute3);
                AllowEmptyStringAttribute attr3 = new AllowEmptyStringAttribute();
                atts3.Add(attr3);
                dynamicParameters.Add(
                    "ProcessId", 
                    new RuntimeDefinedParameter(
                        "ProcessId", 
                        typeof(int), 
                        atts3));
                
                return dynamicParameters;
            }
            catch (Exception e) {
                WriteVerbose(e.Message);
                WriteVerbose("UIAProvider::NewDriveDynamicParameters()");
                return null;
            }
        }
        
        protected override Collection<PSDriveInfo> InitializeDefaultDrives()
        {
            NewDriveDynamicParameters();
            try{
                Collection<PSDriveInfo> result = new Collection<PSDriveInfo>();
                PSDriveInfo drive =
                    new PSDriveInfo(
                        "UIA",
                        this.ProviderInfo,
                        @"UIAutomation\UIAProvider::\", //"UIAutomation",
                        "This is the UI Automation root drive",
                        null);
                rootDrive = new UIADriveInfo(drive);
                result.Add(rootDrive);
                return result;
            }
            catch (Exception e) {
                WriteVerbose(e.Message);
                WriteVerbose("UIAProvider::InitializeDefaultDrives()");
                return null;
            }
        }
   
        // 20120824
//        protected override PSDriveInfo NewDrive(PSDriveInfo drive)
//        {
//            try{
//                WriteVerbose("UIAProvider::NewDrive()");
//                string windowName = string.Empty;
//                string processName = string.Empty;
//                int processId = 0;
//
//                RuntimeDefinedParameterDictionary dynamicParameters = 
//                    base.DynamicParameters as RuntimeDefinedParameterDictionary;
//                try{windowName = dynamicParameters["WindowName"].Value.ToString();} 
//                catch (Exception e1) {
//                    // nothing to report
//                    // there might not be a parameter
//                }
//                try{processName = dynamicParameters["ProcessName"].Value.ToString();} 
//                catch (Exception e2) {
//                    // nothing to report
//                    // there might not be a parameter
//                }
//                try{processId = (int)dynamicParameters["ProcessId"].Value;} 
//                catch (Exception e3) {
//                    // nothing to report
//                    // there might not be a parameter
//                }
//                if (processId > 0) {
//                    return new UIADriveInfo(processId, drive);
//                } else if (processName.Length > 0) {
//                    return new UIADriveInfo(processName, drive);
//                } else if (windowName.Length > 0) {
//                    return new UIADriveInfo(windowName, drive);
//                } else {
//                    return new UIADriveInfo(drive);
//                }
//            }
//            catch (Exception e) {
//                WriteVerbose(e.Message);
//                WriteVerbose("UIAProvider::NewDrive()");
//                return null;
//            }
//        }
        
        /// <summary>
        /// The Windows PowerShell engine calls this method when the 
        /// Remove-PSDrive cmdlet is run and the path to this provider is 
        /// specified. This method closes the ODBC connection of the drive.
        /// </summary>
        /// <param name="drive">The drive to remove.</param>
        /// <returns>An accessDBPSDriveInfo object that represents 
        /// the removed drive.</returns>
        protected override PSDriveInfo RemoveDrive(PSDriveInfo drive)
        {
            try{

                // Check if drive object is null.
                if (drive == null)
                {
                    ErrorRecord err =
                        new ErrorRecord(
                          new ArgumentNullException("drive"),
                          "NullDrive",
                          ErrorCategory.InvalidArgument,
                          null);
                    err.ErrorDetails = 
                        new ErrorDetails(
                            "The PSDriveInfo argument is null");
                    //ThrowTerminatingError(err);
                    this.ThrowTerminatingError(err);
                }

                UIADriveInfo driveInfo = drive as UIADriveInfo;
                
                if (driveInfo == null)
                {
                    return null;
                }
                
                driveInfo.Window = null;
                
                return driveInfo;
            }
            catch (Exception e) {
                WriteVerbose(e.Message);
                WriteVerbose("UIAProvider::RemoveDrive()");
                return null;
            }
        } // End RemoveDrive.
        
        #endregion DriveCmdletProvider Overloads
        
//        #region ItemCmdletProvider Overloads
//        
//        protected override bool IsValidPath(string path)
//        {
//            bool result = false;
//            //throw new NotImplementedException();
//            
//            // drive-qualified paths
//            if (path.ToUpper().Contains(
//                uIAPSDriveInfo.Name.ToUpper() + 
//                @":\")) { return true; }
//            
//            // provider-qualified paths
//            if (path.ToUpper().Contains(
//                @"UIAUTOMATION::\" + 
//                uIAPSDriveInfo.Name.ToUpper())) { return true; }
//            
//            if (path.ToUpper().Contains(
//                @"UIAUTOMATION::" + 
//                uIAPSDriveInfo.Name.ToUpper())) { return true; }
//            
//            // provider-direct paths
//            if (path.ToUpper().Contains(
//                @"\\" + 
//                uIAPSDriveInfo.Name.ToUpper() + 
//                @"\")) { return true; }
//            
//            
//            return result;
//        }
//        
////        protected override void GetItem(string path)
////        {
////            //base.GetItem(path);
////            
////        }
//        
//        /// <summary>
//        /// The Windows PowerShell engine calls this method when the 
//        /// Get-Item cmdlet is run and the path to this provider is 
//        /// specified. This method retrieves an item using the specified path.
//        /// </summary>
//        /// <param name="path">The path to the item to be return.</param>
//        protected override void GetItem(string path)
//        {
//            // Check to see if the path represents a valid drive.
//            if (this.PathIsDrive(path))
//            {
//                WriteItemObject(this.PSDriveInfo, path, true);
//                return;
//            } // End if(PathIsDrive...).
//            
//            // Get the table name and row information from the path and do 
//            // the necessary actions.
//            string tableName;
//            int rowNumber;
//            
//            PathType type = this.GetNamesFromPath(path, out tableName, out rowNumber);
//            
//            if (type == PathType.Table)
//            {
//                DatabaseTableInfo table = this.GetTable(tableName);
//                WriteItemObject(table, path, true);
//            }
//            else if (type == PathType.Row)
//            {
//                DatabaseRowInfo row = this.GetRow(tableName, rowNumber);
//                WriteItemObject(row, path, false);
//            }
//            else
//            {
//                this.ThrowTerminatingInvalidPathException(path);
//            }
//        } // End GetItem method.
//        
//        /// <summary>
//        /// Tests to see if the specified item exists.
//        /// </summary>
//        /// <param name="path">The path to the item to verify.</param>
//        /// <returns>True if the item is found.</returns>
//        protected override bool ItemExists(string path)
//        {
//            // Check if the path represented is a drive
//            if (this.PathIsDrive(path))
//            {
//                return true;
//            }
//            
//            // Obtain type, table name, and row number from path.
//            string tableName;
//            int rowNumber;
//            
//            PathType type = this.GetNamesFromPath(path, out tableName, out rowNumber);
//            
//            DatabaseTableInfo table = this.GetTable(tableName);
//            
//            if (type == PathType.Table)
//            {
//                // If the specified path represents a table, then the DatabaseTableInfo
//                // object should exist.
//                if (table != null)
//                {
//                    return true;
//                }
//            }
//            else if (type == PathType.Row)
//            {
//                // If the specified path represents a row, then the DatabaseTableInfo 
//                // should exist for the table and the row number must be within
//                // the maximum row count in the table
//                if (table != null && rowNumber < table.RowCount)
//                {
//                    return true;
//                }
//            }
//            
//            return false;
//        } // End ItemExists method.
//        
////        /// <summary>
////        /// Tests to see if the specified path is syntactically valid.
////        /// </summary>
////        /// <param name="path">The path to validate.</param>
////        /// <returns>True if the specified path is valid.</returns>
////        protected override bool IsValidPath(string path)
////        {
////            bool result = true;
////            
////            // Check to see if the path is null or empty.
////            if (String.IsNullOrEmpty(path))
////            {
////                result = false;
////            }
////            
////            // Convert all separators in the path to a uniform one.
////            path = this.NormalizePath(path);
////            
////            // Split the path into individual chunks.
////            string[] pathChunks = path.Split(this.pathSeparator.ToCharArray());
////            
////            foreach (string pathChunk in pathChunks)
////            {
////                if (pathChunk.Length == 0)
////                {
////                    result = false;
////                }
////            }
////            
////            return result;              
////        } // End IsValidPath method.
//
//    #endregion ItemCmdletProvider Overloads
        
    #region ContainerCmdletProvider Overloads
    #endregion ContainerCmdletProvider Overloads
    
    #region NavigationCmdletProvider Overloads
    #endregion NavigationCmdletProvider Overloads
    
    #region Helper Methods
//
//        /// <summary>
//        /// Checks to see if a given path is actually a drive name.
//        /// </summary>
//        /// <param name="path">The path to check.</param>
//        /// <returns>
//        /// True if the path given represents a drive, otherwise false 
//        /// is returned.
//        /// </returns>
//        private bool PathIsDrive(string path)
//        {
//            // Remove the drive name and first path separator.  If the 
//            // path is reduced to nothing, it is a drive. Also, if it is
//            // just a drive then there will not be any path separators.
//            if (String.IsNullOrEmpty(
//                path.Replace(this.PSDriveInfo.Root, string.Empty)) ||
//                String.IsNullOrEmpty(
//                path.Replace(this.PSDriveInfo.Root + this.pathSeparator, string.Empty)))
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        } // End PathIsDrive method.
//        
//        /// <summary>
//        /// Breaks up the path into individual elements.
//        /// </summary>
//        /// <param name="path">The path to split.</param>
//        /// <returns>An array of path segments.</returns>
//        private string[] ChunkPath(string path)
//        {
//            // Normalize the path before splitting
//            string normalPath = this.NormalizePath(path);
//            
//            // Return the path with the drive name and first path 
//            // separator character removed, split by the path separator.
//            string pathNoDrive = normalPath.Replace(
//                this.PSDriveInfo.Root + this.pathSeparator,
//                string.Empty);
//            return pathNoDrive.Split(this.pathSeparator.ToCharArray());
//        } // End ChunkPath method.
//            
//        /// <summary>
//        /// Modifies the path ensuring that the correct path separator
//        /// character is used.
//        /// </summary>
//        /// <param name="path">Path to normanlize.</param>
//        /// <returns>Normanlized path.</returns>
//        private string NormalizePath(string path)
//        {
//            string result = path;
//            
//            if (!String.IsNullOrEmpty(path))
//            {
//                result = path.Replace("/", this.pathSeparator);
//            }
//            
//            return result;
//        } // NormalizePath
//        
//        
//    
    #endregion Helper Methods
    
    }
    

    
    internal class UIADriveInfo : PSDriveInfo
    {
        private System.Windows.Automation.AutomationElement _driveWindow = null;
        private string _windowName = string.Empty;
        private string _processName = string.Empty;
        private int _processId = 0;
//        private System.Diagnostics.Process _process;
        
        public System.Windows.Automation.AutomationElement Window
        {
            get { return _driveWindow; }
            internal set {_driveWindow = value; }
        }
        
        public string WindowName
        {
            get { return _windowName; }
        }
        
        public string ProcessName
        {
            get { return _processName; }
        }
        
        public int ProcessId
        {
            get { return _processId; }
        }
        
//        public System.Diagnostics.Process Process
//        {
//            get { return _process; }
//        }
        
        public UIADriveInfo(
            PSDriveInfo drive) : base(drive)
        {
            try{
                _driveWindow = 
                    AutomationElement.RootElement;
            }
            catch (Exception e) {
                //WriteVerbose(e.Message);
                //WriteVerbose("UIADriveInfo(PSDriveInfo)");
            }
        }

//        public UIADriveInfo(
//            System.Diagnostics.Process process,
//            PSDriveInfo drive) : base(drive)
//        {
//            try{
//                this._process = process;
//                GetUIAWindowCommand cmd;
//                _driveWindow = 
//                    ((cmd = new GetUIAWindowCommand())).GetWindow(
//                        cmd, 
//                        process, 
//                        string.Empty,
//                        process.Id,
//                        string.Empty);
//            }
//            catch (Exception e  ) {
//                WriteVerbose(e.Message);
//                WriteVerbose("UIADriveInfo(Process, PSDriveInfo)");
//            }
//        }
  
  // 20120824
//        public UIADriveInfo(
//            int processId,
//            PSDriveInfo drive) : base(drive)
//        {
//            try{
//                this._processId = processId;
//                GetUIAWindowCommand cmd;
//                _driveWindow = 
//                    ((cmd = new GetUIAWindowCommand())).GetWindow(
//                        cmd, 
//                        null, 
//                        string.Empty,
//                        processId,
//                        string.Empty);
//            }
//            catch (Exception e) {
//                //WriteVerbose(e.Message);
//                //WriteVerbose("UIADriveInfo(int, PSDriveInfo)");
//            }
//        }
//        
//        public UIADriveInfo(
//            string processNameOrWindowTitle,
//            PSDriveInfo drive) : base(drive)
//        {
//            try{
//                this._processName = processNameOrWindowTitle;
//                this._windowName = processNameOrWindowTitle;
//
//                GetUIAWindowCommand cmd;
//                _driveWindow = 
//                    ((cmd = new GetUIAWindowCommand())).GetWindow(
//                        cmd, 
//                        null, 
//                        processNameOrWindowTitle,
//                        0,
//                        processNameOrWindowTitle);
//            }
//            catch (Exception e){
//                //WriteVerbose(e.Message);
//                //WriteVerbose("UIADriveInfo(string, PSDriveInfo)");
//            }
//        }
    }
}
