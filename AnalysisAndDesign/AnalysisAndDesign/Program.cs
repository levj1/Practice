using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisAndDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            GuitarSpec guitarspec = new GuitarSpec(Builder.Fender, "c", Type.Accousting, Wood.Indian_Wood, Wood.Indian_Wood);
            var spec1 = new GuitarSpec(Builder.Gibson, "mdl1", Type.Accousting, Wood.Brazilian_Rosewood, Wood.Indian_Wood);
            var spec2 = new GuitarSpec(Builder.Fender, "mdl2", Type.Accousting, Wood.Indian_Wood, Wood.Indian_Wood);

            List<Guitar> list = new List<Guitar>
            {
                new Guitar ("Sean", 15.5, spec1),
                new Guitar ("sn2", 35.5, spec2 )
            };

            GuitarInventory inventory = new GuitarInventory();
            inventory.Guitars = list;
            inventory.Guitars.Add(new Guitar("012", 123.3, guitarspec));

            List<Guitar> search = inventory.SearchGuitars(new Guitar("012", 123.3, guitarspec));
            if (search.Count == 0)
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                foreach (var item in search)
                {
                    Console.WriteLine("SR: {0}\nPrice: {1}", item.SerialNumber, item.Price);
                }
            }
            

            Console.ReadLine();
        }
    }
}
