/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 5/27/2013
 * Time: 8:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
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
	using Tmx.Interfaces;
    
    /// <summary>
    /// Description of StorageHelper.
    /// </summary>
    public static class StorageHelper
    {
        static StorageHelper()
        {
        }
        
        internal static ISessionFactory SessionFactory = null;
        
        public static void InitializeStorage()
        {
            if (!string.IsNullOrEmpty(Preferences.StorageUsername)) {
            // if (null != Preferences.StorageUsername && string.Empty != Preferences.StorageUsername) {
                Preferences.StorageConnectionString =
                    //@"Data Source=" + 
                    @"Server=" + 
                    Preferences.StorageServer +
                    //";Initial Catalog=" +
                    ";Database=" +
                    Preferences.StorageDatabase +
                    ";Username=" + 
                    Preferences.StorageUsername +
                    ";Password=" +
                    Preferences.StoragePassword +
                    ";";
            } else {
                
                Preferences.StorageConnectionString =
                    //@"Data Source=" + 
                    @"Server=" + 
                    Preferences.StorageServer +
                    //";Initial Catalog=" +
                    ";Database=" +
                    Preferences.StorageDatabase +
                    ";Integrated Security=SSPI;";
            }
            
            try {
                
//                cmdlet.WriteVerbose("building configuration...");
                
if (null == Fluently.Configure()) {
    
    Console.WriteLine("Fluently == null");
}
Console.WriteLine("Fluently != null");
    			Fluently.Configure();
//    			    .Database(MsSqlConfiguration
//    			              .MsSql2008
//    			              //.ConnectionString(Preferences.StorageConnectionString))
//    			              //.ConnectionString(x => x.Is(connString)))
//    			              .ConnectionString(x => x.Is(Preferences.StorageConnectionString)))
//    			    //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProductMap>())
//    			    .Mappings(m => m.FluentMappings
//    			              .AddFromAssemblyOf<TestSuiteMap>())
//    			              //.AddFromAssemblyOf<System.Object>())
//    			    .ExposeConfiguration(CreateSchema)
//    			    .BuildConfiguration();
    			
//    			cmdlet.WriteVerbose("creating session factory...");
    			
    			SessionFactory = Fluently.Configure()
    			    .Database(MsSqlConfiguration
    			              .MsSql2008
    			              .ConnectionString(Preferences.StorageConnectionString))
    			    .Mappings(m =>m.FluentMappings
    			              //.AddFromAssembly(Assembly.GetExecutingAssembly()))
    			              .AddFromAssemblyOf<TestSuiteMap>())
    			              //.AddFromAssemblyOf<System.Object>())
    			    .BuildSessionFactory();
    			
//    			cmdlet.WriteVerbose("session factory has been created...");
    			
            }
            catch (Exception eSession) {
                // 20140720
//                cmdlet.WriteError(
//                    cmdlet,
//                    eSession.InnerException.Message,
//                    "SessionFailed",
//                    ErrorCategory.InvalidOperation,
//                    true);
                throw new Exception(
                    eSession.InnerException.Message);
            }
        }
        
		static void CreateSchema(Configuration cfg)
		{
Console.WriteLine("creating schema export object...");
            //cmdlet.WriteVerbose("creating schema export object...");
		    var schemaExport = new SchemaExport(cfg);
Console.WriteLine("dropping the previous schema object...");
            //cmdlet.WriteVerbose("dropping the previous schema object...");
            try {
                schemaExport.Drop(false, true);
            }
            catch (Exception eDroppingSchema) {
                //cmdlet.
Console.WriteLine(eDroppingSchema.InnerException.Message);
            }
Console.WriteLine("drocreating a new schema object...");
		    //cmdlet.WriteVerbose("drocreating a new schema object...");
            schemaExport.Create(false, true);
Console.WriteLine("schema has been created");
		}
    }
}
