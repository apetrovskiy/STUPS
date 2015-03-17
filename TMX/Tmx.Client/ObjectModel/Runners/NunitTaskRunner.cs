/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/11/2014
 * Time: 7:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Client.ObjectModel.Runners
{
    using System;
    using System.Collections.Generic;
    using Interfaces.Remoting;
    
    /// <summary>
    /// Description of NunitTaskRunner.
    /// </summary>
    public class NunitTaskRunner : IRunnableClient
    {
        public bool RunBeforeAction(
            string code,
            IDictionary<string, string> parameters,
            IDictionary<string, string> previousTaskResults)
        {
            
            return true;
        }
        
        public bool RunMainAction(
            string code,
            IDictionary<string, string> parameters,
            IDictionary<string, string> previousTaskResults)
        {
            
            return true;
        }
        
        public bool RunAfterAction(
            string code,
            IDictionary<string, string> parameters,
            IDictionary<string, string> previousTaskResults)
        {
            
            return true;
        }
    }
}
