namespace Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Admin Admin { get; set; }
        public ICollection<ContactAddress> ContactAddresses { get; set; }
    }

    public class Admin
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string Address { get; set; }
        public string BusinessGroup { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }

    public class ContactAddress
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsPrimary { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}