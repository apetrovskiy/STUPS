/*
 * Created by SharpDevelop.
 * User: shuran
 * Date: 2/11/2013
 * Time: 2:30 AM
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
    /// Description of TestScenarioMap.
    /// </summary>
    public class TestScenarioMap : ClassMap<TestScenario>
    {
        public TestScenarioMap()
        {
            Map(x => x.Name);
            Map(x => x.Id);
            Map(x => x.Status);
            Map(x => x.Description);
        }
    }
}
