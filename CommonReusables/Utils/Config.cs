using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SeleniumCodingChallangeSDET.CommonReusables.Configuration
{
    public class Config
    {
        public string findValueOfAConfiguration(System.Configuration.Configuration config,string key)
        {
            return config.AppSettings.Settings[key].Value;
        }
        public System.Configuration.Configuration GetConfig()
        {
            var configFile = Path.Combine(TestContext.CurrentContext.TestDirectory, "App.config");
            var map = new ExeConfigurationFileMap { ExeConfigFilename = configFile };
            return ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
        }
        public static string ParseJson(string jsonpath)
        {
            JObject parsedJson = JObject.Parse(File.ReadAllText("testdata.json"));
            return parsedJson.SelectToken(jsonpath).ToString();
        }

    }
}
