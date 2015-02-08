/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/26/2015
 * Time: 7:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EsxiMgmt.Tests.Helpers.UnderlyingCode.Commands.Connect
{
    using System;
    using System.Collections.Generic;
    using EsxiMgmt.Cmdlets;
    using EsxiMgmt.Cmdlets.Commands.Connect;
    using EsxiMgmt.Cmdlets.Helpers.UnderlyingCode.Commands;
    using EsxiMgmt.Cmdlets.Helpers.UnderlyingCode.Commands.Connect;
    using EsxiMgmt.Core.Data;
    using Renci.SshNet;
    
    /// <summary>
    /// Description of NewHostConnectionDataCommandTestFixture.
    /// </summary>
    public class NewHostConnectionDataCommandTestFixture
    {
        const string _hostname01 = "host01";
        const string _username01 = "user01";
        const string _password01 = "pwd01";
        const string _keyFilePath01 = @"..\..\files\my_esxi.key";
        
        const string _hostname02 = "host02";
        const string _username02 = "user02";
        const string _password02 = "pwd02";
        const string _keyFilePath02 = @"..\..\files\my_esxi.key";
        
        public NewHostConnectionDataCommandTestFixture()
        {
            prepareConnData();
        }
        
        [NUnit.Framework.SetUp][MbUnit.Framework.SetUp]
        public void SetUp()
        {
            prepareConnData();
        }
        
        [NUnit.Framework.Test][MbUnit.Framework.Test]
        public void Add_first_connection_info()
        {
            var cmdlet = GIVEN_cmdlet();
            var command = GIVEN_command(cmdlet);
            WHEN_executing_command(command);
            THEN_there_are_N_connection_infos(1);
            THEN_first_connection_info();
        }
        
        [NUnit.Framework.Test][MbUnit.Framework.Test]
        public void Add_two_connection_infos()
        {
            var cmdlet = GIVEN_cmdlet();
            var command = GIVEN_command(cmdlet);
            GIVEN_executing_command(command);
            cmdlet = GIVEN_one_more_cmdlet();
            command = GIVEN_command(cmdlet);
            WHEN_executing_command(command);
            
            THEN_there_are_N_connection_infos(2);
            THEN_first_connection_info();
            THEN_second_connection_info();
        }
        
        void prepareConnData()
        {
            ConnectionData.Entries = new List<ConnectionInfo>();
        }
        
        NewEsxiHostConnectionDataCommand GIVEN_cmdlet()
        {
            return new NewEsxiHostConnectionDataCommand {
                Server = _hostname01,
                Username = _username01,
                Password = _password01,
                KeyFilePath = _keyFilePath01
            };
        }
        
        NewEsxiHostConnectionDataCommand GIVEN_one_more_cmdlet()
        {
            return new NewEsxiHostConnectionDataCommand {
                Server = _hostname02,
                Username = _username02,
                Password = _password02,
                KeyFilePath = _keyFilePath02
            };
        }
        
        NewHostConnectionDataCommand GIVEN_command(CommonCmdletBase cmdlet)
        {
            return new NewHostConnectionDataCommand(cmdlet);
        }
        
        void WHEN_executing_command(NewHostConnectionDataCommand command)
        {
            command.AddConnectionInfo();
        }
        
        void GIVEN_executing_command(NewHostConnectionDataCommand command)
        {
            WHEN_executing_command(command);
        }
        
        void THEN_there_are_N_connection_infos(int number)
        {
            Xunit.Assert.Equal(number, ConnectionData.Entries.Count);
        }
        
        void THEN_first_connection_info()
        {
            Xunit.Assert.Equal(_hostname01, ConnectionData.Entries[0].Host);
            Xunit.Assert.Equal(_username01, ConnectionData.Entries[0].Username);
        }
        
        void THEN_second_connection_info()
        {
            Xunit.Assert.Equal(_hostname02, ConnectionData.Entries[1].Host);
            Xunit.Assert.Equal(_username02, ConnectionData.Entries[1].Username);
        }
    }
}
