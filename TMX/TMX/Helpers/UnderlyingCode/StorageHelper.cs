/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/27/2013
 * Time: 8:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX
{
    using System;
    using System.Management.Automation;
    using NHibernate;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;
    using System.Reflection;
    using NHibernate.Dialect;
    using NHibernate.Driver;
    using System.Collections;
    
    /// <summary>
    /// Description of StorageHelper.
    /// </summary>
    public static class StorageHelper
    {
        static StorageHelper()
        {
        }
        
        internal static ISessionFactory SessionFactory = null;
        
        public static void InitializeStorage(CommonCmdletBase cmdlet)
        {
            if (null != TMX.Preferences.StorageUsername && string.Empty != TMX.Preferences.StorageUsername) {
                TMX.Preferences.StorageConnectionString =
                    @"Data Source=" + 
                    TMX.Preferences.StorageServer +
                    ";Initial Catalog=" +
                    TMX.Preferences.StorageDatabase +
                    ";Username=" + 
                    TMX.Preferences.StorageUsername +
                    ";Password=" +
                    TMX.Preferences.StoragePassword +
                    ";";
            } else {
                TMX.Preferences.StorageConnectionString =
                    @"Data Source=" + 
                    TMX.Preferences.StorageServer +
                    ";Initial Catalog=" +
                    TMX.Preferences.StorageDatabase +
                    ";Integrated Security=SSPI;";
            }
            
            try {
    			Fluently.Configure()
    			    .Database(MsSqlConfiguration
    			              .MsSql2008
    			              .ConnectionString(TMX.Preferences.StorageConnectionString))
    			              //.ConnectionString(x => x.Is(connString)))
    			    //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProductMap>())
    			    .Mappings(m => m.FluentMappings
    			              .AddFromAssemblyOf<TestSuiteMap>()
    			              .AddFromAssemblyOf<System.Object>())
    			    .ExposeConfiguration(CreateSchema)
    			    .BuildConfiguration();
    			
Console.WriteLine("00001");
    			
    			SessionFactory = Fluently.Configure()
    			    .Database(MsSqlConfiguration
    			              .MsSql2008
    			              .ConnectionString(TMX.Preferences.StorageConnectionString))
    			    .Mappings(m =>m.FluentMappings
    			              .AddFromAssembly(Assembly.GetExecutingAssembly()))
    			              //.AddFromAssemblyOf<TestSuiteMap>()
    			              //.AddFromAssemblyOf<System.Object>())
    			    .BuildSessionFactory();
    			
Console.WriteLine("00002");
    			
            }
            catch (Exception eSession) {
                cmdlet.WriteError(
                    cmdlet,
                    eSession.InnerException.Message,
                    "SessionFailed",
                    ErrorCategory.InvalidOperation,
                    true);
            }
        }
        
		private static void CreateSchema(Configuration cfg)
		{
Console.WriteLine("00001-1");
		    var schemaExport = new SchemaExport(cfg);
Console.WriteLine("00001-2");
		    schemaExport.Drop(false, true);
Console.WriteLine("00001-3");
		    schemaExport.Create(false, true);
Console.WriteLine("00001-4");
		}
    }
}
