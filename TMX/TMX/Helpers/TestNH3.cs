/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/12/2013
 * Time: 1:01 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

//namespace TMX.Helpers
//{
//    using System;
//    using TMX.Commands;
//    using FluentNHibernate;
//    using FluentNHibernate.Mapping;
//    using NHibernate;
//    using FluentNHibernate.Cfg;
//    using FluentNHibernate.Cfg.Db;
//    using NHibernate.Cfg;
//    using NHibernate.Tool.hbm2ddl;
//    using FluentNHibernate.Cfg.Db;
//    using NHibernate.Impl;
//    
//    /// <summary>
//    /// Description of TestNH3.
//    /// </summary>
//    public static class TestNH3
//    {
//        static TestNH3()
//        {
//        }
//        
////        public static void Init()
////        {
////            try {
////            SQLiteHelper.OpenDatabase((new OpenTmxTestDBCommand()), @"C:\1\nnn.db3", false, false, false);
////            
////            //var sessionFactory = FluentNHibernate.Cfg.
////            //ISessionFactory sessionFactory = SessionFactoryObjectFactory.
////            //SQLiteData.Databases[0].ConnectionString
////            Fluently.Configure()
////                //.Database(SQLiteConfiguration.Standard //MsSqlConfiguration
////                //.Database(MsSqlCeConfiguration
////                //          .MsSql2008
////                //.MsSql2008
////                .ConnectionString(SQLiteData.Databases[0].ConnectionString)) //connString))
////                .Mappings(m =>m.FluentMappings
////                .AddFromAssemblyOf<TestSuiteMap>())
////                .ExposeConfiguration(CreateSchema)
////                .BuildConfiguration();
////            }
////            //catch (Exception e) {
////            catch (FluentConfigurationException e) {
////                Console.WriteLine(e.Message);
////                if (null != e.PotentialReasons && 0 < e.PotentialReasons.Count) {
////                    Console.WriteLine("There are reasons");
////                }
////                //Console.WriteLine(e.PotentialReasons);
////                foreach (var element in e.PotentialReasons) {
////                    Console.WriteLine(element.GetType().Name);
////                    Console.WriteLine(element.ToString());
////                }
////            }
////        }
//        
//        private static void CreateSchema(Configuration cfg)
//        {
//            var schemaExport = new SchemaExport(cfg);
//            schemaExport.Drop(false, true);
//            schemaExport.Create(false, true);
//        }
//    }
//}
