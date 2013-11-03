/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/27/2013
 * Time: 8:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InitializeTMXResultsStorageCommand.
    /// </summary>
    [Cmdlet(VerbsData.Initialize, "TMXResultsStorage", DefaultParameterSetName = "WithCredentials")]
    public class InitializeTMXResultsStorageCommand : DatabaseCmdletBase
    {
        public InitializeTMXResultsStorageCommand()
        {
        }
        
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
            TMX.Preferences.Storage = true;
            TMX.Preferences.StorageServer = this.Server;
            TMX.Preferences.StorageDatabase = this.Database;
            if (!string.IsNullOrEmpty(this.Username)) {
                TMX.Preferences.StorageUsername = this.Username;
                TMX.Preferences.StoragePassword = this.Password;
            } else {
                TMX.Preferences.StorageIntegratedSecurity = true;
            }
            
            StorageHelper.InitializeStorage(this);
        }
    }
}
