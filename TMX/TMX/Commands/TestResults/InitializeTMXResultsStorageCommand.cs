/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/27/2013
 * Time: 8:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InitializeTmxResultsStorageCommand.
    /// </summary>
    [Cmdlet(VerbsData.Initialize, "TmxResultsStorage", DefaultParameterSetName = "WithCredentials")]
    public class InitializeTmxResultsStorageCommand : DatabaseCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = true,
                   ParameterSetName = "WithCredentials")]
        [Parameter(Mandatory = true,
                   ParameterSetName = "Integrated")]
        [ValidateNotNullOrEmpty()]
        public string Server { get; set; }
        
        [Parameter(Mandatory = true,
                   ParameterSetName = "WithCredentials")]
        [Parameter(Mandatory = true,
                   ParameterSetName = "Integrated")]
        [ValidateNotNullOrEmpty()]
        public string Database { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "WithCredentials")]
        [ValidateNotNullOrEmpty()]
        public string Username { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "WithCredentials")]
        public string Password { get; set; }
        
        [Parameter(Mandatory = false,
                   ParameterSetName = "Integrated")]
        public SwitchParameter IntegratedSecurity { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            Preferences.Storage = true;
            Preferences.StorageServer = Server;
            Preferences.StorageDatabase = Database;
            if (!string.IsNullOrEmpty(Username)) {
                Preferences.StorageUsername = Username;
                Preferences.StoragePassword = Password;
            } else {
                Preferences.StorageIntegratedSecurity = true;
            }
            
            StorageHelper.InitializeStorage();
        }
    }
}
