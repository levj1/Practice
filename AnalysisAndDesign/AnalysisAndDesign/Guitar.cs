using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisAndDesign
{
    public enum Type
    {
        Accousting,
        Electric
    }

    public enum Builder
    {
        Fender, Martin, Gibson, Colling, Olson, Ryan, PRS, ANY
    }
    public enum Wood
    {
        Indian_Wood, Brazilian_Rosewood
    }
    public class Guitar
    {
        public string SerialNumber { get; set; }
        public double Price { get; set; }
        public GuitarSpec GuitarSpec { get; set; }

        public Guitar(string serialNumber, double price, GuitarSpec spec)
        {
            SerialNumber = serialNumber;
            Price = price;
            GuitarSpec = spec;
        }
    }
}
