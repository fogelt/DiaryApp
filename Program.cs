using DiaryApp.UI;
using DiaryApp.Services;
using DiaryApp.Models;

namespace DiaryApp
{
    public class Program
    {
        public static List<DiaryEntry> LocalEntries = new List<DiaryEntry>();
        public static Dictionary<DateTime, List<DiaryEntry>> LocalEntriesWithDate
    = new Dictionary<DateTime, List<DiaryEntry>>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("---Diary---");
                Console.WriteLine("1. Write new note");
                Console.WriteLine("2. Show all entries");
                Console.WriteLine("3. Show all entries on a specific date");
                Console.WriteLine("4. Save entries to file");
                Console.WriteLine("5. Read entries from file");
                Console.WriteLine("6. Remove entry - (extra)");
                Console.WriteLine("7. Edit entry - extra)");
                Console.WriteLine("8. Exit program");

                MenuChoice choice = GetMenuChoice();

                switch (choice)
                {
                    case MenuChoice.WriteNote:
                        Console.Clear();
                        DiaryMethods.WriteNote();
                        break;
                    case MenuChoice.ShowEntries:
                        Console.Clear();
                        DiaryMethods.ShowEntries();
                        break;
                    case MenuChoice.ShowEntryOnDate:
                        Console.Clear();
                        DiaryMethods.ShowEntryOnDate();
                        break;
                    case MenuChoice.SaveEntries:
                        Console.Clear();
                        Serializer.SaveEntries();
                        break;
                    case MenuChoice.LoadEntries:
                        Console.Clear();
                        Serializer.LoadEntries();
                        break;
                     case MenuChoice.RemoveEntry:
                        Console.Clear();
                        DiaryMethods.DeleteEntry();
                        break;
                     case MenuChoice.EditEntry:
                        Console.Clear();
                        DiaryMethods.UpdateEntry();
                        break;
                    case MenuChoice.Exit:
                        Console.WriteLine("---Exiting---");
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice!");
                        DiaryMethods.MethodFinished();
                        break;
                }

            }
        }

        private static MenuChoice GetMenuChoice()
        {
            string? input = Console.ReadLine();
            if (input != null && int.TryParse(input, out int choice)
                && Enum.IsDefined(typeof(MenuChoice), choice))
            {
                return (MenuChoice)choice;
            }
            return MenuChoice.Invalid;
        }
    }
}