/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/22/2014
 * Time: 9:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Library.ObjectModel.Objects
{
    using System.Collections.Generic;
    using Tmx.Interfaces.Remoting;

    /// <summary>
    /// Description of TaskPool.
    /// </summary>
    public class TaskPool
    {
        public static List<ITestTask> Tasks = new List<ITestTask>();
        public static List<ITestTask> TasksForClients = new List<ITestTask>();
    }
}
