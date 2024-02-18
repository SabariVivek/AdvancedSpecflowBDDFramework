using Microsoft.Extensions.Configuration;
using SpecflowBDDFramework.Base;
using SpecflowBDDFramework.Resources;

namespace SpecflowBDDFramework.Utils
{
    public class ReadConfigUtil
    {
        public static ConfigBase ReadConfig(string sectionKey)
        {
            var configuration = new ConfigurationBuilder().
                AddJsonFile(GetProjectDirectory() + TestDataService.CONFIG_FILE_PATH).
                Build();

            if (sectionKey != null)
            {
                return configuration.GetSection(sectionKey).Get<ConfigBase>()!;
            }
            else
            {
                return configuration.Get<ConfigBase>()!;
            }
        }

        /**
        * This function returns the project directory...
        */
        public static string GetProjectDirectory()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            int binIndex = baseDirectory.IndexOf("\\bin\\", StringComparison.OrdinalIgnoreCase);
            return baseDirectory[..binIndex];
        }
    }
}