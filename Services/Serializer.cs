using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using DiaryApp.Models;

namespace DiaryApp.Services
{
    public class Serializer
    {
        private static readonly string filePath = "diary.json";

        internal static void SaveEntries()
        {
            try
            {
                string json = JsonSerializer.Serialize(
                    Program.LocalEntries,
                    new JsonSerializerOptions { WriteIndented = true }
                );

                File.WriteAllText(filePath, json);
                Console.WriteLine("Entries saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while saving: {ex.Message}");
                ErrorLogger.WriteErrorLog(ex.Message);
            }
            DiaryMethods.MethodFinished();
        }

        internal static void LoadEntries()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("No saved entries found.");
                    return;
                }

                string json = File.ReadAllText(filePath);

                var loadedEntries = JsonSerializer.Deserialize<List<DiaryEntry>>(json);

                if (loadedEntries != null)
                {
                    Program.LocalEntries = loadedEntries;

                    Program.LocalEntriesWithDate = new Dictionary<DateTime, List<DiaryEntry>>();
                    foreach (var entry in Program.LocalEntries)
                    {
                        DateTime date = entry.Date.Date;
                        if (!Program.LocalEntriesWithDate.ContainsKey(date))
                        {
                            Program.LocalEntriesWithDate[date] = new List<DiaryEntry>();
                        }
                        Program.LocalEntriesWithDate[date].Add(entry);
                    }

                    Console.WriteLine("Entries loaded successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while loading: {ex.Message}");
                ErrorLogger.WriteErrorLog(ex.Message);
            }
            DiaryMethods.MethodFinished();
        }
    }
}
