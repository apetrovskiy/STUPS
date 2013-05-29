/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 5/29/2013
 * Time: 9:59 AM
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
    
    /// <summary>
    /// Description of ITestScenarioMap.
    /// </summary>
    public class ITestScenarioMap : ClassMap<ITestScenario>
    {
        public ITestScenarioMap()
        {
            Id(x => x.DbId);
            Map(x => x.Name);
            Map(x => x.Id);
            Map(x => x.Status);
            Map(x => x.Description);
            HasMany(x => x.TestResults);
            
            //Map(x => x.Status);
            
            //Map(x => x.Statistics);
            Map(x => x.SuiteId);
            Map(x => x.Timestamp);
            //Map(x => x.TimeSpent);
            //HasMany(x => x.Tags);
            //HasMany(x => x.PlatformIds);
        }
    }
}
