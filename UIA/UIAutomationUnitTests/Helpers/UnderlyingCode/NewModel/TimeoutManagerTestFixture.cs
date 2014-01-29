/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/27/2014
 * Time: 11:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationUnitTests.Helpers.UnderlyingCode.NewModel
{
    using UIAutomation;
    using MbUnit.Framework;using Xunit;
    
    /// <summary>
    /// Description of TimeoutManagerTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture]
    public class TimeoutManagerTestFixture
    {
        internal TimeoutManager TimeoutManager { get; set; }
        
        public TimeoutManagerTestFixture()
        {
        }
        
        [SetUp]
        public void SetUp()
        {
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
        // test cases?
        [Test][Fact]
        public void Timeout_0()
        {
            // Arrange
            var timeoutManager = new TimeoutManager(0);
            
            // Act
            var result = timeoutManager.CalculateAdaptiveDelay();
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(Preferences.OnSleepDelay, result);
            Xunit.Assert.Equal(Preferences.OnSleepDelay, result);
        }
        
        [Test][Fact]
        public void Timeout_100()
        {
            // Arrange
            var timeoutManager = new TimeoutManager(100);
            
            // Act
            var result = timeoutManager.CalculateAdaptiveDelay();
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(Preferences.OnSleepDelay, result);
            Xunit.Assert.Equal(Preferences.OnSleepDelay, result);
        }
        
        [Test][Fact]
        public void Timeout_5000()
        {
            // Arrange
            var timeoutManager = new TimeoutManager(5000);
            
            // Act
            var result = timeoutManager.CalculateAdaptiveDelay();
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(250, result);
            Xunit.Assert.Equal(250, result);
        }
        
        [Test][Fact]
        public void Timeout_20000()
        {
            // Arrange
            var timeoutManager = new TimeoutManager(20000);
            
            // Act
            var result = timeoutManager.CalculateAdaptiveDelay();
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(500, result);
            Xunit.Assert.Equal(500, result);
        }
        
        [Test][Fact]
        public void Timeout_60000()
        {
            // Arrange
            var timeoutManager = new TimeoutManager(60000);
            
            // Act
            var result = timeoutManager.CalculateAdaptiveDelay();
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(1000, result);
            Xunit.Assert.Equal(1000, result);
        }
        
        [Test][Fact]
        public void Timeout_600000()
        {
            // Arrange
            var timeoutManager = new TimeoutManager(600000);
            
            // Act
            var result = timeoutManager.CalculateAdaptiveDelay();
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(6000, result);
            Xunit.Assert.Equal(6000, result);
        }
        
        [Test][Fact]
        public void Timeout_1200000()
        {
            // Arrange
            var timeoutManager = new TimeoutManager(1200000);
            
            // Act
            var result = timeoutManager.CalculateAdaptiveDelay();
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(6000, result);
            Xunit.Assert.Equal(6000, result);
        }
    }
}
