using DiaryApp.Models;

namespace DiaryApp.Services
{
    public class DiaryMethods
    {
        internal static void WriteNote()
        {
            Console.Write("New entry: ");
            string? input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                DiaryEntry entry = new DiaryEntry(DateTime.Now, input);

                Program.LocalEntries.Add(entry);

                DateTime date = entry.Date.Date;
                if (!Program.LocalEntriesWithDate.ContainsKey(date))
                {
                    Program.LocalEntriesWithDate[date] = new List<DiaryEntry>();
                }
                Program.LocalEntriesWithDate[date].Add(entry);
            }
            else
            {
                Console.WriteLine("Entry cannot be empty -- Invalid entry");
            }
            MethodFinished();
        }

        internal static void ShowEntries()
        {
            if (Program.LocalEntries.Count == 0)
            {
                Console.WriteLine("There are no entries in the diary");
            }
            else
            {
                foreach (var entry in Program.LocalEntries)
                {
                    Console.WriteLine($"{entry.Date}: {entry.Text}");
                }
            }
            MethodFinished();
        }

        internal static void ShowEntryOnDate()
        {
            Console.Write("Enter a date (yyyy-MM-dd): ");
            string? input = Console.ReadLine();

            try
            {
                DateTime date = DateTime.Parse(input!).Date;

                if (Program.LocalEntriesWithDate.TryGetValue(date, out List<DiaryEntry>? entries))
                {
                    Console.WriteLine($"Entries on {date:yyyy-MM-dd}:");
                    foreach (var e in entries)
                    {
                        Console.WriteLine($"- {e.Date:HH:mm} {e.Text}");
                    }
                }
                else
                {
                    Console.WriteLine("No entries found on that date.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date format. Please use yyyy-MM-dd.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                ErrorLogger.WriteErrorLog(ex.Message);
            }
            MethodFinished();
        }

        internal static void DeleteEntry()
        {
            Console.Write("Enter a date (yyyy-MM-dd): ");
            string? input = Console.ReadLine();

            try
            {
                DateTime date = DateTime.Parse(input!).Date;

                if (Program.LocalEntriesWithDate.TryGetValue(date, out List<DiaryEntry>? entries) && entries.Count > 0)
                {
                    Console.WriteLine($"Entries on {date:yyyy-MM-dd}:");
                    for (int i = 0; i < entries.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {entries[i].Date:HH:mm} - {entries[i].Text}");
                    }

                    Console.Write("Select entry number to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int choice) &&
                        choice > 0 && choice <= entries.Count)
                    {
                        var toRemove = entries[choice - 1];

                        entries.RemoveAt(choice - 1);
                        if (entries.Count == 0)
                        {
                            Program.LocalEntriesWithDate.Remove(date);
                        }

                        Program.LocalEntries.Remove(toRemove);

                        Console.WriteLine("Entry deleted - You must save to make it permanent");
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection.");
                    }
                }
                else
                {
                    Console.WriteLine("No entries found on that date.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date format. Please use yyyy-MM-dd.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                ErrorLogger.WriteErrorLog(ex.Message);
            }
            MethodFinished();
        }

        internal static void UpdateEntry()
        {
            Console.Write("Enter a date (yyyy-MM-dd): ");
            string? input = Console.ReadLine();

            try
            {
                DateTime date = DateTime.Parse(input!).Date;

                if (Program.LocalEntriesWithDate.TryGetValue(date, out List<DiaryEntry>? entries) && entries.Count > 0)
                {
                    Console.WriteLine($"Entries on {date:yyyy-MM-dd}:");
                    for (int i = 0; i < entries.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {entries[i].Date:HH:mm} - {entries[i].Text}");
                    }

                    Console.Write("Select entry number to update: ");
                    if (int.TryParse(Console.ReadLine(), out int choice) &&
                        choice > 0 && choice <= entries.Count)
                    {
                        var toUpdate = entries[choice - 1];

                        Console.WriteLine($"Current text: {toUpdate.Text}");
                        Console.Write("Enter new text: ");
                        string? newText = Console.ReadLine();

                        if (!string.IsNullOrEmpty(newText))
                        {
                            toUpdate.Text = newText;
                            Console.WriteLine("Entry updated. - You must save to make it permanent");
                        }
                        else
                        {
                            Console.WriteLine("Update cancelled (empty input).");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection.");
                    }
                }
                else
                {
                    Console.WriteLine("No entries found on that date.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date format. Please use yyyy-MM-dd.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                ErrorLogger.WriteErrorLog(ex.Message);
            }
            MethodFinished();
        }

        internal static void MethodFinished()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("Press any key to return");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
