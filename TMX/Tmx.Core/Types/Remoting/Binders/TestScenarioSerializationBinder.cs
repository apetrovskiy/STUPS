/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/5/2014
 * Time: 2:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Core.Types.Remoting
{
    using System;
    using System.Runtime.Serialization;
    
    /// <summary>
    /// Description of TestScenarioSerializationBinder.
    /// </summary>
    public class TestScenarioSerializationBinder : SerializationBinder
    {
        public string TypeFormat { get; private set; }
        
        public override Type BindToType(string assemblyName, string typeName)
        {
            throw new NotImplementedException();
        }
    }
}
