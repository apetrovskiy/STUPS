/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/25/2013
 * Time: 7:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Data
{
    using System;
    using Autofac;
    using Autofac.Builder;
    using Autofac.Features.ResolveAnything;
    using System.Reflection;
    
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of DataModule.
    /// </summary>
    public class DataModule : Autofac.Module
    {
        public DataModule()
        {
        }
        
        internal IContainer container = null;
        
		protected override void Load(ContainerBuilder builder)
		{
		    
		    
		    builder.RegisterType<XMLDataEntry>()
		        .As<IXMLDataEntry>()
		        .UsingConstructor(
		            new Type[] {
		                typeof(string),
		                typeof(string)
		            })
		        .Named<IXMLDataEntry>("full");
		    
		    builder.RegisterType<XMLComparer>()
		        .As<IXMLComparer>()
		        .UsingConstructor(
		            new Type[] {
		                typeof(List<IXMLDataEntry>)
		            })
		        .Named<IXMLComparer>("simple");
		    
		    builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
		    
		}
    }
}
