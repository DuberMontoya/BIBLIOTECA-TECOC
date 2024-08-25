namespace LibraryTecoc.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public string Address { get; set; }
        public List<Loan> LoanHistory { get; set; } = new List<Loan>();
    }
}
