/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/11/2014
 * Time: 6:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Interfaces.Remoting
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of IRunnableClient.
    /// </summary>
    public interface IRunnableClient
    {
        bool RunBeforeAction(string code, IDictionary<string, string> parameters, IDictionary<string, string> previousTaskResults);
        bool RunMainAction(string code, IDictionary<string, string> parameters, IDictionary<string, string> previousTaskResults);
        bool RunAfterAction(string code, IDictionary<string, string> parameters, IDictionary<string, string> previousTaskResults);
    }
}
