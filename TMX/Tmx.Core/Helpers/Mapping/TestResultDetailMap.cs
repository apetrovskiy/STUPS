/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/11/2013
 * Time: 9:29 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Data;
	using Tmx.Interfaces;
//    using System.Data.SQLite;
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
            Id(x => x.DbId);
            //Map(x => x.Name);
        }
    }
}
