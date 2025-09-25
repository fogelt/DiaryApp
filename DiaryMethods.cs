using System;
using System.Collections.Generic;

namespace DiaryApp
{
    public class DiaryMethods
    {
        internal static void WriteNote()
        {
            Console.Clear();
            Console.Write("New entry: ");
            string? input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                DiaryEntry entry = new DiaryEntry(DateTime.Now, input);

                Program.LocalEntries.Add(entry);
                Program.LocalEntriesWithDate[entry.Date.Date] = entry;
            }
            MethodFinished();
        }

        internal static void ShowEntries()
        {
            Console.Clear();
            foreach (var entry in Program.LocalEntries)
            {
                Console.WriteLine($"{entry.Date}: {entry.Text}");
            }
            MethodFinished();
        }

        internal static void ShowEntryOnDate()
        {
            Console.Clear();
            Console.Write("Enter a date (yyyy-MM-dd): ");
            string? input = Console.ReadLine();

            try
            {
                DateTime date = DateTime.Parse(input!).Date;

                if (Program.LocalEntriesWithDate.TryGetValue(date, out DiaryEntry? entry))
                {
                    Console.WriteLine($"{entry.Date}: {entry.Text}");
                }
                else
                {
                    Console.WriteLine("No entry found on that date.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date format. Please use yyyy-MM-dd.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            MethodFinished();
        }
        internal static void MethodFinished()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("Press Any key to return");
            Console.ReadKey();
            Console.Clear();
        }


    }
}
