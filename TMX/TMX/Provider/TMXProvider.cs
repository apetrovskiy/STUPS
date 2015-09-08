/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 15/12/2011
 * Time: 10:27 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    using System.Management.Automation.Provider;
    using System.Collections.ObjectModel;
    //using UIAutomation.Commands;
    using System.Text.RegularExpressions;
    
    /// <summary>
    /// Description of TmxProvider.
    /// </summary>
    [CmdletProvider("TmxProvider", ProviderCapabilities.None)]
    
    public class TmxProvider : ItemCmdletProvider // ContainerCmdletProvider // DriveCmdletProvider // CmdletProvider
    {

        //private TmxDriveInfo uIAPSDriveInfo; // ???????????????
        private TmxDriveInfo rootDrive;
        private RuntimeDefinedParameterDictionary dynamicParameters;
        
        #region CmdletProvider Overrides
        protected override ProviderInfo Start(ProviderInfo providerInfo)
        {
            WriteVerbose("TmxProvider::Start()");
            return providerInfo;
        } 
        
        protected override void Stop()
        {
            rootDrive = null;
        }
        #endregion CmdletProvider Overrides
        
        #region DriveCmdletProvider Overrides
        protected override object NewDriveDynamicParameters()
        {
            try{
                WriteVerbose("TmxProvider::NewDriveDynamicParameters()");
                dynamicParameters =
                    new RuntimeDefinedParameterDictionary();
                var atts1 = new Collection<Attribute>();
                var parameterAttribute1 = new ParameterAttribute {Mandatory = true};
                //ParameterAttribute parameterAttribute1 = new ParameterAttribute();
                //parameterAttribute1.Mandatory = true;
                //parameterAttribute2.ParameterSetName = "WindowNameParameterSet";
                atts1.Add(parameterAttribute1);
                var attr1 = new AllowEmptyStringAttribute();
                atts1.Add(attr1);
                dynamicParameters.Add(
                    "windowName", 
                    new RuntimeDefinedParameter(
                        "windowName", 
                        typeof(string), 
                        atts1));
                
                var atts2 = new Collection<Attribute>();
                var parameterAttribute2 = new ParameterAttribute {Mandatory = true};
                //ParameterAttribute parameterAttribute2 = new ParameterAttribute();
                //parameterAttribute2.Mandatory = true;
                //parameterAttribute2.ParameterSetName = "ProcessNameParameterSet";
                atts2.Add(parameterAttribute2);
                var attr2 = new AllowEmptyStringAttribute();
                atts2.Add(attr2);
                dynamicParameters.Add(
                    "processName", 
                    new RuntimeDefinedParameter(
                        "processName", 
                        typeof(string), 
                        atts2));
                
                var atts3 = new Collection<Attribute>();
                var parameterAttribute3 = new ParameterAttribute {Mandatory = true};
                //ParameterAttribute parameterAttribute3 = new ParameterAttribute();
                //parameterAttribute3.Mandatory = true;
                //parameterAttribute3.ParameterSetName = "ProcessIdParameterSet";
                atts3.Add(parameterAttribute3);
                var attr3 = new AllowEmptyStringAttribute();
                atts3.Add(attr3);
                dynamicParameters.Add(
                    "processId", 
                    new RuntimeDefinedParameter(
                        "processId", 
                        typeof(int), 
                        atts3));
                
                return dynamicParameters;
            }
            catch (Exception e) {
                WriteVerbose(e.Message);
                WriteVerbose("TmxProvider::NewDriveDynamicParameters()");
                return null;
            }
        }
        
        protected override Collection<PSDriveInfo> InitializeDefaultDrives()
        {
            
            NewDriveDynamicParameters();
            
            try{
                var result = new Collection<PSDriveInfo>();
                var drive =
                    new PSDriveInfo(
                        "TMX",
                        ProviderInfo,
                        @"TMX\TmxProvider::\",
                        "This is the TMX root drive",
                        null);
                rootDrive = new TmxDriveInfo(drive);
                result.Add(rootDrive);
                return result;
            }
            catch (Exception e) {
                WriteVerbose(e.Message);
                WriteVerbose("TmxProvider::InitializeDefaultDrives()");
                return null;
            }
        }
        
        protected override PSDriveInfo NewDrive(PSDriveInfo drive)
        {
            try{
            
                string id = string.Empty;
                string name = string.Empty;
            
                WriteVerbose("TmxProvider::NewDrive()");
                var dynamicParameters = DynamicParameters as RuntimeDefinedParameterDictionary;
                try{ id = dynamicParameters["Id"].Value.ToString(); } 
                catch (Exception) {
                    // nothing to report
                    // there might not be a parameter
                }
                try{name = dynamicParameters["Name"].Value.ToString();} 
                catch (Exception) {
                    // nothing to report
                    // there might not be a parameter
                }
                if (id.Length > 0) {
                    return new TmxDriveInfo(id, drive);
                } else if (name.Length > 0) {
                    return new TmxDriveInfo(name, drive);
                } else {
                    return new TmxDriveInfo(drive);
                }
            }
            catch (Exception e) {
                WriteVerbose(e.Message);
                WriteVerbose("TmxProvider::NewDrive()");
                return null;
            }
        }
        
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
                    var err =
                        new ErrorRecord(
                            new ArgumentNullException("drive"),
                            "NullDrive",
                            ErrorCategory.InvalidArgument,
                            null)
                        {
                            ErrorDetails = new ErrorDetails(
                                "The PSDriveInfo argument is null")
                        };
                    ThrowTerminatingError(err);
                }
        
                var driveInfo = drive as TmxDriveInfo;
                
                return driveInfo ?? null;

                /*
                if (driveInfo == null)
                {
                    return null;
                }
                */

                //driveInfo.Window = null;
            }
            catch (Exception e) {
                WriteVerbose(e.Message);
                WriteVerbose("TmxProvider::RemoveDrive()");
                return null;
            }
        } // End RemoveDrive.
        #endregion DriveCmdletProvider Overrides
        
        #region ItemCmdletProvider Overrides
        /// <summary>
        /// test-path cmdlet callback
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected override bool ItemExists(string path)
        {
            bool result = false;
            WriteVerbose(string.Format("TmxProvider::ItemExists(Path = '{0}')",path));
            
            string relativePath = GetTheRestOfPathWihoutProvider(path);
            relativePath = GetTheRestOfPathWihoutDrive(relativePath);
            

//            string npath = XmlProviderUtils.NormalizePath(path);
//            string xpath = XmlProviderUtils.PathNoDrive(npath);
//          
//            XmlDriveInfo drive = XmlProviderUtils.GetDriveFromPath(path,base.ProviderInfo);
//
//            if (drive == null)
//            {
//                return false;
//            }
//            XmlDocument xml = drive.XmlDocument;
//            if (xml.SelectSingleNode(xpath,drive.NamespaceManager) == null)                         
//                return false;         
//            else
//                return true;

            return result;
        }
        
        /// <summary>
        /// Callback used to verify the syntax of a path. This method is usually invoked before the callback method
        /// for the cmdlet(ie set-item, clear-item)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected override bool IsValidPath(string path)
        {
            bool result = false;
            WriteVerbose(string.Format("TmxProvider::IsValidPath(Path = '{0}')", path));

            // Check if the path is null or empty.
            if (string.IsNullOrEmpty(path))
            {
                return result;
            }

//            // Convert all separators in the path to a uniform one.
//            path = XmlProviderUtils.NormalizePath(path);
            
            // drive-qualified paths
//            if (path.ToUpper().Contains(
//                uIAPSDriveInfo.Name.ToUpper() + 
//                @":\")) { return true; }
            if (Regex.IsMatch(
                    path,
                    //(([a-zA-Z0-9]+?[\\]){0,1}[a-zA-Z0-9]+?[\:]{2}([\\]|[\/]){0,2}){0,1}
                    @"(([a-zA-Z0-9]+?[\\]){0,1}[a-zA-Z0-9]+?[\:]{2}([\\]|[\/]){0,2}){0,1}([a-zA-Z0-9\w]+?([\:][\\]|[\/])){0,1}([a-zA-Z0-9\w]+){1}(([\\]|[\/])[a-zA-Z0-9\w]+){0,}")) {
                result = true;
                //return result;
            }
              
            // path expansion
            //if (path == 
            
            
            return result;
            
#region commented
//            // provider-qualified paths
//            if (path.ToUpper().Contains(
//                @"UiaUTOMATION::\" + 
//                uIAPSDriveInfo.Name.ToUpper())) { return true; }
//            
//            if (path.ToUpper().Contains(
//                @"UiaUTOMATION::" + 
//                uIAPSDriveInfo.Name.ToUpper())) { return true; }
//            
//            // provider-direct paths
//            if (path.ToUpper().Contains(
//                @"\\" + 
//                uIAPSDriveInfo.Name.ToUpper() + 
//                @"\")) { return true; }
//
//            // Split path
//            string[] pathChunks = path.Split(XmlProviderUtils.XML_PATH_SEP.ToCharArray());
//
//            foreach (string pathChunk in pathChunks)
//            {
//                if (pathChunk.Length == 0)
//                    return false;
//            }
//
//            return true;
#endregion commented
        }
        
