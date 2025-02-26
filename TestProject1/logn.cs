using System;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;
using NUnit.Framework;

[TestFixture]
public class LoggingTest
{
    private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

    [OneTimeSetUp]
    public void Setup()
    {
        string WorkingDirectory = Environment.CurrentDirectory;
        string ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
        string configPath = Path.Combine(ProjectDirectory, "log4net.config");
        

        if (File.Exists(configPath))
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo(configPath));
            Logger.Info("log4net successfully configured.");
        }
        else
        {
            Console.WriteLine("ERROR: log4net.config file not found!");
        }
    }

    [Test]
    public void TestLogging()
    {
        Logger.Debug("Debug message.");
        Logger.Info("Info message.");
        Logger.Warn("Warning message.");
        Logger.Error("Error message.");
        Logger.Fatal("Fatal error message.");
        Console.WriteLine("Completed");
    }
}
