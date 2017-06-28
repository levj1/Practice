namespace LinqEx
{
    public class Address: IAddress
    {
        public string Line1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

    public class InternationAddress: IAddress
    {
        public string Street { get; set; }
        public string Ville { get; set; }
        public string Country { get; set; }
    }

    
    public interface IAddress
    {

    }
}