#region commented
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
//                @"UiaUTOMATION::\" + 
//                uIAPSDriveInfo.Name.ToUpper())) { return true; }
//            
//            if (path.ToUpper().Contains(
//                @"UiaUTOMATION::" + 
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
#endregion commented
        
        #endregion ItemCmdletProvider Overrides
        
        string GetTheRestOfPathWihoutProvider(string path)
        {
            string result = string.Empty;
            
            if (path == string.Empty || path.Length == 0) {
                return result;
            }
            
            string tempString = string.Empty;
            
            // provider
            tempString = Regex.Match(
                    path,
                    @"(([a-zA-Z0-9]+?[\\]){0,1}[a-zA-Z0-9]+?[\:]{2}([\\]|[\/]){0,2}){0,1}").Value.ToString();
            if (tempString.Length > 0) {
                result = 
                    path.Substring(
                        path.IndexOf(
                            tempString) +
                        tempString.Length);
            }
            return result;
        }
        
        string GetTheRestOfPathWihoutDrive(string path)
        {
            string result = string.Empty;
            
            if (path == string.Empty || path.Length == 0) {
                return result;
            }
            
            string tempString = string.Empty;
            
            // drive
            tempString = Regex.Match(
                    path,
                    @"([a-zA-Z0-9]+(([\:]){0,1}([\\]|[\/])){1}){1}").Value.ToString();
            if (tempString.Length > 0) {
                result = 
                    path.Substring(
                        path.IndexOf(
                            tempString) +
                        tempString.Length);
            }
            return result;
        }
        
    }
    
    class TmxDriveInfo : PSDriveInfo
    {
//        private string _name = string.Empty;
        string _id = string.Empty;
        
//        public string Name
//        {
//            get { return _name; }
//        }
        
        public string Id
        {
            get { return _id; }
        }
        
        public TmxDriveInfo(
            PSDriveInfo drive) : base(drive)
        {
            try{
                //_driveWindow = 
                //    AutomationElement.RootElement;
            }
            catch (Exception) {
                //WriteVerbose(e.Message);
                //WriteVerbose("TmxDriveInfo(PSDriveInfo)");
            }
        }
        
        public TmxDriveInfo(
            string nameOrId,
            PSDriveInfo drive) : base(drive)
        {
            try{
//                this._name = nameOrId;
                _id = nameOrId;
    
//                GetUiaWindowCommand cmd;
//                _driveWindow = 
//                    ((cmd = new GetUiaWindowCommand())).GetWindow(
//                        cmd, 
//                        null, 
//                        processNameOrWindowTitle,
//                        0,
//                        processNameOrWindowTitle);
            }
            catch (Exception){
                //WriteVerbose(e.Message);
                //WriteVerbose("TmxDriveInfo(string, PSDriveInfo)");
            }
        }
    }
}
