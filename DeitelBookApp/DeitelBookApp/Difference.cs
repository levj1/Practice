using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeitelBookApp
{
    public class Difference
    {
        private int[] Elements;
        public int MaximumDifference;

        public Difference(int[] arr)
        {
            Elements = arr;
        }

        public void computeDifference(){
            MaximumDifference = Math.Abs(Elements.Min() - Elements.Max());
        }
        
    }
}
