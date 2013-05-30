/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/29/2013
 * Time: 9:58 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Data;
    using System.Data.SQLite;
    using FluentNHibernate;
    using FluentNHibernate.Mapping;
    using NHibernate;
    using NHibernate.Mapping;
    
    /// <summary>
    /// Description of ITestResultMap.
    /// </summary>
    public class ITestResultMap : ClassMap<ITestResult>
    {
        public ITestResultMap()
        {
            Id(x => x.DbId);
            Map(x => x.Name);
            Map(x => x.Id);
            //Map(x => x.Error);
            //HasMany(x => x.Details);
            
            Map(x => x.ScriptName);
            Map(x => x.LineNumber);
            Map(x => x.Position);
            Map(x => x.Error);
            Map(x => x.Code);
            //HasMany(x => x.Parameters);
            
            Map(x => x.Status);
            Map(x => x.enStatus);
            
            Map(x => x.TimeSpent);
            Map(x => x.Timestamp);
            Map(x => x.SuiteId);
            Map(x => x.ScenarioId);
            Map(x => x.Generated);
            Map(x => x.Screenshot);
            Map(x => x.Origin);
            
            //HasMany(x => x.PlatformIds);
            Map(x => x.PlatformId);
        }
    }
}
