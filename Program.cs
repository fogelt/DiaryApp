using System;
using System.IO;

namespace DiaryApp
{
    internal class Program
    {
        private static readonly string todoFilePath = "todo.txt";
        //notes = List<DiaryEntry>; TODO
        // Dictionary<DateTime, DiaryEntry>; TODO
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
                Console.WriteLine("6. Exit program");

                MenuChoice choice = GetMenuChoice();

                switch (choice)
                {
                    case MenuChoice.WriteNote:
                        break;
                    case MenuChoice.ShowEntries:
                        break;
                    case MenuChoice.ShowEntryOnDate:
                        break;
                    case MenuChoice.SaveEntries:
                        break;
                    case MenuChoice.LoadEntries:
                        break;
                    case MenuChoice.Exit:
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
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