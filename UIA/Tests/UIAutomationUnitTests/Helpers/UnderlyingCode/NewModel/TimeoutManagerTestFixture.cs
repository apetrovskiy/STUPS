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
    using Xunit;
    
    /// <summary>
    /// Description of TimeoutManagerTestFixture.
    /// </summary>
    [MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
    public class TimeoutManagerTestFixture
    {
        internal TimeoutManager TimeoutManager { get; set; }
        
        public TimeoutManagerTestFixture()
        {
        }
        
        [MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
        public void SetUp()
        {
        }
        
        [MbUnit.Framework.TearDown][NUnit.Framework.TearDown]
        public void TearDown()
        {
        }
        
        // test cases?
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Timeout_0()
        {
            // Arrange
            var timeoutManager = new TimeoutManager(0);
            
            // Act
            var result = timeoutManager.CalculateAdaptiveDelay();
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(Preferences.OnSleepDelay, result);
            Assert.Equal(Preferences.OnSleepDelay, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Timeout_100()
        {
            // Arrange
            var timeoutManager = new TimeoutManager(100);
            
            // Act
            var result = timeoutManager.CalculateAdaptiveDelay();
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(Preferences.OnSleepDelay, result);
            Assert.Equal(Preferences.OnSleepDelay, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Timeout_5000()
        {
            // Arrange
            var timeoutManager = new TimeoutManager(5000);
            
            // Act
            var result = timeoutManager.CalculateAdaptiveDelay();
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(250, result);
            Assert.Equal(250, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Timeout_20000()
        {
            // Arrange
            var timeoutManager = new TimeoutManager(20000);
            
            // Act
            var result = timeoutManager.CalculateAdaptiveDelay();
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(500, result);
            Assert.Equal(500, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Timeout_60000()
        {
            // Arrange
            var timeoutManager = new TimeoutManager(60000);
            
            // Act
            var result = timeoutManager.CalculateAdaptiveDelay();
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(1000, result);
            Assert.Equal(1000, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Timeout_600000()
        {
            // Arrange
            var timeoutManager = new TimeoutManager(600000);
            
            // Act
            var result = timeoutManager.CalculateAdaptiveDelay();
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(6000, result);
            Assert.Equal(6000, result);
        }
        
        [NUnit.Framework.Test] // [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Timeout_1200000()
        {
            // Arrange
            var timeoutManager = new TimeoutManager(1200000);
            
            // Act
            var result = timeoutManager.CalculateAdaptiveDelay();
            
            // Assert
            MbUnit.Framework.Assert.AreEqual(6000, result);
            Assert.Equal(6000, result);
        }
    }
}
