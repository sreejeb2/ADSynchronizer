using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System.CommandLine;

namespace ADSynchronizer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            if (args.Length > 0)
            {
                var fileOption = new Option<FileInfo?>(
            name: "--file",
            description: "Full path to the settings.json file.");

                var rootCommand = new RootCommand("Scheduler utility for ADSynchronizer");
                rootCommand.AddOption(fileOption);

                rootCommand.SetHandler((file) =>
                {
                    var scheduler = new Scheduler();
                    scheduler.Start(file!, ServiceProvider.GetRequiredService<IEncryptionService>());
                }, fileOption);

                rootCommand.Invoke(args);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.Run(ServiceProvider.GetRequiredService<frmSyncSettings>());
            }
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {

                    services.AddLogging(option =>
                    {
                        option.SetMinimumLevel(LogLevel.Debug);
                        option.AddNLog("nlog.config");
                    });

                    services.AddScoped<IEncryptionService, EncryptionService>();
                    services.AddScoped<frmSyncSettings>();
                });
        }
    }
}