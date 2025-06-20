using System.IO;
using System.Text.Json;

namespace WpfApp1
{
    public class LauncherConfig
    {
        public string GamePath { get; set; }

        private static readonly string ConfigFile = "config.json";

        public static LauncherConfig Load()
        {
            if (File.Exists(ConfigFile))
            {
                string json = File.ReadAllText(ConfigFile);
                return JsonSerializer.Deserialize<LauncherConfig>(json) ?? new LauncherConfig();
            }
            return new LauncherConfig();
        }

        public void Save()
        {
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ConfigFile, json);
        }
    }
}