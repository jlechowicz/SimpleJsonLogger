using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJsonLogger.Configuration
{
    public static class ConfigurationSectionFactory
    {
        public static SimpleJsonLoggerConfigurationSection GetSimpleJsonLoggerConfigurationSection()
        {
            SimpleJsonLoggerConfigurationSection config = System.Configuration.ConfigurationManager.GetSection("simpleJsonLogger") as SimpleJsonLoggerConfigurationSection;
            return config;
        }
    }
}
