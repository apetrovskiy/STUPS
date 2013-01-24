///*
// * Created by SharpDevelop.
// * User: Alexander Petrovskiy
// * Date: 11/17/2012
// * Time: 3:56 AM
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//
//namespace TLAddinUnitTests
//{
//    using System;
//    using MbUnit.Framework;
//    using PSTestLib;
//    using Moq;
//    //using Autofac;
//    //using Autofac.Builder;
//    using TMX;
//    using Meyn.TestLink;
//    using CookComputing.XmlRpc;
//    
//    /// <summary>
//    /// Description of FakeTestProject.
//    /// </summary>
//    public class FakeTestProject : Meyn.TestLink.TL_Data
//    {
//        public FakeTestProject(
//            int id, 
//            string name, 
//            string prefix, 
//            string notes,
//            string color,
//            int tc_counter,
//            bool active,
//            bool option_automation,
//            bool option_inventory,
//            bool option_priority,
//            bool option_reqs)
//        {
//            this._id = id;
//            this._name = name;
//            this._prefix = prefix;
//            this._notes = notes;
//            this._color = color;
//            this._tc_counter = tc_counter;
//            this._active = active;
//            this._option_automation = option_automation;
//            this._option_inventory = option_inventory;
//            this._option_priority = option_priority;
//            this._option_reqs = option_reqs;
//        }
//
//        internal int _id;
//        internal string _notes;
//        internal string _name;
//        internal string _color;
//        internal string _prefix;
//        internal int _tc_counter;
//        internal bool _active;
//        internal bool _option_reqs;
//        internal bool _option_priority;
//        internal bool _option_automation;
//        internal bool _option_inventory;
//        
//        /// <summary>
//        /// internal id
//        /// </summary>
//        public int id { get { return this._id;} }
//        /// <summary>
//        /// notes
//        /// </summary>
//        public string notes { get { return this._notes; } }
//        /// <summary>
//        /// 
//        /// </summary>
//        public string color { get { return this._color; } }
//        /// <summary>
//        /// 
//        /// </summary>
//        public bool active { get { return this._active; } }
//        /// <summary>
//        /// true of requirements feature is enabled
//        /// </summary>
//        public bool option_reqs { get { return this._option_reqs; } }
//        /// <summary>
//        /// true if priority feature is enabled
//        /// </summary>
//        public bool option_priority { get { return this._option_priority; } }
//        /// <summary>
//        /// string prefix for test cases
//        /// </summary>
//        public string prefix { get { return this._prefix; } }
//        /// <summary>
//        /// 
//        /// </summary>
//        public  int tc_counter { get { return this._tc_counter; } }
//        /// <summary>
//        /// true if automation is enabled
//        /// </summary>
//        public bool option_automation { get { return this._option_automation; } }
//        /// <summary>
//        /// true of inventory is enabled
//        /// </summary>
//        public bool option_inventory { get { return this._option_inventory; } }
//        /// <summary>
//        /// project name
//        /// </summary>
//        public string name { get { return this._name; } }
//        /// <summary>
//        /// constructor used by XMLRPC interface on decoding the function return
//        /// </summary>
//        /// <param name="data">data returned by Testlink</param>
////        internal FakeTestProject(XmlRpcStruct data)
////        {
////            id = toInt(data, "id");
////            notes = (string)data["notes"];
////            color = (string)data["color"];
////            active = toInt(data, "active") == 1;
////            //changed option encoding sinc V 1.9
////            XmlRpcStruct opt = data["opt"] as XmlRpcStruct;
////            option_reqs = (int)opt["requirementsEnabled"] == 1;
////            option_priority = (int)opt["testPriorityEnabled"] == 1;
////            option_automation = (int)opt["automationEnabled"] == 1;
////            option_inventory = (int)opt["inventoryEnabled"] == 1;
////            prefix = (string)data["prefix"];
////            tc_counter = toInt(data, "tc_counter");
////            name = (string)data["name"];
////        }
//    }
//}
