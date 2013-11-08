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
//Console.WriteLine("-0005");
            if (!string.IsNullOrEmpty(TMX.Preferences.StorageUsername)) {
            // if (null != TMX.Preferences.StorageUsername && string.Empty != TMX.Preferences.StorageUsername) {
//Console.WriteLine("-0004");
                TMX.Preferences.StorageConnectionString =
                    //@"Data Source=" + 
                    @"Server=" + 
                    TMX.Preferences.StorageServer +
                    //";Initial Catalog=" +
                    ";Database=" +
                    TMX.Preferences.StorageDatabase +
                    ";Username=" + 
                    TMX.Preferences.StorageUsername +
                    ";Password=" +
                    TMX.Preferences.StoragePassword +
                    ";";
            } else {
//Console.WriteLine("-0003");
                TMX.Preferences.StorageConnectionString =
                    //@"Data Source=" + 
                    @"Server=" + 
                    TMX.Preferences.StorageServer +
                    //";Initial Catalog=" +
                    ";Database=" +
                    TMX.Preferences.StorageDatabase +
                    ";Integrated Security=SSPI;";
            }
            
            try {
                
//Console.WriteLine("-0002");
                
                cmdlet.WriteVerbose("building configuration...");
//Console.WriteLine("-0001");
//Console.WriteLine(TMX.Preferences.StorageConnectionString);
if (null == Fluently.Configure()) {
    
    Console.WriteLine("Fluently == null");
}
Console.WriteLine("Fluently != null");
    			Fluently.Configure();
//    			    .Database(MsSqlConfiguration
//    			              .MsSql2008
//    			              //.ConnectionString(TMX.Preferences.StorageConnectionString))
//    			              //.ConnectionString(x => x.Is(connString)))
//    			              .ConnectionString(x => x.Is(TMX.Preferences.StorageConnectionString)))
//    			    //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProductMap>())
//    			    .Mappings(m => m.FluentMappings
//    			              .AddFromAssemblyOf<TestSuiteMap>())
//    			              //.AddFromAssemblyOf<System.Object>())
//    			    .ExposeConfiguration(CreateSchema)
//    			    .BuildConfiguration();
    			
Console.WriteLine("00001");
    			
    			cmdlet.WriteVerbose("creating session factory...");
    			
    			SessionFactory = Fluently.Configure()
    			    .Database(MsSqlConfiguration
    			              .MsSql2008
    			              .ConnectionString(TMX.Preferences.StorageConnectionString))
    			    .Mappings(m =>m.FluentMappings
    			              //.AddFromAssembly(Assembly.GetExecutingAssembly()))
    			              .AddFromAssemblyOf<TestSuiteMap>())
    			              //.AddFromAssemblyOf<System.Object>())
    			    .BuildSessionFactory();
    			
Console.WriteLine("00002");
    			
    			cmdlet.WriteVerbose("session factory has been created...");
    			
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
