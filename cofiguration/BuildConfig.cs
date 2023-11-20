using Microsoft.Extensions.Configuration;

namespace PlaywrightTests.cofiguration
{
    public static class BuildConfig
    {
        private static IConfigurationRoot _configuration;

        public static IConfigurationRoot ConfigurationRoot { get { return _configuration; } }

        static BuildConfig()
        {
            var environmentName = Environment.GetEnvironmentVariable("env");

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();

            _configuration = config.Build();
        }
    }
}