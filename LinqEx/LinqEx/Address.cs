namespace LinqEx
{
    public class Address: IAddress
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }

    public class HaitiAddress: IAddress
    {
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    
    public interface IAddress
    {
        string AddressLine1 { get; set; }
        string City { get; set; }
        string Country { get; set; }
    }
}