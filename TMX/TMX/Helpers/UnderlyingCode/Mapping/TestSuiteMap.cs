/*
 * Created by SharpDevelop.
 * User: shuran
 * Date: 2/11/2013
 * Time: 2:08 AM
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
    /// Description of TestSuiteMapping.
    /// </summary>
    public class TestSuiteMap : ClassMap<TestSuite>
    {
        public TestSuiteMap()
        {
            Map(x => x.Name);
            Map(x => x.Id);
            Map(x => x.Status);
            Map(x => x.Description);
        }
    }
}
