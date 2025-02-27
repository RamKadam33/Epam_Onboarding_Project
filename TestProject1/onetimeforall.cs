using log4net.Config;
using log4net;
using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace TestProject1
{
    [SetUpFixture]
    public class OnetimeForAll
    {
        [OneTimeSetUp]
        public void Setup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string configPath = Path.Combine(projectDirectory, "log4net.config");

            if (File.Exists(configPath))
            {
                var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
                XmlConfigurator.Configure(logRepository, new FileInfo(configPath));
                Console.WriteLine("log4net successfully configured.");
            }
            else
            {
                Console.WriteLine("ERROR: log4net.config file not found!");
            }
        }
    }
}
