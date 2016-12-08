namespace ClassLibrary
{
    public class Address
    {
        public int AddressID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public Address()
        {
        }
        public Address(int id, string line1, string line2, string city, string state, string zipcode)
        {
            AddressID = id;
            AddressLine1 = line1;
            AddressLine2 = line2;
            City = city;
            State = state;
            ZipCode = zipcode;
        }
        public Address(string line1, string line2, string city, string state, string zipcode)
        {
            AddressLine1 = line1;
            AddressLine2 = line2;
            City = city;
            State = state;
            ZipCode = zipcode;
        }
    }
}