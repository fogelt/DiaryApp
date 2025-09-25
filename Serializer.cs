using System.Text.Json;

namespace DiaryApp
{
    public class Serializer
    {
        private static readonly string filePath = "diary.json";

        internal static void SaveEntries()
        {
            try
            {
                string json = JsonSerializer.Serialize(Program.LocalEntries, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                
                File.WriteAllText(filePath, json);
                Console.WriteLine("Entries saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while saving: {ex.Message}");
            }
            DiaryMethods.MethodFinished();
        }

        internal static void LoadEntries()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);

                    var loadedEntries = JsonSerializer.Deserialize<List<DiaryEntry>>(json);

                    if (loadedEntries != null)
                    {
                        Program.LocalEntries = loadedEntries;

                        Program.LocalEntriesWithDate = new Dictionary<DateTime, DiaryEntry>();
                        foreach (var entry in Program.LocalEntries)
                        {
                            Program.LocalEntriesWithDate[entry.Date.Date] = entry;
                        }

                        Console.WriteLine("Entries loaded successfully.");
                    }
                }
                else
                {
                    Console.WriteLine("No saved entries found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while loading: {ex.Message}");
            }
            DiaryMethods.MethodFinished();
        }
    }
}
