using CommandDemo.ViewModels;
using System;
using System.Windows.Input;

namespace CommandDemo.Command
{
    class ConvertToCelciusCommand: ICommand
    {
        private DegreeViewModel _viewModel;

        public ConvertToCelciusCommand(DegreeViewModel degreeViewModel)
        {
            // TODO: Complete member initialization
            this._viewModel = degreeViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.CanConvertToCelcius();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
             _viewModel.ConvertToCelcius();
        }
    }
}
