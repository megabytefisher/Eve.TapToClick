using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Eve.TapToClick
{
    public class AppConfiguration
    {
        public uint DetectionThreshold { get; set; }
        public uint TapTriggerThreshold { get; set; }
        public int MaxTapMilliseconds { get; set; }
        public int MaxTapDeltaPosition { get; set; }

        private static AppConfiguration instance;

        private static string ConfigPath =
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "config.json");

        public AppConfiguration()
        {
            DetectionThreshold = 3;
            TapTriggerThreshold = 10;
            MaxTapMilliseconds = 175;
            MaxTapDeltaPosition = 500;
        }

        public void Save()
        {
            File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(this));
        }

        public static AppConfiguration Instance
        {
            get
            {
                if (instance == null)
                    instance = Load();

                return instance;
            }
        }

        private static AppConfiguration Load()
        {
            if (!File.Exists(ConfigPath))
            {
                AppConfiguration newConfig = new AppConfiguration();
                newConfig.Save();

                return newConfig;
            }

            return JsonConvert.DeserializeObject<AppConfiguration>(File.ReadAllText(ConfigPath));
        }
    }
}
