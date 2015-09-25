namespace TestClientRegistration
{
    using System;
    using Common.Logging;
    using Tmx;
    using Tmx.Client;
    using Tmx.Client.Library.ObjectModel;
    using Tmx.Commands;

    class Program
    {
        static void Main(string[] args)
        {
            var command = new RegisterSystemUnderTestCommand(new RegisterTmxSystemUnderTestCommand { Seconds = 3, CustomClientString = "testConsole", ServerUrl = "http://localhost:12340" });
            command.Execute();

            var clientSettings = ClientSettings.Instance;
            clientSettings.ServerUrl = "http://localhost:12340";
            clientSettings.StopImmediately = false;

            Console.WriteLine(ClientSettings.Instance.ServerUrl);
            Console.WriteLine(ClientSettings.Instance.StopImmediately);

            var log = LogManager.GetLogger("111");
            log = null;

            // var registration = ProxyFactory.Get<Registration>();
            var registration = new Registration();
            registration.SendRegistrationInfoAndGetClientId("testConsole");

            Console.WriteLine("Done!");
            Console.Read();
        }
    }
}
