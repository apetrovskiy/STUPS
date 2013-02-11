/*
 * Created by SharpDevelop.
 * User: shuran
 * Date: 2/11/2013
 * Time: 9:29 AM
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
    /// Description of TestResultDetailMap.
    /// </summary>
    public class TestResultDetailMap : ClassMap<TestResultDetail>
    {
        public TestResultDetailMap()
        {
            Map(x => x.Name);
        }
    }
}
