using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CommandDemo.Models
{
    public class Degree : INotifyPropertyChanged
    {
        private string fahrenheit;

        public string Fahrenheit
        {
            get { return fahrenheit; }
            set 
            {
                fahrenheit = value;
                OnPropertyChanged();
            }
        }

        private string celcius;

        public string Celcius
        {
            get { return celcius; }
            set 
            { 
                celcius = value;
                OnPropertyChanged();
            }
        }
        
        

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(
            [CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
