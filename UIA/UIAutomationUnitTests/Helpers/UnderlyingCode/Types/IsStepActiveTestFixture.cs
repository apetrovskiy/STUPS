/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/27/2014
 * Time: 1:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.UnderlyingCode.Types
{
    using System;
    
    using System.Windows.Automation;
    using UIAutomation;
    using MbUnit.Framework;using Xunit;
    
    /// <summary>
    /// Description of IsStepActiveTestFixture.
    /// </summary>
    public class IsStepActiveTestFixture
    {
        public IsStepActiveTestFixture()
        {
            FakeFactory.Init();
        }
        
        [SetUp]
        public void SetUp()
        {
            FakeFactory.Init();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        [Test][Fact]
        public void None_Criteria_None_Elements()
        {
            
        }
        
        [Test][Fact]
        public void None_Criteria_One_Element()
        {
            
        }
        
        [Test][Fact]
        public void None_Criteria_Three_Elements()
        {
            
        }
        
        [Test][Fact]
        public void One_Criterion_None_Elements()
        {
            
        }
        
        [Test][Fact]
        public void One_Criterion_One_Element()
        {
            
        }
        
        [Test][Fact]
        public void One_Criterion_Three_Elements()
        {
            
        }
        
        [Test][Fact]
        public void Three_Criteria_None_Elements()
        {
            
        }
        
        [Test][Fact]
        public void Three_Criteria_One_Element()
        {
            
        }
        
        [Test][Fact]
        public void Three_Criteria_Three_Elements()
        {
            
        }
    }
}
