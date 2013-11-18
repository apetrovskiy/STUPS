using System.Windows.Automation;
/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/10/2013
 * Time: 10:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using Ninject;
    using Ninject.Modules;
    using Ninject.Extensions.NamedScope;
    
    /// <summary>
    /// Description of ObjectLifecycleModule.
    /// </summary>
    public class ObjectLifecycleModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IMySuperWrapper>().To<MySuperWrapper>().InCallScope();
            Bind<IMySuperWrapper>()
                .ToConstructor(
                    x =>
                    new MySuperWrapper(x.Inject<AutomationElement>()))
                .InCallScope()
                .Named("AutomationElement.NET");
            
            Bind<IMySuperWrapper>()
                .ToConstructor(
                    x =>
                    new MySuperWrapper(x.Inject<IMySuperWrapper>()))
                .InCallScope()
                .Named("MySuperWrapper");
            
            Bind<IMySuperWrapper>()
                .To<MySuperWrapper>()
                .InCallScope()
                .Named("Empty");
            
            Bind<IMySuperCollection>().To<MySuperCollection>().InCallScope();
            
            Bind<IMySuperWrapperInformation>().To<MySuperWrapperInformation>().InCallScope();
            
            /*
            //Dependencies for the "StandAloneUser" Object
            Bind<IUserDataMappingDAO>().To<UserDataMappingMSSQLDAO>();
            Bind<IRoles>().To<RolesMockImpl>();
            Bind<IUserGroupAssociationDAO>().To<UserGroupAssociationDAO>();
            Bind<IGroupDAO>().To<GroupMSSQLDAO>();
            Bind<IEmailDAO>().To<EmailMSSQLDAO>();
            
            //Bindings for StandAloneUser
            Bind<StandAloneUser>()
                .ToConstructor(
                    x =>
                    new StandAloneUser(x.Inject<MembershipUser>(), x.Inject<IUserDataMappingDAO>(), x.Inject<IRoles>(),
                                       x.Inject<IUserGroupAssociationDAO>(), x.Inject<IGroupDAO>(),
                                       x.Inject<APortalLogger>(), x.Inject<IEmailDAO>()))
                .Named("FromMembershipUser");
            Bind<StandAloneUser>()
                .ToConstructor(
                    x =>
                    new StandAloneUser(x.Inject<PortableStandAloneUser>(), x.Inject<IUserDataMappingDAO>(), x.Inject<IRoles>(),
                                       x.Inject<IUserGroupAssociationDAO>(), x.Inject<IGroupDAO>(),
                                       x.Inject<APortalLogger>(), x.Inject<IEmailDAO>()))
                .Named("FromPortableStandAloneUser");
            
            //Things we can use to build a "StandAloneUser" Object
            Bind<MembershipUser>().ToSelf();
            Bind<PortableStandAloneUser>().ToSelf();
            */
            /*
            StandardKernel _kernel = new StandardKernel(new NinjectTestModule());
            _kernel.Get<StandAloneUser>(new ConstructorArgument("user", new MembershipUser()));
            _kernel.Get<StandAloneUser>(new ConstructorArgument("portableStandAloneUser", new PortableStandAloneUser()));
            */
        }
    }
}
