using Newtonsoft.Json;
using System.IO;
using System.IO.IsolatedStorage;

namespace Eve.TapToClick
{
    public class AppConfiguration
    {
        public uint DetectionThreshold { get; set; }
        public uint TapTriggerThreshold { get; set; }
        public int MaxTapMilliseconds { get; set; }
        public int MaxTapDeltaPosition { get; set; }

        private static AppConfiguration instance;

        private const string ConfigFileName = "config.json";

        public AppConfiguration()
        {
            DetectionThreshold = 3;
            TapTriggerThreshold = 10;
            MaxTapMilliseconds = 175;
            MaxTapDeltaPosition = 500;
        }

        public void Save()
        {
            using (IsolatedStorageFile isoStore =
                IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
            {
                using (IsolatedStorageFileStream configStream = isoStore.OpenFile(ConfigFileName, FileMode.Create, FileAccess.Write))
                using (StreamWriter configWriter = new StreamWriter(configStream))
                {
                    configWriter.Write(JsonConvert.SerializeObject(this));
                }
            }
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
            using (IsolatedStorageFile isoStore =
                IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null))
            {
                if (!isoStore.FileExists(ConfigFileName))
                {
                    AppConfiguration newConfig = new AppConfiguration();
                    newConfig.Save();

                    return newConfig;
                }

                using (IsolatedStorageFileStream configStream = new IsolatedStorageFileStream(ConfigFileName, FileMode.Open, FileAccess.Read))
                using (StreamReader configReader = new StreamReader(configStream))
                {
                    return JsonConvert.DeserializeObject<AppConfiguration>(configReader.ReadToEnd());
                }
            }
        }
    }
}
