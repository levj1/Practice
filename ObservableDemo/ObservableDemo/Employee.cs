using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ObservableDemo
{
    public class Employee:INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get { return name; }
            set 
            { 
                name = value;
                OnPropertyChanged();
            }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set 
            { 
                title = value;
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

        public static ObservableCollection<Employee> GetEmployees()
        {
            var employees = new ObservableCollection<Employee>();
            employees.Add(new Employee() { Name = "GW", Title = "President 1" });
            employees.Add(new Employee() { Name = "Adams", Title = "President 2" });
            employees.Add(new Employee() { Name = "Jefferson", Title = "President 3" });
            employees.Add(new Employee() { Name = "Madison", Title = "President 4" });
            employees.Add(new Employee() { Name = "Monroe", Title = "President 5" });

            return employees;
        }

    }
}
