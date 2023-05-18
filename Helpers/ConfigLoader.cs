using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Configuration;

namespace PlaywrightMSTestProject.Helpers
{
    public static class ConfigLoader
    {
        //   static  osdelimiter = RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? "/" : "\\";

        // string path = string.Empty;

        public static JObject LoadConfig()
        {
            var osdelimiter = RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? "/" : "\\";
            string path = $"{Directory.GetCurrentDirectory()}{osdelimiter}TestData{osdelimiter}GE4{osdelimiter}";
            return JObject.Parse(File.ReadAllText($@"{path}" + "TestConfig" + ".json"));
            //var builder = new ConfigurationBuilder().SetBasePath(path).AddJsonFile("TestConfig" + ".json");
            //return builder.Build();
        }
        public static JObject LoadTestData(string filename)
        {
            var osdelimiter = RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? "/" : "\\";
            string path = $"{Directory.GetCurrentDirectory()}{osdelimiter}TestData{osdelimiter}GE4{osdelimiter}";
            return JObject.Parse(File.ReadAllText($@"{path}" + filename + ".json"));
            //var builder = new ConfigurationBuilder().SetBasePath(path).AddJsonFile("TestConfig" + ".json");
            //return builder.Build();
        }
    }
}
