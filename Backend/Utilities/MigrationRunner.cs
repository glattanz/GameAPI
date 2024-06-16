using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace GameAPI.Utilities
{
    public class MigrationRunner
    {
        private readonly string _connectionString;
        private readonly string _scriptsPath;
        private readonly string _configFilePath;

        public MigrationRunner(
            string connectionString,
            string scriptsPath,
            string configFilePath)
        {
            _connectionString = connectionString;
            _scriptsPath = scriptsPath;
            _configFilePath = configFilePath;
        }

        public void RunMigrations()
        {
            var scriptsToRun = GetScriptsFromConfig();

            using var connection = _connectionString.CreateOpenConnection();

            foreach (var scriptFile in scriptsToRun)
            {
                var scriptPath = Path.Combine(_scriptsPath, scriptFile);
                if (File.Exists(scriptPath))
                {
                    Console.WriteLine($"Executing migration script: {scriptFile}");
                    var script = File.ReadAllText(scriptPath);
                    ExecuteScript(connection, script);
                }
                else
                {
                    Console.WriteLine($"Script file not found: {scriptFile}");
                }
            }
        }

        private List<string> GetScriptsFromConfig()
        {
            var configContent = File.ReadAllText(_configFilePath);
            var scripts = JsonConvert.DeserializeObject<List<string>>(configContent);

            return scripts;
        }

        private void ExecuteScript(SqlConnection connection, string script)
        {
            var batches = script.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var batch in batches)
            {
                using var command = new SqlCommand(batch, connection);

                command.ExecuteNonQuery();
            }
        }
    }
}