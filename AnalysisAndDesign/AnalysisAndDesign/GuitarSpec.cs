using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisAndDesign
{
    public class GuitarSpec
    {
        public Builder Builder { get; set; }
        public string Model { get; set; }
        public Type Type { get; set; }
        public Wood BackWood { get; set; }
        public Wood TopWood { get; set; }
        public GuitarSpec(Builder builder, string model, Type type, Wood backwood, Wood topWood)
        {
            Builder = builder;
            Model = model;
            Type = type;
            BackWood = backwood;
            TopWood = topWood;
        }
    }
}
