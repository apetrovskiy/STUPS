/* 
Gallio TestLink Adapter 
Copyright (c) 2009, Stephan Meyn <stephanmeyn@gmail.com>

Permission is hereby granted, free of charge, to any person 
obtaining a copy of this software and associated documentation 
files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, merge, 
publish, distribute, sublicense, and/or sell copies of the Software, 
and to permit persons to whom the Software is furnished to do so, 
subject to the following conditions:

The above copyright notice and this permission notice shall be 
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
DEALINGS IN THE SOFTWARE.
*/

using System;
using System.IO;
using System.Xml;

namespace Meyn.TestLink
{
    /// <summary>
    /// this attribute is used for the various exporter adapters such as the Gallio and the NUnit test frameworks
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TestLinkFixtureAttribute : Attribute
    {
        private string url;

        /// <summary>
        /// the url for the Testlink XmlRPC api.
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        private string projectName;

        /// <summary>
        /// the name of the test project in testlink
        /// </summary>
        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }
        private string userId;

        /// <summary>
        /// the user name to be used for creating new testcases (must conicide with the DevKey)
        /// </summary>
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        //private string password;

        //public string Password
        //{
        //    get { return password; }
        //    set { password = value; }
        //}
        private string devKey;

        /// <summary>
        /// the devkey or ApiKey for the above userid. provided by testlink
        /// </summary>
        public string DevKey
        {
            get { return devKey; }
            set { devKey = value; }
        }

        private string testPlan;
        /// <summary>
        /// the name of the test plan containing the test case results
        /// </summary>
        public string TestPlan
        {
            get { return testPlan; }
            set { testPlan = value; }
        }

        private string testSuite;

        /// <summary>
        /// the name of the top level test suite where the test cases are expected.
        /// </summary>
        public string TestSuite
        {
            get { return testSuite; }
            set { testSuite = value; }
        }

        private string platformName;
        public string PlatformName
        {
            get { return platformName; }
            set { platformName = value; }
        }


        private string configFile;
        /// <summary>
        /// path to a configuration file to override settings here
        /// </summary>
        public string ConfigFile
        {
            get { return configFile; }
            set { configFile = value; }
        }

        public TestLinkFixtureAttribute()
        {
        }

        /// <summary>
        /// need to override this because we need to be able to compare them
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            TestLinkFixtureAttribute other = obj as TestLinkFixtureAttribute;
            if (other == null)
                return false;
            return ((other.devKey.Equals(devKey))
                && (other.configFile.Equals(configFile))
                && (other.projectName.Equals(projectName))
                && (other.testPlan.Equals(testPlan))
                && (other.testSuite.Equals(testSuite))
                && (other.url.Equals(url))
                && (other.userId.Equals(userId)));
        }

        public override int GetHashCode()
        {
            return (devKey.GetHashCode()
                 ^ configFile.GetHashCode()
                 ^ projectName.GetHashCode()
                 ^ testPlan.GetHashCode()
                 ^ testSuite.GetHashCode()
                 ^ url.GetHashCode()
                 ^ userId.GetHashCode());
        }

        /// <summary>
        /// check to see if a config file is specified. If it is, 
        /// read it in and apply it as default value. 
        /// </summary>
        /// <param name="directory">the directory where to look for the config file</param>
        /// <remarks>if the attribute already has a value for a key then ignore the config file settings</remarks>
        /// <returns></returns>
        public bool ConsiderConfigFile(string directory)
        {

            if(string.IsNullOrEmpty(configFile))
              return false;

            if (Path.IsPathRooted(configFile) == false)
            {
                configFile = Path.Combine(directory, configFile);
            }       
            
            Console.WriteLine("Reading config file {0}", configFile);
            if (File.Exists(configFile) == false)
            {
               string absPath = Path.GetFullPath(configFile);
               Console.WriteLine("config file not found in {0}", absPath);
                return false;
            }
            
           
            XmlDocument doc = new XmlDocument();
            doc.Load(ConfigFile);
            // check for elements for each attribute
            // Use the value if:
            //  - it is present, and
            //  - not set in attribute, or
            //  - override is set
            url = updateAttributeFromConfigFile(doc, url, "url"); 
            projectName = updateAttributeFromConfigFile(doc, projectName, "ProjectName");
            userId = updateAttributeFromConfigFile(doc,userId, "UserId");
            testPlan = updateAttributeFromConfigFile(doc, testPlan, "TestPlan");
            testSuite = updateAttributeFromConfigFile(doc, testSuite, "TestSuite");
            platformName = updateAttributeFromConfigFile(doc, platformName,"PlatformName");
            devKey = updateAttributeFromConfigFile(doc, devKey, "DevKey");
            
            return true;
        }

        /// <summary>
        /// interpret the configuration setting for a particular attribute
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="existingValue">the existing value for the attribute</param>
        /// <param name="attributeName">the name of the attribute</param>
        /// <returns></returns>
        private string updateAttributeFromConfigFile(XmlDocument doc, string existingValue, string attributeName)
        {
            string path2Attribute = string.Format("/TestLinkFixtureConfiguration/{0}[@value]", attributeName);
            XmlNode Node = doc.SelectSingleNode(path2Attribute);
            if (Node == null)
                return existingValue;
            XmlAttribute overrrideAttr = Node.Attributes["override"];
            bool isOverride = false;
            if (overrrideAttr != null) 
                isOverride = overrrideAttr.Value.ToLower() == "yes";
            if ((existingValue == null) || isOverride)
                return Node.Attributes["value"].Value;
            else
                return existingValue;
        }
    }
}
