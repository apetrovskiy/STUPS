/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/6/2012
 * Time: 6:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests
{
    #region using
    using System;
//    using OpenQA.Selenium;
//    using OpenQA.Selenium.Firefox;
//    using OpenQA.Selenium.Chrome;
//    using OpenQA.Selenium.IE;

//    using OpenQA.Selenium.Safari;
//    //using OpenQA.Selenium.Opera;
//    using OpenQA.Selenium.Android;

//    using OpenQA.Selenium.Support;
//    using UIAutomation;
//    using OpenQA.Selenium.Remote;

//    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections;
    
    using MbUnit.Framework;
    //using NUnit.Framework;
//    using System.Drawing;

    //
    //
//    using System.Windows.Automation;
    //
    //

    //using OpenQA.Selenium.Remote;

    using PSTestLib;
//    using SePSX;
    
    using SePSX;

    #endregion using
    
    /// <summary>
    /// Description of CheckRecordingsAssert.
    /// </summary>
    public static class CheckRecordingsAssert
    {
        public static void IsCollectionsContent(
            System.Collections.Generic.List<IRecordedCodeSequence> expectedCollection,
            System.Collections.Generic.List<IRecordedCodeSequence> realCollection)
        {
            testCollections(expectedCollection, realCollection);
            testCollections(realCollection, expectedCollection);
            
#region commented
//            for (int iRecordings = 0; iRecordings < expectedCollection.Count; iRecordings++) {
//                
//                var expectedSequence = expectedCollection[iRecordings];
//                var realSequence = realCollection[iRecordings];
//                
//                if (((null != expectedSequence) && (null == realSequence)) ||
//                    ((null == expectedSequence) && (null != realSequence))) {
//                    
//                    Assert.Fail(
//                        "Elements of the recording collections don't match at " +
//                        iRecordings.ToString() +
//                        "th code sequence.");
//                }
//                
//                if ((null == expectedSequence) && (null == realSequence)) {
//                    continue;
//                }
//                
//                if ((null != expectedSequence) && (null != realSequence)) {
//                    
//                    if (expectedSequence.GetType().Name != realSequence.GetType().Name) {
//                        
//                        Assert.Fail(
//                            "Elements of the recording collections of not the same type at " +
//                            iRecordings.ToString() + 
//                            "th code sequence.");
//                    }
//                    
//                    for (int iElements = 0; iElements < expectedSequence.Items.Count; iElements++) {
//                        
//                        var expectedItem = expectedSequence.Items[iElements];
//                        var realItem = realSequence.Items[iElements];
//                        
//                        if ((null != expectedItem) && (null == realItem) ||
//                            ((null == expectedItem) && (null != realItem))) {
//                                
//                            Assert.Fail(
//                                "Items of the code sequences are not equal. " +
//                                "Collections at " +
//                                iRecordings.ToString() +
//                                "th code sequence, items at " + 
//                                iElements.ToString() +
//                                "th position");
//                        }
//                        
//                        if ((null == expectedItem) && (null == realItem)) {
//                            continue;
//                        }
//                        
//                        if ((null != expectedItem) && (null != realItem)) {
//                            
//                            RecordedWebElement expectedWebElement = expectedItem as RecordedWebElement;
//                            RecordedWebElement realWebElement = realItem as RecordedWebElement;
//                            
//                            RecordedAction expectedAction = expectedItem as RecordedAction;
//                            RecordedAction realAction = realItem as RecordedAction;
//                            
//                            RecordedData expectedData = expectedItem as RecordedData;
//                            RecordedData realData = realItem as RecordedData;
//                            
//                            
//                            if ((null != expectedWebElement) || (null != realWebElement)) {
//                                
//                                if ((null != expectedWebElement) && (null == realWebElement) ||
//                                    (null == expectedWebElement) && (null != realWebElement)) {
//                                    
//                                    Assert.Fail(
//                                        "Items of different types. " +
//                                        "Collections at " +
//                                        iRecordings.ToString() +
//                                        "th code sequence, items at " +
//                                        iElements.ToString() +
//                                        "th position");
//                                }
//                                
//                                if ((null == expectedWebElement) && (null == realWebElement)) {
//                                        
//                                      // choose another type to compare
//                                    
//                                } else {
//                                    
//                                    // compare two RecordedWebElements
//                                    
//                                    //RecordedWebElement expectedElement = (expectedCollection[iRecordings].Items[iElements] as RecordedWebElement);
//                                    //RecordedWebElement realElement = (realCollection[iRecordings].Items[iElements] as RecordedWebElement);
//                                    
//                                    for (int iWebKeys = 0; iWebKeys < expectedWebElement.UserData.Count; iWebKeys++) {
//                                        
//                                        object webValueExpected = expectedWebElement.UserData[expectedWebElement.UserData.Keys[iWebKeys]];
//                                        object webValueReal = realWebElement.UserData[realWebElement.UserData.Keys[iWebKeys]];
//                                        
//                                    }
//                                    
//                                    
//                                }
//                                
//                                
//                            } else if ((null != expectedAction) || (null != realAction)) {
//                            
//                                if ((null != expectedAction) && (null == realAction) ||
//                                    (null == expectedAction) && (null != realAction)) {
//                                    
//                                    Assert.Fail(
//                                        "Items of different types. " +
//                                        "Collections at " +
//                                        iRecordings.ToString() +
//                                        "th code sequence, items at " +
//                                        iElements.ToString() +
//                                        "th position");
//                                    
//                                }
//                                
//                                if ((null == expectedAction) && (null == realAction)) {
//                                    
//                                    // choose another type to compare
//                                    
//                                } else {
//                                    
//                                    // copmpare two RecordedActions
//                                    
//                                    for (int iActKeys = 0; iActKeys < expectedData.UserData.Count; iActKeys++) {
//                                        
//                                        
//                                        
//                                    }
//                                    
//                                }
//                            
//                            
//                            } else if ((null != expectedData) || (null != realData)) {
//                                
//                                if ((null != expectedData) && (null == expectedData) ||
//                                    (null == expectedData) && (null != realData)) {
//                                    
//                                    Assert.Fail(
//                                        "Items of different types. " +
//                                        "Collections at " +
//                                        iRecordings.ToString() +
//                                        "th code sequence, items at " +
//                                        iElements.ToString() +
//                                        "th position");
//                                    
//                                }
//                                
//                                if ((null == expectedData) && (null == realData)) {
//                                    
//                                    // choose another type to compare
//                                    
//                                } else {
//                                    
//                                    // compare two RscordedDatas
//                                    
//                                    for (int iDataKeys = 0; iDataKeys < expectedData.UserData.Count; iDataKeys++) {
//                                        
//                                        
//                                        
//                                    }
//                                    
//                                }
//                                
//                            }
//                            
//                        }
//                    }
//                }
//                
//            }
#endregion commented
        }
        
        private static void testCollections(
           System.Collections.Generic.List<IRecordedCodeSequence> expectedCollection,
           System.Collections.Generic.List<IRecordedCodeSequence> realCollection)
        {
            for (int iRecordings = 0; iRecordings < expectedCollection.Count; iRecordings++) {
                
                var expectedSequence = expectedCollection[iRecordings];
                var realSequence = realCollection[iRecordings];
                
                if (((null != expectedSequence) && (null == realSequence)) ||
                    ((null == expectedSequence) && (null != realSequence))) {
                    
                    Assert.Fail(
                        "Elements of the recording collections don't match at " +
                        iRecordings.ToString() +
                        "th code sequence.");
                }
                
                if ((null == expectedSequence) && (null == realSequence)) {
                    continue;
                }
                
                if ((null != expectedSequence) && (null != realSequence)) {
                    
                    if (expectedSequence.GetType().Name != realSequence.GetType().Name) {
                        
                        Assert.Fail(
                            "Elements of the recording collections of not the same type at " +
                            iRecordings.ToString() + 
                            "th code sequence.");
                    }
                    
                    for (int iElements = 0; iElements < expectedSequence.Items.Count; iElements++) {
                        
                        var expectedItem = expectedSequence.Items[iElements];
                        var realItem = realSequence.Items[iElements];
                        
                        if ((null != expectedItem) && (null == realItem) ||
                            ((null == expectedItem) && (null != realItem))) {
                                
                            Assert.Fail(
                                "Items of the code sequences are not equal. " +
                                "Collections at " +
                                iRecordings.ToString() +
                                "th code sequence, items at " + 
                                iElements.ToString() +
                                "th position");
                        }
                        
                        if ((null == expectedItem) && (null == realItem)) {
                            continue;
                        }
                        
                        if ((null != expectedItem) && (null != realItem)) {
                            
                            RecordedWebElement expectedWebElement = expectedItem as RecordedWebElement;
                            RecordedWebElement realWebElement = realItem as RecordedWebElement;
                            
                            RecordedAction expectedAction = expectedItem as RecordedAction;
                            RecordedAction realAction = realItem as RecordedAction;
                            
                            RecordedData expectedData = expectedItem as RecordedData;
                            RecordedData realData = realItem as RecordedData;
                            
                            
                            if ((null != expectedWebElement) || (null != realWebElement)) {
                                
                                if ((null != expectedWebElement) && (null == realWebElement) ||
                                    (null == expectedWebElement) && (null != realWebElement)) {
                                    
                                    Assert.Fail(
                                        "Items of different types. " +
                                        "Collections at " +
                                        iRecordings.ToString() +
                                        "th code sequence, items at " +
                                        iElements.ToString() +
                                        "th position");
                                }
                                
                                if ((null == expectedWebElement) && (null == realWebElement)) {
                                        
                                      // choose another type to compare
                                    
                                } else {
                                    
                                    // compare two RecordedWebElements
                                    
                                    //RecordedWebElement expectedElement = (expectedCollection[iRecordings].Items[iElements] as RecordedWebElement);
                                    //RecordedWebElement realElement = (realCollection[iRecordings].Items[iElements] as RecordedWebElement);
                                    
                                    foreach (string keyWeb in expectedWebElement.UserData.Keys) {
                                    //for (int iWebKeys = 0; iWebKeys < expectedWebElement.UserData.Count; iWebKeys++) {
                                        
                                        //object webValueExpected = expectedWebElement.UserData[expectedWebElement.UserData.Keys[iWebKeys]];
                                        //object webValueReal = realWebElement.UserData[realWebElement.UserData.Keys[iWebKeys]];
                                        
                                        object webValueExpected = expectedWebElement.UserData[keyWeb];
                                        object webValueReal = realWebElement.UserData[keyWeb];
                                        
                                        if (webValueExpected != webValueReal) {
                                            
                                            Assert.Fail(
                                                "Items with diferent values. " +
                                                "Collections at " +
                                                iRecordings.ToString() +
                                                "th code sequence, items at " +
                                                iElements.ToString() +
                                                "th position, key is " +
                                                keyWeb);
                                            
                                        }
                                        
                                    }
                                    
                                    
                                }
                                
                                
                            } else if ((null != expectedAction) || (null != realAction)) {
                            
                                if ((null != expectedAction) && (null == realAction) ||
                                    (null == expectedAction) && (null != realAction)) {
                                    
                                    Assert.Fail(
                                        "Items of different types. " +
                                        "Collections at " +
                                        iRecordings.ToString() +
                                        "th code sequence, items at " +
                                        iElements.ToString() +
                                        "th position");
                                    
                                }
                                
                                if ((null == expectedAction) && (null == realAction)) {
                                    
                                    // choose another type to compare
                                    
                                } else {
                                    
                                    // compare two RecordedActions
                                    
                                    foreach (string keyAction in expectedAction.UserData.Keys) {
                                        
                                        object actValueExpected = expectedAction.UserData[keyAction];
                                        object actValueReal = realAction.UserData[keyAction];
                                        
                                        if (actValueExpected != actValueReal) {
                                            
                                            Assert.Fail(
                                                "Items with diferent values. " +
                                                "Collections at " +
                                                iRecordings.ToString() +
                                                "th code sequence, items at " +
                                                iElements.ToString() +
                                                "th position, key is " +
                                                keyAction);
                                            
                                        }
                                        
                                    }
                                    
                                }
                            
                            
                            } else if ((null != expectedData) || (null != realData)) {
                                
                                if ((null != expectedData) && (null == expectedData) ||
                                    (null == expectedData) && (null != realData)) {
                                    
                                    Assert.Fail(
                                        "Items of different types. " +
                                        "Collections at " +
                                        iRecordings.ToString() +
                                        "th code sequence, items at " +
                                        iElements.ToString() +
                                        "th position");
                                    
                                }
                                
                                if ((null == expectedData) && (null == realData)) {
                                    
                                    // choose another type to compare
                                    
                                } else {
                                    
                                    // compare two RscordedDatas
                                    
                                    foreach (string keyData in expectedData.UserData.Keys) {
                                        
                                        object dataValueExpected = expectedData.UserData[keyData];
                                        object dataValueReal = realData.UserData[keyData];
                                        
                                        if (dataValueExpected != dataValueReal) {
                                            
                                            Assert.Fail(
                                                "Items with diferent values. " +
                                                "Collections at " +
                                                iRecordings.ToString() +
                                                "th code sequence, items at " +
                                                iElements.ToString() +
                                                "th position, key is " +
                                                keyData);
                                            
                                        }
                                        
                                    }
                                    
                                }
                                
                            }
                            
                        }
                    }
                }
                
            }
        }
        
    }
}
