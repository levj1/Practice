using CommandDemo.Command;
using CommandDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandDemo.ViewModels
{
    public class DegreeViewModel
    {
        private Degree degree;

        public Degree Degree
        {
            get { return degree; }
        }

        public DegreeViewModel()
        {
            degree = new Degree() { Fahrenheit = "19" };
            ToCelciusCommand = new ConvertToCelciusCommand(this);
        }

        public ICommand ToCelciusCommand
        {
            get;
            set;
        }


        public void ConvertToCelcius()
        {
            int result = 5*(int.Parse(degree.Fahrenheit) - 32) / 9;
            degree.Celcius = result.ToString();
        }

        public bool CanConvertToCelcius()
        {
            int value;
            return int.TryParse(degree.Fahrenheit, out value);
        }
    }
}
