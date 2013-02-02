/*
 * Created by SharpDevelop.
  * User: Alexander Petrovskiy
 * Date: 1/2/2013
 * Time: 11:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PSTestLib
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of UnitTestOutputClass.
    /// </summary>
    public static class UnitTestOutput //Class
    {
        static UnitTestOutput() //Class()
        {
            InitCollection();
        }
        
        private static System.Collections.Generic.List<System.Collections.ObjectModel.Collection<object>> outputCollection;
        
        public static System.Collections.ObjectModel.Collection<object> getItem(int index)
        {
            return outputCollection[index];
        }
        
        public static System.Collections.ObjectModel.Collection<object> LastOutput
        { 
            get
            {
                if (null != outputCollection && 0 < outputCollection.Count) {
                    return outputCollection[outputCollection.Count - 1];
                } else {
                    return null;
                    //CheckInitialized();
                    
                }
            }
            set
            {
                if (null != outputCollection && 0 < outputCollection.Count) {
                    
                    outputCollection[outputCollection.Count - 1] = value;
                } else if (null == outputCollection) {
                    
                    InitCollection();
                    outputCollection.Add(value);
                } else if (0 == outputCollection.Count) {
                    
                    outputCollection.Add(value);
                }
            }
        }
        
        public static System.Collections.ObjectModel.Collection<object> PreviousOutput
        {
            get
            {
                if (null != outputCollection && 1 < outputCollection.Count) {

                    return outputCollection[outputCollection.Count - 2];
                } else {

                    return null;
                }
            }
            set
            {
                if (null != outputCollection && 1 < outputCollection.Count) {

                    outputCollection[outputCollection.Count - 2] = value;
                } else if (null == outputCollection) {

                    InitCollection();
                    // nothing to do
                } else if (1 == outputCollection.Count) {

                    // nothing to do
                }
            }
        }
        
        //public static void InitCollection()
        internal static void InitCollection()
        {

            outputCollection =
                new System.Collections.Generic.List<System.Collections.ObjectModel.Collection<object>>();
            StartAddingOutput();
        }
        
        public static void CheckInitialized()
        {

            if (null == outputCollection) {

                InitCollection();
            }
        }
        
        public static bool IsInitialized
        {
            get {
                bool result = false;
                if (null != outputCollection) {
                    result = true;
                }
                return result;
            }
        }
        
        public static System.Collections.Generic.List<System.Collections.ObjectModel.Collection<object>> Pipelines
        {
            get
            {
                return outputCollection;
            }
            set
            {
                outputCollection = value;
            }
        }
        
        public static int Count
        {
            get 
            {
                if (null != outputCollection) {
                    return outputCollection.Count;
                } else {
                    return 0;
                }
            }
        }
        
        public static void Clear()
        {
            InitCollection();
        }
        
        public static void StartAddingOutput()
        {

            if (null != outputCollection &&
                (0 == outputCollection.Count) || // no elements in UnitTestOutput
                (0 < outputCollection.Count && // there is at elast one element in UnitTestOutput
                 0 < outputCollection[outputCollection.Count - 1].Count)) { // that is not empty
            
                System.Collections.ObjectModel.Collection<object> collection =
                    new System.Collections.ObjectModel.Collection<object>();

                outputCollection.Add(collection);

            }
        }
        
        public static void StopAddingOutput()
        {
            // nothing to do ??
        }
        
        public static void Add(object outputObject)
        {
            LastOutput.Add(outputObject);
        }
        
//        public static System.Collections.Generic.List<T> AsList<T>(this System.Collections.ObjectModel.Collection<object> collection)
//        {
//            System.Collections.Generic.List<T> resultList =
//                new System.Collections.Generic.List<T>();
//            
//            foreach (object element in collection) {
//                resultList.Add((T)element);
//            }
//            
//            return resultList;
//        }
        
//        public static void Add(System.Collections.ObjectModel.Collection<PSObject> collection)
//        {
//            outputCollection.Add(collection);
//        }
//        
//        public static void Add(object outputObject)
//        {
//            System.Collections.ObjectModel.Collection<PSObject> collection =
//                new System.Collections.ObjectModel.Collection<PSObject>();
//            collection.Add((PSObject)outputObject);
//            outputCollection.Add(collection);
//        }
//        
//        public static void Add(object[] outputObjectCollection)
//        {
//            System.Collections.ObjectModel.Collection<PSObject> collection =
//                new System.Collections.ObjectModel.Collection<PSObject>();
//            foreach (object element in outputObjectCollection) {
//                collection.Add((PSObject)element);
//            }
//            outputCollection.Add(collection);
//        }
//        
//        public static void Add(System.Collections.Generic.List<object> outputObjectCollection)
//        {
//            System.Collections.ObjectModel.Collection<PSObject> collection =
//                new System.Collections.ObjectModel.Collection<PSObject>();
//            foreach (object element in outputObjectCollection) {
//                collection.Add((PSObject)element);
//            }
//            outputCollection.Add(collection);
//        }
//       
//        public static void Add(ArrayList outputObjectCollection)
//        {
//            System.Collections.ObjectModel.Collection<PSObject> collection =
//                new System.Collections.ObjectModel.Collection<PSObject>();
//            foreach (object element in outputObjectCollection) {
//                collection.Add((PSObject)element);
//            }
//            outputCollection.Add(collection);
//        }
//        
//        public static void Add(IList outputObjectCollection)
//        {
//            System.Collections.ObjectModel.Collection<PSObject> collection =
//                new System.Collections.ObjectModel.Collection<PSObject>();
//            foreach (object element in outputObjectCollection) {
//                collection.Add((PSObject)element);
//            }
//            outputCollection.Add(collection);
//        }
//        
//        public static void Add(IEnumerable outputObjectCollection)
//        {
////            IEnumerator en = outputObjectCollection.GetEnumerator();
////            while (en.MoveNext()) {
////                this.writeSingleObject(cmdlet, en.Current);
////            }
//            System.Collections.ObjectModel.Collection<PSObject> collection =
//                new System.Collections.ObjectModel.Collection<PSObject>();
//            foreach (object element in outputObjectCollection) {
//                collection.Add((PSObject)element);
//            }
//            outputCollection.Add(collection);
//        }
//        
//        public static void Add(string outputObject)
//        {
//            System.Collections.ObjectModel.Collection<PSObject> collection =
//                new System.Collections.ObjectModel.Collection<PSObject>();
//            collection.Add((PSObject)(object)outputObject);
//            outputCollection.Add(collection);
//        }
//        
//        public static void Add(ICollection outputObjectCollection)
//        {
//            System.Collections.ObjectModel.Collection<PSObject> collection =
//                new System.Collections.ObjectModel.Collection<PSObject>();
//            foreach (object element in outputObjectCollection) {
//                collection.Add((PSObject)element);
//            }
//            outputCollection.Add(collection);
//        }
//        
//        public static void Add(Hashtable outputObjectCollection)
//        {
//            System.Collections.ObjectModel.Collection<PSObject> collection =
//                new System.Collections.ObjectModel.Collection<PSObject>();
//            foreach (object element in outputObjectCollection) {
//                collection.Add((PSObject)element);
//            }
//            outputCollection.Add(collection);
//        }

    }
}
