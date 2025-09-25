namespace DiaryApp
{
    public class DiaryEntry
    {
        public DateTime Date { get; set; }
        public string Text { get; set; } = String.Empty;

        // Constructor
        public DiaryEntry(DateTime date, string text)
        {
            Date = date;
            Text = text;
        }

        public DiaryEntry() { }
    }
}
