namespace Portfolio.Models
{
    public class EmailAddress
    {
        public EmailAddress(string address)
        {
            Address = address;
        }

        public string Name { get; set; }
        public string Address { get; set; }
    }
}
