using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisAndDesign
{
    public class GuitarInventory
    {
        public List<Guitar> Guitars;

        public GuitarInventory()
        {
            Guitars = new List<Guitar>();
        }

        public void AddGuitar(Guitar guitar)
        {
            Guitars.Add(guitar);
        }

        public List<Guitar> SearchGuitars(Guitar guitar)
        {
            List<Guitar> newList = new List<Guitar>();
            foreach (var item in Guitars)
            {
                if (item.GuitarSpec.TopWood == guitar.GuitarSpec.TopWood && item.GuitarSpec.Model == guitar.GuitarSpec.Model
                    && item.GuitarSpec.BackWood == guitar.GuitarSpec.BackWood && item.GuitarSpec.Builder == guitar.GuitarSpec.Builder)
                {
                    newList.Add(item);
                }
            }

            return newList;

        }
        public Guitar GetGuitar(string searchSN)
        {
            
            foreach (var guitar in Guitars)
            {
                if (guitar.SerialNumber == searchSN)
                    return guitar;
            }
            return null;
        }
        
    }
}
