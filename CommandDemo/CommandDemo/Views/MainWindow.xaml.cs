using CommandDemo.ViewModels;
using System.Windows;

namespace CommandDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DegreeViewModel();
        }
    }
}
