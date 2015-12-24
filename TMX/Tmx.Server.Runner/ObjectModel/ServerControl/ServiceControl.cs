namespace Tmx.Server.Runner.ObjectModel.ServerControl
{
    using System.ServiceProcess;

    public class ServiceControl : ServiceBase
    {
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
        }

        protected override void OnStop()
        {
            base.OnStop();
        } 
    }
}