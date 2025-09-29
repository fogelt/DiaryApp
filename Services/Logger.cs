using System.Text.Json;

namespace DiaryApp.Services
{
    public class ErrorLogger
    {
        private static readonly string filePath = "error_log.json";

        internal static void WriteErrorLog(string errorLog)
        {
            try
            {
                string json = JsonSerializer.Serialize(
                    errorLog,
                    new JsonSerializerOptions { WriteIndented = true }
                );

                File.WriteAllText(filePath, json);
                Console.WriteLine("Entries saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while saving: {ex.Message}");
            }
            DiaryMethods.MethodFinished();
        }
    }
}