namespace LibraryTecoc.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public BookStatus Status { get; set; }
        public int LoanCount { get; set; }
    }

    public enum BookStatus
    {
        Available,
        Loaned,
        Reserved
    }
}
