using SimpleJsonLogger.Enum;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJsonLogger.Configuration
{
    public class SimpleJsonLoggerConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("fileName", DefaultValue = "SimpleJsonLog.json", IsRequired = false)]
        public string FileName
        {
            get
            {
                return (string)this["fileName"];
            }
            set
            {
                this["fileName"] = value;
            }
        }

        [ConfigurationProperty("logId",  IsRequired = true)]
        public string LogId
        {
            get
            {
                return (string)this["logId"];
            }
            set
            {
                this["logId"] = value;
            }
        }

        [ConfigurationProperty("logDescription", IsRequired = false)]
        public string LogDescription
        {
            get
            {
                return (string)this["logDescription"];
            }
            set
            {
                this["logDescription"] = value;
            }
        }

        [ConfigurationProperty("detailLevelToLog", IsRequired = true)]
        public int DetailLevelToLog
        {
            get
            {
                return (int)this["detailLevelToLog"];
            }
            set
            {
                if(value >= (int)DetailLevel.None && value <= (int)DetailLevel.High)
                {
                    this["detailLevelToLog"] = value;
                }
                else
                {
                    throw new ArgumentException("Invalid DetailLevel", nameof(value));
                }
            }
        }
    }
}
