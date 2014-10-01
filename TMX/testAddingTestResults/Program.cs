/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/14/2014
 * Time: 10:11 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testAddingTestResults
{
    using System;
    using Tmx;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
//            TmxHelper.NewTestSuite("name", "id", null, null, null, null);
//        	
//
//    		TmxHelper.AddTestScenario(
//    			new AddScenarioCmdletBase {
//    			// new AddTmxTestScenarioCommand {
//    				Name = "name 2",
//    				Id = "id 2",
//    				TestPlatformId = null,
//    				TestSuiteId = null,
//    				Description = null
//    			});
        		
            // Tmx.Server.ServerControl.Start(@"http://localhost:12340");
            Tmx.Server.ServerControl.Start("localhost", 12340);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}