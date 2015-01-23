/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/23/2015
 * Time: 7:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Core.Data
{
    using System;
    using System.Collections.Generic;
    using Renci.SshNet;
    
    /// <summary>
    /// Description of ConnectionData.
    /// </summary>
    public class ConnectionData
    {
        /*
        public ConnectionData()
        {
            Entries = new List<ConnectionInfo>();
        }
        
        public static List<ConnectionInfo> Entries { get; set; }
        */
        public static List<ConnectionInfo> Entries = new List<ConnectionInfo>();
    }
}
