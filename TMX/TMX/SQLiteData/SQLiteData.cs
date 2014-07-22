/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/6/2012
 * Time: 8:15 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
    using System.Collections.Generic;
	using Tmx.Interfaces;
    
    /// <summary>
    /// Description of SQLiteData.
    /// </summary>
    public static class SQLiteData
    {
        static SQLiteData()
        {
            Databases = new List<IDatabase>();
        }
        
        public static List<IDatabase> Databases {get; internal set; }
    }
    
#region commented
//    public class Database : IDatabase
//    {
//        public Database(
//            string name, 
//            string path, 
//            System.Data.SQLite.SQLiteConnection connection)
//        {
//            this.Name = name;
//            this.Path = path;
//            this.Connection = connection;
//            this.ConnectionString = connection.ConnectionString;
//        }
//        
//        public string Name { get; set; }
//        public string Path { get; set; }
//        public System.Data.SQLite.SQLiteConnection Connection { get; set; }
//        public string ConnectionString { get; set; }
//        public bool IsStructureDB { get; set; }
//        public bool IsRepositoryDB { get; set; }
//        public bool IsResultsDB { get; set; }
//    }
    
//    public class TestBucket : ITestBucket
//    {
//        public TestBucket(string name)
//        {
//            this.BucketName = name;
//        }
//        
//        public TestBucket(string name, string tag)
//        {
//            this.BucketName = name;
//            this.BucketTag = tag;
//        }
//        
////        public TestBucket(string name, string description)
////        {
////            this.Name = name;
////            this.Description = description;
////        }
//        
//        public TestBucket(string name, string tag, string description)
//        {
//            this.BucketName = name;
//            this.BucketTag = tag;
//            this.Description = description;
//        }
//        
//        public int BucketId { get; set; }
//        public string BucketName { get; set; }
//        public string BucketTag { get; set; }
//        public string Description { get; set; }
//    }
    
//    public class TestConstant : ITestConstant
//    {
//        public TestConstant(
//            string constantName, 
//            object constantValue, 
//            System.Type constantType)
//        {
//            this.ConstantName = constantName;
//            this.ConstantValue = ConstantValue;
//            this.ConstantType = ConstantType;
//        }
//        
//        public TestConstant(
//            string constantName, 
//            object constantValue, 
//            System.Type constantType,
//            string constantTag,
//            string description)
//        {
//            this.ConstantName = constantName;
//            this.ConstantValue = ConstantValue;
//            this.ConstantType = ConstantType;
//            this.ConstantTag = constantTag;
//            this.Description = description;
//        }
//        
//        public int ConstantId { get; set; }
//        public string ConstantName { get; set; }
//        public object ConstantValue { get; set; }
//        public System.Type ConstantType { get; set; }
//        public string ConstantTag { get; set; }
//        public string Description { get; set; }
//        public int BucketId { get; set; }
//    }
    
//    public class TestCase : ITestCase
//    {
//        public TestCase(string testCaseName, string testCaseNumber)
//        {
//            this.TestCaseName = testCaseName;
//            this.TestCaseNumber = testCaseNumber;
//        }
//        
//        public TestCase(
//            string testCaseName, 
//            string testCaseNumber,
//            ScriptBlock beforeCode,
//            ScriptBlock mainCode,
//            ScriptBlock afterCode)
//        {
//            this.TestCaseName = testCaseName;
//            this.TestCaseNumber = testCaseNumber;
//            this.BeforeCode = beforeCode;
//            this.MainCode = mainCode;
//            this.AfterCode = afterCode;
//        }
//        
//        public int TestCaseId { get; set; }
//        public string TestCaseName { get; set; }
//        public string TestCaseNumber { get; set; }
//        public ScriptBlock BeforeCode { get; set; }
//        public ScriptBlock MainCode { get; set; }
//        public ScriptBlock AfterCode { get; set; }
//        public string TestCaseTag { get; set; }
//        public string Description { get; set; }
//    }
#endregion commented
}
